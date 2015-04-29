using System.Web.UI;
using System.Web.UI.WebControls;

namespace NRecaptcha2.WebControls
{
    public class NRecaptcha2Validator : WebControl, IValidator
    {
        public string ErrorMessage
        {
            get
            {
                var message = (string)ViewState["ErrorMessage"];
                return message;
            }
            set
            {
                ViewState["ErrorMessage"] = value;
            }
        }

        public bool IsValid
        {
            get;
            set;
        }

        public void Validate()
        {
            // TODO
            IsValid = false;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
        }
    }
}
