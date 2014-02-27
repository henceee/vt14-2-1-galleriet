<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Galleriet.aspx.cs" Inherits="Galleriet.Galleriet" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <link href="~/Content/reset.css" rel="stylesheet" />--%>
    <link href="~/Content/StyleSheet.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="lefty"></div>
    <div id="gallery">
        <div id="filler">
        <h1>Galleriet</h1>
        
        </div>
        
            <asp:Image ID="Image1" runat="server"  Width="400px" Height="375" Visible="false"/>
           
                          
            <asp:Repeater ID="Repeater1" runat="server" ItemType="System.String"  SelectMethod="Repeater1_GetData">
                <HeaderTemplate>
                    <div id="ThumbsPanel">

                    <div id="Scrollable">
                </HeaderTemplate>
                
                <ItemTemplate>                   
                    
                    <asp:HyperLink runat="server" 
                        NavigateUrl='<%#: "~/Galleriet.aspx?name="+ Item %>'
                        ImageUrl='<%#: "~/Content/Images/Thumbs/"+ Item %>' />
                   
                </ItemTemplate>
                    
                <FooterTemplate>
                    </div>
                    </div>
                </FooterTemplate>

            </asp:Repeater>

            
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="red" ForeColor="Red"/>
         <asp:Label ID="Success" runat="server" Text="Uppladdningen lyckad!" Forecolor="White" BackColor="ForestGreen" Visible="false" ></asp:Label>
        <br />
        <br />

        <asp:FileUpload ID="FileUpload" runat="server"/>  
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" text="*" CssClass="red" 
           ControlToValidate="FileUpload" ErrorMessage="En fil måste väljas!" Display="Dynamic" ForeColor="Red">
        </asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="FileUpload" text="*"  CssClass="red" ForeColor="Red"
            ErrorMessage="Endast bilder av typerna GIF, JPEG eller PNG är tillåtna!" 
            ValidationExpression="(?i:^.*.(gif|jpg|png)$)" Display="Dynamic">
        </asp:RegularExpressionValidator>
        

        <br />
        <br />
        <asp:Button ID="Upload" runat="server" Text="Ladda Upp" OnClick="Upload_Click" />


    </div>
    </form>
</body>
</html>
