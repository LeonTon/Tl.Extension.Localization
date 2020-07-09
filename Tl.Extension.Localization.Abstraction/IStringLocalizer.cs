using System;
using System.Collections.Generic;
using System.Text;

namespace Tl.Extension.Localization.Abstraction
{
    public interface IStringLocalizer
    {
        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        /// <param name="name">The name of the string resource.</param>
        /// <returns>The string resource as a <see cref="LocalizedString"/>.</returns>
        LocalizedString this[string name] { get; }

       
        LocalizedString this[string name, StringLocalizerParamMapper map, Func<StringLocalizerParamMapper, string> func] { get; }
    }
}
