<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndiaEdit Profile.aspx.cs" Inherits="_Default" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Edit Profile</title>

       <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
    $( "#tabs" ).tabs();
  });

  $(function () {
      $("#pdobdatepicker,#sdobdatepicker,#sp1dobdatepicker,#sp2dobdatepicker,#checkindatedatepicker,#checkoutdatedatepicker,#tourdatedatepicker").datepicker({
          changeMonth: true,
          changeYear: true,
          yearRange: "-100:+0",
          dateFormat: 'yy-mm-dd'
          
      });
  });

  $("#btn").on('click', function () {
      $("#tabs").fetchTabID('2');
  });

  </script>
       <script type="text/javascript">

           function shows() {
              var checkbox1 = document.getElementById('chs');
             if (checkbox1.checked) {
               document.getElementById("hidden").style.display = "block";
               }
               else {
                   document.getElementById("hidden").style.display = "none";
                    }

           }



           
           function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

           }

       </script>

<script type="text/javascript">


    function shows2() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs2');
        
        if (checkbox2.checked) {

            document.getElementById("panel").style.display = "block";

        }
        else {
            document.getElementById("panel").style.display = "none";

        }

    }

    function shows3() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs3');

        if (checkbox2.checked) {

            document.getElementById("panel2").style.display = "block";

        }
        else {
            document.getElementById("panel2").style.display = "none";

        }

    }
    
</script>

        <style type="text/css">
    
    #panel,#chs2,#chs3,#panel2 {
        display: none;
    }
    #TextBox22 {
        vertical-align: top;
    }
   

     #myBtn {
  display: block;
  position: fixed;
  bottom: 20px;
  right: 30px;
  z-index: 99;

  border: none;
  outline: none;
  background-color: #555;
  color: white;
  cursor: pointer;
  padding: 15px;
  border-radius: 10px;
}

#myBtn:hover {
  background-color: #555;
}

    
   
</style>

</head>
<body>
 
