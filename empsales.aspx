<%@ Page Title="" Language="C#" MasterPageFile="~/empzeno.Master" AutoEventWireup="true" CodeBehind="empsales.aspx.cs" Inherits="testzeno.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <h3 class="mt-4">Manage Orders</h3>
        <br />
        
       <div class="row">
           <div class="col-lg-5">
            <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Order Details</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                          <label>Order Number</label>
                          <div class="form-group">
                              <div class="input-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ex :00000001" TextMode="Number"></asp:TextBox>
                                  <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                              </div>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Customer ID</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="ex :000001" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                          <label>Product ID</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="ex: 0003" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Order Quantity</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ex: 100" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                 
                  <div class="row">
                      <div class="col-lg-6">
                          <label>Sold Employee ID</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="ex: 0001" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Ordered Date</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="YYYY-MM-DD" TextMode="SingleLine">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>


                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>


                  <div class="row">
                      <div class="col-lg-4">
                           <div class="form-group">
                              <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" />
                          </div>
                      </div>
                      <div class="col-lg-4">
                          <div class="form-group">
                              <asp:Button class="btn btn-info btn-block" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                          </div>
                      </div>
                      <div class="col-lg-4">
                          <div class="form-group">
                              <asp:Button class="btn btn-danger btn-block" ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
                          </div>
                      </div>
                  </div>


              </div>
            </div>
           </div>

           <div class="col-lg-7">

             <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Order Data Table</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [orders]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="orderNo" DataSourceID="SqlDataSource1">
                              <Columns>
                                  <asp:BoundField DataField="orderNo" HeaderText="orderNo" ReadOnly="True" SortExpression="orderNo" />
                                  <asp:BoundField DataField="customerID" HeaderText="customerID" SortExpression="customerID" />
                                  <asp:BoundField DataField="productID" HeaderText="productID" SortExpression="productID" />
                                  <asp:BoundField DataField="orderedQty" HeaderText="orderedQty" SortExpression="orderedQty" />
                                  <asp:BoundField DataField="soldEmpId" HeaderText="soldEmpId" SortExpression="soldEmpId" />
                                  <asp:BoundField DataField="orderDate" HeaderText="orderDate" SortExpression="orderDate" />
                              </Columns>
                          </asp:GridView>
                      </div>
                  </div>


              </div>
            </div>


           </div>
       </div>




    </div>

</asp:Content>
