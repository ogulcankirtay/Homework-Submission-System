<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EklemeSayfası.aspx.cs" Inherits="yazlab1_3.v._1.EklemeSayfası" %>

<!Docytpe html>
   
<html lang="tr">

<head>

    <title>Login </title>
    <script src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/yazlab/style.css">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <meta charset="utf-8">
</head>

<body>

    <form class="box" action="#" method="post" runat="server">
        <h1>Ekle</h1>
        <asp:TextBox ID="TextBox2" runat="server" placaeholder="username">Username</asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" placaeholder="psw">Password</asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Kullanıcıyı Ekle" CssClass="btn btn-primary" OnClick="Button1_Click" />
    </form>




</body>

</html>