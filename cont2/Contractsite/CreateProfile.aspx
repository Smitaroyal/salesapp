﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateProfile.aspx.cs" EnableEventValidation="false"  Inherits="_Default" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
       <style>
           #hrf{
               color:#fff;

           }
       </style>
    
       

      
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Contracts Application</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
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


//for venue
  $(document).ready(function () {
      $("#VenueCountryDropDownList").change(function () {

          var id = $("#VenueCountryDropDownList").val();

         // alert(id);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateVenueDropDownList",
              data: "{'id': '" + id + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#VenueDropDownList").empty();
                  $("#VenueDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#VenueDropDownList").append($("<option></option>").val(value.VenueTypeName).html(value.VenueTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

  });


  $(document).ready(function () {
      $("#VenueDropDownList").change(function () {

          var id = $("#VenueDropDownList").val();

          var id2 = $("#VenueCountryDropDownList").val();

          //alert(id+"   "+id2);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateVenueGroupDropDownList",
              data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#GroupVenueDropDownList").empty();
                  $("#GroupVenueDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#GroupVenueDropDownList").append($("<option></option>").val(value.VenueGroupTypeName).html(value.VenueGroupTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

  });


  $(document).ready(function () {
      $("#GroupVenueDropDownList").change(function () {

          var id = $("#VenueDropDownList").val();

          var id2 = $("#VenueCountryDropDownList").val();

         // alert(id + "   " + id2);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateMrktProgDropDownList",
              data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#MarketingPrgmDropDownList").empty();
                  $("#MarketingPrgmDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#MarketingPrgmDropDownList").append($("<option></option>").val(value.MrktProgTypeName).html(value.MrktProgTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

  });



  $(document).ready(function () {
      $("#MarketingPrgmDropDownList").change(function () {
         // alert("hi");
          var id = $("#MarketingPrgmDropDownList").val();

          var id2 = $("#VenueDropDownList").val();

          var id3 = $("#VenueCountryDropDownList").val();

         // alert(id );

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateAgentDropDownList",
              data: "{'markid': '" + id + "','venueid': '" + id2 + "','countid': '"+ id3 +"'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#AgentsDropDownList").empty();
                  $("#AgentsDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#AgentsDropDownList").append($("<option></option>").val(value.AgentTypeName).html(value.AgentTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

  });


  $(document).ready(function () {
      $("#AgentsDropDownList").change(function () {
          //alert("hi");
          var id = $("#AgentsDropDownList").val();

          var id2 = $("#MarketingPrgmDropDownList").val();

         // alert(id + "   " + id2);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateAgentCodeDropDownList",
              data: "{'markid': '" + id2 + "','agentid':'" + id + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#AgentCodeDropDownList").empty();
                  $("#AgentCodeDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#AgentCodeDropDownList").append($("<option></option>").val(value.AgentCodeTypeName).html(value.AgentCodeTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

  });


  $(document).ready(function () {
      //for primary
      $("#PrimaryCountryDropDownList").change(function () {
         // alert("hi");
          var id = $("#PrimaryCountryDropDownList").val();

          

          // alert(id + "   " + id2);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
              data: "{'Countid': '" + id + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#primarymobileDropDownList").empty();
                  //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#primarymobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

      //for secondary
      $("#SecondaryCountryDropDownList").change(function () {
          //alert("hi");
          var id = $("#SecondaryCountryDropDownList").val();



          // alert(id + "   " + id2);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
              data: "{'Countid': '" + id + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#secondarymobileDropDownList").empty();
                 // $("#secondarymobileDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#secondarymobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

      //for Subprofile1
      $("#SubProfile1CountryDropDownList").change(function () {
          //alert("hi");
          var id = $("#SubProfile1CountryDropDownList").val();



          // alert(id + "   " + id2);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
              data: "{'Countid': '" + id + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#subprofile1mobileDropDownList").empty();
                  //$("#subprofile1mobileDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#subprofile1mobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });


      //for Subprofile2
      $("#SubProfile2CountryDropDownList").change(function () {
          //alert("hi");
          var id = $("#SubProfile2CountryDropDownList").val();



          // alert(id + "   " + id2);

          $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              //url is the path of our web method (Page name/function name)
              url: "CreateProfile.aspx/PopulateCountryCodeDropDownList",
              data: "{'Countid': '" + id + "'}",
              dataType: "json",
              //called on jquery ajax call success
              success: function (data) {
                  $("#subprofile2mobileDropDownList").empty();
                 // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                  jsdata = JSON.parse(data.d);
                  $.each(jsdata, function (key, value) {

                      $("#subprofile2mobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                  });
              },
              //called on jquery ajax call failure
              error: function () {
                  alert('error');
              }
          });
          return false;


      });

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

    var l = 1;

    function f() {
        //var p = 1;
        l++;
        //alert(l);
        var s = 'item88s' + l;
        var p = 'item88p' + l;
        //alert('kkk');
        document.getElementById(s).style.display = "block";
        document.getElementById(p).style.display = "block";
        //alert('kkk');
        if (l == '3') {
            document.getElementById("bittu").style.display = "none";
            //alert('kkk');
        }

    }

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

    function hi2()
    {
        
        var rem = true;
        if (document.getElementById('<%= pfnameTextBox.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= pfnameTextBox.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
            alert(rem);
        }
       
        if (document.getElementById('<%= VenueCountryDropDownList.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= VenueCountryDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
           // alert(rem);
        }
         if (document.getElementById('<%= VenueDropDownList.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= VenueDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
           // alert(rem);
         }
         if (document.getElementById('<%= GroupVenueDropDownList.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= GroupVenueDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
           // alert(rem);
         }
         if (document.getElementById('<%= MarketingPrgmDropDownList.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= MarketingPrgmDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
           // alert(rem);
         }
         if (document.getElementById('<%= AgentsDropDownList.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= AgentsDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
           // alert(rem);
         }
         if (document.getElementById('<%= AgentCodeDropDownList.ClientID %>').value == '')
        {
            //alert('hi');
            document.getElementById('<%= AgentCodeDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
           // alert(rem);
        }
        alert(Error);
        return rem;
    }
    
</script>




        <style type="text/css">
    
    #hidden{
        display: none;
     }

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

  p{
         margin:0px;
         padding:0px;
     }

  hr{
   border: 1px thin #ccc;
}

.grid-container{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr auto auto auto;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
     
  
  padding: 10px;
  grid-template-areas:
    'item1 item1 item2 item3 item3 item3'
      'item4 item5 item6 item7 item8 item9';
}

.grid-container>div {
  
  padding:5px 2.5px;
  
}

.grid-container2{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  width:1200px;
  padding: 10px;
  grid-template-areas:
    'item21 item22 item23 item24';
}

.grid-container2>div {
 
  padding:5px 2.5px;
  
}

.grid-container3{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  grid-template-areas:
    'item31 item32 item32 item33 item33 item33'
      'item34 item35 item36 item37 item37 item37'
      'item38 item39 item39 item310 item311 item311';
}

.grid-container3>div {
  
  padding:5px 2.5px;
  
}


.grid-container4{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item41 item42 item42 item43 item43 item43'
      'item44 item45 item46 item47 item47 item47'
      'item48 item49 item49 item410 item411 item411';
}

.grid-container4>div {
 
  padding:5px 2.5px;
  
}

.grid-container5{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  grid-template-areas:
    'item51 item51 item51 item52 item52 item52'
      'item53 item54 item54 item551 item55 .'
      'item56 item57 item57 item58 item58 item58';
}

.grid-container5>div {
  
  padding:5px 2.5px;
  
}

.grid-container6{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item61 item62 item62 item63 item63 item43'
      'item64 item65 item66 item67 item67 item67'
      'item68 item69 item69 item610 item611 item611';
}

.grid-container6>div {
  
  padding:5px 2.5px;
  
}

.grid-container7{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item71 item72 item72 item73 item73 item73'
      'item74 item75 item76 item77 item77 item77'
      'item78 item79 item79 item710 item711 item711';
}

.grid-container7>div {
  
  padding:5px 2.5px;
  
}

.grid-container8{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item81 item82 . .'
      'item83 item84 item85 item86 ';
}

.grid-container8>div {
  
  padding:5px 2.5px;
  
}

.grid-container88{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item88s1 item88p1 . .'
      'item88s2 item88p2 . .'
      'item88s3 item88p3 . .';
}

.grid-container88>div {
  
  padding:5px 2.5px;
  
}

.grid-container882{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*background-color:blue;
    grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item8822 item8824 item8823 item8821'
     'item8826 item8827 item8828 item8829' ;
}

.grid-container882>div {
  /*background-color: aqua;*/
  padding:5px 2.5px;
  
}




.item1 {
   grid-area: item1;
}
.item2{
grid-area: item2;
}
.item3 {
   grid-area: item3;
}

.item4{
    grid-area: item4;
}
.item5{
    grid-area: item5;

}
.item6{grid-area: item6;

}
.item7{
    grid-area: item7;
}
.item8{
    grid-area: item8;

}
.item9{
    grid-area: item9;

}

.item21 {
   grid-area: item21;
}
.item22{
grid-area: item22;
}
.item23 {
   grid-area: item23;
}

.item24{
    grid-area: item24;
}


/*primary profile*/
.item31 {
   grid-area: item31;
}
.item32{
grid-area: item32;
}
.item33 {
   grid-area: item33;
}

.item34{
    grid-area: item34;
}
.item35{
    grid-area: item35;

}
.item36{grid-area: item36;

}
.item37{
    grid-area: item37;
}
.item38{
    grid-area: item38;
    
}
.item39{
    grid-area: item39;

}
.item310{
    grid-area: item310;
    

}
.item311{
    grid-area: item311;

}


/*Secondary profile*/
.item41 {
   grid-area: item41;
}
.item42{
grid-area: item42;
}
.item43 {
   grid-area: item43;
}

.item44{
    grid-area: item44;
}
.item45{
    grid-area: item45;

}
.item46{grid-area: item46;

}
.item47{
    grid-area: item47;
}
.item48{
    grid-area: item48;
    
}
.item49{
    grid-area: item49;

}
.item410{
    grid-area: item410;
    

}
.item411{
    grid-area: item411;

}

/*Address*/
.item51 {
   grid-area: item51;
}
.item52{
grid-area: item52;
}
.item53 {
   grid-area: item53;
}

.item54{
    grid-area: item54;
}
.item55{
    grid-area: item55;

}
.item551{
    grid-area: item551;

}
.item56{grid-area: item56;

}
.item57{
    grid-area: item57;
}
.item58{
    grid-area: item58;
    
}


/*Sub profile 1*/
.item61 {
   grid-area: item61;
}
.item62{
grid-area: item62;
}
.item63 {
   grid-area: item63;
}

.item64{
    grid-area: item64;
}
.item65{
    grid-area: item65;

}
.item66{grid-area: item66;

}
.item67{
    grid-area: item67;
}
.item68{
    grid-area: item68;
    
}
.item69{
    grid-area: item69;

}
.item610{
    grid-area: item610;
    

}
.item611{
    grid-area: item611;

}

/*Sub profile 2*/
.item71 {
   grid-area: item71;
}
.item72{
grid-area: item72;
}
.item73 {
   grid-area: item73;
}

.item74{
    grid-area: item74;
}
.item75{
    grid-area: item75;

}
.item76{grid-area: item76;

}
.item77{
    grid-area: item77;
}
.item78{
    grid-area: item78;
    
}
.item79{
    grid-area: item79;

}
.item710{
    grid-area: item710;
    

}
.item711{
    grid-area: item711;

}


/*Stay Details */
.item81 {
   grid-area: item81;
}
.item82{
grid-area: item82;
}
.item83 {
   grid-area: item83;
}

.item84{
    grid-area: item84;
}
.item85{
    grid-area: item85;

}
.item86{grid-area: item86;

}
#item88s1{
    grid-area: item88s1;
}
#item88p1{
    grid-area: item88p1;
    
}
#item88s2{
    grid-area: item88s2;
    display: none;
}
#item88p2{
    grid-area: item88p2;
    display :none;
}
#item88s3{
    grid-area: item88s3;
    display :none;
}
#item88p3{
    grid-area: item88p3;
    display :none;
}
.item8821{
    grid-area: item8821;

}
.item8822{
    grid-area: item8822;
    

}
.item8823{
    grid-area: item8823;

}
.item8824{
    grid-area: item8824;

}
.item8829{
    grid-area: item8829;

}
.item8826{
    grid-area: item8826;

}
.item8827{
    grid-area: item8827;

}
.item8828{
    grid-area: item8828;

}
  

html,body
{
    width: 100%;
    height: auto;
    margin: 0px;
    padding: 0px;
    overflow-x: hidden; 
}
 
</style>

</head>
<body>

<nav style="background-color:red;height:20px;padding:1px 20px 1px 10px;"><p style="font:bold;color:white;font-size:18px;font-family:Arial,Helvetica,sans-serif;">TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p></nav>   
    <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
<div id="tabs">
      
  <ul>
    <li><a href="#tabs-1">Profile</a></li>
    
  </ul>
    
        
  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
      <form id="form1" runat="server">
        
       <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PROFILE</h3>
        <hr />
        <br />
           <div class="grid-container">
               <div class="item1">
        <p>Profile ID</p>
        <asp:TextBox ID="ProfileIDTextBox" runat="server" Enabled="True" Width="450px"></asp:TextBox>
                  </div>
               <div class="item2">
                   <p>Date Insert</p>
        <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="150px"></asp:TextBox>
               </div>
               <div class="item3">
                   <p>Created By</p>
       
        <asp:TextBox ID="CreatedByTextBox" runat="server" Enabled="False" Width="500px"></asp:TextBox>
                   </div>
        <div class="item4">
            <p>Venue Country</p>
            <asp:DropDownList ID="VenueCountryDropDownList" runat="server" Width="150px" ></asp:DropDownList>
           
         </div>  
         <div class="item5">
            <p>Venue</p>
            <asp:DropDownList ID="VenueDropDownList" runat="server" Width="150px" ></asp:DropDownList>
         </div> 
        <div class="item6">
            <p>Marketing Program</p>
            <asp:DropDownList ID="GroupVenueDropDownList" runat="server" Width="150px" ></asp:DropDownList>
        </div>
        <div class="item7">
            <p>Sub Program</p>
            <asp:DropDownList ID="MarketingPrgmDropDownList" runat="server" Width="150px" ></asp:DropDownList>
        </div>
        <div class="item8">
            <p>Location</p>
            <asp:DropDownList ID="AgentsDropDownList" runat="server" Width="150px"></asp:DropDownList>
        </div>
        <div class="item9">
            <p>Location Code</p>
            <asp:DropDownList ID="AgentCodeDropDownList" runat="server" Width="150px"></asp:DropDownList>
        </div>
        </div>
        <br />
        <input id="chs" type="checkbox" onclick="shows();"/> <asp:Label ID="Label10" runat="server" Text="Label">Are you a Member?</asp:Label>
        <br />
        <br />
        <div id ="hidden">
        <div class="grid-container2">
        <div class="item21">
             <p>Choose Member Type</p>
             <asp:DropDownList ID="MemType1DropDownList" runat="server" Width="200px"></asp:DropDownList>
        </div>
        <div class="item22">
             <p>Member Number</p>
             <asp:TextBox ID="Memno1TextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
        </div>
        <div class="item23">
            <p>Choose Member Type</p>
            <asp:DropDownList ID="MemType2DropDownList" runat="server" Width="200px"></asp:DropDownList>
        </div>
        <div class="item24">
        <p>Member Number</p>
        <asp:TextBox ID="Memno2TextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
        </div>
        </div>
        </div>
        
        </div>
        
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PRIMARY PROFILE</h3>
        <hr />
        <br />
         
        <div class="grid-container3">
        <div class="item31">
            <p>Title</p>
        <asp:DropDownList ID="primarytitleDropDownList" runat="server" Width="100px"></asp:DropDownList>
        </div>
       <div class="item32">
           <p>First Name</p>
        
        <asp:TextBox ID="pfnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
         
           </div>
        <div class="item33">
            <p>Last Name</p>
        
        <asp:TextBox ID="plnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
            
            
            </div>
       <div class="item34">
           <p>Date Of Birth</p>
       
        <asp:TextBox ID="pdobdatepicker" runat="server" Enabled="True" Width="150px"></asp:TextBox>
           </div>
            <div class="item35">
                <p>Nationality</p>
          
        <asp:DropDownList ID="primarynationalityDropDownList" runat="server" Width="150px"></asp:DropDownList>
                </div>
            <div class="item36">
                <p>Country</p>
          
        <asp:DropDownList ID="PrimaryCountryDropDownList" runat="server" Width="150px"></asp:DropDownList>
                </div>
            <div class="item37">
         <p>Email</p>
          
        <asp:TextBox ID="pemailTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>
            <div class="item38">
                <p>CCode</p>
       
        <asp:DropDownList ID="primarymobileDropDownList" runat="server" Width="100px"></asp:DropDownList>
                </div>
            <div class="item39">
                <p>Mobile Number</p>
                <asp:TextBox ID="pmobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
       
     
                </div>
            <div class="item310">
                <p>CCode</p>
        <asp:DropDownList ID="primaryalternateDropDownList" runat="server" Width="100px"></asp:DropDownList>
                </div>
                <div class="item311">
                    <p>Alternate Number</p>
        <asp:TextBox ID="palternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
        </div>

       
        <br />
         </div>
     
         
        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
        <div class="grid-container4">
            <div class="item41">
                <p>Title</p>
        <asp:DropDownList ID="secondarytitleDropDownList" runat="server" Width="100px"></asp:DropDownList>
                </div>
            <div class="item42">
                <p>First Name</p>
        <asp:TextBox ID="sfnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>
            <div class="item43">
                 <p>Last Name</p>
       
        <asp:TextBox ID="slnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>
            <div class="item44">
        <p>Date Of Birth</p>
       
        <asp:TextBox ID="sdobdatepicker" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                </div>
            <div class="item45">
                <p>Nationality</p>
          
        <asp:DropDownList ID="secondarynationalityDropDownList" runat="server" Width="150px"></asp:DropDownList>
                </div>
            <div class="item46">
           
                <p>Country</p>
        <asp:DropDownList ID="SecondaryCountryDropDownList" runat="server" Width="150px"></asp:DropDownList>
                </div>
            <div class="item47">
          <p>Email</p>
          
        <asp:TextBox ID="semailTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>
            <div class="item48">
        <p>CCode</p>
        <asp:DropDownList ID="secondarymobileDropDownList" runat="server" Width="100px"></asp:DropDownList>
                </div>
            <div class="item49">
                <p>Mobile Number</p>
           
        <asp:TextBox ID="smobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
            <div class="item410">
        <p>CCode</p>
        <asp:DropDownList ID="secondaryalternateDropDownList" runat="server" Width="100px"></asp:DropDownList>
                </div>
            <div class="item411">
                <p>Alternate Number</p>
            
        <asp:TextBox ID="salternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
        </div>
      
        <br />
        </div>
 
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>ADDRESS</h3>
        <hr />
        <br />
          <div class="grid-container5">
              <div class="item51">
                  <p>Address Line1</p>
      
        <asp:TextBox ID="address1TextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                  </div>
              <div class="item52">
                  <p>Address Line2</p>
        
        <asp:TextBox ID="address2TextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                  </div>
       <div class="item53">
           <p>State</p>
       
        <asp:TextBox ID="stateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
           </div>
              <div class="item54">
                <p>City</p>
        
      <asp:TextBox ID="cityTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                  </div>

                  <div class="item551">
                  <p>Country</p>
        
      <asp:DropDownList ID="AddCountryDropDownList" runat="server" Width="200px"></asp:DropDownList>
                  </div>

              <div class="item55">
                  <p>Pincode</p>
        
      <asp:TextBox ID="pincodeTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                  </div>

           

       <div class="item56">
           <p>Employee Status</p>
      
        <asp:DropDownList ID="employmentstatusDropDownList" runat="server" Width="200px"></asp:DropDownList>
           </div>
              <div class="item57">
                  <p>Marital Status</p>
          
        <asp:DropDownList ID="MaritalStatusDropDownList" runat="server" Width="200px"></asp:DropDownList>
                  </div>
              <div class="item58">
                  <p>No of Year living together as a couple</p>
         
          <asp:TextBox ID="livingyrsTextBox" runat="server" Width="200px"></asp:TextBox>
                  </div>
          
              </div>
      
       <br />
    </div>
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs2" type="checkbox" onclick="shows2();"/>
 <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <div class="grid-container6">
                <div class="item61">
                    <p>Title</p>
        <asp:DropDownList ID="subprofile1titleDropDownList" runat="server" Width="100px"></asp:DropDownList>
                    </div>
                <div class="item62">
                    <p>First Name</p>
        
                
        <asp:TextBox ID="sp1fnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                    </div>
                <div class="item63">
                    <p>Last Name</p>
        
        <asp:TextBox ID="sp1lnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                    </div>
                <div class="item64">
        <p>Date Of Births</p>
       
        <asp:TextBox ID="sp1dobdatepicker" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                    </div>
                <div class="item65">
                    <p>Nationality</p>
      
        <asp:DropDownList ID="subprofile1nationalityDropDownList" runat="server" Width="150px"></asp:DropDownList>
                    </div>
                <div class="item66">
                    <p>Country</p>
          
        <asp:DropDownList ID="SubProfile1CountryDropDownList" runat="server" Width="150px"></asp:DropDownList>
            </div>
          <div class="item67">
              <p>Email</p>
         
        <asp:TextBox ID="sp1emailTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
              </div>
                <div class="item68">
        <p>CCode</p>
        <asp:DropDownList ID="subprofile1mobileDropDownList" runat="server" Width="100px"></asp:DropDownList>
                    </div>
        <div class="item69">
            <p>Mobile Number</p>
                
        <asp:TextBox ID="sp1mobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
            </div>
          <div class="item610">     
        <p>CCode</p>
        <asp:DropDownList ID="subprofile1alternateDropDownList" runat="server" Width="100px"></asp:DropDownList>
              </div> 
                <div class="item611">
                    <p>Alternate Number</p>
             
        <asp:TextBox ID="sp1alternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div> 
        </div>
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
            <div class="grid-container7">
                <div class="item71">
                    <p>Title</p>
        <asp:DropDownList ID="subprofile2titleDropDownList" runat="server" Width="100px"></asp:DropDownList>
                    </div>
                <div class="item72">
                    <p>First Name</p>
        
        <asp:TextBox ID="sp2fnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                    </div>
                <div class="item73">
                    <p>Last Name</p>
        
        <asp:TextBox ID="sp2lnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                    </div>
        <div class="item74">
            <p>Date Of Birth</p>
       
        <asp:TextBox ID="sp2dobdatepicker" runat="server" Enabled="True" Width="150px"></asp:TextBox>
            </div>
                <div class="item75">
                    <p>Nationality</p>
          
        <asp:DropDownList ID="subprofile2nationalityDropDownList" runat="server" Width="150px"></asp:DropDownList>
                    </div>
                <div class="item76">
                    <p>Country</p>
           
        <asp:DropDownList ID="SubProfile2CountryDropDownList" runat="server" Width="100px" ></asp:DropDownList>
                    </div>
                <div class="item77">
            <p>Email</p>
          
        <asp:TextBox ID="sp2emailTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                    </div>
                <div class="item78">
        <p>CCode</p>
        <asp:DropDownList ID="subprofile2mobileDropDownList" runat="server" Width="100px"></asp:DropDownList>
                    </div>
                <div class="item79">
                    <p>Mobile Number</p>
                    
        <asp:TextBox ID="sp2mobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
                <div class="item710">
        <p>CCode</p>
        <asp:DropDownList ID="subprofile2alternateDropDownList" runat="server" Width="100px"></asp:DropDownList>
                    </div>
                <div class="item711">
                    <p>Alternate Number</p>
                    
        <asp:TextBox ID="sp2alternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
         </div>
    </div>
         <br />
     <br />
   </div>
 
        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>STAY DETAILS</h3>
        <hr />
        <br />
            <div class="grid-container8">
           <div class="item81">    
                <p>Resort Name</p>
        
        <asp:TextBox ID="hotelTextBox" runat="server" Enabled="True"></asp:TextBox>
               </div> 
                <div class="item82"> 
                     <p>Resort Room No</p>
        
        <asp:TextBox ID="roomnoTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div> 
        <div class="item83"> 
             <p>Arrival</p> 
     
        <asp:TextBox ID="checkindatedatepicker" runat="server" Enabled="True"></asp:TextBox>
            </div>
                <div class="item84"> 
                     <p>Departure</p> 
    
        <asp:TextBox ID="checkoutdatedatepicker" runat="server" Enabled="True"></asp:TextBox>
                </div>

                <div class="item85"> 
                     <p>Sales Deck Check-In Time</p>
      
        <asp:TextBox ID="deckcheckintimeTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item86"> 
                     <p>Sales Deck Check-Out Time</p> 
     
        <asp:TextBox ID="deckcheckouttimeTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                </div>
            <div class="grid-container88">
                <div id="item88s1">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p1">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div id="item88s2">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList2" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p2">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox2" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div id="item88s3">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList3" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p3">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox3" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                </div>
             <div id='kk2'>
		<input type="button" id="bittu" value="More Gifts" onclick="f();"/>
	</div>
            <div class="grid-container882">
                <div class="item8821">  
                     <p>Comment if Any</p>
    
        <asp:TextBox ID="commentTextBox" runat="server" Enabled="True" TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
                    </div>
        <div class="item8822"> 
             <p>Guest Status</p>
     
        <asp:DropDownList ID="gueststatusDropDownList" runat="server" Width="200px"></asp:DropDownList>
            </div>
                <div class="item8823">
                     <p>Tour Date</p>
        
        <asp:TextBox ID="tourdatedatepicker" runat="server" Enabled="True"></asp:TextBox>
                    </div>
               <div class="item8824"> 
                     <p>Sales Represntative</p> 
       
        <asp:DropDownList ID="salesrepDropDownList" runat="server" Width="200px"></asp:DropDownList>
                    </div>

                <div class="item8826">
                     <p>Taxi in Price</p>
        
        <asp:TextBox ID="taxipriceInTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item8827"> 
                     <p>Taxi in Reference</p> 
     
        <asp:TextBox ID="TaxiRefInTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item8828"> 
                     <p>Taxi out Price</p>
          
        <asp:TextBox ID="TaxiPriceOutTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item8829">
                     <p>Taxi out Reference</p>  
     
        <asp:TextBox ID="TaxiRefOutTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
         </div>
        </div>

        
          
    
          <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClientClick="if (!hi2()) return false;" OnClick="Button1_Click" Text="Create Profile" />
          <asp:Button ID="Button2" class="btn btn-success" runat="server" OnClick="Button2_Click" Text="test bu" />
          <a href="index.aspx" id="hrf"  class="btn btn-success">Back</a>
          
    
    </form>
</div>

  </div>

  
  
</div>
 
 
</body>

</html>
