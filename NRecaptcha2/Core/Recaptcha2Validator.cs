﻿using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace NRecaptcha2.Core
{
    /// <summary>
    /// reCAPTCHA v2.0 validator
    /// </summary>
    public static class Recaptcha2Validator
    {
        /// <summary>
        /// Validates captcha
        /// </summary>
        /// <param name="secret">reCAPTCHA secret key</param>
        /// <returns>True is captcha has been validated, otherwise false</returns>
        public static bool Validate(string secret)
        {
            var response = HttpContext.Current.Request.Form["g-recaptcha-response"];
            var parameters = string.Format("secret={0}&response={1}", secret, response);

            var web = WebRequest.Create("https://www.google.com/recaptcha/api/siteverify") as HttpWebRequest;
            web.ContentType = "application/x-www-form-urlencoded";
            web.Method = "POST";
            web.ContentLength = parameters.Length;

            using (var writer = new StreamWriter(web.GetRequestStream()))
            {
                writer.Write(parameters);
            }

            using (var reader = new StreamReader(web.GetResponse().GetResponseStream()))
            {
                var jsonResult = reader.ReadToEnd();
                var serializer = new JavaScriptSerializer();
                var result = serializer.Deserialize<dynamic>(jsonResult);
                return result["success"];
            }
        }
    }
}
