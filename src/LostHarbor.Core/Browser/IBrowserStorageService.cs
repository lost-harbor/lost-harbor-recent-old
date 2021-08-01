/*
SPDX-License-Identifier: AGPL-3.0-or-later

Lost Harbor - A procedurally generated space exploration game.
Copyright (C) 2021 Marc King and Achal Chhetri

This program is free software: you can redistribute it and/or modify it under the terms of the
GNU Affero General Public License as published by the Free Software Foundation, either version 3
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License along with this program.
If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LostHarbor.Core.Browser
{
    public interface IBrowserStorageService
    {
        event EventHandler<StorageChangedEventArgs> StorageChanged;
        event EventHandler<StorageChangingEventArgs> StorageChanging;

        bool Set(string key, object value);
        Task<bool> SetAsync(string key, object value);
        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);
        void Remove(string key);
        Task RemoveAsync(string key);
        void Clear();
        Task ClearAsync();
        int Length();
        Task<int> LengthAsync();
        string Key(int index);
        Task<string> KeyAsync(int index);
        bool Contains(string key);
        Task<bool> ContainsAsync(string key);
        IEnumerable<string> Keys();
        IAsyncEnumerable<string> KeysAsync();
    }
}
