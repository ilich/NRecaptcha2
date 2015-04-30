using System;
using System.Web;
using System.Web.Mvc;
using NRecaptcha2.WebControls;

namespace NRecaptcha2.Core
{
    class Recaptcha2Tag : IHtmlString
    {
        public Recaptcha2Tag(
            string siteKey,
            Theme theme = Theme.Light,
            CaptchaType type = CaptchaType.Image,
            int tabIndex = 0,
            string callback = "",
            string expiredCallback = "")
        {
            if (string.IsNullOrEmpty(siteKey))
            {
                throw new InvalidOperationException("SiteKey is required");
            }

            SiteKey = siteKey;
            Theme = theme;
            Type = type;
            TabIndex = tabIndex;
            Callback = callback;
            ExpiredCallback = expiredCallback;
        }

        public string SiteKey
        {
            get;
            set;
        }

        public Theme Theme
        {
            get;
            set;
        }

        public CaptchaType Type
        {
            get;
            set;
        }

        public int TabIndex
        {
            get;
            set;
        }

        public string Callback
        {
            get;
            set;
        }

        public string ExpiredCallback
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
            var tag = new TagBuilder("div");
            tag.AddCssClass(Constants.RecaptchaClass);
            tag.MergeAttribute(Constants.SiteKey, SiteKey);
            tag.MergeAttribute(Constants.Theme, Theme.ToString().ToLower());
            tag.MergeAttribute(Constants.Type, Type.ToString().ToLower());
            tag.MergeAttribute(Constants.TabIndex, TabIndex.ToString());

            if (!string.IsNullOrEmpty(Callback))
            {
                tag.MergeAttribute(Constants.Callback, Callback);
            }

            if (!string.IsNullOrEmpty(ExpiredCallback))
            {
                tag.MergeAttribute(Constants.ExpiredCallback, ExpiredCallback);
            }

            return tag.ToString();
        }
    }
}
