<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="PizzaShop.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="ftco-section ftco-degree-bg">
        <div class="container">
            <div class="row">
                <div class="col-md-12 sidebar ftco-animate">
                    <h2 class="mb-3" style="color: gray; text-decoration: underline">Billing Details</h2>
                    <div class="sidebar-box ftco-animate" style="border: 1px solid #e5e4e4">
                        <div class="categories">
                            <div class="col-md-6" style="float: left; position: inherit;">
                                First Name    
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter First Name" />
                            </div>
                            <div class="col-md-6" style="float: right; position: inherit;">
                                Last Name
                               <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Enter Last Name" />
                            </div>

                            <div class="col-md-12">
                                Address
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Shipping Address" TextMode="MultiLine" Rows="2" />
                            </div>

                            <div class="col-md-6" style="float: left;">
                                Town/City
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Shipping City" />
                            </div>
                            <div class="col-md-6" style="float: right;">
                                Zipcode
                               <asp:TextBox ID="txtZipcode" runat="server" CssClass="form-control" placeholder="Shipping Zipcode" />
                            </div>

                            <div class="col-md-6" style="float: left;">
                                Phone Number
                               <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" placeholder="Your Phone Number" MaxLength="10"/>
                            </div>
                            <div class="col-md-6" style="float: right;">
                                Email
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Your Email" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 sidebar ftco-animate">
                    <h2 class="mb-3" style="color: gray; text-decoration: underline">Payment Details</h2>
                    <div class="sidebar-box ftco-animate" style="border: 1px solid #e5e4e4">
                        <div class="categories">
                            <div class="col-md-12">
                                Name On Card                                       
                                <asp:TextBox ID="txtNameOnCard" runat="server" CssClass="form-control" placeholder="Your Name On Card" />
                            </div>

                            <div class="col-md-6" style="float: left;">
                                Card Number
                                <asp:TextBox ID="txtCardNo" runat="server" CssClass="form-control" placeholder="Your Card Number" MaxLength="16"/>
                            </div>

                            <div class="col-md-3" style="float: left;">
                                CCV
                                <asp:TextBox ID="txtCCV" runat="server" CssClass="form-control" placeholder="CCV" MaxLength="3" ToolTip="The 3 digit code usually found on the back of your card." />
                            </div>
                            <div class="col-md-3" style="float: right;">
                                Date (MM/YY)
                                <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control" placeholder="MM/YY" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 sidebar ftco-animate">
                    <h2 class="mb-3" style="color: gray; text-decoration: underline">Your Order</h2>
                    <div class="sidebar-box ftco-animate" style="border: 1px solid #e5e4e4">
                        <div class="categories">
                            <asp:GridView ID="gvPizza" runat="server" AutoGenerateColumns="false" class="table table-bordered nowrap"
                                ClientIDMode="Static" Width="100%" Style="border: 1px solid #dee2e6; font-size: 13px;" DataKeyNames="PizzaID" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="PizzaID" HeaderText="Pizza ID" Visible="true" />
                                    <asp:BoundField DataField="PizzaName" HeaderText="Pizza Details" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                                    <%--<asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Qty") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtQuantity" class="form-control" runat="server" Text='<%# Bind("Qty") %>' Style="font-size: 13px;" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Total" HeaderText="Total" />
                                    <asp:BoundField DataField="CartID" HeaderText="CartID" Visible="true" />
                                </Columns>
                                <EmptyDataTemplate>Records not found...</EmptyDataTemplate>
                            </asp:GridView>

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
                                            <asp:Button ID="btnCheckout" runat="server" Text="Place Your Order" CssClass="btn btn-white btn-outline-white" Style="width: 100%;" OnClick="btnCheckout_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                    </div>

                </div>

                <br />
                <a href="ShoppingCart.aspx"><i class="icon-arrow-left"></i>&nbsp; Edit Shopping Cart</a>
            </div>
        </div>
    </section>

</asp:Content>
