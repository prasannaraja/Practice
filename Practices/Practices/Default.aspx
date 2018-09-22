<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="crudGridView_01.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="gvPhoneBook" AutoGenerateColumns="false" runat="server" 
                OnRowCommand="gvPhoneBook_RowCommand"
                OnRowEditing="gvPhoneBook_RowEditing"
                OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                OnRowUpdating="gvPhoneBook_RowUpdating"
                OnRowDeleting="gvPhoneBook_RowDeleting"
                ShowHeaderWhenEmpty="true" ShowFooter="true" DataKeyNames="PhoneBookID">
                <Columns>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FirstName")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LastName")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLastNameFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Contact")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("Contact")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Email")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" Text='<%# Eval("Email")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button CommandName="Edit" runat="server" Text="Edit" ToolTip="Edit" Height="20px" Width="60px"  />
                            <asp:Button CommandName="Delete" runat="server" Text="Delete"  ToolTip="Delete" Height="20px" Width="60px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button CommandName="Update" runat="server" Text="Save"  ToolTip="Save" Height="20px" Width="60px"  />
                            <asp:Button CommandName="Cancel" runat="server" Text="Cancel"  ToolTip="Cancel" Height="20px" Width="60px" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Button CommandName="AddNew" runat="server" Text="Add"  ToolTip="Add" Height="20px" Width="60px" />
                            <asp:Button CommandName="Cancel" runat="server" Text="Cancel"  ToolTip="Cancel" Height="20px" Width="60px" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
