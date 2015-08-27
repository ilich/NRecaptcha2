using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using NRecaptcha2.Core;

namespace NRecaptcha2.WebControls
{
    /// <summary>
    /// reCAPTCHA v2.0 Widget
    /// </summary>
    [ToolboxData("<{0}:NRecaptcha2Validator runat=\"server\" ErrorMessage=\"[ErrorMessage]\" SiteKey=\"[SiteKey]\" SecretKey=\"[SecretKey]\">")]
    public class NRecaptcha2Validator : WebControl, IValidator
    {
        private bool _isValid;

        [Bindable(false)]
        public string ExplicitRenderingFunction
        {
            get
            {
                var function = (string)ViewState["ExplicitRenderingFunction"];
                return function ?? string.Empty;
            }
            set
            {
                ViewState["ExplicitRenderingFunction"] = value;
            }
        }

        /// <summary>
        /// Gets or sets your sitekey.
        /// </summary>
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

        /// <summary>
        /// Gets or sets your secret key.
        /// </summary>
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

        /// <summary>
        /// Gets or sets reCAPTCHA language
        /// </summary>
        [Bindable(false)]
        public Language? Language
        {
            get
            {
                var lang = ViewState["Language"] as Language?;
                return lang;
            }
            set
            {
                ViewState["Language"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the color theme of the widget.
        /// </summary>
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

        /// <summary>
        ///  Gets or sets the type of CAPTCHA to serve.
        /// </summary>
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

        /// <summary>
        /// Gets or sets your callback function that's executed when the user submits a successful 
        /// CAPTCHA response. The user's response, g-recaptcha-response, 
        /// will be the input for your callback function.
        /// </summary>
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

        /// <summary>
        /// Gets or sets your callback function that's executed when the recaptcha response expires 
        /// and the user needs to solve a new CAPTCHA.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the text for the error message displayed in a ValidationSummary control 
        /// when validation fails.
        /// </summary>
        [Bindable(false)]
        [Localizable(true)]
        public string ErrorMessage
        {
            get
            {
                var message = (string)ViewState["ErrorMessage"];
                return message ?? Constants.DefaultErrorMessage;
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
            
            _isValid = Recaptcha2Validator.Validate(SecretKey);
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
            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), "GoogleRecaptcha2API"))
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

                var tag = string.Format("<script src='{0}' async defer></script>", url);
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "GoogleRecaptcha2API", tag);
            }
            
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
            if (!string.IsNullOrEmpty(ExplicitRenderingFunction))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
                return;
            }

            if (string.IsNullOrEmpty(SiteKey))
            {
                throw new InvalidOperationException("SiteKey is required");
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Class, Constants.RecaptchaClass);
            writer.AddAttribute(Constants.SiteKey, SiteKey);
            writer.AddAttribute(Constants.Theme, Theme.ToString().ToLower());
            writer.AddAttribute(Constants.Type, Type.ToString().ToLower());
            writer.AddAttribute(Constants.TabIndex, TabIndex.ToString());

            if (!string.IsNullOrEmpty(Callback))
            {
                writer.AddAttribute(Constants.Callback, Callback);
            }

            if (!string.IsNullOrEmpty(ExpiredCallback))
            {
                writer.AddAttribute(Constants.ExpiredCallback, ExpiredCallback);
            }
        }
    }
}
