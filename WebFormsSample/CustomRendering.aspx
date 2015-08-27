<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CustomRendering.aspx.cs" Inherits="WebFormsSample.CustomRendering" %>
<%@ Register Assembly="NRecaptcha2" Namespace="NRecaptcha2.WebControls" TagPrefix="nrecaptcha2" %>

<asp:Content ContentPlaceHolderID="form" runat="server">
    <asp:PlaceHolder ID="form" runat="server">
        <asp:ValidationSummary runat="server" />

        <asp:HiddenField id="siteKey" runat="server" ClientIDMode="Static" />

        <asp:Label runat="server">First Name:</asp:Label>
        <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ErrorMessage="First name is required" 
            EnableClientScript="false"
            ControlToValidate="firstName"></asp:RequiredFieldValidator>

        <br />
        <br />

        <asp:Label runat="server">Last Name:</asp:Label>
        <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ErrorMessage="Last name is required" 
            EnableClientScript="false"
            ControlToValidate="lastName"></asp:RequiredFieldValidator>
            
        <br />
        <br />

        <nrecaptcha2:NRecaptcha2Validator ID="captcha" ClientIDMode="Static" Language="Spanish" runat="server" ExplicitRenderingFunction="showCaptcha" ErrorMessage="Captcha is invalid" />
            
        <br />

        <asp:Button  runat="server" OnClick="SubmitForm" Text="Submit" />

        <script>
            function showCaptcha() {
                var siteKey = document.getElementById("siteKey");
                grecaptcha.render("captcha", {
                    "sitekey": siteKey.value
                });
            }
        </script>
    </asp:PlaceHolder>
        
    <asp:PlaceHolder ID="results" runat="server" Visible="false">
        <asp:Label ID="capturedFirstName" runat="server"></asp:Label>
        <asp:Label ID="capturedLastName" runat="server"></asp:Label>
    </asp:PlaceHolder>
</asp:Content>
