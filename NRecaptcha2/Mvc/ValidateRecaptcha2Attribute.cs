using System;
using System.Configuration;
using System.Web.Mvc;
using NRecaptcha2.Core;

namespace NRecaptcha2.Mvc
{
    /// <summary>
    /// reCAPTCHA v2.0 validation attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ValidateRecaptcha2Attribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Gets or sets the text for error message
        /// </summary>
        public string ErrorMessage
        {
            get;
            set;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            var provider = ResolveSecretKeyProvider();
            var secretKey = provider.GetSecretKey();
            var isValid = Recaptcha2Validator.Validate(secretKey);
            if (!isValid)
            {
                var error = !string.IsNullOrEmpty(ErrorMessage) ? ErrorMessage : Constants.DefaultErrorMessage;
                filterContext.Controller.ViewData.ModelState.AddModelError("NRecaptcha2ValidationError", error);
            }
        }

        private ISecretKeyProvider ResolveSecretKeyProvider()
        {
            var typeName = ConfigurationManager.AppSettings["NRecaptcha2.SecretKeyProvider"];
            var type = Type.GetType(typeName);
            var provider = (ISecretKeyProvider)Activator.CreateInstance(type);
            return provider;
        }
    }
}
