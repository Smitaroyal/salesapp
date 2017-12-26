<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeFile="IndiaCreateProfile.aspx.cs" Inherits="_Default" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
       <style>
           #hrf{
               color:#C0C0C0;

           }
          
       </style>
    
    

      
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Contracts Application</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
       <%--<link rel="stylesheet" href="/resources/demos/style.css">--%>
   
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

    
           function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

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
   <!-- <li><a href="#tabs-2">Contracts</a></li>
    <li><a href="#tabs-3">Finance Data</a></li>-->
  </ul>
    
       
  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
      <form id="form1" runat="server">
        
       <div style="background-color:#e9e9e9; padding-top:10px; padding-left:5px; padding-right:5px;">
        <h3>PROFILE</h3>
        <hr />
          
           <table style="width:100%;">
               <tbody>
               <tr>
                   <td><asp:Label ID="Label1" runat="server" Font-Size="Medium"  Text="Profile ID" ></asp:Label></td>
                   <td><asp:TextBox ID="ProfileIDTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Label">Date Insert</asp:Label></td>
                   <td><asp:TextBox ID="createddateTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="False"></asp:TextBox></td>
                   <td><asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Label">Created By</asp:Label></td>
                   <td><asp:TextBox ID="CreatedByTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label7" runat="server" Text="Marketing Program"  Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="MarketingPrgmDropDownList" runat="server" Font-Size="small" style="width:170px; height:25px" OnSelectedIndexChanged="MarketingPrgmDropDownList_SelectedIndexChanged" Height="16px" Width="178px"></asp:DropDownList></td>
                   
               </tr>
                   
               <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Venue Country" Font-Size="Medium"></asp:Label></td>
                    <td><asp:DropDownList ID="VenueCountryDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px" OnSelectedIndexChanged="VenueCountryDropDownList_SelectedIndexChanged" Height="24px" Width="148px"></asp:DropDownList></td>
                    <td><asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Venue" ></asp:Label></td>
                    <td><asp:DropDownList ID="VenueDropDownList"  Font-Size="Small" runat="server" style="width:175px; height:25px" OnSelectedIndexChanged="VenueDropDownList_SelectedIndexChanged" Height="21px" Width="142px"></asp:DropDownList></td>
                    <td><asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Group Venue" ></asp:Label></td>
                    <td><asp:DropDownList ID="GroupVenueDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px" OnSelectedIndexChanged="GroupVenueDropDownList_SelectedIndexChanged" Height="21px" Width="149px"></asp:DropDownList></td>
               </tr>

               <tr>
                   <td><asp:Label ID="Label8" runat="server" Text="Agents" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="AgentsDropDownList" runat="server" Font-Size="Small" style="width:175px; height:25px"></asp:DropDownList></td>
                   <td><asp:Label ID="Label9" runat="server" Text="TO Name" BorderStyle="None"></asp:Label></td>
                   <td><asp:DropDownList ID="TONameDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px"></asp:DropDownList></td>
                   <td><asp:Label ID="Label72" runat="server" Text="Manager"></asp:Label></td>
                   <td><asp:DropDownList ID="ManagerDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px"></asp:DropDownList></td>
                   
               </tr>
                   <tr>
                       <td> <input id="chs" type="checkbox" onclick="shows();"/> <asp:Label ID="Label10" runat="server" Font-Size="Medium" Text="Label">Are you a Member?</asp:Label></td>

                   </tr>
            </tbody>
           </table>

           <table style="width:100%;">
           <tbody id="hidden1">
              <tr>
                  <td><asp:Label ID="Label11" runat="server" Font-Size="Medium" Text="Label">Choose Member Type</asp:Label></td>
                  <td><asp:DropDownList ID="MemType1DropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label15" runat="server" Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                  <td><asp:TextBox ID="Memno1TextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label12" runat="server" Font-Size="Medium" Text="Label">Choose Member Type</asp:Label></td>
                  <td><asp:DropDownList ID="MemType2DropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label16" runat="server" Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                  <td><asp:TextBox ID="Memno2TextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
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
              <tr>
                    <td><asp:Label ID="Label90" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                  <td ><asp:DropDownList ID="primarytitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label13" runat="server" Font-Size="Medium" Text="Label">First Name</asp:Label></td>
                  <td><asp:TextBox ID="pfnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label14" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                  <td><asp:TextBox ID="plnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label17" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                  <td><asp:TextBox ID="pdobdatepicker" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
              </tr>
              <tr>
                   <td></td>
                  <td></td>
                  <td> <asp:Label ID="Label18" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                  <td><asp:DropDownList ID="primarynationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label19" runat="server" Font-Size="Medium"  Text="Label">Country</asp:Label></td>
                  <td><asp:DropDownList ID="PrimaryCountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="PrimaryCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                   <td><asp:Label ID="Label70" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                  <td><asp:TextBox ID="primaryAge" runat="server" Font-Size="Small" Enabled="True" style="width:170px; height:20px"></asp:TextBox></td>
              </tr>
              <tr>
                   <td></td>
                   <td></td>
                  <td><asp:Label ID="Label21" runat="server" Font-Size="Medium" Text="Mobile #"></asp:Label></td>
                  <td><asp:DropDownList ID="primarymobileDropDownList" Font-Size="Small" runat="server" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="pmobileTextBox" Font-Size="Small" style="width:95px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label22" runat="server" Font-Size="Medium" Text="Alternate #"></asp:Label></td>
                  <td><asp:DropDownList ID="primaryalternateDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="palternateTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label20" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                  <td><asp:TextBox ID="pemailTextBox" runat="server" Font-Size="Small" Enabled="True" style="width:170px; height:20px"></asp:TextBox></td>
              </tr>
              <tr>
                  
                  <td></td>
                  <td></td>
                  <td><asp:Label ID="Label85" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" name="primarylang" id="primarylang">
                              <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="Kannada">Kannada</option>
                              <option value="Malayam">Malayam</option>
                              <option value="Tamil">Tamil</option>
                              <option value="Telegu">Telegu</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>

             
          </table>
        <br />
         </div>
     
         
        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                         <td><asp:Label ID="Label73" runat="server" Font-Size="Medium"  Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="secondarytitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label23" runat="server" Font-Size="Medium" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sfnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label24" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="slnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label25" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sdobdatepicker" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>

                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label26" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="secondarynationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label27" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="SecondaryCountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="SecondaryCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                         
                         <td><asp:Label ID="Label77" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="secondaryAge" runat="server" Font-Size="Small" Enabled="True" style="width:170px; height:20px"></asp:TextBox></td>
                    </tr>

                    <tr>
                         <td></td>
                         <td></td>
                         <td><asp:Label ID="Label29" runat="server" Font-Size="Medium" Text="Mobile #"></asp:Label></td>
                         <td><asp:DropDownList ID="secondarymobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="smobileTextBox" runat="server" style="width:95px; height:20px" Font-Size="Medium" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label30" runat="server" Font-Size="Medium"  Text="Alternate #"></asp:Label></td>
                         <td><asp:DropDownList ID="secondaryalternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="salternateTextBox" Font-Size="Small" style="width:95px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label28" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="semailTextBox" runat="server" Font-Size="Small" style="width:170px; height:25px" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                  <td></td>
                  <td></td>
                  <td><asp:Label ID="Label88" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                         <td><select multiple="multiple" style="width:175px; height:70px" name="seclang">
                             <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="Kannada">Kannada</option>
                              <option value="Malayam">Malayam</option>
                              <option value="Tamil">Tamil</option>
                              <option value="Telegu">Telegu</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
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
                      <td><asp:Label ID="Label31" runat="server" Font-Size="Medium" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address1TextBox" runat="server" Font-Size="Small" style="height:25px" Enabled="True" Width="250px"></asp:TextBox></td>
                      <td><asp:Label ID="Label32" runat="server" Font-Size="Medium" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address2TextBox" runat="server" Font-Size="Small" style="height:25px" Enabled="True" Width="220px"></asp:TextBox></td>
                      <td><asp:Label ID="Label61" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="AddCountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>

                  </tr>

                  <tr>
                      <td><asp:Label ID="Label33" runat="server" Font-Size="Medium" Text="Label">State</asp:Label></td>
                      <td><asp:TextBox ID="stateTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label34" runat="server" Font-Size="Medium" Text="Label">City</asp:Label></td>
                      <td><asp:TextBox ID="cityTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label39" runat="server"  Font-Size="Medium" Text="Label">Pincode</asp:Label></td>
                      <td><asp:TextBox ID="pincodeTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                  </tr>

                 
     
              </tbody>
          </table>
    </div>

          <div style="padding-top: 10px; padding-left: 5px; padding-right: 5px;">
              <h3>OTHER DETAILS</h3>
              <hr />
              <br />
              <table style="width: 100%;">
                  <tbody>
                       <tr>
                      <td><asp:Label ID="Label40" runat="server" Font-Size="Medium" Text="Label">Employee Status</asp:Label></td>
                      <td><asp:DropDownList ID="employmentstatusDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label35" runat="server" Font-Size="Medium" Text="Label">Marital Status</asp:Label></td>
                      <td><asp:DropDownList ID="MaritalStatusDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label41" runat="server" Font-Size="Medium" Text="Label">No of Year living together as a couple</asp:Label></td>
                      <td><asp:TextBox ID="livingyrsTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>

                  <tr>
                      <td><asp:Label ID="Label80" runat="server" Font-Size="Medium" Text="Label">Professional/Designation :</asp:Label></td>
                      <td></td>
                      <td><asp:Label ID="Label81" runat="server" Font-Size="Medium" Text="Label">Male</asp:Label></td>
                      <td><asp:TextBox ID="maledesgTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label82" runat="server" Font-Size="Medium" Text="Label">Female</asp:Label></td>
                      <td><asp:TextBox ID="femaledesgTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>
                  <tr>
                    <td><asp:Label ID="Label83" runat="server" Font-Size="Medium" Text="Label">Photo Identity:</asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" name="pidentity">
                       <option value="Membership Card">Membership Card(if member with any club)</option>
                          <option value="Driving License">Driving License</option>
                          <option value="Pan Card">PAN Card</option>
                          <option value="Passport">Passport</option>
                          <option value="Others">Others</option>
                        </select></td>
                    <td><asp:Label ID="Label84" runat="server" Font-Size="Medium" Text="Label">Kind Of Card:</asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" name="card">
                        <option value="T1">Titanium</option>
                        <option value="Platinum">Platinum</option>
                        <option value="Gold">Gold</option>
                        <option value="Silver">Silver</option>
                        <option value="Visa">Visa</option>
                        <option value="Mastercard">Mastercard</option>
                        <option value="Debit Card">Debit Card</option>
                        <option value="Others">Others</option>

                        </select></td>

                  </tr>


                  </tbody>

              </table>


          </div><br>
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs2" type="checkbox" onclick="shows2();"/>
 <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                         <td><asp:Label ID="Label75" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label36" runat="server" Font-Size="Medium" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp1fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label37" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp1lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label38" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sp1dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label42" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label43" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="SubProfile1CountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="SubProfile1CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                      <td><asp:Label ID="Label78" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                        <td><asp:TextBox ID="subProfile1Age" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label45" runat="server" Font-Size="Medium" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1mobileTextBox" runat="server" style="width:95px;  height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label46" runat="server" Font-Size="Medium" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1alternateTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                          <td><asp:Label ID="Label44" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp1emailTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
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
                         <td><asp:Label ID="Label76" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2titleDropDownList" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label47" runat="server" Font-Size="Medium"  Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp2fnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label48" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp2lnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label49" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sp2dobdatepicker" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label50" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2nationalityDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label51" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="SubProfile2CountryDropDownList" runat="server" style="width:175px; height:25px" Font-Size="Small"  OnSelectedIndexChanged="SubProfile2CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:Label ID="Label79" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                        <td><asp:TextBox ID="subProfile2Age" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label53" runat="server" Font-Size="Medium" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2mobileDropDownList" style="width:70px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2mobileTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label54" runat="server" Font-Size="Medium" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2alternateTextBox" Font-Size="Small" runat="server" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label52" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp2emailTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                          </tr>

                </tbody>
            </table>   
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
                        <td><asp:Label ID="Label55" runat="server" Font-Size="Medium" Text="Label">Resort Name</asp:Label></td>
                        <td><asp:TextBox ID="hotelTextBox" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label56" runat="server" Font-Size="Medium" Text="Label">Resort Room No</asp:Label></td>
                        <td><asp:TextBox ID="roomnoTextBox" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label57" runat="server" Font-Size="Medium" Text="Label">Arrival-Date</asp:Label></td>
                        <td><asp:TextBox ID="checkindatedatepicker" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label58" runat="server" Font-Size="Medium" Text="Label">Departure-Date</asp:Label></td>
                        <td><asp:TextBox ID="checkoutdatedatepicker" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label59" runat="server" Font-Size="Medium" Text="Choose Gift Option"  BorderStyle="None" ></asp:Label></td>
                        <td><asp:ListBox ID="giftListBox" runat="server" Font-Size="Small" Height="100px" SelectionMode="Multiple" Width="155px" ></asp:ListBox></td>
                        <td><asp:Label ID="Label60" runat="server" Font-Size="Medium" Text="Label">Voucher No.</asp:Label></td>
                        <td><asp:TextBox ID="vouchernoTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label74" runat="server" Font-Size="Medium" Text="Comment"></asp:Label></td>
                        <td><asp:TextBox ID="commentTextBox" runat="server" Font-Size="Small" Enabled="True" TextMode="MultiLine" Height="60px" Width="150px"></asp:TextBox></td>
                        <td><asp:Label ID="Label62" runat="server" Font-Size="Medium" Text="Label">Guest Status</asp:Label></td>
                        <td><asp:DropDownList ID="gueststatusDropDownList" Font-Size="Small" style="width:150px; height:25px" runat="server"></asp:DropDownList></td>

                    </tr>

                    <tr>
                        <td><asp:Label ID="Label71" runat="server" Font-Size="Medium" Text="Tour Date"></asp:Label></td>
                        <td><asp:TextBox ID="tourdatedatepicker" Font-Size="Small" style="width:150px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label63" runat="server" Font-Size="Medium" Text="Sales Rep"></asp:Label></td>
                        <td><asp:DropDownList ID="salesrepDropDownList" Font-Size="Small" style="width:155px; height:25px;" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label64" runat="server" Font-Size="Medium"  Text="Check-In Time" BorderStyle="None" ></asp:Label></td>
                        <td><asp:TextBox ID="deckcheckintimeTextBox" Font-Size="Small" placeholder="HH:MM" style="width:150px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label65" runat="server" Font-Size="Medium" Text="Check-Out Time" BorderStyle="None" ></asp:Label></td>
                        <td><asp:TextBox ID="deckcheckouttimeTextBox" Font-Size="Small" placeholder="HH:MM" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td><asp:Label ID="Label66" runat="server" Font-Size="Medium" Text="Taxi in Price" BorderStyle="None"></asp:Label></td>
                        <td><asp:TextBox ID="taxipriceInTextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label67" runat="server" Font-Size="Medium" Text="Taxi in Reference" BorderStyle="None"></asp:Label></td>
                        <td><asp:TextBox ID="TaxiRefInTextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label68" runat="server" Font-Size="Medium" Text="Label">Taxi out Price</asp:Label></td>
                        <td><asp:TextBox ID="TaxiPriceOutTextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label69" runat="server" Font-Size="Medium" Text="Label">Taxi out Reference</asp:Label></td>
                        <td><asp:TextBox ID="TaxiRefOutTextBox" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>

                    </tr>
                   
                </tbody>
            </table>
             <table style="width:59%;">

                    <tr>
                          <td><asp:Label ID="Label86" runat="server" Font-Size="Medium" Text="Comments" BorderStyle="None"></asp:Label></td>
                          <td><asp:TextBox ID="commentsTextBox"  runat="server" style="width:300px; height:120px" TextMode="MultiLine"></asp:TextBox></td>

                    </tr>

               </table>
        <br />
        <br />
        </div>
          

    
          <%--<asp:Label ID="Label70" runat="server" Text="Label"></asp:Label>--%>
          
    
          <br />

         <center><asp:Button ID="Button1"  runat="server"  autopostback="true" OnClick="Button1_Click" Text="Create Profile" /></center> <br />
          
          
    
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
            $("#VenueCountryDropDownList").change(function ()
            {
                var value = $("#VenueCountryDropDownList").val();
             
                $.ajax({
                    
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadVenueOnVenueCountry',
                    data: "{'venuecountry':'" + value + "'}",
                    async: false,
                    success: function (data) {
                       // alert(data.d);
                        $("#VenueDropDownList").empty();
                        $("#VenueDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                      //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                               // $("#adminfeeTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                                $("#VenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }
                    


                });
                return false;
                
            });
 


        });
    </script>
    <script>
        $(document).ready(function () {
            $("#VenueDropDownList").change(function () {
                var value = $("#VenueDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadGroupVenueOnVenue',
                    data: "{'venue':'" + value + "'}",
                    async: false,
                    success: function (data) {
                       //  alert(data.d);
                         $("#GroupVenueDropDownList").empty();
                         $("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                       // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                
                            $("#GroupVenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                //get sales rep name
                var v = document.getElementById("VenueCountryDropDownList");
                var vcountry = v.options[v.selectedIndex].text;
               
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadSalesRepOnVenue',
                    data: "{'venue':'" + value + "','country':'"+vcountry+"'}",
                    async: false,
                    success: function (data) {
                       // alert(data.d);
                        $("#salesrepDropDownList").empty();
                        $("#salesrepDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                       // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#salesrepDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
               
                //agents
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAgents',
                    data: "{'venue':'"+value+"'}",
                    async: false,
                    success: function (data) {
                       /// alert(data.d);
                        $("#AgentsDropDownList").empty();
                        $("#AgentsDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                     //   alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#AgentsDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                //to amnagers
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadTO',
                    data: "{'venue':'" + value + "'}",
                    async: false,
                    success: function (data) {
                      //  alert(data.d);
                        $("#TONameDropDownList").empty();
                        $("#TONameDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                       // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#TONameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                //to venue mgrs
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadManagersOnVenue',
                    data: "{'venue':'" + value + "'}",
                    async: false,
                    success: function (data) {
                     //   alert(data.d);
                        $("#ManagerDropDownList").empty();
                        $("#ManagerDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

//alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#ManagerDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;

            });



        });
    </script>

    <script>
        //    mktg prgm
        $(document).ready(function () {
            $("#GroupVenueDropDownList").change(function () {
                var value = $("#GroupVenueDropDownList").val();
                var v1 = document.getElementById("VenueDropDownList");
                var venue = v1.options[v1.selectedIndex].text;
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadMktgOnVenuenVenueGrp',
            data: "{'venue':'" + venue + "','venuegrp':'" + value + "'}",
            async: false,
            success: function (data) {
                // alert(data.d);
                $("#MarketingPrgmDropDownList").empty();
                $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#MarketingPrgmDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });

        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadAgentsOnVenuegrp',
            data: "{'venue':'" + venue + "','vgrp':'" + value + "'}",
            async: false,
            success: function (data) {
                // alert(data.d);
                $("#AgentsDropDownList").empty();
                $("#AgentsDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#AgentsDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadTOOnVenueNVGrp',
            data: "{'venue':'" + venue + "','vgrp':'" + value + "'}",
            async: false,
            success: function (data) {
                // alert(data.d);
                $("#TONameDropDownList").empty();
                $("#TONameDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#TONameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });
       
            });
        });
    </script>

    <script>
      //country code
        $(document).ready(function () {
            $("#PrimaryCountryDropDownList").change(function () {
                var value = $("#PrimaryCountryDropDownList").val();
              
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadCountryCode',
            data: "{'country':'" + value + "'}",
            async: false,
            success: function (data) {
             
                $("#primarymobileDropDownList").empty();
              //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });
            });

            $("#PrimaryCountryDropDownList").change(function () {
                var value = $("#PrimaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#primaryalternateDropDownList").empty();
                        $("#primaryalternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });


            //secondary

            $("#SecondaryCountryDropDownList").change(function () {
                var value = $("#SecondaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#secondarymobileDropDownList").empty();
                        //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#SecondaryCountryDropDownList").change(function () {
                var value = $("#SecondaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#secondaryalternateDropDownList").empty();
                        $("#secondaryalternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            //subprofile1

            $("#SubProfile1CountryDropDownList").change(function () {
                var value = $("#SubProfile1CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile1mobileDropDownList").empty();
                        //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#SubProfile1CountryDropDownList").change(function () {
                var value = $("#SubProfile1CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile1alternateDropDownList").empty();
                        $("#subprofile1alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            //subprofile2

            $("#SubProfile2CountryDropDownList").change(function () {
                var value = $("#SubProfile2CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile2mobileDropDownList").empty();
                        //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#SubProfile2CountryDropDownList").change(function () {
                var value = $("#SubProfile2CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile2alternateDropDownList").empty();
                        $("#subprofile2alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

        });
    </script>
 
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

    <script>
        $(document).ready(function () {
            $("#pdobdatepicker").change(function () {
                
                var date = $("#pdobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#primaryAge').val(age);
            });
        });

    </script>

    <script>
        $(document).ready(function () {
            $("#sdobdatepicker").change(function () {
                var date = $("#sdobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#secondaryAge').val(age);
            });



        });
    </script>

     <script>
        $(document).ready(function () {
            $("#sp1dobdatepicker").change(function () {
                var date = $("#sp1dobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile1Age').val(age);
            });



        });
    </script>

    <script>
        $(document).ready(function () {
            $("#sp2dobdatepicker").change(function () {
                var date = $("#sp2dobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile2Age').val(age);
            });



        });
    </script>

    <script>
        $(document).ready(function () {
            $("#Button1").click(function (e) {
                var isValid = true;
                if ($.trim($("#MarketingPrgmDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Marketing Program");
                    $("#MarketingPrgmDropDownList").css({
                   
                        "border": "1px solid red",
                       
                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();
          
                       
                } else {
                    $("#MarketingPrgmDropDownList").css({
                      
                        "border": "",
                     
                        "background": ""
               
                });
                   // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#VenueCountryDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Venue Country ");
                    $("#VenueCountryDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#VenueCountryDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                   // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
               
                var isValid = true;
                if ($.trim($("#VenueDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Venue  ");
                    $("#VenueDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#VenueDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#GroupVenueDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Venue Group");
                    $("#GroupVenueDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#GroupVenueDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#AgentsDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Agent");
                    $("#AgentsDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#AgentsDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#TONameDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select TO Name");
                    $("#TONameDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#TONameDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#ManagerDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Manager");
                    $("#ManagerDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#ManagerDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
                   
                //primary profile

                var isValid = true;
                if ($.trim($("#primarytitleDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Title");
                    $("#primarytitleDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primarytitleDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#pfnameTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter First Name");
                    $("#pfnameTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pfnameTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
                var isValid = true;
                if ($.trim($("#plnameTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter Last Name");
                    $("#plnameTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#plnameTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
                var isValid = true;
                if ($.trim($("#pdobdatepicker").val()) == '') {
                    isValid = false;
                    alert("Select Date Of Birth");
                    $("#pdobdatepicker").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pdobdatepicker").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#primarynationalityDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Nationality");
                    $("#primarynationalityDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primarynationalityDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#PrimaryCountryDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Country");
                    $("#PrimaryCountryDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#PrimaryCountryDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#primaryAge").val()) == '') {
                    isValid = false;
                    alert("Enter Age");
                    $("#primaryAge").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primaryAge").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#primarymobileDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Country Code");
                    $("#primarymobileDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primarymobileDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#pmobileTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter Mobile Number");
                    $("#pmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pmobileTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                //var isValid = true;
                //if ($.trim($("#primaryalternateDropDownList").val()) == '') {
                //    isValid = false;
                //    alert("Select Country Code");
                //    $("#primaryalternateDropDownList").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#primaryalternateDropDownList").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

                ////////
                //var isValid = true;
                //if ($.trim($("#palternateTextBox").val()) == '') {
                //    isValid = false;
                //    alert("Enter Mobile Number");
                //    $("#palternateTextBox").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#palternateTextBox").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}



                var isValid = true;
                if ($.trim($("#pemailTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter Email");
                    $("#pemailTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pemailTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#primarylang").val()) == '') {
                    isValid = false;
                    alert("Select Language");
                    $("#primarylang").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primarylang").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                ////// Stay Details/////

                var isValid = true;
                if ($.trim($("#hotelTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter Resort Name");
                    $("#hotelTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#hotelTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#roomnoTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter Resort Room Number");
                    $("#roomnoTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#roomnoTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#checkindatedatepicker").val()) == '') {
                    isValid = false;
                    alert("Enter Arrival-Date");
                    $("#checkindatedatepicker").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#checkindatedatepicker").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#checkoutdatedatepicker").val()) == '') {
                    isValid = false;
                    alert("Enter Depature-Date");
                    $("#checkoutdatedatepicker").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#checkoutdatedatepicker").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
   

                var isValid = true;
                if ($.trim($("#gueststatusDropDownList").val()) == '') {
                    isValid = false;
                    alert("Enter Guest Status");
                    $("#gueststatusDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#gueststatusDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#tourdatedatepicker").val()) == '') {
                    isValid = false;
                    alert("Enter Tour Date");
                    $("#tourdatedatepicker").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#tourdatedatepicker").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#salesrepDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Sales Rep");
                    $("#salesrepDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#salesrepDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#deckcheckintimeTextBox").val()) == '') {
                    isValid = false;
                    alert("Select Check-In-Date");
                    $("#deckcheckintimeTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#deckcheckintimeTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#deckcheckouttimeTextBox").val()) == '') {
                    isValid = false;
                    alert("Select Check-Out Time");
                    $("#deckcheckouttimeTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#deckcheckouttimeTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

            });

        });



        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
       
        
    </script>

</body>

</html>
