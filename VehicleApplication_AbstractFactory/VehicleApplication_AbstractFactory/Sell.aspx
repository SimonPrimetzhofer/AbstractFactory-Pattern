<%@ Page Title="Sell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="VehicleApplication_AbstractFactory.Sell" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Sales</h1>

    <table class="auto-style1 ">
        <tr>
            <td>
                <h3>Seller</h3>
                <asp:DropDownList AutoPostBack="true" ID="SellerDropdown" runat="server" DataSourceID="SellDataSource" DataTextField="LastName" DataValueField="ID" AppendDataBoundItems="True" OnSelectedIndexChanged="SellerDropdown_SelectedIndexChanged">
                    <asp:ListItem Text="Select Seller" Selected="True" Value="DefaultSeller" />
                </asp:DropDownList>
            </td>
            <td>
                <h3>Buyer</h3>
                <asp:DropDownList ID="BuyerDropdown" runat="server" DataSourceID="BuyerDataSource" DataTextField="LastName" DataValueField="ID" AppendDataBoundItems="True">
                     <asp:ListItem Text="Select Buyer" Selected="True" Value="DefaultBuyer" />
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <h3>Vehicle</h3>
                <asp:DropDownList ID="VehicleDropdown" runat="server">
                     <asp:ListItem Text="Select Vehicle" Selected="True" Value="DefaultVehicle" />
                </asp:DropDownList>
            </td>
            <td>
                <h3>Price</h3>
                <asp:TextBox ID="Price" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <h3>Complete transaction</h3>
                <asp:Button CssClass="btn btn-primary" ID="CompleteButton" runat="server" Text="Complete" OnClick="CompleteButton_Click" />
            </td>
        </tr>
    </table>

    <asp:SqlDataSource ID="SellDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString %>" SelectCommand="select * from customer where (select count(*) from vehicle where owner=customer.ID) &gt; 0;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="BuyerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="VehicleDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Vehicle]"></asp:SqlDataSource>

</asp:Content>
