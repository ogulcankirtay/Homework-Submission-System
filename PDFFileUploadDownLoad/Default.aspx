<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PDFFileUploadDownLoad.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body bgcolor="gray">
    <form id="form1" runat="server">
        <div style="margin-top: 15px">

        </div>

        <div>
            <table>
                <tr>
                    <td>Select File
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only Excel File" />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
                    </td>
                    <td>

                        <asp:Button ID="Button2" runat="server" Text="View Files"
                            OnClick="Button2_Click" />
                    </td>
                </tr>

            </table>
            <p>
                <asp:Label ID="Label2" runat="server" Text="label"></asp:Label>
            </p>

            <br />
       
           
             //<asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="349px">
           <Columns >
               <asp:TemplateField>
                   <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Bind("name")%>'  OnClick ="LinkButton1_Click">LinkButton</asp:LinkButton>
                   </ItemTemplate>

               </asp:TemplateField>
           </Columns>
        </asp:GridView>
        </div>
        
        <p>
            &nbsp;</p>
    </form>


</body>
</html>
