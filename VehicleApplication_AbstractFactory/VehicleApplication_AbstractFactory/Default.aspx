<%@ Page Title="Vehicle Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VehicleApplication_AbstractFactory._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Vehicles</h1>

    <asp:GridView ID="vehicleGrid" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="VehicleDB" OnRowDataBound="vehicleGrid_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
            <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
            <asp:BoundField DataField="Kilowatt" HeaderText="Kilowatt" SortExpression="Kilowatt" />
            <asp:BoundField DataField="Seats" HeaderText="Seats" SortExpression="Seats" />
            <asp:BoundField DataField="Preowned" HeaderText="Preowned" SortExpression="Preowned" />
            <asp:BoundField DataField="LastName" HeaderText="Owner" SortExpression="LastName" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="VehicleDB" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString %>" SelectCommand="SELECT Vehicle.Type, Vehicle.Brand, Vehicle.Model, Vehicle.Kilowatt, Vehicle.Seats, Vehicle.Preowned, Customer.LastName FROM Customer INNER JOIN Vehicle ON Customer.ID = Vehicle.Owner"></asp:SqlDataSource>



</asp:Content>
