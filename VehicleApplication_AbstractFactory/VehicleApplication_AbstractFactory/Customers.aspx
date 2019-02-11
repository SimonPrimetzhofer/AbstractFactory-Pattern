<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="VehicleApplication_AbstractFactory.Customers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Customers</h1>
    <asp:GridView ID="customersGrid" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="VehicleDB_Customers">
        <Columns>
            <asp:BoundField DataField="CustomerType" HeaderText="CustomerType" SortExpression="CustomerType" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="Income" HeaderText="Income" SortExpression="Income" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="VehicleDB_Customers" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString %>" SelectCommand="SELECT [CustomerType], [FirstName], [LastName], [Income] FROM [Customer]"></asp:SqlDataSource>


</asp:Content>
