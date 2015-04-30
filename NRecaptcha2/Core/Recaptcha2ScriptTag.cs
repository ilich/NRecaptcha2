using System.Web;
using System.Web.Mvc;

namespace NRecaptcha2.Core
{
    class Recaptcha2ScriptTag : IHtmlString
    {
        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            var tag = new TagBuilder("script");
            tag.MergeAttribute("src", Constants.ScriptUrl);
            return tag.ToString();
        }
    }
}
