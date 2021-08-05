using System;
using System.Net;
using System.Net.Sockets;
using LostHarbor.Core.Extensions;

namespace LostCode.Core.Time
{
    public static class NtpTime
    {
        /// <summary>
        /// Retrieves the seconds since 1900-01-01 00:00:00 UTC from a NTP server.
        /// </summary>
        /// <returns>
        /// Number of seconds since 1900-01-01 00:00:00 UTC, or 0.0 if there is a connection issue.
        /// </returns>
        public static double Now()
        {
            var ntpData = GetNtpData();
            if (ntpData == null)
            {
                return 0.0;
            }
            else
            {
                return TimeFromNtpData(ntpData);
            }
        }

        private static byte[] GetNtpData()
        {
            const string NTP_SERVER = "pool.ntp.org";
            const int UDP_PORT = 123;
            const byte NTP_QUERY = 0x1B; // Leap Warning = 0 (off), Version = 3 (IPv4), Mode = 3 (Client)
            const int NTP_RESPONSE_SIZE = 48;
            const int NTP_TIMEOUT = 1000;

            try
            {
                var ntpData = new byte[NTP_RESPONSE_SIZE];
                ntpData[0] = NTP_QUERY;

                var addresses = Dns.GetHostEntry(NTP_SERVER).AddressList;
                var ipEndPoint = new IPEndPoint(addresses[0], UDP_PORT);
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                socket.Connect(ipEndPoint);

                socket.ReceiveTimeout = NTP_TIMEOUT;
                socket.Send(ntpData);
                socket.Receive(ntpData);

                socket.Close();

                return ntpData;
            }
            catch (Exception e)
            {
                // Debug.Log("Error querying NTP data.");
                // Debug.Log(e);
                return null;
            }
        }

        private static double TimeFromNtpData(byte[] ntpData)
        {
            const int INTEGER_OFFSET = 40;
            const int FRACTION_OFFSET = 44;

            ulong integerPart = ntpData.ParseUInt32(INTEGER_OFFSET);
            ulong fractionPart = ntpData.ParseUInt32(FRACTION_OFFSET);

            ulong fixedPointSeconds = ntpData.ParseUInt32(INTEGER_OFFSET) << 32 | ntpData.ParseUInt32(FRACTION_OFFSET);

            return (double)fixedPointSeconds / 0x100000000U;
        }
    }
}
