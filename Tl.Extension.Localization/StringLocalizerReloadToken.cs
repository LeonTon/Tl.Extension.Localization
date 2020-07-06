using System;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace Tl.Extension.Localization
{
    public class StringLocalizerReloadToken : IChangeToken
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public bool HasChanged => _cts.IsCancellationRequested;
        
        public bool ActiveChangeCallbacks  => true;
        
        public IDisposable RegisterChangeCallback(Action<object> callback, object state) => _cts.Token.Register(callback, state);
        
        public void OnReload() => _cts.Cancel();
    }
}