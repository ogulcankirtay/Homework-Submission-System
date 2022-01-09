<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guncelle.aspx.cs" Inherits="yazlab1_3.v._1.Guncelle" %>

<!Docytpe html>
    <html lang="tr">

    <head>
        <title>Login </title>
        <script src="Scripts/bootstrap.min.js"></script>
        <link rel="stylesheet" type="text/css" href="/yazlab/style.css">
        <meta charset="utf-8">
    </head>

    <body>

        <form class="box" action="#" method="post" runat="server">
            <h1>Güncelle</h1>
            <asp:TextBox ID="TextBox1" runat="server" placaeholder="id">ID</asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placaeholder="username">Username</asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" placaeholder="psw">Sifre</asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Güncelle" CssClass="btn btn-info" OnClick="Button1_Click"/>
        </form>




    </body>

    </html>
