<%@ Page Title="" Language="C#" MasterPageFile="~/empzeno.Master" AutoEventWireup="true" CodeBehind="empsupretrns.aspx.cs" Inherits="testzeno.WebForm21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h3 class="mt-4">Manage Returned Orders</h3>
        <br />
        
       <div class="row">
           <div class="col-lg-5">
            <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center"> Supplier Returned Order Details</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                          <label>Returned Invoice Number</label>
                          <div class="form-group">
                              <div class="input-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ex :00000001" TextMode="Number"></asp:TextBox>
                                  <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                              </div>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Purchase Order ID</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="ex :00000001" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                          <label>Supplier ID</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="ex: 000001" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Product ID</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ex: 0001" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                 
                  <div class="row">
                      <div class="col-lg-6">
                          <label>Returned Quantity</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="ex: 100" TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Returned Date</label>
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
                          <h5 class="card-title text-center"> Supplier Returns Data Table</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [purchase_returns]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="supreturnInvoiceNo" DataSourceID="SqlDataSource1">
                              <Columns>
                                  <asp:BoundField DataField="supreturnInvoiceNo" HeaderText="supreturnInvoiceNo" ReadOnly="True" SortExpression="supreturnInvoiceNo" />
                                  <asp:BoundField DataField="purchaseId" HeaderText="purchaseId" SortExpression="purchaseId" />
                                  <asp:BoundField DataField="supId" HeaderText="supId" SortExpression="supId" />
                                  <asp:BoundField DataField="productId" HeaderText="productId" SortExpression="productId" />
                                  <asp:BoundField DataField="returnedQty" HeaderText="returnedQty" SortExpression="returnedQty" />
                                  <asp:BoundField DataField="returnDate" HeaderText="returnDate" SortExpression="returnDate" />
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
