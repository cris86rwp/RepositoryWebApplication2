<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WMS_Wheel.aspx.vb" Inherits="WebApplication2.WMS_Wheel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style11 {
            position: absolute;
            top: 1039px;
            left: 645px;
            z-index: 1;
            width: 149px;
            height: 41px;
            right: 608px;
        }
        .auto-style13 {
            position: absolute;
            top: 235px;
            left: 652px;
            z-index: 1;
            width: 142px;
            height: 28px;
        }
        .auto-style14 {
            margin-top: 0px;
        }
        .auto-style15 {
            position: absolute;
            top: 46px;
            left: 382px;
        }
        .auto-style16 {
            text-align: center;
            font-weight: 700;
        }
        .table {
            margin-left: 469px;
            margin-top: 0px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style16">
            Workshop Manufacturing Suspense(WMS)&nbsp; Expenditure<br />
        </div>


        <TD >
        <asp:Label ID="lblMessage1" runat="server" CssClass="auto-style15" style="z-index: 1; width: 714px; height: 27px; text-align: center; bottom: 737px;" Text="Message" ViewStateMode="Enabled"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Year"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="YEAR" DataValueField="YEAR" Height="22px" style="margin-left: 67px" Width="132px">
        </asp:DropDownList> </td>
        &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:newWAP %>" SelectCommand="SELECT [YEAR] FROM [YEAR_PLANHEAD]"></asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
         <asp:Button ID="Button2" runat="server" CssClass="auto-style13" Text="OK" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" Text="Month"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="MONTH" DataValueField="MONTH" Height="20px" style="margin-left: 57px" Width="129px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:newWAP %>" SelectCommand="SELECT [MONTH] FROM [MONTH_PLANHEAD]"></asp:SqlDataSource>
        
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="Label3" runat="server" Text="Planhead"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" style="margin-left: 39px" Width="130px" DataSourceID="SqlDataSource3" DataTextField="PLANHEAD" DataValueField="PLANHEAD" >
        </asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:newWAP %>" SelectCommand="SELECT [PLANHEAD] FROM [PLAN_HEAD]"></asp:SqlDataSource>
         
        <br />
         
        <br />
        <br />
         
        <br />
        <br />
        <asp:datagrid id="Datagrid2" runat="server" CssClass="table"   AutoGenerateColumns="False" BackColor="Gray"  ForeColor="Black" Width="562px">
							<SelectedItemStyle ForeColor="LightGray"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="LightGray"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="PLANHEAD" ReadOnly="True" HeaderText="PLANHEAD"></asp:BoundColumn>
								<asp:BoundColumn DataField="HEAD" HeaderText="HEAD"></asp:BoundColumn>
								<asp:BoundColumn DataField="TYPE" HeaderText="TYPE"></asp:BoundColumn>
                                <asp:BoundColumn DataField="YEAR" HeaderText="YEAR"></asp:BoundColumn>
								<asp:BoundColumn DataField="MONTH" HeaderText="MONTH"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DEBIT" HeaderText="DEBIT"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
        <asp:datagrid id="Datagrid3" runat="server" CssClass="table"   AutoGenerateColumns="False" BackColor="Gray"  ForeColor="Black" Width="562px">
							<SelectedItemStyle ForeColor="LightGray"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="LightGray"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="TOTAL" ReadOnly="True" HeaderText="TOTAL"></asp:BoundColumn>
								
							</Columns>
						</asp:datagrid>
        <br />
        <br />
        
     
    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" BackColor="Gray" ForeColor="Black" PageSize="12" AllowPaging="True" CssClass="auto-style14" Height="400px" Width="250px" >
       <AlternatingRowStyle BackColor="white" />
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
            <Columns>
                <asp:BoundField DataField="planhead" HeaderText="PLANHEAD" />
                <asp:BoundField DataField="head" HeaderText="HEADS" />
                <asp:BoundField DataField="type" HeaderText="TYPE" />
                      
                <asp:TemplateField HeaderText="Debit">
            <ItemTemplate>
                <asp:textbox id="debit" runat="server"   CssClass="form-control" MaxLength="100" Width="100px"  TextMode="singleline"></asp:textbox>
            </ItemTemplate>
                    </asp:TemplateField>
      
    </Columns>
</asp:GridView>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style11" Text="Submit" />
</TD>
        <TD colspan="4" style="HEIGHT: 105px"></TD>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