<div id="tabs">
<button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
  <ul>
    <li><a href="#tabs-1">Profile</a></li>
  <%--  <li><a href="#tabs-2">Contracts</a></li>
    <li><a href="#tabs-3">Finance Data</a></li>--%>
  </ul>
    
        
  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
      <form id="form1" runat="server">
        
       <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;" >
        <h3>PROFILE</h3>
        <hr />
           <table style="width:100%;">
               <tr>
                   <td><asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Label">Profile ID</asp:Label></td>
                   <td><asp:TextBox ID="ProfileIDTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True" ReadOnly="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Created Date"></asp:Label></td>
                   <td><asp:TextBox ID="createddateTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label3" runat="server" Text="Label">Created By</asp:Label></td>
                   <td><asp:TextBox ID="CreatedByTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True" ReadOnly="True"></asp:TextBox></td>
                   <td> <asp:Label ID="Label7" runat="server" Text="Label">Marketing Program</asp:Label></td>
                   <td> <asp:DropDownList ID="MarketingPrgmDropDownList" Font-Size="Small"  style="width:175px; height:25px"  runat="server"></asp:DropDownList></td>
               </tr>

               <tr>
               <td><asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Label">Venue Country</asp:Label></td>
               <td><asp:DropDownList ID="VenueCountryDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="VenueCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
               <td><asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Label">Venue</asp:Label></td>
               <td><asp:DropDownList ID="VenueDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="VenueDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
               <td><asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Label">Group Venue</asp:Label></td>
               <td><asp:DropDownList ID="GroupVenueDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="GroupVenueDropDownList_SelectedIndexChanged"></asp:DropDownList></td>

               </tr>
               <tr>
                   <td><asp:Label ID="Label8" runat="server" Font-Size="Medium" Text="Label">Agents</asp:Label></td>
                   <td><asp:DropDownList ID="AgentsDropDownList" Font-Size="Small"  runat="server" style="width:175px; height:25px"><asp:ListItem></asp:ListItem></asp:DropDownList></td>
                   <td><asp:Label ID="Label9" runat="server" Font-Size="Medium" Text="TO"></asp:Label></td>
                   <td><asp:DropDownList ID="TonameDropDownList" Font-Size="Small"  runat="server" style="width:175px; height:25px"><asp:ListItem></asp:ListItem></asp:DropDownList></td>
                   <td><asp:Label ID="Label72" runat="server" Font-Size="Medium" Text="Manager"></asp:Label></td>
                   <td><asp:DropDownList ID="mgrDropDownList" Font-Size="Small"  runat="server" style="width:175px; height:25px"><asp:ListItem></asp:ListItem></asp:DropDownList></td>

               </tr>

               <tr>
               <td><input id="chs" type="checkbox" onclick="shows();"/>
               <asp:Label ID="Label10" runat="server" Text="Label">Are you a Member?</asp:Label></td>

               </tr>
           </table>
        <br />
               <table style="width:100%;">
               <tbody id ="hidden1">
                   <tr>
                     <td> <asp:Label ID="Label11" runat="server"  Font-Size="Medium" Text="Label">Choose Member Type</asp:Label></td>
                     <td><asp:DropDownList ID="MemType1DropDownList" Font-Size="Small"  style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                     <td> <asp:Label ID="Label15" runat="server"   Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                     <td><asp:TextBox ID="Memno1TextBox" runat="server" Font-Size="Small"   style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                     <td><asp:Label ID="Label12" runat="server"  Font-Size="Medium" Text="Label">Choose Member Type</asp:Label></td>
                     <td><asp:DropDownList ID="MemType2DropDownList" Font-Size="Small"  style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                     <td><asp:Label ID="Label16" runat="server"  Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                      <td> <asp:TextBox ID="Memno2TextBox" Font-Size="Small"  runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                   </tr>
               </tbody>
              
           </table>
        <br />
        </div>
        
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PRIMARY PROFILE</h3>
        <hr />
        <br />
          <table style="width:100%;">
              <tbody>
                  <tr>

                      <td><asp:DropDownList ID="primarytitleDropDownList" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label13" runat="server" Text="Label">First Name</asp:Label></td>
                      <td><asp:TextBox ID="pfnameTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label14" runat="server" Text="Label">Last Name</asp:Label></td>
                      <td><asp:TextBox ID="plnameTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label17" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                      <td><asp:TextBox ID="pdobdatepicker" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td></td>
                      <td><asp:Label ID="Label18" runat="server" Text="Label">Nationality</asp:Label></td>
                      <td><asp:DropDownList ID="primarynationalityDropDownList" style="width:175px;  height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label19" runat="server" Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="PrimaryCountryDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PrimaryCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                      <td><asp:Label ID="Label20" runat="server" Text="Label">Email</asp:Label></td>
                      <td><asp:TextBox ID="pemailTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>

                  </tr>
                  <tr>
                      <td></td>
                      <td><asp:Label ID="Label21" runat="server" Text="Label">Mobile Number</asp:Label></td>
                      <td><asp:DropDownList ID="primarymobileDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="pmobileTextBox" Font-Size="Small"  runat="server" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label22" runat="server" Text="Label">Alternate Number</asp:Label></td>
                      <td><asp:DropDownList ID="primaryalternateDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="palternateTextBox" Font-Size="Small"  style="width:95px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                  </tr>
              </tbody>
          </table>
          <br />
        <br />
         </div>
     
         
        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:DropDownList ID="secondarytitleDropDownList" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label23" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sfnameTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label24" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="slnameTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label25" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sdobdatepicker" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="Label26" runat="server" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="secondarynationalityDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label27" runat="server" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="SecondaryCountryDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SecondaryCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:Label ID="Label28" runat="server" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="semailTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="Label29" runat="server" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="secondarymobileDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="smobileTextBox"  Font-Size="Small" runat="server" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label30" runat="server" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="secondaryalternateDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="salternateTextBox" Font-Size="Small"  style="width:95px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                    </tr>
                </tbody>
            </table>
         <br />
        <br />
        </div>
 
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>ADDRESS</h3>
        <hr />
        <br />
          <table style="width:100%;">
              <tbody>
                  <tr>
                      
                      <td><asp:Label ID="Label31" runat="server" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address1TextBox" Font-Size="Small"  runat="server" Enabled="True" Width="250px" Height="20px"></asp:TextBox></td>
                      <td><asp:Label ID="Label32" runat="server" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address2TextBox" Font-Size="Small"  runat="server" Enabled="True" Width="250px" Height="20px"></asp:TextBox></td>
                      <td><asp:Label ID="Label70" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="AddCountryDropDownList" Font-Size="Small" style="width:170px; height:25px" runat="server" ></asp:DropDownList></td>

                  </tr>
                  <tr>
                      <td><asp:Label ID="Label33" runat="server" Text="Label">State</asp:Label></td>
                       <td><asp:TextBox ID="stateTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                       <td><asp:Label ID="Label34" runat="server" Text="Label">City</asp:Label></td>
                       <td><asp:TextBox ID="cityTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                       <td><asp:Label ID="Label39" runat="server" Text="Label">Pincode</asp:Label></td>
                       <td><asp:TextBox ID="pincodeTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                     
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label40" runat="server" Text="Label">Employee Status</asp:Label></td>
                       <td><asp:DropDownList ID="employmentstatusDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label35" runat="server" Text="Label">Marital Status</asp:Label></td>
                       <td><asp:DropDownList ID="MaritalStatusDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label41" runat="server" Text="Label">No of Year living together as a couple</asp:Label></td>
                       <td><asp:TextBox ID="livingyrsTextBox" style="width:170px;  height:20px" Font-Size="Small"  runat="server"></asp:TextBox></td>
                  </tr>
              </tbody>
          </table>
       <br />
       <br />
    </div>
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
   <input id="chs2" type="checkbox" onclick="shows2();"/>
   <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
        <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:DropDownList ID="subprofile1titleDropDownList" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label36" runat="server" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp1fnameTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label37" runat="server" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp1lnameTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label38" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sp1dobdatepicker" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="Label42" runat="server"  Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1nationalityDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label43" runat="server" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="SubProfile1CountryDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SubProfile1CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:Label ID="Label44" runat="server" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp1emailTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td><asp:Label ID="Label45" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="subprofile1mobileDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1mobileTextBox" Font-Size="Small"  style="width:95px; height:20px" runat="server"  Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label46" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="subprofile1alternateDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1alternateTextBox" Font-Size="Small"  runat="server" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                         <td></td>
                         <td></td>


                    </tr>
                </tbody>
            </table>
    </div>
       <br />
     <br />
   </div>
     
     <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs3" type="checkbox" onclick="shows3();"/>
 <label for="chs3">SUB PROFILE 2</label>      
        <div id="panel2" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:DropDownList ID="subprofile2titleDropDownList" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label47" runat="server" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp2fnameTextBox" Font-Size="Small"  runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label48" runat="server" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp2lnameTextBox" Font-Size="Small"  runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label49" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                        <td> <asp:TextBox ID="sp2dobdatepicker" Font-Size="Small"  runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td><asp:Label ID="Label50" runat="server" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2nationalityDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label51" runat="server" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="SubProfile2CountryDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="SubProfile2CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:Label ID="Label52" runat="server" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp2emailTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td></td>
                        <td><asp:Label ID="Label53" runat="server" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2mobileDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2mobileTextBox" Font-Size="Small"  style="width:95px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label54" runat="server" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2alternateDropDownList" Font-Size="Small"  style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2alternateTextBox" Font-Size="Small"  style="width:95px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                    </tr>
                </tbody>
            </table >   
            </div>
         <br />
         <br />
   </div>
 
        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>STAY DETAILS</h3>
        <hr />
        <br />
        <table style="width:100%;">
            <tbody>
                <tr>
                    <td><asp:Label ID="Label55" runat="server" Text="Label">Resort Name</asp:Label></td>
                    <td><asp:TextBox ID="hotelTextBox" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label56" runat="server" Text="Label">Resort Room No</asp:Label></td>
                    <td><asp:TextBox ID="roomnoTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label57" runat="server" Text="Label">Arrival</asp:Label></td>
                    <td><asp:TextBox ID="checkindatedatepicker" Font-Size="Small"  style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label58" runat="server" Text="Label">Departure</asp:Label></td>
                    <td><asp:TextBox ID="checkoutdatedatepicker" Font-Size="Small"   style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                </tr>


                <tr>
                    <td> <asp:Label ID="Label59" runat="server" Text="Label">Choose Gift Option</asp:Label></td>
                    <td> <asp:DropDownList ID="giftoptionDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                    <td><asp:Label ID="Label60" runat="server" Text="Label">Voucher No.</asp:Label></td>
                    <td><asp:TextBox ID="vouchernoTextBox" runat="server" Font-Size="Small"  style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label61" runat="server" Text="Label">Comment if Any</asp:Label></td>
                    <td><asp:TextBox ID="commentTextBox" runat="server" Font-Size="Small"  Enabled="True" style="width:170px; height:20px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                    <td><asp:Label ID="Label62" runat="server" Text="Label">Guest Status</asp:Label></td>
                    <td><asp:DropDownList ID="gueststatusDropDownList" Font-Size="Small"  style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                </tr>
                 <tr>
                    <td><asp:Label ID="Label71" runat="server" Text="Tour Date"></asp:Label></td>
                    <td><asp:TextBox ID="tourdatedatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label63" runat="server" Text="Label">Sales Represntative</asp:Label></td>
                    <td><asp:DropDownList ID="salesrepDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label64" runat="server" Text="Label">Sales Deck Check-In Time</asp:Label></td>
                    <td><asp:TextBox ID="deckcheckintimeTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label65" runat="server" Text="Label">Sales Deck Check-Out Time</asp:Label></td>
                    <td><asp:TextBox ID="deckcheckouttimeTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label66" runat="server" Text="Label">Taxi in Price</asp:Label></td>
                     <td><asp:TextBox ID="taxipriceInTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                     <td><asp:Label ID="Label67" runat="server" Text="Label">Taxi in Reference</asp:Label></td>
                     <td><asp:TextBox ID="TaxiRefInTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                     <td><asp:Label ID="Label68" runat="server" Text="Label">Taxi out Price</asp:Label></td>
                     <td><asp:TextBox ID="TaxiPriceOutTextBox" Font-Size="Small" style="width:170px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                     <td><asp:Label ID="Label69" runat="server" Text="Label">Taxi out Reference</asp:Label></td>
                    <td><asp:TextBox ID="TaxiRefOutTextBox" Font-Size="Small" style="width:170px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                </tr>
            </tbody>
        </table>  
         <br />
        <br />
        </div>
    
          <br />
          <br />
          <center> <asp:Button ID="Button1" runat="server" Text="Update Profile" OnClick="Button1_Click" /></center>    
    </form>
</div>

  </div>

  <div id="tabs-2">

  </div>
  <div id="tabs-3">
    

  </div>
  
</div>
 <script>

        $(document).ready(function () {
            $("#hidden1").hide();
            $("#chs").click(function () {
                if ($("#chs").is(':checked')) {

                    $("#hidden1").show();
                } else {
                    $("#hidden1").hide();
                }
            });
        });


    </script>
 
</body>

</html>
