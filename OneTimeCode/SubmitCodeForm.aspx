<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitCodeForm.aspx.cs" Inherits="OneTimeCode.SubmitCodeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="submitform" runat="server">
        <div>
            Activation Code: <br />
            <asp:TextBox ID="activationCode" runat="server"></asp:TextBox> <br />
            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click"/>
        </div>
    </form>
</body>
</html>
