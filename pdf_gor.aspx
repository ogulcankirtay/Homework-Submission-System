<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pdf_gor.aspx.cs" Inherits="yazlab1_3.v._1.pdf_gor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
              <Columns>
                  <asp:TemplateField>
                      <ItemTemplate>
     <asp:LinkButton ID="LinkButton1" runat="server"  Text='<%# Bind("name")%>' OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                      </ItemTemplate>

                  </asp:TemplateField>

              </Columns>
            </asp:GridView>
       
        </div>
    </form>
</body>
</html>
