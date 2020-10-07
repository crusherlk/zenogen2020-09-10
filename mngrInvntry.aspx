<%@ Page Title="" Language="C#" MasterPageFile="~/mngrzeno.Master" AutoEventWireup="true" CodeBehind="mngrInvntry.aspx.cs" Inherits="testzeno.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
        <h3 class="mt-4">Manage Inventory</h3>
        <br />
        
       <div class="row">
           <div class="col-lg-5">
            <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Product Details</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                          <label>Product ID</label>
                          <div class="form-group">
                              <div class="input-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ex : 0001" TextMode="Number"></asp:TextBox>
                                  <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                              </div>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Product Name</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Product Name">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                         <label>One Quantity Price</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="One Quantity Price" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                           <label>Product Quantity</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Product Quantity" TextMode="Number">

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




    </div>

</asp:Content>
