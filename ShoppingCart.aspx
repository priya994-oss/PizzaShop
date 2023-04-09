<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="PizzaShop.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="ftco-section ftco-degree-bg">
        <div class="container">
            <div class="row">
                <div class="col-md-12 sidebar ftco-animate">
                    <h2 class="mb-3" style="color: gray; text-decoration: underline">Shopping Cart</h2>
                    <div class="sidebar-box ftco-animate" style="border: 1px solid #e5e4e4">
                        <div class="categories">
                            <asp:GridView ID="gvPizza" runat="server" AutoGenerateColumns="false" class="table table-bordered nowrap"
                                ClientIDMode="Static" Width="100%" Style="border: 1px solid #dee2e6; font-size: 13px;" DataKeyNames="PizzaID" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="PizzaID" HeaderText="Pizza ID" Visible="false" />
                                    <asp:BoundField DataField="PizzaName" HeaderText="Pizza Details" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Qty") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtQuantity" class="form-control" runat="server" Text='<%# Bind("Qty") %>' Style="font-size: 13px;" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Total" HeaderText="Total" />
                                </Columns>
                                <EmptyDataTemplate>Records not found...</EmptyDataTemplate>
                            </asp:GridView>
                            <br />
                            <a href="Home.aspx"><i class="icon-arrow-left"></i>&nbsp; Continue Shopping</a>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 sidebar ftco-animate">
                    <h2 class="mb-3" style="color: gray; text-decoration: underline">Order Summary</h2>
                    <div class="sidebar-box ftco-animate" style="border: 1px solid #e5e4e4">
                        <div class="categories">
                            <table style="width: 100%; border: 1px solid #dee2e6;" class="table table-borderless table-responsive">
                                <tbody>
                                    <tr style="visibility: collapse">
                                        <th style="width: 50%;"></th>
                                        <th style="width: 50%;"></th>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Subtotal</td>
                                        <td style="text-align: right; width: 100%;">
                                            <asp:Label ID="lblSubtotal" runat="server" Text="0.00" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Shipping</td>
                                        <td style="text-align: right; color: forestgreen; font-weight: bold;">Free</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Discount</td>
                                        <td style="text-align: right;">0.00</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Total To Pay</td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblTotalAmt" runat="server" Text="0.00" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" CssClass="btn btn-white btn-outline-white" Style="width: 100%;" OnClick="btnCheckout_Click"/>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                    </div>

                </div>

            </div>
        </div>
    </section>
</asp:Content>
