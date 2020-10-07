<%@ Page Title="" Language="C#" MasterPageFile="~/mngrzeno.Master" AutoEventWireup="true" CodeBehind="mngremp.aspx.cs" Inherits="testzeno.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h3 class="mt-4">Manage Employees</h3>
        <br />
        
       <div class="row">
           <div class="col-lg-8 mx-auto">
            <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Employee Details</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6">
                          <label>Employee ID</label>
                          <div class="form-group">
                              <div class="input-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ex: 0001" TextMode="Number"></asp:TextBox>
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
                              <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="ex: 011 123 4567"  TextMode="Phone">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Recruited Date</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
                          </div>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-8">
                          <label>Employee Role</label>
                          <div class="form-group">
                              <asp:DropDownList Class="form-control" ID="DropDownList1" runat="server">
                                  <asp:ListItem Text="-Select" Value="Select" />
                                  <asp:ListItem Text="Sales Representative" Value="Sales Representative" />
                                  <asp:ListItem Text="Administrator" Value="Administrator" />
                                  <asp:ListItem Text="Manager" Value="Manager" />
                              </asp:DropDownList>
                          </div>
                      </div>

                  </div>


                  <div class="row">
                      <div class="col-lg-5">
                          <label>Area Code</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="ex: 00130"  TextMode="Number">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-7">
                          <label>City</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ex: Colombo">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <label>Employee Full Address</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="ex : 132, My Street, Kingston, New York 12401" TextMode="MultiLine">

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
                      <div class="col-lg-6">
                          <label>Employee Username</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Employee Username">

                              </asp:TextBox>
                          </div>
                      </div>
                      <div class="col-lg-6">
                          <label>Employee Password</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Employee Password">

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

           <!--
           <div class="col-lg-7">

             <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Employee Data Table</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [employees]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="empID" DataSourceID="SqlDataSource1">
                              <Columns>
                                  <asp:BoundField DataField="empID" HeaderText="empID" ReadOnly="True" SortExpression="empID" />
                                  <asp:BoundField DataField="empFname" HeaderText="empFname" SortExpression="empFname" />
                                  <asp:BoundField DataField="empLname" HeaderText="empLname" SortExpression="empLname" />
                                  <asp:BoundField DataField="empPhone" HeaderText="empPhone" SortExpression="empPhone" />
                                  <asp:BoundField DataField="empRegdate" HeaderText="empRegdate" SortExpression="empRegdate" />
                                  <asp:BoundField DataField="empType" HeaderText="empType" SortExpression="empType" />
                                  <asp:BoundField DataField="empAreacode" HeaderText="empAreacode" SortExpression="empAreacode" />
                                  <asp:BoundField DataField="empCity" HeaderText="empCity" SortExpression="empCity" />
                                  <asp:BoundField DataField="empAddress" HeaderText="empAddress" SortExpression="empAddress" />
                                  <asp:BoundField DataField="empUname" HeaderText="empUname" SortExpression="empUname" />
                                  <asp:BoundField DataField="empPass" HeaderText="empPass" SortExpression="empPass" />
                              </Columns>
                              
                          </asp:GridView>
                      </div>
                  </div>


              </div>
            </div>


           </div>
           -->
       </div>

        <br />

        <div class="col-lg">

             <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">Employee Data Table</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:zenogenConnectionString %>" SelectCommand="SELECT * FROM [employees]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="empID" DataSourceID="SqlDataSource2">
                              <Columns>
                                  <asp:BoundField DataField="empID" HeaderText="empID" ReadOnly="True" SortExpression="empID" />
                                  <asp:BoundField DataField="empFname" HeaderText="empFname" SortExpression="empFname" />
                                  <asp:BoundField DataField="empLname" HeaderText="empLname" SortExpression="empLname" />
                                  <asp:BoundField DataField="empPhone" HeaderText="empPhone" SortExpression="empPhone" />
                                  <asp:BoundField DataField="empRegdate" HeaderText="empRegdate" SortExpression="empRegdate" />
                                  <asp:BoundField DataField="empType" HeaderText="empType" SortExpression="empType" />
                                  <asp:BoundField DataField="empAreacode" HeaderText="empAreacode" SortExpression="empAreacode" />
                                  <asp:BoundField DataField="empCity" HeaderText="empCity" SortExpression="empCity" />
                                  <asp:BoundField DataField="empAddress" HeaderText="empAddress" SortExpression="empAddress" />
                                  <asp:BoundField DataField="empUname" HeaderText="empUname" SortExpression="empUname" />
                                  <asp:BoundField DataField="empPass" HeaderText="empPass" SortExpression="empPass" />
                              </Columns>
                              
                          </asp:GridView>
                      </div>
                  </div>


              </div>
            </div>


           </div>




    </div>

</asp:Content>
