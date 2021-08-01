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

using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace LostHarbor.Core.Browser
{
    public class SessionStorageService : BaseStorageService, ISessionStorageService
    {
        public SessionStorageService(IJSRuntime jsRuntime) : base(jsRuntime) { }

        protected override void JSSetItem(string key, string value) => _jsInProcessRuntime.InvokeVoid("sessionStorage.setItem", key, value);
        protected override ValueTask JSSetItemAsync(string key, string value) => _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", key, value);
        protected override string JSGetItem(string key) => _jsInProcessRuntime.Invoke<string>("sessionStorage.getItem", key);
        protected override ValueTask<string> JSGetItemAsync(string key) => _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", key);
        protected override void JSRemoveItem(string key) => _jsInProcessRuntime.InvokeVoid("sessionStorage.removeItem", key);
        protected override ValueTask JSRemoveItemAsync(string key) => _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", key);
        protected override void JSClear() => _jsInProcessRuntime.InvokeVoid("sessionStorage.clear");
        protected override ValueTask JSClearAsync() => _jsRuntime.InvokeVoidAsync("sessionStorage.clear");
        protected override int JSLength() => _jsInProcessRuntime.Invoke<int>("eval", "sessionStorage.length");
        protected override ValueTask<int> JSLengthAsync() => _jsRuntime.InvokeAsync<int>("eval", "sessionStorage.length");
        protected override string JSKey(int index) => _jsInProcessRuntime.Invoke<string>("sessionStorage.key", index);
        protected override ValueTask<string> JSKeyAsync(int index) => _jsRuntime.InvokeAsync<string>("sessionStorage.key", index);
        protected override bool JSHasOwnProperty(string key) => _jsInProcessRuntime.Invoke<bool>("sessionStorage.hasOwnProperty", key);
        protected override ValueTask<bool> JSHasOwnPropertyAsync(string key) => _jsRuntime.InvokeAsync<bool>("sessionStorage.hasOwnProperty", key);
    }
}
