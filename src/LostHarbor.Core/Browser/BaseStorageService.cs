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
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace LostHarbor.Core.Browser
{
    public abstract class BaseStorageService
    {
        private const string ERROR_INVALID_KEY = "The provided key is invalid.";
        private const string ERROR_JS_RUNTIME = "The Javascript runtime is not available.";

        protected readonly IJSRuntime _jsRuntime;
        protected readonly IJSInProcessRuntime _jsInProcessRuntime;
        protected readonly JsonSerializerOptions _jsonOptions;

        protected BaseStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _jsInProcessRuntime = jsRuntime as IJSInProcessRuntime;
            _jsonOptions = new JsonSerializerOptions();
        }

        protected abstract void JSSetItem(string key, string value);
        protected abstract ValueTask JSSetItemAsync(string key, string value);
        protected abstract string JSGetItem(string key);
        protected abstract ValueTask<string> JSGetItemAsync(string key);
        protected abstract void JSRemoveItem(string key);
        protected abstract ValueTask JSRemoveItemAsync(string key);
        protected abstract void JSClear();
        protected abstract ValueTask JSClearAsync();
        protected abstract int JSLength();
        protected abstract ValueTask<int> JSLengthAsync();
        protected abstract string JSKey(int index);
        protected abstract ValueTask<string> JSKeyAsync(int index);
        protected abstract bool JSHasOwnProperty(string key);
        protected abstract ValueTask<bool> JSHasOwnPropertyAsync(string key);

        public bool Set(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsInProcessRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);

            var eventArgs = OnStorageChanging(key, value);
            if (eventArgs.Cancel) return false;
            JSSetItem(key, Serialize(value));
            OnStorageChanged(key, eventArgs.PreviousValue, value);
            return true;
        }

        public async Task<bool> SetAsync(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);

            var eventArgs = await OnStorageChangingAsync(key, value);
            if (eventArgs.Cancel) return false;
            await JSSetItemAsync(key, Serialize(value));
            OnStorageChanged(key, eventArgs.PreviousValue, value);
            return true;
        }

        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsInProcessRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);

            return Deserialize<T>(JSGetItem(key));
        }

        public async Task<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);

            return Deserialize<T>(await JSGetItemAsync(key));
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsInProcessRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            JSRemoveItem(key);
        }

        public async Task RemoveAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            await JSRemoveItemAsync(key);
        }

        public void Clear()
        {
            if (_jsInProcessRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            JSClear();
        }

        public async Task ClearAsync()
        {
            if (_jsRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            await JSClearAsync();
        }

        public int Length()
        {
            if (_jsInProcessRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            return JSLength();
        }

        public async Task<int> LengthAsync()
        {
            if (_jsRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            return await JSLengthAsync();
        }

        public string Key(int index)
        {
            if (_jsInProcessRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            return JSKey(index);
        }

        public async Task<string> KeyAsync(int index)
        {
            if (_jsRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            return await JSKeyAsync(index);
        }

        public bool Contains(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsInProcessRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            return JSHasOwnProperty(key);
        }

        public async Task<bool> ContainsAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(ERROR_INVALID_KEY);
            if (_jsRuntime == null) throw new InvalidOperationException(ERROR_JS_RUNTIME);
            return await JSHasOwnPropertyAsync(key);
        }

        public IEnumerable<string> Keys()
        {
            var length = Length();
            for (int i = 0; i < length; i++) yield return Key(i);
        }

        public async IAsyncEnumerable<string> KeysAsync()
        {
            var length = await LengthAsync();
            for (int i = 0; i < length; i++) yield return await KeyAsync(i);
        }

        private string Serialize(object value)
        {
            if (value is string) return value as string;
            else return JsonSerializer.Serialize(value, _jsonOptions);
        }

        private T Deserialize<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return default(T);
            if (value.StartsWith("{") && value.EndsWith("}") ||
                value.StartsWith("\"") && value.EndsWith("\"") ||
                typeof(T) != typeof(string))
                return JsonSerializer.Deserialize<T>(value, _jsonOptions);
            else return (T)(object)value;
        }

        public event EventHandler<StorageChangedEventArgs> StorageChanged;
        public event EventHandler<StorageChangingEventArgs> StorageChanging;

        private void OnStorageChanged(string key, object previousValue, object newValue)
        {
            var eventArgs = new StorageChangedEventArgs
            {
                Key = key,
                PreviousValue = previousValue,
                NewValue = newValue
            };

            StorageChanged?.Invoke(this, eventArgs);
        }

        private StorageChangingEventArgs OnStorageChanging(string key, object newValue)
        {
            var eventArgs = new StorageChangingEventArgs
            {
                Key = key,
                PreviousValue = Get<object>(key),
                NewValue = newValue
            };

            StorageChanging?.Invoke(this, eventArgs);
            return eventArgs;
        }

        private async Task<StorageChangingEventArgs> OnStorageChangingAsync(string key, object newValue)
        {
            var eventArgs = new StorageChangingEventArgs
            {
                Key = key,
                PreviousValue = await GetAsync<object>(key),
                NewValue = newValue
            };

            StorageChanging?.Invoke(this, eventArgs);
            return eventArgs;
        }
    }
}
