namespace NRecaptcha2.Mvc
{
    /// <summary>
    /// Secret Key provider interface used in ValidateRecaptcha2Attribute 
    /// (reCAPTCHA v2.0 for ASP.NET MVC)
    /// </summary>
    public interface ISecretKeyProvider
    {
        /// <summary>
        /// Returns secret key
        /// </summary>
        /// <returns>Secret key</returns>
        string GetSecretKey();
    }
}
