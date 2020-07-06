using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Tl.Extension.Localization.File;

namespace Tl.Extension.Localization.Json
{
    public class JsonStringLocalizerProvider : FileStringLocalizerProvider
    {
        public JsonStringLocalizerProvider(FileStringLocalizerSource source) : base(source)
        {
        }

        protected override void OnReload(CultureInfo culture, Stream input)
        {
            Load(culture, input);
        }

        public override void Load(CultureInfo culture, Stream input)
        {
            using (var reader = new StreamReader(input))
            {
                Data[culture] = JsonSerializer.Deserialize<Dictionary<string, string>>(reader.ReadLine());
            }
        }
    }
}