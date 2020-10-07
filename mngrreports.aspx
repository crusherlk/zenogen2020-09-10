<%@ Page Title="" Language="C#" MasterPageFile="~/mngrzeno.Master" AutoEventWireup="true" CodeBehind="mngrreports.aspx.cs" Inherits="testzeno.WebForm6" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h3 class="mt-4">Reports</h3>
        
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
                          <h5 class="card-title text-center">Selling of Products by Order Quantity</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-10 mx-auto">

                          <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" Width="888px">
                            <Series>
                            <asp:Series Name="Series1" ChartType="Pie" XValueMember="productID" YValueMembers="orderedQty" ChartArea="ChartArea1" Legend="Legend1"></asp:Series>
                            </Series>

                            <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" Name="Legend1">
                            </asp:Legend>
                            </Legends>
                            </asp:Chart>

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
                          <h5 class="card-title text-center">Selling of Products by the Employee sales</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-10 mx-auto">

                          <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" Width="888px" OnLoad="Chart2_Load">
                            <Series>
                            <asp:Series Name="Employee Sales" XValueMember="soldEmpId" YValueMembers="orderedQty" ChartArea="ChartArea1" Legend="Legend1"></asp:Series>
                            </Series>

                            <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" Name="Legend1">
                            </asp:Legend>
                            </Legends>
                            </asp:Chart>

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
                          <h5 class="card-title text-center">Selling of Products by the Customer</h5>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <hr />
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-lg-10 mx-auto">

                          <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource2" Width="888px" OnLoad="Chart2_Load">
                            <Series>
                            <asp:Series Name="Customer" XValueMember="customerID" YValueMembers="orderedQty" ChartArea="ChartArea1" Legend="Legend1"></asp:Series>
                            </Series>

                            <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" Name="Legend1">
                            </asp:Legend>
                            </Legends>
                            </asp:Chart>

                      </div>
                  </div>


              </div>
            </div>


            </div>
       </div>


    </div>

</asp:Content>
