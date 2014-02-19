<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="hur_många_versaler.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/css/ErrorStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="ErrorLabel" runat="server">
            <h1>Hur Många Versaler?</h1>
            <br />
            <h2>Serverfel</h2>
            <br />
            <p>Vi beklagar att ett fel har inträffat och vi inte kunde hantera din förfrågan</p>
            <a href="default.aspx">Tillbaka</a>

        </asp:Label>
    </div>
    </form>
</body>
</html>
