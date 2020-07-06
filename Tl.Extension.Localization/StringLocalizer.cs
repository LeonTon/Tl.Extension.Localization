using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.Extensions.Primitives;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization
{
    internal class StringLocalizer : IStringLocalizer, IDisposable
    {
        private readonly CultureInfo _culture;
        private readonly IList<IStringLocalizerProvider> _providers;
        private readonly IList<IDisposable> _changeTokenRegistrations;
        private StringLocalizerReloadToken _changeToken = new StringLocalizerReloadToken();

        public StringLocalizer(CultureInfo culture, IList<IStringLocalizerProvider> providers)
        {
            _culture = culture;
            _providers = providers;
            
            
            _changeTokenRegistrations = new List<IDisposable>(providers.Count);
            foreach (var p in providers)
            {
                p.Load();
                _changeTokenRegistrations.Add(ChangeToken.OnChange(() => p.GetReloadToken(), () => RaiseChanged()));
            }
        }
        
        
        public LocalizedString this[string name]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                string value = null;
                foreach (var provider in _providers)
                {
                    if (provider.TryGet(_culture, name, out value))
                    {
                        break;
                    }
                }

                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments] =>
            throw new System.NotImplementedException();


        
        public void Reload()
        {
            foreach (var provider in _providers)
            {
                provider.Load();
            }
            RaiseChanged();
        }

        private void RaiseChanged()
        {
            var previousToken = Interlocked.Exchange(ref _changeToken, new StringLocalizerReloadToken());
            previousToken.OnReload();
        }

        public void Dispose()
        {
            // dispose change token registrations
            foreach (var registration in _changeTokenRegistrations)
            {
                registration.Dispose();
            }

            // dispose providers
            foreach (var provider in _providers)
            {
                (provider as IDisposable)?.Dispose();
            }
        }
    }
}