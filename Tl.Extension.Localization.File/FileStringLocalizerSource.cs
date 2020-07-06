using Microsoft.Extensions.FileProviders;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.File
{
    public abstract class FileStringLocalizerSource : IStringLocalizerSource
    {
        public IFileProvider FileProvider { get; set; }

        public bool ReloadOnChange { get; set; }

        public int ReloadDelay { get; set; } = 250;

        public string Directory { get; set; }

        public string FilePathPattern { get; set; }

        public abstract IStringLocalizerProvider Build();

        public void ResolveFileProvider()
        {
            FileProvider = new PhysicalFileProvider(Directory);
        }
    }
}