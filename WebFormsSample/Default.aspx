<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NRecaptcha2 ASP.NET Web Forms validation</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:PlaceHolder ID="form" runat="server">
            <asp:ValidationSummary runat="server" />

            <asp:Label runat="server">First Name:</asp:Label>
            <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="First name is required" EnableClientScript="false"
                ControlToValidate="firstName"></asp:RequiredFieldValidator>

            <asp:Label runat="server">Last Name:</asp:Label>
            <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Last name is required" EnableClientScript="false" 
                ControlToValidate="lastName"></asp:RequiredFieldValidator>
            
            <asp:Button  runat="server" OnClick="SubmitForm" Text="Submit" />
        </asp:PlaceHolder>
        
        <asp:PlaceHolder ID="results" runat="server" Visible="false">
            <asp:Label ID="capturedFirstName" runat="server"></asp:Label>
            <asp:Label ID="capturedLastName" runat="server"></asp:Label>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
