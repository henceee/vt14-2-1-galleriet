<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Galleriet.aspx.cs" Inherits="Galleriet.Galleriet" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Galleriet</h1>
        <asp:Panel ID="Gallery" runat="server" Visible="false">

            <asp:Panel ID="ThumbsPanel" runat="server">
                           
            <asp:Repeater ID="Repeater1" runat="server" ItemType="Galleriet.Model.FileData"  SelectMethod="Repeater1_GetData">
                <HeaderTemplate>
                    <a href="#">
                </HeaderTemplate>
                
                <ItemTemplate>

                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#: Item.href %>' />
                    

                </ItemTemplate>

                <FooterTemplate>
                    </a>
                </FooterTemplate>

            </asp:Repeater>

                </asp:Panel>
            
        </asp:Panel>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:FileUpload ID="FileUpload" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" text="*" 
           ControlToValidate="FileUpload" ErrorMessage="En fil måste väljas!" Display="Dynamic">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="FileUpload" text="*" 
            ErrorMessage="Endast bilder av typerna GIF, JPEG eller PNG är tillåtna!" 
            ValidationExpression="^(\w.*?)(.)(gif|jpg|png)$">
        </asp:RegularExpressionValidator>
        

        <br />
        <br />
        <asp:Button ID="Uppload" runat="server" Text="Ladda Upp" OnClick="Uppload_Click" />


    </div>
    </form>
</body>
</html>
