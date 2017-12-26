using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Sql;
using System.Net;
using System.IO;
using System.Web.UI.WebControls.Adapters;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Globalization;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc;

    static string pemail, semail,sp1email, sp2email;

    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager,ophid,ocard;
    static string oProfile_Primary_ID,   oProfile_Primary_Title, oProfile_Primary_Fname,   oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID,opage,oplang,opdesignation;
    static string oProfile_Secondary_ID,  oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB,   oProfile_Secondary_Nationality, oProfile_Secondary_Country, osage, oslang, osdesignation;
    static string oSub_Profile1_ID,  oSub_Profile1_Title, oSub_Profile1_Fname,  oSub_Profile1_Lname, oSub_Profile1_DOB ,   oSub_Profile1_Nationality, oSub_Profile1_Country,osp1age;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country,osp2age;
    static string oProfile_Address_ID ,   oProfile_Address_Line1, oProfile_Address_Line2,   oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city,    oProfile_Address_Postcode, oProfile_Address_Created_Date,    oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email;
    static string oProfile_Stay_ID ,  oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID ,  oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep,    oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In,    oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price,  oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;


    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }

        string ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);


        if (!Page.IsPostBack)
        {
           
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);
            //



            DataSet ds = Queries.LoadProfielDetailsFull(ProfileID);
            ProfileIDTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();         
            createddateTextBox.Text  = ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"].ToString();
            CreatedByTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString();
            ophid = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
            ocard = ds.Tables[0].Rows[0]["Card_Holder"].ToString();
            DataSet ds1 = Queries.LoadProfileVenueCountry(ProfileID);
            VenueCountryDropDownList.DataSource = ds1;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            DataSet ds2 = Queries.LoadProfileVenue(ProfileID, VenueCountryDropDownList.SelectedItem.Text);
            VenueDropDownList.DataSource = ds2;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            DataSet ds3 = Queries.LoadProfileVenueGroup(ProfileID,VenueDropDownList.SelectedItem.Text);
            GroupVenueDropDownList.DataSource = ds3;
            GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            GroupVenueDropDownList.AppendDataBoundItems = true;
            GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            GroupVenueDropDownList.DataBind();

            DataSet ds4 = Queries.LoadProfileMktg(ProfileID,VenueDropDownList.SelectedItem.Text,GroupVenueDropDownList.SelectedItem.Text);
            MarketingPrgmDropDownList.DataSource = ds4;
            MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            MarketingPrgmDropDownList.AppendDataBoundItems = true;
            MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            MarketingPrgmDropDownList.DataBind();

            if(GroupVenueDropDownList.SelectedItem.Text=="Coldline")
            {
                //     DataSet ds5 = Queries.LoadProfileAgent(ProfileID);
                DataSet ds5 = Queries.LoadProfileAgent1(ProfileID, VenueDropDownList.SelectedItem.Text);
                AgentsDropDownList.DataSource = ds5;
                AgentsDropDownList.DataTextField = "agentname";
                AgentsDropDownList.DataValueField = "agentname";
                AgentsDropDownList.AppendDataBoundItems = true;
                AgentsDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                AgentsDropDownList.DataBind();

            
            }
            else
            {
                DataSet ds5 = Queries.LoadProfileAgentNotColdline(ProfileID, VenueDropDownList.SelectedItem.Text);
                AgentsDropDownList.DataSource = ds5;
                AgentsDropDownList.DataTextField = "Sales_Rep_Name";
                AgentsDropDownList.DataValueField = "Sales_Rep_Name";
                AgentsDropDownList.AppendDataBoundItems = true;
                AgentsDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                AgentsDropDownList.DataBind();
                


            }

            DataSet ds6 = Queries.LoadProfileTOName(ProfileID, VenueDropDownList.SelectedItem.Text);
            TonameDropDownList.DataSource = ds6;
            TonameDropDownList.DataTextField = "TO_Manager_Name";
            TonameDropDownList.DataValueField = "TO_Manager_Name";
            TonameDropDownList.AppendDataBoundItems = true;
            TonameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            TonameDropDownList.DataBind();

            DataSet dsmg = Queries.LoadProfileManager(ProfileID, VenueDropDownList.SelectedItem.Text);
            mgrDropDownList.DataSource = dsmg;
            mgrDropDownList.DataTextField = "Manager_Name";
            mgrDropDownList.DataValueField = "Manager_Name";
            mgrDropDownList.AppendDataBoundItems = true;
            mgrDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["manager"].ToString(), ""));
            mgrDropDownList.DataBind();

         



            DataSet dsm = Queries.LoadMemberType();
            MemType1DropDownList.DataSource = dsm;
            MemType1DropDownList.DataTextField = "Member_Type_name";
            MemType1DropDownList.DataValueField = "Member_Type_name";
            MemType1DropDownList.AppendDataBoundItems = true;
            MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
            MemType1DropDownList.DataBind();

            DataSet ds7 = Queries.LoadMemberType();
            MemType2DropDownList.DataSource = ds7;
            MemType2DropDownList.DataTextField = "Member_Type_name";
            MemType2DropDownList.DataValueField = "Member_Type_name";
            MemType2DropDownList.AppendDataBoundItems = true;
            MemType2DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString(), ""));
            MemType2DropDownList.DataBind();
            //if (ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString()!="")
            //{
            //    MemType1DropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
                Memno1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
             //   MemType2DropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
                Memno2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
            // }

            DataSet dsem = Queries.LoadEmploymentStatusNotInProfile(ProfileID);
            employmentstatusDropDownList.DataSource = dsem;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();

            //load marital status

            DataSet dsms = Queries.LoadMaritalStatusNotInProfile(ProfileID);
            MaritalStatusDropDownList.DataSource = dsms;
            MaritalStatusDropDownList.DataTextField = "MaritalStatus";
            MaritalStatusDropDownList.DataValueField = "MaritalStatus";
            MaritalStatusDropDownList.AppendDataBoundItems = true;
            MaritalStatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            MaritalStatusDropDownList.DataBind();
           
           
            livingyrsTextBox.Text    = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
           string  Profile_Office  = ds.Tables[0].Rows[0]["Office"].ToString();
     

            DataSet dspt = Queries.LoadPrimarySalutation(ProfileID);
            primarytitleDropDownList.DataSource = dspt;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            primarytitleDropDownList.DataBind();

           


          //  primarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            
            pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            pdobdatepicker.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            primarynationalityDropDownList.Items.Add (ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString());
            primaryAge.Text = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            pdesginationTextBox.Text = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
            oplang= ds.Tables[0].Rows[0]["Primary_Language"].ToString();


            DataSet ds8 = Queries.LoadCountryPrimary(ProfileID);
            PrimaryCountryDropDownList.DataSource = ds8;
            PrimaryCountryDropDownList.DataTextField = "country_name";
            PrimaryCountryDropDownList.DataValueField = "country_name";
            PrimaryCountryDropDownList.AppendDataBoundItems = true;
            PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            PrimaryCountryDropDownList.DataBind();
            DataSet ds14p = Queries.LoadCountryWithCodePrimaryMobile(ProfileID);
            primarymobileDropDownList.DataSource = ds14p;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();
            DataSet ds14al = Queries.LoadCountryWithCodePrimaryAlt(ProfileID);
            primaryalternateDropDownList.DataSource = ds14al;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();           
              
            pmobile = pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            palternate = palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            pemail = pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();

            //secondary profile
           // secondarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());

 
            DataSet dsst = Queries.LoadSecondarySalutation(ProfileID);
            secondarytitleDropDownList.DataSource = dsst;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();



            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            sdobdatepicker.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            secondarynationalityDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());
             secondaryAge.Text  = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            sdesignationTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
            oslang= ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

            DataSet ds9 = Queries.LoadCountrySecondary(ProfileID);
            SecondaryCountryDropDownList.DataSource = ds9;
            SecondaryCountryDropDownList.DataTextField = "country_name";
            SecondaryCountryDropDownList.DataValueField = "country_name";
            SecondaryCountryDropDownList.AppendDataBoundItems = true;
            SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString(), ""));
            SecondaryCountryDropDownList.DataBind();
            DataSet ds14  = Queries.LoadCountryWithCodeSecondaryMobile(ProfileID);
            secondarymobileDropDownList.DataSource = ds14 ;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();
            DataSet ds14a = Queries.LoadCountryWithCodeSecondaryAlt(ProfileID);
            secondaryalternateDropDownList.DataSource = ds14a;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();
    
            smobileTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            salternateTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            semailTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();

            //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            DataSet dssp_1 = Queries.LoadSub_Profile1Salutation(ProfileID);
            subprofile1titleDropDownList.DataSource = dssp_1;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            subprofile1titleDropDownList.DataBind();


            //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            sp1dobdatepicker.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            subprofile1nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());
            subProfile1Age.Text= ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();
            DataSet ds10 = Queries.LoadCountrySP1(ProfileID);
            SubProfile1CountryDropDownList.DataSource = ds10;
            SubProfile1CountryDropDownList.DataTextField = "country_name";
            SubProfile1CountryDropDownList.DataValueField = "country_name";
            SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            SubProfile1CountryDropDownList.DataBind();


            DataSet dssp1 = Queries.LoadCountryWithCodeSP1Mobile(ProfileID);
            subprofile1mobileDropDownList.DataSource = dssp1;
            subprofile1mobileDropDownList.DataTextField = "name";
            subprofile1mobileDropDownList.DataValueField = "name";
            subprofile1mobileDropDownList.AppendDataBoundItems = true;
            subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            subprofile1mobileDropDownList.DataBind();
            DataSet dsspalt = Queries.LoadCountryWithCodeSP1Alt(ProfileID);
            subprofile1alternateDropDownList.DataSource = dsspalt;
            subprofile1alternateDropDownList.DataTextField = "name";
            subprofile1alternateDropDownList.DataValueField = "name";
            subprofile1alternateDropDownList.AppendDataBoundItems = true;
            subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            subprofile1alternateDropDownList.DataBind();

           
            sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            sp1emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();


        //    subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());

            DataSet dssp_2 = Queries.LoadSub_Profile2Salutation(ProfileID);
            subprofile2titleDropDownList.DataSource = dssp_2;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            subprofile2titleDropDownList.DataBind();

            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            sp2dobdatepicker.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            subprofile2nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());
            subProfile2Age.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            DataSet ds11 = Queries.LoadCountrySP2(ProfileID);
            SubProfile2CountryDropDownList.DataSource = ds11;
            SubProfile2CountryDropDownList.DataTextField = "country_name";
            SubProfile2CountryDropDownList.DataValueField = "country_name";
            SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            SubProfile2CountryDropDownList.DataBind();
          
          

            DataSet dssp2 = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            subprofile2mobileDropDownList.DataSource = dssp2;
            subprofile2mobileDropDownList.DataTextField = "name";
            subprofile2mobileDropDownList.DataValueField = "name";
            subprofile2mobileDropDownList.AppendDataBoundItems = true;
            subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            subprofile2mobileDropDownList.DataBind();
            DataSet dsspalt2 = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            subprofile2alternateDropDownList.DataSource = dsspalt2;
            subprofile2alternateDropDownList.DataTextField = "name";
            subprofile2alternateDropDownList.DataValueField = "name";
            subprofile2alternateDropDownList.AppendDataBoundItems = true;
            subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            subprofile2alternateDropDownList.DataBind();


            sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            sp2emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString(); 

          address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
           address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
             stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
         cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
             pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();

            DataSet ds12 = Queries.LoadCountryName();
            AddCountryDropDownList.DataSource = ds12;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();



            //stay details
            hotelTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
             roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            checkindatedatepicker.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
            checkoutdatedatepicker.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

          


            //guest status

            DataSet dsg = Queries.LoadGuestStatusInProfile(ProfileID);
            gueststatusDropDownList.DataSource = dsg;
            gueststatusDropDownList.DataTextField = "Guest_Status_name";
            gueststatusDropDownList.DataValueField = "Guest_Status_name";
            gueststatusDropDownList.AppendDataBoundItems = true;
            gueststatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            gueststatusDropDownList.DataBind();
            //       gueststatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString()); 

            salesrepDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
             deckcheckintimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
             deckcheckouttimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            tourdatedatepicker.Text= Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
            taxipriceInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            TaxiRefInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
              TaxiPriceOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
             TaxiRefOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();

            oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
            oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
            oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
            oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
            oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
            oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
            oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
            oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
            oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
            oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
            oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
            oManager = ds.Tables[0].Rows[0]["Manager"].ToString();
           
            oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            oProfile_Primary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
           opage= ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            opdesignation = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
            oplang = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

            oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            oProfile_Secondary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
            osage = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            osdesignation = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
            oslang = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();


            oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            oSub_Profile1_DOB =Convert.ToDateTime( ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
           osp1age = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

            
            oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            oSub_Profile2_DOB =Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
            osp2age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

            oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
            oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();

            oProfile_Address_Country = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();

            oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
            oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
            oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
            oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
            oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
            oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
            oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
            oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
            oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
         
            oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
            oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            oProfile_Stay_Arrival_Date =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Stay_Departure_Date =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

            oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
            oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
            oTour_Details_Tour_Date =Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
            oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();



        }
    }

    

    protected void VenueCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecountry =Queries.GetVenueCountryCode( VenueCountryDropDownList.SelectedItem.Text);
        //ProfileIDTextBox.ReadOnly = true;
        //ProfileIDTextBox.Text = Queries.GetProfileID(VenueCountryDropDownList.SelectedItem.Text);

        DataSet ds1 = Queries.LoadVenuebasedOnCountryID(venuecountry);
        VenueDropDownList.DataSource = ds1;
        VenueDropDownList.DataTextField = "Venue_Name";
        VenueDropDownList.DataValueField = "Venue_Name";
        VenueDropDownList.AppendDataBoundItems = true;
        VenueDropDownList.Items.Insert(0, new ListItem("", ""));
        VenueDropDownList.DataBind();
    }
    protected void VenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////get code
        //string venuecode= Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));

        
        //DataSet ds1 = Queries.LoadVenueGroup(venuecode);
        //GroupVenueDropDownList.DataSource = ds1;
        //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        //GroupVenueDropDownList.AppendDataBoundItems = true;
        //GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        //GroupVenueDropDownList.DataBind();
    }

    protected void GroupVenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);


        //DataSet ds1 = Queries.LoadMarketingProgram(venuecode);
        //MarketingPrgmDropDownList.DataSource = ds1;
        //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.AppendDataBoundItems = true;
        //MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        //MarketingPrgmDropDownList.DataBind();
        
    }

    protected void PrimaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        primarymobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(PrimaryCountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        primarymobileDropDownList.DataSource = ds12;
        primarymobileDropDownList.DataTextField = "name";
        primarymobileDropDownList.DataValueField = "name";
        primarymobileDropDownList.AppendDataBoundItems = true;
        primarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        primarymobileDropDownList.DataBind();

    }

    protected void SecondaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        secondarymobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(SecondaryCountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        secondarymobileDropDownList.DataSource = ds12;
        secondarymobileDropDownList.DataTextField = "name";
        secondarymobileDropDownList.DataValueField = "name";
        secondarymobileDropDownList.AppendDataBoundItems = true;
        secondarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        secondarymobileDropDownList.DataBind();
    }

    protected void SubProfile1CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        subprofile1mobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(SubProfile1CountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        subprofile1mobileDropDownList.DataSource = ds12;
        subprofile1mobileDropDownList.DataTextField = "name";
        subprofile1mobileDropDownList.DataValueField = "name";
        subprofile1mobileDropDownList.AppendDataBoundItems = true;
        subprofile1mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        subprofile1mobileDropDownList.DataBind();
    }
    protected void SubProfile2CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        subprofile2mobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(SubProfile2CountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        subprofile2mobileDropDownList.DataSource = ds12;
        subprofile2mobileDropDownList.DataTextField = "name";
        subprofile2mobileDropDownList.DataValueField = "name";
        subprofile2mobileDropDownList.AppendDataBoundItems = true;
        subprofile2mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        subprofile2mobileDropDownList.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        DataSet ds = Queries.LoadProfielDetailsFull(ProfileIDTextBox.Text);
        oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
        oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
        oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
        oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
        oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
        oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
        oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
        oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
        oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
        oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
        oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
        oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
        oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
        oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
        oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
        oManager = ds.Tables[0].Rows[0]["Manager"].ToString();
        ophid = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
        ocard = ds.Tables[0].Rows[0]["Card_Holder"].ToString();

        oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
        oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
        oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
        oProfile_Primary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
        oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
       opage = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
        opdesignation  = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
        oplang = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

        oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
        oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
        oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
        oProfile_Secondary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
        oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
        osage= ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
       osdesignation = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
        oslang = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

        oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
        oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
        oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
        oSub_Profile1_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
        oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
        oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
       osp1age= ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

        oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
        oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
        oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
        oSub_Profile2_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
        oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
        oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
        osp2age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

        oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
        oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
        oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
        oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
        oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
        oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
        oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();
        oProfile_Address_Country = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();

        oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
        oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
        oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
        oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
        oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
        oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
        oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
        oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
        oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
        oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
        oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
        oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
        oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
        oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
        oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
        oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

        oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
        oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
        oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
        oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
        oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
        oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
        oProfile_Stay_Arrival_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Stay_Departure_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

        oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
        oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
        oTour_Details_Tour_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
        oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
        oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
        oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
        oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
        oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
        oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
        //update profile

        string user =(string)Session["username"]; 
        CreatedByTextBox.Text = user;
        //get office of user
        string office = Queries.GetOffice(user);

        string profile = ProfileIDTextBox.Text;
        string createdby = CreatedByTextBox.Text;
        string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
        string venue = VenueDropDownList.SelectedItem.Text;
        string venuegroup = GroupVenueDropDownList.SelectedItem.Text;
        string mktg = MarketingPrgmDropDownList.SelectedItem.Text;
        string agents = AgentsDropDownList.SelectedItem.Text;
        string agentcode = TonameDropDownList.SelectedItem.Text;
        string mgr = mgrDropDownList.SelectedItem.Text;

        string photoidentity; 
        if (Request.Form["pidentity"] == null)
        {
            photoidentity = "";
        }
        else
        {
            photoidentity = Request.Form["pidentity"];
        }
        string card; 
        if (Request.Form["card"] == null)
        {
            card = "";
        }
        else
        {
            card = Request.Form["card"];
        }
        //member details
        string membertype1 = MemType1DropDownList.SelectedItem.Text;
        string memno1 = Memno1TextBox.Text;
        string membertype2 = MemType2DropDownList.SelectedItem.Text;
        string memno2 = Memno2TextBox.Text;
        //primary profile
        string primarytitle = primarytitleDropDownList.SelectedItem.Text;
        string primaryfname = pfnameTextBox.Text;
        string primaylname = plnameTextBox.Text;
        string primarydob = pdobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd");
        string primarynationality = primarynationalityDropDownList.SelectedItem.Text;
        string primarycountry = PrimaryCountryDropDownList.SelectedItem.Text;
        string npage = primaryAge.Text;
        string npdesg = pdesginationTextBox.Text;
        string primarylanguage;


        if (Request.Form["primarylang"] == null)
        {
            primarylanguage = "";
        }
        else
        {
            primarylanguage = Request.Form["primarylang"];

        }
        if (primarymobileDropDownList.SelectedIndex == 0)
        {
            pcc = "";

        }
        else
        {
          
            pcc = primarymobileDropDownList.SelectedItem.Text;

        }
        if (primaryalternateDropDownList.SelectedIndex == 0)
        {
            paltrcc = "";
        }
        else
        {
          
            paltrcc = primaryalternateDropDownList.SelectedItem.Text; 
        }
        if (pmobileTextBox.Text == "" || pmobileTextBox.Text == null)
        {
            pmobile = "0";
        }
        else
        {
            pmobile = pmobileTextBox.Text;
        }

        if (palternateTextBox.Text == "" || palternateTextBox.Text == null)
        {
            palternate = "0";
        }
        else
        {
            palternate = palternateTextBox.Text;
        }

        if (pemailTextBox.Text == "" || pemailTextBox.Text == null)
        {
            pemail = "";
        }
        else
        {
            pemail = pemailTextBox.Text;
        }

        //secondary profile

        string secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
        string secondaryfname = sfnameTextBox.Text;
        string secondarylname = slnameTextBox.Text;
        string secondarydob = sdobdatepicker.Text;//Convert.ToDateTime(sdobdatepicker.Text).ToString("yyyy-MM-dd"); 
        string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
        string secondarycountry = SecondaryCountryDropDownList.SelectedItem.Text;
        string nsage = secondaryAge.Text;
        string nsdesg = sdesignationTextBox.Text;

        string secondarylanguage; 
        if (Request.Form["seclang"] == null)
        {
            secondarylanguage = "";
        }
        else
        {
            secondarylanguage = Request.Form["seclang"];

        }
        if (secondarymobileDropDownList.SelectedIndex == 0)
        {
            scc = "";
        }
        else
        {
           
            scc = secondarymobileDropDownList.SelectedItem.Text;  
        }

        if (secondaryalternateDropDownList.SelectedIndex == 0)
        {
            saltcc = "0";
        }
        else
        {
            
            saltcc = secondaryalternateDropDownList.SelectedItem.Text; 
        }

        if (smobileTextBox.Text == "" || smobileTextBox.Text == null)
        {
            smobile = "0";
        }
        else
        {
            smobile = smobileTextBox.Text;
        }
        if (salternateTextBox.Text == "" || salternateTextBox.Text == null)
        {
            salternate = "0";
        }
        else
        {
            salternate = salternateTextBox.Text;
        }
        if (semailTextBox.Text == "" || semailTextBox.Text == null)
        {
            semail = "";
        }
        else
        {
            semail = semailTextBox.Text;
        }
        //sub profile1

        string sp1title = subprofile1titleDropDownList.SelectedItem.Text;
        string sp1fname = sp1fnameTextBox.Text;
        string sp1lname = sp1lnameTextBox.Text;
        string sp1dob = sp1dobdatepicker.Text;//Convert.ToDateTime(sp1dobdatepicker.Text).ToString("yyyy-MM-dd"); 


        string sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
        string sp1country = SubProfile1CountryDropDownList.SelectedItem.Text;
        string nsp1age = subProfile1Age.Text;
        if (subprofile1mobileDropDownList.SelectedIndex == 0)
        {
            sp1cc = "";
        }
        else
        {
           
            sp1cc = subprofile1mobileDropDownList.SelectedItem.Text; 
        }

        if (subprofile1alternateDropDownList.SelectedIndex == 0)
        {
            sp1altcc = "0";
        }
        else
        {
             
            sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text; 
        }


        if (sp1mobileTextBox.Text == "" || sp1mobileTextBox.Text == null)
        {
            sp1mobile = "0";
        }
        else
        {
            sp1mobile = sp1mobileTextBox.Text;
        }
        if (sp1alternateTextBox.Text == "" || sp1alternateTextBox.Text == null)
        {
            sp1alternate = "0";
        }
        else
        {
            sp1alternate = sp1alternateTextBox.Text;
        }
        if (sp1emailTextBox.Text == "" || sp1emailTextBox.Text == null)
        {
            sp1email = "";
        }
        else
        {
            sp1email = sp1emailTextBox.Text;
        }



        //sub profile 2
        string sp2title = subprofile2titleDropDownList.SelectedItem.Text;
        string sp2fname = sp2fnameTextBox.Text;
        string sp2lname = sp2lnameTextBox.Text;
        string sp2dob = sp2dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
        string sp2country = SubProfile2CountryDropDownList.SelectedItem.Text;
        string nsp2age = subProfile2Age.Text;
        if (subprofile2mobileDropDownList.SelectedIndex == 0)
        {
            sp2cc = "";
        }
        else
        {
            
            sp2cc = subprofile2mobileDropDownList.SelectedItem.Text; 
        }

        if (subprofile2alternateDropDownList.SelectedIndex == 0)
        {
            sp2altccc = "";
        }
        else
        {
           
            sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text; 
        }


        if (sp2mobileTextBox.Text == "" || sp2mobileTextBox.Text == null)
        {
            sp2mobile = "0";
        }
        else
        {
            sp2mobile = sp2mobileTextBox.Text;

        }
        if (sp2alternateTextBox.Text == "" || sp2alternateTextBox.Text == null)
        {
            sp2alternate = "0";

        }
        else
        {
            sp2alternate = sp2alternateTextBox.Text;

        }
        if (sp2emailTextBox.Text == "" || sp2emailTextBox.Text == null)
        {
            sp2email = "";
        }
        else
        {
            sp2email = sp2emailTextBox.Text;
        }

        //address

        string address1 = address1TextBox.Text;
        string address2 = address2TextBox.Text;
        string state = stateTextBox.Text;
        string city = cityTextBox.Text;
        string pincode = pincodeTextBox.Text;
        string acountry = AddCountryDropDownList.SelectedItem.Text;
        //other details

        string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
        string maritalstatus = MaritalStatusDropDownList.SelectedItem.Text;
        string livingyrs = livingyrsTextBox.Text;

        //stay details
        string resort = hotelTextBox.Text;
        string roomno = roomnoTextBox.Text;
        string arrivaldate = checkindatedatepicker.Text;
        string departuredate = checkoutdatedatepicker.Text;
       
        //guest status

        string gueststatus = gueststatusDropDownList.SelectedItem.Text;
        string salesrep = salesrepDropDownList.SelectedItem.Text;
        string timeIn = deckcheckintimeTextBox.Text;
        string timeOut = deckcheckouttimeTextBox.Text;
        string tourdate = tourdatedatepicker.Text;
        string taxin = taxipriceInTextBox.Text;
        string taxirefin = TaxiRefInTextBox.Text;
        string taxiout = TaxiPriceOutTextBox.Text;
        string taxirefout = TaxiRefOutTextBox.Text;

        if (String.Compare(oProfile_Venue_Country, venuecountry) != 0)
        {
            string act = "venue country changed from:" + oProfile_Venue_Country + "To:" + venuecountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Venue, venue) != 0)
        { string act = "venue changed from:" + oProfile_Venue + "To:" + venue;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Group_Venue, venuegroup) != 0)
        { string act = "venue group changed from:" + oProfile_Group_Venue + "To:" + venuegroup;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Marketing_Program, mktg) != 0)
        { string act = "marketing prgm changed from:" + oProfile_Marketing_Program + "To:" + mktg;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent, agents) != 0)
         { string act = "agent name changed from:" + oProfile_Agent + "To:" + agents;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent_Code, agentcode) != 0)
        { string act = "To Name changed from:" + oProfile_Agent_Code + "To:" + agentcode;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oManager, mgr) != 0)
        { string act = "manager changed from:" + oManager + "To:" + mgr;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type1, membertype1) != 0)
        { string act = "membertype1 changed from:" + oProfile_Member_Type1 + "To:" + membertype1;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ophid, photoidentity) != 0)
        {
            string act = "Photo Identity changed from:" + ophid + "To:" + photoidentity;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ocard, card) != 0)
        {
            string act = "Card Holder value changed from:" + ocard + "To:" + card;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number1, memno1) != 0)
          { string act = "memno1 changed from:" + oProfile_Member_Number1 + "To:" + memno1;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type2, membertype2) != 0)
         { string act = "membertype2 changed from:" + oProfile_Member_Type2 + "To:" + membertype2;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number2, memno2) != 0)
         {
            string act = "memno2 changed from:" + oProfile_Member_Number2 + "To:" + memno2;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Title, primarytitle) != 0)
        { string act = "primary title changed from:" + oProfile_Primary_Title + "To:" + primarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Fname, primaryfname) != 0)
       {
            string act = "primary fname changed from:" + oProfile_Primary_Fname + "To:" + primaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Lname, primaylname) != 0)
         { string act = "primay lname changed from:" + oProfile_Primary_Lname + "To:" + primaylname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_DOB, primarydob) != 0)
       { string act = "primary dob changed from:" + oProfile_Primary_DOB + "To:" + primarydob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Nationality, primarynationality) != 0)
        { string act = "primary nationality changed from:" + oProfile_Primary_Nationality + "To:" + primarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Country, primarycountry) != 0)
          { string act = "primary country changed from:" + oProfile_Primary_Country + "To:" + primarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opage,npage) != 0)
        {
            string act = "primary age changed from:" + opage + "To:" + npage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opdesignation,npdesg) != 0)
        {
            string act = "primary designation changed from:" + opdesignation + "To:" + npdesg;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oplang,primarylanguage) != 0)
        {
            string act = "primary Language changed from:" + oplang + "To:" + primarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_CC, pcc) != 0)
        { string act = "primary mobile code changed from:" + oPrimary_CC + "To:" + pcc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Mobile, pmobile) != 0)
        { string act = "primary mobile no changed from:" + oPrimary_Mobile + "To:" + pmobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
        {
            string act = "primary mobile changed from:" + oPrimary_Alt_CC + "To:" + paltrcc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alternate, palternate) != 0)
         { string act = "primary alternate no changed from:" + oPrimary_Alternate + "To:" + palternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Email, pemail) != 0)
         { string act = "primary email changed from:" + oPrimary_Email + "To:" + pemail;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Title, secondarytitle) != 0)
        {
            string act = "secondary title changed from:" + oProfile_Secondary_Title + "To:" + secondarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Fname, secondaryfname) != 0)
         {
            string act = "secondary fname changed from:" + oProfile_Secondary_Fname + "To:" + secondaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Lname, secondarylname) != 0)
         {
            string act = "secondary lname changed from:" + oProfile_Secondary_Lname + "To:" + secondarylname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_DOB, secondarydob) != 0)
        { string act = "secondary dob changed from:" + oProfile_Secondary_DOB + "To:" + secondarydob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(oProfile_Secondary_Nationality, secondarynationality) != 0)
         { string act = "secondary nationality changed from:" + oProfile_Secondary_Nationality + "To:" + secondarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osage, nsage) != 0)
        {
            string act = "secondary age changed from:" + osage + "To:" + nsage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osdesignation, nsdesg) != 0)
        {
            string act = "secondary designation changed from:" + osdesignation + "To:" + nsdesg;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oslang, secondarylanguage) != 0)
        {
            string act = "secondary Language changed from:" + oslang + "To:" + secondarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Country, secondarycountry) != 0)
            { string act = "secondary country changed from:" + oProfile_Secondary_Country + "To:" + secondarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
            if (String.Compare(oSecondary_CC, scc) != 0)
            {        string act = "secondary mobile code changed from:" + oSecondary_CC + "To:" + scc;
                    int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
            } else { }
            if (String.Compare(oSecondary_Mobile, smobile) != 0)
            {
            string act = "secondary mobile no changed from:" + oSecondary_Mobile + "To:" + smobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());

        } else { }
            if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
            { string act = "secondary alternaet num code changed from:" + oSecondary_Alt_CC + "To:" + saltcc;
              int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
                } else { }
            if (String.Compare(oSecondary_Alternate, salternate) != 0)
            { string act = "secondary alternate no changed from:" + oSecondary_Alternate + "To:" + salternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(oSecondary_Email, semail) != 0)
        {
            string act = "secondary email changed from:" + oSecondary_Email + "To:" + semail;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oSub_Profile1_Title, sp1title) != 0)
        { string act = "subprofile1 title changed from:" + oSub_Profile1_Title + "To:" + sp1title;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
         else { }
         if (String.Compare(oSub_Profile1_Fname, sp1fname) != 0)
        { string act = "subprofile1 fname changed from:" + oSub_Profile1_Fname + "To:" + sp1fname;
                  int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
         }
            else { }
            if (String.Compare(oSub_Profile1_Lname, sp1lname) != 0)
             {
            string act = "subprofile1 lname changed from:" + oSub_Profile1_Lname + "To:" + sp1lname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_DOB, sp1dob) != 0)
            {
            string act = "subprofile1 dob changed from:" + oSub_Profile1_DOB + "To:" + sp1dob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
            }
            else { }
        if (String.Compare(oSub_Profile1_Nationality, sp1nationality) != 0)
        { string act = "subprofile1 nationality changed from:" + oSub_Profile1_Nationality + "To:" + sp1nationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(osp1age, nsp1age) != 0)
        {
            string act = "subprofile1 age changed from:" + osp1age + "To:" + nsp1age;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Country, sp1country) != 0)
          { string act = "subprofile1 country changed from:" + oSub_Profile1_Country + "To:" + sp1country;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
                if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
                 { string act = "subprofile1 mobile code changed from:" + oSubprofile1_CC + "To:" + sp1cc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
                if (String.Compare(oSubprofile1_Mobile, sp1mobile) != 0)
                { string act = "subprofile1 mobile no changed from:" + oSubprofile1_Mobile + "To:" + sp1mobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
                if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
                 { string act = "subprofile1 alternate no code changed from:" + oSubprofile1_Alt_CC + "To:" + sp1altcc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
        if (String.Compare(oSubprofile1_Alternate, sp1alternate) != 0)
        { string act = "subprofile1 alternate changed from:" + oSubprofile1_Alternate + "To:" + sp1alternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }


        if (String.Compare(oSubprofile1_Email, sp1email) != 0)
        {
            string act = "subprofile1 email changed from:" + oSubprofile1_Email + "To:" + sp1email;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oSub_Profile2_Title, sp2title) != 0)
        {
            string act = "subprofile2 title changed from:" + oSub_Profile2_Title + "To:" + sp2title;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oSub_Profile2_Fname, sp2fname) != 0)
        { string act = "subprofile2 fname changed from:" + oSub_Profile2_Fname + "To:" + sp2fname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
         if (String.Compare(oSub_Profile2_Lname, sp2lname) != 0)
        { string act = "subprofile2 lname changed from:" + oSub_Profile2_Lname + "To:" + sp2lname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
      if (String.Compare(oSub_Profile2_DOB, sp2dob) != 0)
        { string act = "subprofile2 dob changed from:" + oSub_Profile2_DOB + "To:" + sp2dob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
       if (String.Compare(oSub_Profile2_Nationality, sp2nationality) != 0)
       { string act = "subprofile2 nationality changed from:" + oSub_Profile2_Nationality + "To:" + sp2nationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
         else { }
        if (String.Compare(osp2age, nsp2age) != 0)
        {
            string act = "subprofile2 age changed from:" + osp2age + "To:" + nsp2age;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Country, sp2country) != 0)

        { string act = "subprofile2 country changed from:" + oSub_Profile2_Country + "To:" + sp2country;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
        {
            string act = "subprofile2 mobile code changed from:" + oSubprofile2_CC + "To:" + sp2cc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Mobile, sp2mobile) != 0)
        { string act = "subprofile2 mobile no changed from:" + oSubprofile2_Mobile + "To:" + sp2mobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
         if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
         { string act = "subprofile2 alternate no code changed from:" + oSubprofile2_Alt_CC + "To:" + sp2altccc ;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
       if (String.Compare(oSubprofile2_Alternate, sp2alternate) != 0)
        { string act = "subprofile2 alternate no changed from:" + oSubprofile2_Alternate + "To:" + sp2alternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Email, sp2email) != 0)
        { string act = "subprofile2 email changed from:" + oSubprofile2_Email + "To:" + sp2email;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oProfile_Address_Line1, address1) != 0)

        { string act = "address1 changed from:" + oProfile_Address_Line1 + "To:" + address1;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Address_Line2, address2) != 0)
        { string act = "address2 changed from:" + oProfile_Address_Line2 + "To:" + address2;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Address_State, state) != 0)
        { string act = "state changed from:" + oProfile_Address_State + "To:" + state;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_city, city) != 0)
        { string act = "city changed from:" + oProfile_Address_city + "To:" + city;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Address_Postcode, pincode) != 0)
        { string act = "pincode changed from:" + oProfile_Address_Postcode + "To:" + pincode;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(oProfile_Address_Country, acountry) != 0)
        {
            string act = "Address Country changed from:" + oProfile_Address_Country + "To:" + acountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oProfile_Employment_status, employmentstatus) != 0)
        { string act = "employment status changed from:" + oProfile_Employment_status + "To:" + employmentstatus;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Marital_status, maritalstatus) != 0)
        { string act = "marital status changed from:" + oProfile_Marital_status + "To:" + maritalstatus;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_NOY_Living_as_couple, livingyrs) != 0)
        { string act = "livingyrs changed from:" + oProfile_NOY_Living_as_couple + "To:" + livingyrs;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Resort_Name, resort) != 0)
        { string act = "resort changed from:" + oProfile_Stay_Resort_Name + "To:" + resort;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Stay_Resort_Room_Number, roomno) != 0)
        { string act = "roomno changed from:" + oProfile_Stay_Resort_Room_Number + "To:" + roomno;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Stay_Arrival_Date, arrivaldate) != 0)
        { string act = "arrival date changed from:" + oProfile_Stay_Arrival_Date + "To:" + arrivaldate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Stay_Departure_Date, departuredate) != 0)
        { string act = "departure date changed from:" + oProfile_Stay_Departure_Date + "To:" + departuredate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Guest_Status, gueststatus) != 0)
        { string act = "guest status changed from:" + oTour_Details_Guest_Status + "To:" + gueststatus;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Guest_Sales_Rep, salesrep) != 0)

        { string act = "salesrep changed from:" + oTour_Details_Guest_Sales_Rep + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Sales_Deck_Check_In, timeIn) != 0)
        {
            string act = "time In changed from:" + oTour_Details_Sales_Deck_Check_In + "To:" + timeIn;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Sales_Deck_Check_Out, timeOut) != 0)
        { string act = "time Out changed from:" + oTour_Details_Sales_Deck_Check_Out + "To:" + timeOut;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Tour_Date, tourdate) != 0)
        { string act = "tour date changed from:" + oTour_Details_Tour_Date + "To:" + tourdate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Taxi_In_Price, taxin) != 0)
        { string act = "taxi in price changed from:" + oTour_Details_Taxi_In_Price + "To:" + taxin;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Taxi_In_Ref, taxirefin) != 0)
        { string act = "taxi reference in changed from:" + oTour_Details_Taxi_In_Ref + "To:" + taxirefin;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Taxi_Out_Price, taxiout) != 0)
        { string act = "taxi outprice changed from:" + oTour_Details_Taxi_Out_Price + "To:" + taxiout;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Taxi_Out_Ref, taxirefout) != 0)
        { string act = "taxi reference out changed from:" + oTour_Details_Taxi_Out_Ref + "To:" + taxirefout;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }


        //update profile
        int updateprofile = Queries.UpdateProfile(profile, venuecountry, venue, venuegroup,  mktg,  agents,  agentcode, membertype1, memno1,  membertype2, memno2,  employmentstatus, maritalstatus, livingyrs,mgr,photoidentity,card);
        int primary = Queries.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry,npage,npdesg,primarylanguage);
        int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry,nsage,nsdesg,secondarylanguage);
        int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country,nsp1age);
        int sp2 = Queries.UpdateSubProfile1(profile, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country,nsp2age);
        int address = Queries.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);
        int phone = Queries.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate);
        int email = Queries.UpdateEmail(profile, pemail, semail, sp1email, sp2email,"","","","");
        int stay = Queries.UpdateProfileStay(profile, resort, roomno, arrivaldate, departuredate);
        int tour = Queries.UpdateTourDetails(profile, gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout);

        string msg = "Details updated for Profile :" + " " + profile;
        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
    }



    [WebMethod]
    public static string getVenueOnCountry(string countryName)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = " select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_Name = '" + countryName + "')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }


    [WebMethod]
    public static string getVenueGroupOnVenue(string venue)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select vg.Venue_Group_ID,vg.Venue_Group_Name from Venue_Group vg where vg.Venue_ID in(select venue.Venue_ID from venue where venue.Venue_Name ='"+venue+"')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(1);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }


    [WebMethod]
    public static string getdata(string prid)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        //string query = "SELECT Primary_Language FROM Profile_Primary WHERE Profile_ID ='"+ '""
     //   SqlCommand sql = new SqlCommand(query, sqlcon);

        //SqlDataReader reader = sql.ExecuteReader();
        SqlDataReader reader = Queries.LoadPrimaryLang(prid);
        while (reader.Read())
        {
            string name = reader.GetString(0);

            string[] arr = name.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {

                JSON += "[\"" + arr[i] + "\"],";
            }
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }

    [WebMethod]
    public static string Secondarylang(string prid)
    {
      
        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadSecLang(prid);
        while (reader.Read())
        {
            string name = reader.GetString(0);

            string[] arr = name.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {

                JSON += "[\"" + arr[i] + "\"],";
            }
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }


    [WebMethod]
    public static string PhotoIdentity(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadPhotoID(prid);
        while (reader.Read())
        {
            string name = reader.GetString(0);

            string[] arr = name.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {

                JSON += "[\"" + arr[i] + "\"],";
            }
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }
    [WebMethod]
    public static string CardType(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadCardType(prid);
        while (reader.Read())
        {
            string name = reader.GetString(0);

            string[] arr = name.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {

                JSON += "[\"" + arr[i] + "\"],";
            }
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }


    [WebMethod]
    public static string getMarketingProgram(string venue,string venueGroup,string profileID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select distinct Marketing_Program_Name from Marketing_Program join Venue_Group vg on vg.Venue_group_ID=Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID= vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='"+ profileID + "' ) and vg.Venue_Group_Name='"+ venueGroup + "' and v.Venue_Name= '"+venue+"'";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }

    
}