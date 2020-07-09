using System;
using System.Collections.Generic;
using System.Text;

namespace Tl.Extension.Localization.Abstraction
{
    public class StringLocalizerParamMapper
    {


        public StringLocalizerParamMapper()
        {
        }

        public StringLocalizerParamMapper(string placeholder, Dictionary<string, string> replaceParam)
        {
            Placeholder = placeholder;
            ReplaceParam = replaceParam;
        }

        /// <summary>
        /// 占位符
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// 模板
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// 参数键值对
        /// </summary>
        public Dictionary<string, string> ReplaceParam { get; set; }


    }
}
