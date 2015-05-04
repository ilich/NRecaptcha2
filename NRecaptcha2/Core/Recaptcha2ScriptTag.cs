using System.Web;
using System.Web.Mvc;

namespace NRecaptcha2.Core
{
    class Recaptcha2ScriptTag : IHtmlString
    {
        public Recaptcha2ScriptTag(string explicitRenderingFunction)
        {
            ExplicitRenderingFunction = explicitRenderingFunction;
        }

        public string ExplicitRenderingFunction
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

            var tag = new TagBuilder("script");
            tag.MergeAttribute("src", url);
            tag.MergeAttribute("async", "async");
            tag.MergeAttribute("defer", "defer");
            return tag.ToString();
        }
    }
}
