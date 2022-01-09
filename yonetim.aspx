<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yonetim.aspx.cs" Inherits="yazlab1_3.v._1.yonetim" %>

<html>

<head>
    <title>Kocaeli Universitesi</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
        }

        li {
            float: left;
        }

            li a {
                display: block;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

                li a:hover {
                    background-color: #111;
                }
    </style>
</head>
<body>

    <ul>
        <li><a class="active" href="Sorgular.aspx">Sor</a></li>
        <li><a href="pdf_gor.aspx">Pdfler</a></li>
        <li><a href="EklemeSayfası.aspx">Yeni Kullanıcı</a></li>
    </ul>
    <form runat="server">
        <div style="margin-top: 15px">

            <table class="table table-bordered">

                <tr>


                    <th>ID</th>
                    <th>Kullanıcı</th>
                    <th>Şifre</th>
                    <th>Sil</th>
                    <th>Güncelle</th>

                </tr>

                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("username ") %></td>
                            <td><%# Eval("psw") %></td>
                            <td>
                                <asp:HyperLink NavigateUrl='<%# "Sil.aspx?ID="+Eval("id") %>' ID="HyperLink1" runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink></td>
                            <td>
                                <asp:HyperLink NavigateUrl='<%# "Guncelle.aspx?ID="+Eval("id") %>' ID="HyperLink2" runat="server" class="btn btn-success">Güncelle</asp:HyperLink></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>



            </table>

        </div>
    </form>

</body>
</html>



