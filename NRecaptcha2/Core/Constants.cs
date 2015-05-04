namespace NRecaptcha2.Core
{
    static class Constants
    {
        public static readonly string DefaultErrorMessage = "Failed to validate captcha";
        public static readonly string ScriptUrl = "https://www.google.com/recaptcha/api.js";
        public static readonly string ExplicitRenderingScriptUrl = "https://www.google.com/recaptcha/api.js?onload={0}&render=explicit";
        public static readonly string RecaptchaClass = "g-recaptcha";
        public static readonly string SiteKey = "data-sitekey";
        public static readonly string Theme = "data-theme";
        public static readonly string Type = "data-type";
        public static readonly string TabIndex = "data-tabindex";
        public static readonly string Callback = "data-callback";
        public static readonly string ExpiredCallback = "data-expired-callback";
    }
}
