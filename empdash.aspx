<%@ Page Title="" Language="C#" MasterPageFile="~/empzeno.Master" AutoEventWireup="true" CodeBehind="empdash.aspx.cs" Inherits="testzeno.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h3 class="mt-4">Dashboard</h3>

        <br />
        
       <div class="row">
           <div class="col-lg-10 mx-auto">

             <div class="card">
              <div class="card-body">

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [inventory]"></asp:SqlDataSource>
                      <div class="col">
                          <h5 class="card-title text-center">Inventory Data Table</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="productID" DataSourceID="SqlDataSource1">
                              <Columns>
                                  <asp:BoundField DataField="productID" HeaderText="productID" ReadOnly="True" SortExpression="productID" />
                                  <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
                                  <asp:BoundField DataField="oneProductPrice" HeaderText="oneProductPrice" SortExpression="oneProductPrice" />
                                  <asp:BoundField DataField="ProductQty" HeaderText="ProductQty" SortExpression="ProductQty" />
                              </Columns>
                          </asp:GridView>
                      </div>
                  </div>


              </div>
            </div>


           </div>
       </div>

        <br />

        <div class="row">
           
            <div class="col-lg-10 mx-auto">

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
                      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [orders]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="orderNo" DataSourceID="SqlDataSource2">
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

        <br />

        <div class="row">
           
            <div class="col-lg-10 mx-auto">

             <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Customer Data Table</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="cusID" DataSourceID="SqlDataSource3">
                              <Columns>
                                  <asp:BoundField DataField="cusID" HeaderText="cusID" ReadOnly="True" SortExpression="cusID" />
                                  <asp:BoundField DataField="cusFname" HeaderText="cusFname" SortExpression="cusFname" />
                                  <asp:BoundField DataField="cusLname" HeaderText="cusLname" SortExpression="cusLname" />
                                  <asp:BoundField DataField="cusPhone" HeaderText="cusPhone" SortExpression="cusPhone" />
                                  <asp:BoundField DataField="cusEmail" HeaderText="cusEmail" SortExpression="cusEmail" />
                                  <asp:BoundField DataField="cusAddress" HeaderText="cusAddress" SortExpression="cusAddress" />
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
