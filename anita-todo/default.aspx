<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="anita_todo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBoxList AutoPostBack="true"  ID="ToDoListBoxes" runat="server" OnSelectedIndexChanged="ToDoListBoxes_OnSelectedIndexChanged"></asp:CheckBoxList>
            <br /><br />
            <asp:TextBox runat="server" ID="ToDoName"></asp:TextBox> <asp:Button ID ="CreateToDo" runat="server" Text="Add Item" OnClick="CreateToDo_OnClick" />
        </div> 
    </form>
</body>
</html>
