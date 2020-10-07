<%@ Page Title="" Language="C#" MasterPageFile="~/empzeno.Master" AutoEventWireup="true" CodeBehind="emprcus.aspx.cs" Inherits="testzeno.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h3 class="mt-4">Manage Customers</h3>
        <br />
        
       <div class="row">
           <div class="col-lg-5">
            <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Customers Details</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-5">
                          <label>Customer ID</label>
                          <div class="form-group">
                              <div class="input-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ex: 000001" TextMode="Number"></asp:TextBox>
                                  <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                              </div>
                          </div>
                      </div>

                     <!--comment
                      <div class="col-lg-8">
                          
                          <label>Employee Name</label>
                          <div class="form-group">
                          </div>

                      </div>
                      comment-->

                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                          <label>First Name</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="First Name">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Last name</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Last Name">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>
                 
                  <div class="row">
                      <div class="col-lg-6">
                          <label>Phone Number</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="ex: 011 123 456"  TextMode="Phone">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Customer Email</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="example@gmail.com" TextMode="Email">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <label>Employee Full Address</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="ex : 132, My Street, Kingston, New York 12401" TextMode="MultiLine"></asp:TextBox>
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
                          <h5 class="card-title text-center">Customer Data Table</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="cusID" DataSourceID="SqlDataSource1">
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
