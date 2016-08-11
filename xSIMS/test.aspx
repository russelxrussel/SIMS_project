<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jscripts/jquery-1.11.3.js" type="text/javascript"></script>
    <script src="jscripts/jquery-ui.js" type="text/javascript"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />

  <%--  <script type="text/javascript">
        $(document).ready(function () {
            $('#txtSearch').autocomplete({
                source: ['dasd', 'google']
            });
        });
    </script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtSearch").autocomplete({
                //source: ['Choice1', 'Choice2', 'Test1', 'Test2']
                source: function (request, response) {
                    $.ajax({
                        url: "WService.asmx/DisplayStudents",
                        method: "POST",
                        contentType: "application/json;charset=utf-8",
                        data: JSON.stringify({ STUDENTNAME: $("#txtSearch").val() }),
                        dataType: "json",
                        success: function (data) {
                            response(data.d)
                        },
                        error: function (err) {
                            alert(err);
                            console.log('Error:', data);
                        }
                    })
                }
            });
        });


        //Keypress on search
        $('#test1').live('keypress', function (e) {
            if (e.which == 13) {
                alert('Enter PRessed');
                //return false;
            }
        });
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
     Applicant<asp:TextBox runat="server" id="txtSearch"></asp:TextBox>
        <br />
        <br />
    </div>

    <asp:Button ID="Button1" runat="server" Text="Generate Random" onclick="test_Click"  />
    <input type="text" id="test1" />
    <script type="text/javascript">

        function CalculateTotals() {
            var gv = document.getElementById("<%= GridView1.ClientID %>");
            var tb = gv.getElementsByTagName("input");
            var lb = gv.getElementsByTagName("span");

            var sub = 0;
            var total = 0;
            var indexQ = 1;
            var indexP = 0;

            for (var i = 0; i < tb.length; i++) {
                if (tb[i].type == "text") {
                    
                    sub = parseFloat(lb[indexP].innerHTML) * parseFloat(tb[i].value);
                    
                    if (isNaN(sub)) {
                        lb[i + indexQ].innerHTML = "";
                        sub = 0;
                    }
                    else {
                        lb[i + indexQ].innerHTML = sub + "SOURCE= " + lb[indexP].innerHTML;
                    }

                    indexQ++;
                    indexP = indexP + 2;

                    total += parseFloat(sub);
                }
            }
            lb[lb.length - 1].innerHTML = total;
        }
 
    </script>

    <asp:gridview ID="GridView1"  runat="server"  ShowFooter="true" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
        <asp:BoundField DataField="Description" HeaderText="Item Description" />
        <asp:TemplateField HeaderText="Item Price">
            <ItemTemplate>
                <asp:Label ID="LBLPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:TextBox ID="TXTQty" runat="server" onkeyup="CalculateTotals();"></asp:TextBox>
            </ItemTemplate>
            <FooterTemplate>
                <b>Total Amount:</b>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sub-Total">
            <ItemTemplate>
               <%-- <asp:Label ID="LBLSubTotal" runat="server"></asp:Label>--%>
               <span runat="server" id="tot"></span>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="LBLTotal" runat="server" ForeColor="Green"></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:gridview>

   
    </form>
</body>
</html>
