<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="yazlab1_3.v._1.WebForm1" %>

<!Docytpe html>
    <html lang="tr">

    <head>
        <title> Login </title>
        <link rel="stylesheet" type="text/css" href="/yazlab/style.css">
        <meta charset="utf-8">
    </head>

    <body>

        <form class="box" action="#" method="post" runat="server">
            <h1>Login</h1>
           <!--  <input type="text" name="username" placeholder="username">  --> 
            <asp:TextBox ID="TextBox1"  runat="server" placeholder="username"></asp:TextBox>
            
            <asp:TextBox ID="TextBox2" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
            
           <!--<input type="button" onclick="location.href='anasayfa.html';" value="Login" /> -->
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="Giris Yap" OnClick="Button1_Click" />
             <asp:Button CssClass="button" ID="Button2" runat="server" Text="Admin" OnClick="Button2_Click" /> 
        </form>



    </body>

    </html>