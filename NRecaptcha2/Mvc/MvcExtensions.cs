using System.Web;
using System.Web.Mvc;
using NRecaptcha2.Core;
using NRecaptcha2.WebControls;

namespace NRecaptcha2.Mvc
{
    /// <summary>
    /// reCAPTCHA v2.0 support for ASP.NET MVC
    /// </summary>
    public static class MvcExtensions
    {
        /// <summary>
        /// Displays reCAPTCHA widget
        /// </summary>
        /// <param name="helper">HTML helper</param>
        /// <param name="siteKey">Your sitekey.</param>
        /// <param name="theme">The color theme of the widget.</param>
        /// <param name="type">The type of CAPTCHA to serve.</param>
        /// <param name="tabIndex">The tabindex of the widget and challenge. If other elements in your page use tabindex, it should be set to make user navigation easier.</param>
        /// <param name="callback">Your callback function that's executed when the user submits a successful CAPTCHA response. The user's response, g-recaptcha-response, will be the input for your callback function.</param>
        /// <param name="expiredCallback">Your callback function that's executed when the recaptcha response expires and the user needs to solve a new CAPTCHA.</param>
        /// <returns>Widget tag HTML</returns>
        public static IHtmlString NRecaptcha2(
            this HtmlHelper helper,
            string siteKey,
            Theme theme = Theme.Light,
            CaptchaType type = CaptchaType.Image,
            int tabIndex = 0,
            string callback = "",
            string expiredCallback = "")
        {
            var tag = new Recaptcha2Tag(
                siteKey,
                theme,
                type,
                tabIndex,
                callback,
                expiredCallback);

            return tag;
        }

        /// <summary>
        /// Registers reCAPTCHA JavaScript API
        /// </summary>
        /// <param name="helper">HTML helper</param>
        /// <returns>Script tag HTML</returns>
        public static IHtmlString NRecaptcha2Script(this HtmlHelper helper)
        {
            var tag = new Recaptcha2ScriptTag();
            return tag;
        }
    }
}
