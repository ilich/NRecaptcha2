using System.Web;
using System.Web.Mvc;

namespace NRecaptcha2.Core
{
    class Recaptcha2ScriptTag : IHtmlString
    {
        public Recaptcha2ScriptTag(string explicitRenderingFunction, Language? language)
        {
            ExplicitRenderingFunction = explicitRenderingFunction;
            Language = language;
        }

        public string ExplicitRenderingFunction
        {
            get;
            set;
        }

        public Language? Language
        {
            get;
            set;
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            var url = string.IsNullOrEmpty(ExplicitRenderingFunction)
                    ? Constants.ScriptUrl
                    : string.Format(Constants.ExplicitRenderingScriptUrl, ExplicitRenderingFunction);

            if (Language != null)
            {
                var lang = LanguageHelpers.Language2String(Language.Value);
                url += url.Contains("?")
                    ? "&hl=" + lang
                    : "?hl=" + lang;
            }

            var tag = new TagBuilder("script");
            tag.MergeAttribute("src", url);
            tag.MergeAttribute("async", "async");
            tag.MergeAttribute("defer", "defer");
            return tag.ToString();
        }
    }
}
