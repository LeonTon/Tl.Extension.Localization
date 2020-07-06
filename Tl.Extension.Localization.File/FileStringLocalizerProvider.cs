using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace Tl.Extension.Localization.File
{
    public abstract class FileStringLocalizerProvider : StringLocalizerProvider, IDisposable
    {
        private readonly IDisposable _changeTokenRegistration;

        public FileStringLocalizerProvider(FileStringLocalizerSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            Source = source;

            if (Source.ReloadOnChange && Source.FileProvider != null)
            {
                _changeTokenRegistration = ChangeToken.OnChange(
                    () => Source.FileProvider.Watch(Source.FilePathPattern),
                    () =>
                    {
                        Thread.Sleep(Source.ReloadDelay);
                        Load();
                    });
            }
        }

        public FileStringLocalizerSource Source { get; }

        public override void Load()
        {
            var files = new DirectoryInfo(Source.Directory).GetFiles(Source.FilePathPattern);
            foreach (var file in files)
            {
                var culture =CultureInfo.GetCultureInfo(Regex.Match(file.Name, @"(?<=\.)[A-Za-z-]+(?=\.[^.]+$)").Value);
                using (var stream = file.OpenRead())
                {
                    OnReload(culture, stream);
                }
            }
        }

        protected abstract void OnReload(CultureInfo culture, Stream stream);

        public abstract void Load(CultureInfo culture, Stream stream);

        public void Dispose()
        {
            _changeTokenRegistration.Dispose();
        }
    }
}