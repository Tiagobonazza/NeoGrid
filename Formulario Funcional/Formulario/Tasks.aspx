<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="Formulario.Tasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="Style.css" rel="stylesheet" type="text/css" />

    <title></title>
</head>
        <body>
                    <form id="form1" runat="server">
                        <div class="caixaa">
                            <asp:TextBox ID="txtTitle" runat="server" Placeholder="Title" />
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Placeholder="Description" />
                            <asp:CheckBox ID="chkIsCompleted" runat="server" Text="Completed" />
                            <asp:Button ID="btnAddTask" runat="server" Text="Add Task" OnClick="btnAddTask_Click" />
             
                        </div>
                            <asp:GridView ID="gvTasks" class="caixac" runat="server" AutoGenerateColumns="False"
                                OnRowUpdating="gvTasks_RowUpdating"
                                OnRowEditing="gvTasks_RowEditing" 
                                OnRowDeleting="gvTasks_RowDeleting"
                                OnRowCancelingEdit="gvTasks_RowCancelingEdit"
                                DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="Title">
        <EditItemTemplate>
            <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' />
        </EditItemTemplate>
        <ItemTemplate>
            <%# Eval("Title") %>
        </ItemTemplate>
    </asp:TemplateField>

    
    <asp:TemplateField HeaderText="Description">
        <EditItemTemplate>
            <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" />
        </EditItemTemplate>
        <ItemTemplate>
            <%# Eval("Description") %>
        </ItemTemplate>
    </asp:TemplateField>

    
    <asp:TemplateField HeaderText="Completed">
        <EditItemTemplate>
            <asp:CheckBox ID="chkIsCompleted" runat="server" Checked='<%# Bind("IsCompleted") %>' />
        </EditItemTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="chkCompleted" runat="server" Checked='<%# Eval("IsCompleted") %>' Enabled="false" />
        </ItemTemplate>
    </asp:TemplateField>

   
    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />      
                    </Columns>
                </asp:GridView>
                    </form>
        </body>
</html>