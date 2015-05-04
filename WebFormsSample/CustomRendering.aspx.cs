using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsSample
{
    public partial class CustomRendering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            siteKey.Value = ConfigurationManager.AppSettings["SiteKey"];
            captcha.SecretKey = ConfigurationManager.AppSettings["SecretKey"];
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            capturedFirstName.Text = firstName.Text;
            capturedLastName.Text = lastName.Text;
            form.Visible = false;
            results.Visible = true;
        }
    }
}