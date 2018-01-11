<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInForm.aspx.cs" Inherits="OneTimeCode.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="loginform" runat="server">
        <div>
            First Name : <br />
            <asp:TextBox ID="firstName" runat="server"></asp:TextBox> <br />
            Last Name : <br />
            <asp:TextBox ID="lastName" runat="server"></asp:TextBox> <br />
            Phone Number : <br />
            <asp:TextBox ID="phoneNumber" runat="server"></asp:TextBox> <br />
            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click"/>
        </div>
    </form>
</body>
</html>
