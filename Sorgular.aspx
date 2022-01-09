<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sorgular.aspx.cs" Inherits="yazlab1_3.v._1.Sorgular" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccccff">
    <form id="form1" runat="server">
    <h4 style="text-align:center, color: #800080" > Sor</h4>
     <div>
        <table class="style1">
            <tr>
                <td class="style3" style="color: #800000; font-size: large;">
                Search</td>
                <td class="style2">
                 <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                 </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Kullanıcı Ara" onclick="Button1_Click" />
                    <asp:Button ID="Button_Yazar" runat="server" OnClick="Button_Yazar_Click1" Text="Yazar Ara" />
                    <asp:Button ID="Button_Ders" runat="server" OnClick="Button_Ders_Click" Text="Ders Ara" />
                    <asp:Button ID="Button_proje" runat="server" OnClick="Button_proje_Click" Text="Proje Ara" />
                    <asp:Button ID="Button_Anahtar" runat="server" OnClick="Button_Anahtar_Click" Text="Anahtar K. Ara" />
                    <asp:Button ID="Button_Donem" runat="server" OnClick="Button_Donem_Click" Text="Donem Ara" />
                    <asp:Button ID="Button_sorgu2" runat="server" OnClick="Button_sorgu2_Click" Text="Dönem Sorgu2" />
                </td>
            </tr>
           
        </table>
    <p> 
        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Maroon"></asp:Label></p>
    </div>
 
        

        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        </asp:GridView>
 
        

        <asp:GridView ID="GridView3" runat="server" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
        </asp:GridView>
        <asp:GridView ID="GridView4" runat="server" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
        </asp:GridView>
        <asp:GridView ID="GridView5" runat="server" OnSelectedIndexChanged="GridView5_SelectedIndexChanged1">
        </asp:GridView>
        <asp:GridView ID="GridView6" runat="server" OnSelectedIndexChanged="GridView6_SelectedIndexChanged">
        </asp:GridView>
        <asp:GridView ID="GridView7" runat="server" OnSelectedIndexChanged="GridView7_SelectedIndexChanged">
        </asp:GridView>
 
        

    </form>
</body>
</html>