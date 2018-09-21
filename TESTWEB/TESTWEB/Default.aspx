<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 style="width: 1490px; text-align: center;" class="text-center">โปรแกรมคำนวนค่าโทร</h1>
    </div>

    <div class="row">
        <div class="col-md-4" style="left: 4px; top: 19px; width: 1505px">
            <h2 style="width: 901px">
                <table id="tbAssetGroup" class="table table-bordered" style="width: 130%">
                           
                        </table>
            </h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="859px">
                                            <Columns>
                                                <asp:BoundField DataField="telno" HeaderText="เบอร์โทร" ReadOnly="True" >
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle BackColor="#003300" BorderColor="White" BorderWidth="2px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Outset" BorderWidth="5px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SumTime" HeaderText="โทรนาที" ReadOnly="True" >
                                                <HeaderStyle BackColor="Black" BorderColor="White" BorderWidth="2px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Outset" BorderWidth="5px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fees" HeaderText="ค่าโทร" ReadOnly="True" >
                                                <HeaderStyle BackColor="Black" BorderColor="White" BorderWidth="2px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Outset" BorderWidth="5px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:GridView>
        </div>
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
        </div>
    </div>
</asp:Content>
