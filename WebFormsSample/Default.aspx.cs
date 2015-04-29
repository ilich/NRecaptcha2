using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            captcha.SiteKey = ConfigurationManager.AppSettings["SiteKey"];
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            if(!Page.IsValid)
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