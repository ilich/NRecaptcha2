﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSample.Default" %>
<%@ Register Assembly="NRecaptcha2" Namespace="NRecaptcha2.WebControls" TagPrefix="nrecaptcha2" %>

<asp:Content ContentPlaceHolderID="form" runat="server">
    <asp:PlaceHolder ID="form" runat="server">
        <asp:ValidationSummary runat="server" />

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

        <nrecaptcha2:NRecaptcha2Validator ID="captcha" Theme="Light" Type="Image" runat="server" ErrorMessage="Captcha is invalid" />
            
        <br />

        <asp:Button  runat="server" OnClick="SubmitForm" Text="Submit" />
    </asp:PlaceHolder>
        
    <asp:PlaceHolder ID="results" runat="server" Visible="false">
        <asp:Label ID="capturedFirstName" runat="server"></asp:Label>
        <asp:Label ID="capturedLastName" runat="server"></asp:Label>
    </asp:PlaceHolder>
</asp:Content>
