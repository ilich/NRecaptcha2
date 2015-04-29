﻿using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using NRecaptcha2.Core;

namespace NRecaptcha2.WebControls
{
    /// <summary>
    /// reCAPTCHA v2.0 Web Control
    /// </summary>
    [ToolboxData("<{0}:NRecaptcha2Validator runat=\"server\" ErrorMessage=\"[ErrorMessage]\" SiteKey=\"[SiteKey]\" SecretKey=\"[SecretKey]\">")]
    public class NRecaptcha2Validator : WebControl, IValidator
    {
        private bool _isValid;

        [Bindable(false)]
        public string SiteKey
        {
            get
            {
                var key = (string)ViewState["SiteKey"];
                return key ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("SiteKey is required");
                }

                ViewState["SiteKey"] = value;
            }
        }

        [Bindable(false)]
        public string SecretKey
        {
            get
            {
                var key = (string)ViewState["SecretKey"];
                return key ?? string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("Secret Key is required");
                }

                ViewState["SecretKey"] = value;
            }
        }

        [Bindable(false)]
        public Theme Theme
        {
            get
            {
                var theme = ViewState["Theme"] as Theme?;
                return theme ?? Theme.Light;
            }
            set
            {
                ViewState["Theme"] = value;
            }
        }

        [Bindable(false)]
        public CaptchaType Type
        {
            get
            {
                var type = ViewState["Type"] as CaptchaType?;
                return type ?? CaptchaType.Image;
            }
            set
            {
                ViewState["Type"] = value;
            }
        }

        [Bindable(false)]
        public string Callback
        {
            get
            {
                var js = (string)ViewState["Callback"];
                return js ?? string.Empty;
            }
            set
            {
                ViewState["Callback"] = value;
            }
        }

        [Bindable(false)]
        public string ExpiredCallback
        {
            get
            {
                var js = (string)ViewState["ExpiredCallback"];
                return js ?? string.Empty;
            }
            set
            {
                ViewState["ExpiredCallback"] = value;
            }
        }

        [Bindable(false)]
        [Localizable(true)]
        public string ErrorMessage
        {
            get
            {
                var message = (string)ViewState["ErrorMessage"];
                return message ?? "Failed to validate captcha";
            }
            set
            {
                ViewState["ErrorMessage"] = value;
            }
        }

        bool IValidator.IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        void IValidator.Validate()
        {
            if (string.IsNullOrEmpty(SecretKey))
            {
                throw new InvalidOperationException("Secret Key is required");
            }
            
            _isValid = RecaptchaValidator.Validate(SecretKey);
        }

        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                return;
            }

            Page.Validators.Add(this);
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptInclude("GoogleReCaptchaAPI", "https://www.google.com/recaptcha/api.js");
            base.OnLoad(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                return;
            }

            Page.Validators.Remove(this);
            base.OnUnload(e);
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(SiteKey))
            {
                throw new InvalidOperationException("SiteKey is required");
            }

            writer.AddAttribute(CaptchaTag.Class, CaptchaTag.RecaptchaClass);
            writer.AddAttribute(CaptchaTag.SiteKey, SiteKey);
            writer.AddAttribute(CaptchaTag.Theme, Theme.ToString().ToLower());
            writer.AddAttribute(CaptchaTag.Type, Type.ToString().ToLower());
            writer.AddAttribute(CaptchaTag.TabIndex, TabIndex.ToString());

            if (!string.IsNullOrEmpty(Callback))
            {
                writer.AddAttribute(CaptchaTag.Callback, Callback);
            }

            if (!string.IsNullOrEmpty(ExpiredCallback))
            {
                writer.AddAttribute(CaptchaTag.ExpiredCallback, ExpiredCallback);
            }
        }
    }
}
