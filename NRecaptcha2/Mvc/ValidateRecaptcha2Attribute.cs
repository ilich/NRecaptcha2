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
            // First try to get provider from current dependency resolver

            var resolver = DependencyResolver.Current;
            var provider = resolver.GetService<ISecretKeyProvider>();
            if (provider != null)
            {
                return provider;
            }

            // If provider hasn't been received then the type specified in
            // NRecaptcha2.SecretKeyProvider setting in Web.Config

            var typeName = ConfigurationManager.AppSettings["NRecaptcha2.SecretKeyProvider"];
            var type = Type.GetType(typeName);
            provider = (ISecretKeyProvider)Activator.CreateInstance(type);
            return provider;
        }
    }
}
