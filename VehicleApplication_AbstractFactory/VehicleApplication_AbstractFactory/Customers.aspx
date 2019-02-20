<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="VehicleApplication_AbstractFactory.Customers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Customers</h1>

    <div id="customerForm" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>Type: </td>
                    <td>
                        <asp:DropDownList ID="customerType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="customerType_SelectedIndexChanged">
                            <asp:ListItem Text="Private Person" Value="Privatperson" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Company" Value="Firma"></asp:ListItem>
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>First name: </td>
                    <td>
                        <asp:TextBox ID="customerFirstname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last name: </td>
                    <td>
                        <asp:TextBox ID="customerLastname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Income: </td>
                    <td>
                        <asp:TextBox ID="customerIncome" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Button ID="customerSubmitButton" runat="server" Text="Save" OnClick="customerSubmitButton_Click" />

                    </td>
                    <td>
                        <asp:Button ID="customerClearButton" runat="server" Text="Clear" OnClick="customerClearButton_Click" />
                    </td>
                </tr>

            </table>
            <br />
            <asp:Label ID="CustomerMessageLabel" runat="server"></asp:Label>
            <br />
        </div>
    </div>

    <asp:GridView ID="customersGrid" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="VehicleDB_Customers" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" Visible="false" />
            <asp:BoundField DataField="CustomerType" HeaderText="CustomerType" SortExpression="CustomerType" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="Income" HeaderText="Income" SortExpression="Income" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="VehicleDB_Customers" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>


</asp:Content>
