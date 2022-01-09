<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminGiris.aspx.cs" Inherits="yazlab1_3.v._1.adminGiris" %>

<!Docytpe html>
    <html lang="tr">

    <head>
        <title> Admin Login </title>
        <link rel="stylesheet" type="text/css" href="/yazlab/style.css">
        <meta charset="utf-8">
    </head>

    <body>

        <form class="box" action="#" method="post" runat="server">
            <h1>Admin Login</h1>
           <!--  <input type="text" name="username" placeholder="username">  --> 
            <asp:TextBox ID="TextBox1"  runat="server" placeholder="username"></asp:TextBox>
            
            <asp:TextBox ID="TextBox2" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
            
           <!--<input type="button" onclick="location.href='anasayfa.html';" value="Login" /> -->
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="Giris Yap" OnClick="Button1_Click" /> 
        </form>



    </body>

    </html>