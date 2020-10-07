<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginzeno.aspx.cs" Inherits="testzeno.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

</head>
<body class="text-center">

    <form id="form9" runat="server">

        <br />
        <br />
        <br />
        <br />
        <br />



       <div class="row">
           <div class="col-lg-5 mx-auto">
            <div class="card">
              <div class="card-body">

                  <div class="row">
                      <div class="col">
                          <h5 class="card-title text-center">SIGN IN</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>


                  <div class="row">
                      <div class="col-lg-6 mx-auto">
                          <label>Employee Role</label>
                          <div class="form-group">
                              <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                  <asp:ListItem Text="-Select" Value="Select" />
                                  <asp:ListItem Text="Sales Representative" Value="Sales Representative" />
                                  <asp:ListItem Text="Administrator" Value="Administrator" />
                                  <asp:ListItem Text="Manager" Value="Manager" />
                              </asp:DropDownList>
                          </div>
                      </div>

                  </div>


                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-6 mx-auto">
                          <label>Employee Username</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="txtusername" runat="server" placeholder="Employee Username">

                              </asp:TextBox>
                          </div>
                      </div>
                  </div>

                  <div class="row">

                      <div class="col-lg-6 mx-auto">
                          <label>Employee Password</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="txtpassword" runat="server" placeholder="Employee Password" TextMode="Password"></asp:TextBox>
                          </div>
                      </div>

                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>


                  <div class="row">
                      <div class="col-lg-3">

                      </div>
                      <div class="col-lg-6">
                          <div class="form-group">
                              <asp:Button class="btn btn-info btn-block" ID="Button" runat="server" Text="SIGN IN" OnClick="Button_Click" />
                          </div>
                      </div>
                      <div class="col-lg-3">

                      </div>
                  </div>


              </div>
            </div>
           </div>
           </div>

    </form>


    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
   
</body>
</html>
