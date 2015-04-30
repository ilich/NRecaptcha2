using System.Configuration;

namespace NRecaptcha2.Mvc
{
    /// <summary>
    /// Default reCAPTCHA v2.0 secret key provider.
    /// The key is stored in NRecaptcha2.SecretKey application settings inside Web.config file.
    /// </summary>
    public class WebConfigSecretKeyProvider : ISecretKeyProvider
    {
        /// <summary>
        /// Returns secret key
        /// </summary>
        /// <returns>Secret key</returns>
        public string GetSecretKey()
        {
            return ConfigurationManager.AppSettings["NRecaptcha2.SecretKey"];
        }
    }
}
