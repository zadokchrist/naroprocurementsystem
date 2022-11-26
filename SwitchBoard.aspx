<%@ Page Language="C#" AutoEventWireup="true" 
CodeFile="SwitchBoard.aspx.cs" 
Inherits="SwitchBoard"
EnableEventValidation="false"
Culture="auto" 
UICulture="auto" %>

 <%@ Register 
 Assembly="AjaxControlToolkit" 
 Namespace="AjaxControlToolkit" 
 TagPrefix="ajaxToolkit" %>
 <%@ Import
  Namespace="System.Threading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> NWSC e-Procurement </title>
    
    <link href="scripts/WQC_stylesheet.css" rel="stylesheet" type="text/css" />
    
    <link href="scripts/globalscape.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="ddtabmenufiles/ddtabmenu.js">

/***********************************************
* DD Tab Menu script- © Dynamic Drive DHTML code library (www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
***********************************************/

    </script>
    

<!-- CSS for Tab Menu #4 -->
<link rel="stylesheet" type="text/css" href="ddtabmenufiles/ddcolortabs_First.css" />

<script type="text/javascript">
//SYNTAX: ddtabmenu.definemenu("tab_menu_id", integer OR "auto")
ddtabmenu.definemenu("ddtabs1", 0) //initialize Tab Menu #1 with 1st tab selected
ddtabmenu.definemenu("ddtabs2", 1) //initialize Tab Menu #2 with 2nd tab selected
ddtabmenu.definemenu("ddtabs3", 1) //initialize Tab Menu #3 with 2nd tab selected
ddtabmenu.definemenu("ddtabs4", 2) //initialize Tab Menu #4 with 3rd tab selected
ddtabmenu.definemenu("ddtabs5", -1) //initialize Tab Menu #5 with NO tabs selected (-1)

</script>
    
    <style type="text/css">
        
        .style12
        {
            width: 100%;
        }
         .style13
        {
            width: 99%;
        }
    
        </style>
    
</head>
<body>
    <form id="form1" runat="server">
    
        
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="vertical-align: top; text-align: left">
               
               <table style="border: 1px solid #EEEEEE; width: 100%; background-color: #ffffff; padding-top: 0px; margin-top: 0px;">
            <tr>
                <td style="border-right: thin solid #ebf3ff; background-color: #ebf3ff; padding-right: 0px; margin-right: 0px; height: 15px;" 
                    colspan="2">
                    
                </td>
            </tr>
            <tr>
                <td style="width: 1%">
                </td>
                <td style="width: 99%">
                    <img alt="" src="Images/header3.png" style="width: 340px; height: 52px" /></td>
            </tr>
            <tr>
                <td style="width: 1%">
                </td>
                <td style="width: 99%">
                
  <div id="ddtabs5" class="ddcolortabs">
<ul>

<li><a href="#" rel="ct1"><span>BUDGETING</span></a>

</li>

<li><a href="#" rel="ct2"><span>PLANNING</span></a>

</li>

<li><a href="#" rel="ct3"><span>REQUISITIONING</span></a>

</li>

<li><a href="#" rel="ct5"><span>BIDDING</span></a>

</li>
<li><a href="#" rel="ct6"><span>EVALUATION</span></a>

</li>
	
<li><a href="#" rel="ct7"><span style="color: #617da6">CONTRACT MANAGEMENT</span></a>

</li>

</ul>
</div>

<div class="ddcolortabsline">&nbsp;</div>
                </td>
            </tr>
            <tr>
                <td style="width: 1%">
                    &nbsp;</td>
                <td style="width: 99%; text-align: center; vertical-align: middle;">
                    <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" 
                        ForeColor="Red" Text="."></asp:Label>
                            </td>
            </tr>
            <tr>
                <td style="width: 1%">
                    &nbsp;</td>
                <td style="width: 99%">
                    <table align="left" class="style13" style="border-right: #617da6 1px solid; padding-right: 3px;
                        border-top: #617da6 1px solid; padding-left: 3px; padding-bottom: 3px; margin: 3px;
                        border-left: #617da6 1px solid; padding-top: 3px; border-bottom: #617da6 1px solid;
                        height: 300px">
                        <tr>
                            <td style="vertical-align: top; text-align: center">
                                <br />
                                <table style="width: 100%">
                                    <tr>
                                        <td style="vertical-align: top; text-align: center">
                                            <UpdatePanel ID="UpdatePanel1" runat="server">
                                                
                                <table align="center" cellpadding="0" cellspacing="0" style="width: 35%">
                                    <tr>
                                        <td style="text-align: center; vertical-align: top;" colspan="3">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td class="InterfaceHeaderLabel">
                                                        CHANGE
                                                        System SETTINGS</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 2px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="InterFaceTableLeftRow" style="width: 29%; height: 30px">
                                            Area</td>
                                        <td class="InterFaceTableMiddleRow" style="width: 1%; height: 30px">
                                        </td>
                                        <td class="InterFaceTableRightRow" style="width: 50%; height: 30px; text-align: center">
                                            <asp:DropDownList ID="cboAreas" runat="server" Width="80%" OnDataBound="cboModules_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="InterFaceTableLeftRow" style="width: 29%; height: 30px;">
                                            Cost Center</td>
                                        <td class="InterFaceTableMiddleRow" style="width: 1%; height: 30px;">
                                            &nbsp;</td>
                                        <td class="InterFaceTableRightRow" style="width: 50%; height: 30px; text-align: center;">
                                            &nbsp;<asp:DropDownList ID="cboCostCenters" runat="server" Width="80%" OnDataBound="cboCostCenters_DataBound">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="InterFaceTableLeftRow" style="width: 29%; height: 30px">
                                            Module</td>
                                        <td class="InterFaceTableMiddleRow" style="width: 1%; height: 30px">
                                        </td>
                                        <td class="InterFaceTableRightRow" style="width: 50%; height: 30px; text-align: center">
                                            <asp:DropDownList ID="cboModule" runat="server" Width="80%" OnDataBound="cboModule_DataBound" >
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="InterFaceTableLeftRow" style="width: 29%; height: 30px">
                                            Financial Year</td>
                                        <td class="InterFaceTableMiddleRow" style="width: 1%; height: 30px">
                                        </td>
                                        <td class="InterFaceTableRightRow" style="width: 50%; height: 30px; text-align: center;">
                                            <asp:DropDownList ID="cboFinancialYear" runat="server" Width="80%" OnDataBound="cboFinancialYear_DataBound" >
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 29%; height: 21px;">
                                            &nbsp;</td>
                                        <td style="width: 1%; height: 21px;">
                                            &nbsp;</td>
                                        <td style="width: 50%; text-align: left; vertical-align: middle; height: 21px;">
                            <asp:Button ID="Btnlogin" runat="server" Font-Size="9pt" Height="23px" Text="OK" 
                                Width="80px" onclick="Btnlogin_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Font-Size="9pt" Height="23px" Text="Cancel" 
                                Width="80px" onclick="btnCancel_Click" /></td>
                                    </tr>
                                    </table>
                                                </ContentTemplate>
                                            </UpdatePanel>
                                                </td>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            </table>
               
               &nbsp;</td>
        </tr>
        <tr>
            <td style="font-family: Tahoma; font-size: 13px; vertical-align: top; text-align: center; background-color: #EEEEEE;">
                <div id="copyinfo" style="padding: 10px 0pt 20px;">© 2010, National Water and Sewerage Corporation |&nbsp; Powered by <a href="#">The Software Development Section</a></div>
                </td>
        </tr>
    </table>

    </form>
</body>
</html>
