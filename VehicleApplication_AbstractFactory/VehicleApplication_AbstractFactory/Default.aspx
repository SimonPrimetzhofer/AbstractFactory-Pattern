<%@ Page Title="Vehicle Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VehicleApplication_AbstractFactory._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Vehicles</h1>

    <div id="vehicleForm" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>Type: </td>
                    <td>
                        <asp:DropDownList ID="vehicleType" runat="server">
                            <asp:ListItem Text="Car" Value="PKW" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Truck" Value="LKW"></asp:ListItem>
                            <asp:ListItem Text="Motorcycle" Value="Motorrad"></asp:ListItem>
                            <asp:ListItem Text="Tractor" Value="Traktor"></asp:ListItem>
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>Brand: </td>
                    <td>
                        <asp:TextBox ID="vehicleBrand" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Model: </td>
                    <td>
                        <asp:TextBox ID="vehicleModel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Kilowatt: </td>
                    <td>
                        <asp:TextBox ID="vehicleKw" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Seats: </td>
                    <td>
                        <asp:TextBox ID="vehicleSeats" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Preowned: </td>
                    <td>
                        <asp:CheckBox ID="vehiclePreowned" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Owner</td>
                    <td>
                        <asp:DropDownList ID="ownerDropdown" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="Select Owner" Value="select" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="submitButton" runat="server" Text="Save" OnClick="submitButton_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <asp:TextBox ID="TextBox1" runat="server" Width="548px"></asp:TextBox>

    <asp:TextBox ID="TextBox2" runat="server" Width="328px"></asp:TextBox>

    <br />

    <asp:GridView ID="vehicleGrid" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="VehicleDB"
        OnRowDataBound="vehicleGrid_RowDataBound">
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
