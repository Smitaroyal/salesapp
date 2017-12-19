using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

public partial class _Default : System.Web.UI.Page
{
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc;

    static string pemail, semail,sp1email, sp2email;

    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager;
    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID;
    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country;
    static string oSub_Profile1_ID, oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country;
    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email;
    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;

    static string ogiftoptionDropDownList, ogiftoptionDropDownList2, ogiftoptionDropDownList3;
    static string ovouchernoTextBox, ovouchernoTextBox2, ovouchernoTextBox3;

    static string ProfileIDo;

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
            //string user = (string)Session["username"];// "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);
            //



           DataSet ds = Queries.LoadProfielDetailsFull(ProfileID);
           // DataSet ds = Queries2.LoadProfileOnCreation(ProfileID);
            ProfileIDTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();  
            
            ProfileIDo= ds.Tables[0].Rows[0]["Profile_ID"].ToString();
            createddateTextBox.Text  = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]).ToString("yyyy-MM-dd");

            CreatedByTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString();
            DataSet ds1 = Queries.LoadProfileVenueCountry(ProfileID);
            VenueCountryDropDownList.DataSource = ds1;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            VenueDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Venue"].ToString());
            //DataSet ds2 = Queries.LoadProfileVenue(ProfileID);
            //VenueDropDownList.DataSource = ds2;
            //VenueDropDownList.DataTextField = "Venue_Name";
            //VenueDropDownList.DataValueField = "Venue_Name";
            //VenueDropDownList.AppendDataBoundItems = true;
            //VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            //VenueDropDownList.DataBind();

            GroupVenueDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString());
            //DataSet ds3 = Queries.LoadProfileVenueGroup(ProfileID);
            //GroupVenueDropDownList.DataSource = ds3;
            //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            //GroupVenueDropDownList.AppendDataBoundItems = true;
            //GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            //GroupVenueDropDownList.DataBind();

            MarketingPrgmDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
            //DataSet ds4 = Queries.LoadProfileMktg(ProfileID);
            //MarketingPrgmDropDownList.DataSource = ds4;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            AgentsDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent"].ToString());
            //DataSet ds5 = Queries.LoadProfileAgent(ProfileID);
            //AgentsDropDownList.DataSource = ds5;
            //AgentsDropDownList.DataTextField = "Agent_Name";
            //AgentsDropDownList.DataValueField = "Agent_Name";
            //AgentsDropDownList.AppendDataBoundItems = true;
            //AgentsDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            //AgentsDropDownList.DataBind();

            AgentCodeDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());
            //DataSet ds6 = Queries.LoadProfileAgentCode(ProfileID);
            //AgentCodeDropDownList.DataSource = ds6;
            //AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
            //AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
            //AgentCodeDropDownList.AppendDataBoundItems = true;
            //AgentCodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //AgentCodeDropDownList.DataBind();
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

            employmentstatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString());
            employmentstatusDropDownList.Items.Add("Employee");
            employmentstatusDropDownList.Items.Add("Worker");
            employmentstatusDropDownList.Items.Add("Self Employed");
            employmentstatusDropDownList.Items.Add("Director");
            employmentstatusDropDownList.Items.Add("Office Holder");
            employmentstatusDropDownList.Items.Add("Unemployed");

            //load marital status
            MaritalStatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString());
            MaritalStatusDropDownList.Items.Add("Single");
            MaritalStatusDropDownList.Items.Add("Married");
            MaritalStatusDropDownList.Items.Add("Divorced");
            MaritalStatusDropDownList.Items.Add("Just Friend");
            MaritalStatusDropDownList.Items.Add("Female Couple");
            MaritalStatusDropDownList.Items.Add("Male Couple");
            MaritalStatusDropDownList.Items.Add("Living Together as couple");
            //if (ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString() != "")
            //{
            //    employmentstatusDropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            //}
            //if (ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString() != "")
            //{
            //    MaritalStatusDropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            //}
            livingyrsTextBox.Text    = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
           string  Profile_Office  = ds.Tables[0].Rows[0]["Office"].ToString();
            primarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            primarytitleDropDownList.Items.Add("Mr");
            primarytitleDropDownList.Items.Add("Ms");
            primarytitleDropDownList.Items.Add("Mrs");
            primarytitleDropDownList.Items.Add("Adv");
            primarytitleDropDownList.Items.Add("Dr");


          //  primarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            
            pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            //pdobdatepicker.Text =  Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Primary_DOB"]).ToString("yyyy-MM-dd");

            string deptt = ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();
            string datep1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"]).ToString("yyyy-MM-dd");
            if (datep1 == "" || datep1 == "1900-01-01")
            {
                pdobdatepicker.Text = "";
            }
            else
            {
                pdobdatepicker.Text = datep1;
            }



            primarynationalityDropDownList.Items.Add (ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString());

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

            secondarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());
            secondarytitleDropDownList.Items.Add("Mr");
            secondarytitleDropDownList.Items.Add("Ms");
            secondarytitleDropDownList.Items.Add("Mrs");
            secondarytitleDropDownList.Items.Add("Adv");
            secondarytitleDropDownList.Items.Add("Dr");


          
            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            //sdobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");

            string datep2 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]).ToString("yyyy-MM-dd");

            if (datep2 == "" || datep2 == "1900-01-01")
            {
                sdobdatepicker.Text = "";
            }
            else
            {
                sdobdatepicker.Text = datep2;
            }

            secondarynationalityDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());
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

            subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            subprofile1titleDropDownList.Items.Add("Mr");
            subprofile1titleDropDownList.Items.Add("Ms");
            subprofile1titleDropDownList.Items.Add("Mrs");
            subprofile1titleDropDownList.Items.Add("Adv");
            subprofile1titleDropDownList.Items.Add("Dr");

        

          //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            //sp1dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]).ToString("yyyy-MM-dd");

            string datep3 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]).ToString("yyyy-MM-dd");

            if (datep3 == " " || datep3 == "1900-01-01")
            {
                sp1dobdatepicker.Text = "";
            }
            else
            {
                sp1dobdatepicker.Text = datep3;
            }

            subprofile1nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());
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


            subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            subprofile2titleDropDownList.Items.Add("Mr");
            subprofile2titleDropDownList.Items.Add("Ms");
            subprofile2titleDropDownList.Items.Add("Mrs");
            subprofile2titleDropDownList.Items.Add("Adv");
            subprofile2titleDropDownList.Items.Add("Dr");
          //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            //sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

            string datep4 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

            if (datep4 == " " || datep4 == "1900-01-01")
            {
                sp2dobdatepicker.Text = "";
            }
            else
            {
                sp2dobdatepicker.Text = datep4;
            }

            subprofile2nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

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
            //checkindatedatepicker.Text = Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd");
            //checkoutdatedatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("yyyy-MM-dd");

            string datep5 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd");

            if (datep5 == " " || datep5 == "1900-01-01")
            {
                checkindatedatepicker.Text = "";
            }
            else
            {
                checkindatedatepicker.Text = datep5;
            }

            string datep6 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("yyyy-MM-dd");

            if (datep6 == " " || datep6 == "1900-01-01")
            {
                checkoutdatedatepicker.Text = "";
            }
            else
            {
                checkoutdatedatepicker.Text = datep6;
            }


            //guest status

            gueststatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString()); 
            salesrepDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
             deckcheckintimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
             deckcheckouttimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
           // tourdatedatepicker.Text= Convert.ToDateTime( ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToString("yyyy-MM-dd");

            string datep7 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToString("yyyy-MM-dd");

            if (datep7 == " " || datep7 == "1900-01-01")
            {
                tourdatedatepicker.Text = "";
            }
            else
            {
                tourdatedatepicker.Text = datep7;
            }

            taxipriceInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            TaxiRefInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
              TaxiPriceOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
             TaxiRefOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();


            string [] ar = new string[10];
            string[] br = new string[10];
            int i = 0;
            SqlDataReader reader = Queries2.getgiftoption(ProfileID);
            while (reader.Read())
            {

                 ar[i] = reader.GetString(0);
                br[i] = reader.GetString(1);

                //string id = "giftoptionDropDownList";
              
                i++;

            }

            if (ar[0] != "")
            {
                DataSet dsgift1 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList.DataSource = dsgift1;
                giftoptionDropDownList.DataTextField = "item";
                giftoptionDropDownList.DataValueField = "item";
                giftoptionDropDownList.AppendDataBoundItems = true;

                giftoptionDropDownList.DataBind();
                giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                vouchernoTextBox.Text = br[0];

                ogiftoptionDropDownList = ar[0];
                ovouchernoTextBox = br[0];

            }

            if (ar[1] != "")
            {
                DataSet dsgift2 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList2.DataSource = dsgift2;
                giftoptionDropDownList2.DataTextField = "item";
                giftoptionDropDownList2.DataValueField = "item";
                giftoptionDropDownList2.AppendDataBoundItems = true;

                giftoptionDropDownList2.DataBind();
                giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                vouchernoTextBox2.Text = br[1];
                ogiftoptionDropDownList2 = ar[1];
                ovouchernoTextBox2 = br[1];
            }

            if (ar[2] != "")
            {
                DataSet dsgift3 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList3.DataSource = dsgift3;
                giftoptionDropDownList3.DataTextField = "item";
                giftoptionDropDownList3.DataValueField = "item";
                giftoptionDropDownList3.AppendDataBoundItems = true;

                giftoptionDropDownList3.DataBind();
                giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList3 = ar[2];
                ovouchernoTextBox3 = br[2];
            }

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

            oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            oProfile_Secondary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();

            oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            oSub_Profile1_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();

            oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            oSub_Profile2_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();


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




        }
    }

    
    /*
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
        //get code
        string venuecode= Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));

        
        DataSet ds1 = Queries.LoadVenueGroup(venuecode);
        GroupVenueDropDownList.DataSource = ds1;
        GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        GroupVenueDropDownList.AppendDataBoundItems = true;
        GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        GroupVenueDropDownList.DataBind();
    }

    protected void GroupVenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);


        DataSet ds1 = Queries.LoadMarketingProgram(venuecode);
        MarketingPrgmDropDownList.DataSource = ds1;
        MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.AppendDataBoundItems = true;
        MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        MarketingPrgmDropDownList.DataBind();
        
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
    }*/

    protected void Button1_Click(object sender, EventArgs e)
    {
        //ProfileID
        try
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

            oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            oProfile_Primary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();

            oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            oProfile_Secondary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();

            oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            oSub_Profile1_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();

            oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            oSub_Profile2_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();


            oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
            oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();

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

            string[] ar = new string[10];
            string[] br = new string[10];
            int i = 0;
            SqlDataReader reader = Queries2.getgiftoption(ProfileIDTextBox.Text);
            while (reader.Read())
            {

                ar[i] = reader.GetString(0);
                br[i] = reader.GetString(1);

                //string id = "giftoptionDropDownList";

                i++;

            }

            if (ar[0] != "")
            {
                //DataSet dsgift1 = Queries2.LoadGiftOption(ProfileIDTextBox.Text);
                //giftoptionDropDownList.DataSource = dsgift1;
                //giftoptionDropDownList.DataTextField = "item";
                //giftoptionDropDownList.DataValueField = "item";
                //giftoptionDropDownList.AppendDataBoundItems = true;

                //giftoptionDropDownList.DataBind();
                //giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                //vouchernoTextBox.Text = br[0];

                ogiftoptionDropDownList = ar[0];
                ovouchernoTextBox = br[0];

            }

            if (ar[1] != "")
            {
                //DataSet dsgift2 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList2.DataSource = dsgift2;
                //giftoptionDropDownList2.DataTextField = "item";
                //giftoptionDropDownList2.DataValueField = "item";
                //giftoptionDropDownList2.AppendDataBoundItems = true;

                //giftoptionDropDownList2.DataBind();
                //giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                //vouchernoTextBox2.Text = br[1];
                ogiftoptionDropDownList2 = ar[1];
                ovouchernoTextBox2 = br[1];
            }

            if (ar[2] != "")
            {
                //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList3.DataSource = dsgift3;
                //giftoptionDropDownList3.DataTextField = "item";
                //giftoptionDropDownList3.DataValueField = "item";
                //giftoptionDropDownList3.AppendDataBoundItems = true;

                //giftoptionDropDownList3.DataBind();
                //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                //vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList3 = ar[2];
                ovouchernoTextBox3 = br[2];
            }




            //update profile

            string user = (string)Session["username"];// "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);

            string profile = ProfileIDTextBox.Text;
            string createdby = CreatedByTextBox.Text;
            string venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, membertype2;

            if (VenueCountryDropDownList.SelectedItem.Text == "")
            {
                venuecountry = "";
            }
            else
            {
                venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            }

            if (VenueDropDownList.SelectedItem.Text == "")
            {
                venue = "";
            }
            else
            {
                venue = VenueDropDownList.SelectedItem.Text;
            }

            if (GroupVenueDropDownList.SelectedItem.Text == "")
            {
                venuegroup = "";
            }
            else
            {
                venuegroup = GroupVenueDropDownList.SelectedItem.Text;
            }

            if (MarketingPrgmDropDownList.SelectedItem.Text == "")
            {
                mktg = "";
            }
            else
            {
                mktg = MarketingPrgmDropDownList.SelectedItem.Text;
            }

            if (AgentsDropDownList.SelectedItem.Text == "")
            {
                agents = "";
            }
            else
            {
                agents = AgentsDropDownList.SelectedItem.Text;
            }

            // if (AgentCodeDropDownList.SelectedItem.Text == "" || AgentCodeDropDownList.SelectedIndex == 0)
            //{
            //  agentcode = "";
            // }
            // else
            // {
            agentcode = AgentCodeDropDownList.SelectedItem.Text;
            //  }


            //member details
            if (MemType1DropDownList.SelectedItem.Text == "")
            {
                membertype1 = "";
            }
            else
            {
                membertype1 = MemType1DropDownList.SelectedItem.Text;
            }

            if (MemType2DropDownList.SelectedItem.Text == "")
            {
                membertype2 = "";
            }
            else
            {
                membertype2 = MemType2DropDownList.SelectedItem.Text;
            }
            //string agentcode = AgentCodeDropDownList.SelectedItem.Text;


            string memno1 = Memno1TextBox.Text;

            string memno2 = Memno2TextBox.Text;


            //Request.Form[AgentCodeDropDownList.UniqueID];
            /*string venuecountry = VenueCountryDropDownList.SelectedItem.Text;//Request.Form[VenueCountryDropDownList.UniqueID];
            string venue = Request.Form[VenueDropDownList.UniqueID];
            string venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];
            string mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];
            string agents = Request.Form[AgentsDropDownList.UniqueID];
            string agentcode = Request.Form[AgentCodeDropDownList.UniqueID];
            //member details
            string membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno1 = Memno1TextBox.Text;
            string membertype2 = MemType2DropDownList.SelectedItem.Text;
            string memno2 = Memno2TextBox.Text;*/
            //primary profile
            string primarytitle = primarytitleDropDownList.SelectedItem.Text;
            string primaryfname = pfnameTextBox.Text;
            string primaylname = plnameTextBox.Text;
            string primarydob = pdobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd"); 
            string tprimarydob;
            if (primarydob == "")
            {
                tprimarydob = "1900-01-01";
            }
            else
            {
                tprimarydob = Convert.ToDateTime(primarydob).ToString("yyyy-MM-dd");
            }

            string primarynationality = primarynationalityDropDownList.SelectedItem.Text;
            string primarycountry = PrimaryCountryDropDownList.SelectedItem.Text;
            if (primarymobileDropDownList.SelectedItem.Text == "")
            {
                pcc = "";

            }
            else
            {
                //Request.Form[primarymobileDropDownList.UniqueID];
                pcc = Request.Form[primarymobileDropDownList.UniqueID];

            }
            if (primaryalternateDropDownList.SelectedItem.Text == "")
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
            string secondarydob = sdobdatepicker.Text;
            string tsecondarydob;
            if (secondarydob == "")
            {
                tsecondarydob = "1900-01-01";
            }
            else
            {
                tsecondarydob = Convert.ToDateTime(secondarydob).ToString("yyyy-MM-dd");
            }
            string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
            string secondarycountry = SecondaryCountryDropDownList.SelectedItem.Text;
            if (secondarymobileDropDownList.SelectedItem.Text == "")
            {
                scc = "";
            }
            else
            {
                //Request.Form[secondarymobileDropDownList.UniqueID];
                scc = Request.Form[secondarymobileDropDownList.UniqueID];
            }

            if (secondaryalternateDropDownList.SelectedItem.Text == "")
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
            string sp1dob = sp1dobdatepicker.Text;

            string tsp1dob;
            if (sp1dob == "")
            {
                tsp1dob = "1900-01-01";
            }
            else
            {
                tsp1dob = Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            string sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
            string sp1country = SubProfile1CountryDropDownList.SelectedItem.Text;
            if (subprofile1mobileDropDownList.SelectedItem.Text == "")
            {
                sp1cc = "";
            }
            else
            {
                //Request.Form[subprofile1mobileDropDownList.UniqueID];
                sp1cc = Request.Form[subprofile1mobileDropDownList.UniqueID];
            }

            if (subprofile1alternateDropDownList.SelectedItem.Text == "")
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
            string sp2dob = sp2dobdatepicker.Text;

            string tsp2dob;
            if (sp2dob == "")
            {
                tsp2dob = "1900-01-01";
            }
            else
            {
                tsp2dob = Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            string sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
            string sp2country = SubProfile2CountryDropDownList.SelectedItem.Text;

            if (subprofile2mobileDropDownList.SelectedItem.Text == "")
            {
                sp2cc = "";
            }
            else
            {
                // Request.Form[subprofile2mobileDropDownList.UniqueID];
                sp2cc = Request.Form[subprofile2mobileDropDownList.UniqueID];
            }

            if (subprofile2alternateDropDownList.SelectedItem.Text == "")
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
            string tarrivaldate;
            if (arrivaldate == "")
            {
                tarrivaldate = "1900-01-01";
            }
            else
            {
                tarrivaldate = Convert.ToDateTime(arrivaldate).ToString("yyyy-MM-dd");
            }

            string departuredate = checkoutdatedatepicker.Text;
            string tdeparturedate;
            if (departuredate == "")
            {
                tdeparturedate = "1900-01-01";
            }
            else
            {
                tdeparturedate = Convert.ToDateTime(departuredate).ToString("yyyy-MM-dd");
            }

            //guest status

            string gueststatus = gueststatusDropDownList.SelectedItem.Text;
            string salesrep = salesrepDropDownList.SelectedItem.Text;
            string timeIn = deckcheckintimeTextBox.Text;
            string timeOut = deckcheckouttimeTextBox.Text;
            string tourdate = tourdatedatepicker.Text;
            string ttourdate;
            if (tourdate == "")
            {
                ttourdate = "1900-01-01";
            }
            else
            {
                ttourdate = Convert.ToDateTime(tourdate).ToString("yyyy-MM-dd");
            }
            string taxin = taxipriceInTextBox.Text;
            string taxirefin = TaxiRefInTextBox.Text;
            string taxiout = TaxiPriceOutTextBox.Text;
            string taxirefout = TaxiRefOutTextBox.Text;



            string gifto1, gifto2, gifto3;
            if (giftoptionDropDownList.SelectedItem.Text == "")
            {
                gifto1 = "";
            }
            else
            {
                gifto1 = giftoptionDropDownList.SelectedItem.Text;
            }

            if (giftoptionDropDownList2.SelectedItem.Text == "")
            {
                gifto2 = "";
            }
            else
            {
                gifto2 = giftoptionDropDownList2.SelectedItem.Text;
            }

            if (giftoptionDropDownList3.SelectedItem.Text == "")
            {
                gifto3 = "";
            }
            else
            {
                gifto3 = giftoptionDropDownList3.SelectedItem.Text;
            }

            string voucher1 = vouchernoTextBox.Text;
            string voucher2 = vouchernoTextBox2.Text;
            string voucher3 = vouchernoTextBox3.Text;

            if (String.Compare(oProfile_Venue_Country, venuecountry) != 0)
            {
                string act = "venue country changed from:" + oProfile_Venue_Country + "To:" + venuecountry;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
                //int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Venue, venue) != 0)
            {
                string act = "venue changed from:" + oProfile_Venue + "To:" + venue;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Group_Venue, venuegroup) != 0)
            {
                string act = "venue group changed from:" + oProfile_Group_Venue + "To:" + venuegroup;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Marketing_Program, mktg) != 0)
            {
                string act = "marketing prgm changed from:" + oProfile_Marketing_Program + "To:" + mktg;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Agent, agents) != 0)
            {
                string act = "agent name changed from:" + oProfile_Agent + "To:" + agents;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Agent_Code, agentcode) != 0)
            {
                string act = "To Name changed from:" + oProfile_Agent_Code + "To:" + agentcode;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            /*if (String.Compare(oManager, mgr) != 0)
            {
                string act = "manager changed from:" + oManager + "To:" + mgr;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }*/
            if (String.Compare(oProfile_Member_Type1, membertype1) != 0)
            {
                string act = "membertype1 changed from:" + oProfile_Member_Type1 + "To:" + membertype1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Member_Number1, memno1) != 0)
            {
                string act = "memno1 changed from:" + oProfile_Member_Number1 + "To:" + memno1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Member_Type2, membertype2) != 0)
            {
                string act = "membertype2 changed from:" + oProfile_Member_Type2 + "To:" + membertype2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Member_Number2, memno2) != 0)
            {
                string act = "memno2 changed from:" + oProfile_Member_Number2 + "To:" + memno2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Title, primarytitle) != 0)
            {
                string act = "primary title changed from:" + oProfile_Primary_Title + "To:" + primarytitle;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Fname, primaryfname) != 0)
            {
                string act = "primary fname changed from:" + oProfile_Primary_Fname + "To:" + primaryfname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Lname, primaylname) != 0)
            {
                string act = "primay lname changed from:" + oProfile_Primary_Lname + "To:" + primaylname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_DOB, primarydob) != 0)
            {
                string act = "primary dob changed from:" + oProfile_Primary_DOB + "To:" + primarydob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Nationality, primarynationality) != 0)
            {
                string act = "primary nationality changed from:" + oProfile_Primary_Nationality + "To:" + primarynationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Country, primarycountry) != 0)
            {
                string act = "primary country changed from:" + oProfile_Primary_Country + "To:" + primarycountry;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_CC, pcc) != 0)
            {
                string act = "primary mobile code changed from:" + oPrimary_CC + "To:" + pcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Mobile, pmobile) != 0)
            {
                string act = "primary mobile no changed from:" + oPrimary_Mobile + "To:" + pmobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
            {
                string act = "primary mobile changed from:" + oPrimary_Alt_CC + "To:" + paltrcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Alternate, palternate) != 0)
            {
                string act = "primary alternate no changed from:" + oPrimary_Alternate + "To:" + palternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Email, pemail) != 0)
            {
                string act = "primary email changed from:" + oPrimary_Email + "To:" + pemail;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Title, secondarytitle) != 0)
            {
                string act = "secondary title changed from:" + oProfile_Secondary_Title + "To:" + secondarytitle;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Fname, secondaryfname) != 0)
            {
                string act = "secondary fname changed from:" + oProfile_Secondary_Fname + "To:" + secondaryfname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Lname, secondarylname) != 0)
            {
                string act = "secondary lname changed from:" + oProfile_Secondary_Lname + "To:" + secondarylname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_DOB, secondarydob) != 0)
            {
                string act = "secondary dob changed from:" + oProfile_Secondary_DOB + "To:" + secondarydob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oProfile_Secondary_Nationality, secondarynationality) != 0)
            {
                string act = "secondary nationality changed from:" + oProfile_Secondary_Nationality + "To:" + secondarynationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Country, secondarycountry) != 0)
            {
                string act = "secondary country changed from:" + oProfile_Secondary_Country + "To:" + secondarycountry;
            }
            else { }
            if (String.Compare(oSecondary_CC, scc) != 0)
            {
                string act = "secondary mobile code changed from:" + oSecondary_CC + "To:" + scc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSecondary_Mobile, smobile) != 0)
            {
                string act = "secondary mobile no changed from:" + oSecondary_Mobile + "To:" + smobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else { }
            if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
            {
                string act = "secondary alternaet num code changed from:" + oSecondary_Alt_CC + "To:" + saltcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSecondary_Alternate, salternate) != 0)
            {
                string act = "secondary alternate no changed from:" + oSecondary_Alternate + "To:" + salternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSecondary_Email, semail) != 0)
            {
                string act = "secondary email changed from:" + oSecondary_Email + "To:" + semail;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Title, sp1title) != 0)
            {
                string act = "subprofile1 title changed from:" + oSub_Profile1_Title + "To:" + sp1title;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Fname, sp1fname) != 0)
            {
                string act = "subprofile1 fname changed from:" + oSub_Profile1_Fname + "To:" + sp1fname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Lname, sp1lname) != 0)
            {
                string act = "subprofile1 lname changed from:" + oSub_Profile1_Lname + "To:" + sp1lname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_DOB, sp1dob) != 0)
            {
                string act = "subprofile1 dob changed from:" + oSub_Profile1_DOB + "To:" + sp1dob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Nationality, sp1nationality) != 0)
            {
                string act = "subprofile1 nationality changed from:" + oSub_Profile1_Nationality + "To:" + sp1nationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Country, sp1country) != 0)
            {
                string act = "subprofile1 country changed from:" + oSub_Profile1_Country + "To:" + sp1country;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
            {
                string act = "subprofile1 mobile code changed from:" + oSubprofile1_CC + "To:" + sp1cc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_Mobile, sp1mobile) != 0)
            {
                string act = "subprofile1 mobile no changed from:" + oSubprofile1_Mobile + "To:" + sp1mobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
            {
                string act = "subprofile1 alternate no code changed from:" + oSubprofile1_Alt_CC + "To:" + sp1altcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_Alternate, sp1alternate) != 0)
            {
                string act = "subprofile1 alternate changed from:" + oSubprofile1_Alternate + "To:" + sp1alternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(oSubprofile1_Email, sp1email) != 0)
            {
                string act = "subprofile1 email changed from:" + oSubprofile1_Email + "To:" + sp1email;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Title, sp2title) != 0)
            {
                string act = "subprofile2 title changed from:" + oSub_Profile2_Title + "To:" + sp2title;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Fname, sp2fname) != 0)
            {
                string act = "subprofile2 fname changed from:" + oSub_Profile2_Fname + "To:" + sp2fname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Lname, sp2lname) != 0)
            {
                string act = "subprofile2 lname changed from:" + oSub_Profile2_Lname + "To:" + sp2lname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_DOB, sp2dob) != 0)
            {
                string act = "subprofile2 dob changed from:" + oSub_Profile2_DOB + "To:" + sp2dob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Nationality, sp2nationality) != 0)
            {
                string act = "subprofile2 nationality changed from:" + oSub_Profile2_Nationality + "To:" + sp2nationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSub_Profile2_Country, sp2country) != 0)

            {
                string act = "subprofile2 country changed from:" + oSub_Profile2_Country + "To:" + sp2country;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
            {
                string act = "subprofile2 mobile code changed from:" + oSubprofile2_CC + "To:" + sp2cc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Mobile, sp2mobile) != 0)
            {
                string act = "subprofile2 mobile no changed from:" + oSubprofile2_Mobile + "To:" + sp2mobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
            {
                string act = "subprofile2 alternate no code changed from:" + oSubprofile2_Alt_CC + "To:" + sp2altccc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Alternate, sp2alternate) != 0)
            {
                string act = "subprofile2 alternate no changed from:" + oSubprofile2_Alternate + "To:" + sp2alternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Email, sp2email) != 0)
            {
                string act = "subprofile2 email changed from:" + oSubprofile2_Email + "To:" + sp2email;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oProfile_Address_Line1, address1) != 0)

            {
                string act = "address1 changed from:" + oProfile_Address_Line1 + "To:" + address1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_Line2, address2) != 0)
            {
                string act = "address2 changed from:" + oProfile_Address_Line2 + "To:" + address2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_State, state) != 0)
            {
                string act = "state changed from:" + oProfile_Address_State + "To:" + state;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_city, city) != 0)
            {
                string act = "city changed from:" + oProfile_Address_city + "To:" + city;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_Postcode, pincode) != 0)
            {
                string act = "pincode changed from:" + oProfile_Address_Postcode + "To:" + pincode;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Employment_status, employmentstatus) != 0)
            {
                string act = "employment status changed from:" + oProfile_Employment_status + "To:" + employmentstatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Marital_status, maritalstatus) != 0)
            {
                string act = "marital status changed from:" + oProfile_Marital_status + "To:" + maritalstatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_NOY_Living_as_couple, livingyrs) != 0)
            {
                string act = "livingyrs changed from:" + oProfile_NOY_Living_as_couple + "To:" + livingyrs;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Resort_Name, resort) != 0)
            {
                string act = "resort changed from:" + oProfile_Stay_Resort_Name + "To:" + resort;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Resort_Room_Number, roomno) != 0)
            {
                string act = "roomno changed from:" + oProfile_Stay_Resort_Room_Number + "To:" + roomno;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Arrival_Date, arrivaldate) != 0)
            {
                string act = "arrival date changed from:" + oProfile_Stay_Arrival_Date + "To:" + arrivaldate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Departure_Date, departuredate) != 0)
            {
                string act = "departure date changed from:" + oProfile_Stay_Departure_Date + "To:" + departuredate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Guest_Status, gueststatus) != 0)
            {
                string act = "guest status changed from:" + oTour_Details_Guest_Status + "To:" + gueststatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Guest_Sales_Rep, salesrep) != 0)

            {
                string act = "salesrep changed from:" + oTour_Details_Guest_Sales_Rep + "To:" + salesrep;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Sales_Deck_Check_In, timeIn) != 0)
            {
                string act = "time In changed from:" + oTour_Details_Sales_Deck_Check_In + "To:" + timeIn;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oTour_Details_Sales_Deck_Check_Out, timeOut) != 0)
            {
                string act = "time Out changed from:" + oTour_Details_Sales_Deck_Check_Out + "To:" + timeOut;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Tour_Date, tourdate) != 0)
            {
                string act = "tour date changed from:" + oTour_Details_Tour_Date + "To:" + tourdate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Taxi_In_Price, taxin) != 0)
            {
                string act = "taxi in price changed from:" + oTour_Details_Taxi_In_Price + "To:" + taxin;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Taxi_In_Ref, taxirefin) != 0)
            {
                string act = "taxi reference in changed from:" + oTour_Details_Taxi_In_Ref + "To:" + taxirefin;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Taxi_Out_Price, taxiout) != 0)
            {
                string act = "taxi outprice changed from:" + oTour_Details_Taxi_Out_Price + "To:" + taxiout;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oTour_Details_Taxi_Out_Ref, taxirefout) != 0)
            {
                string act = "taxi reference out changed from:" + oTour_Details_Taxi_Out_Ref + "To:" + taxirefout;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftoptionDropDownList, gifto1) != 0)
            {
                string act = "Gift option 1 changed from:" + ogiftoptionDropDownList + "To:" + gifto1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftoptionDropDownList2, gifto2) != 0)
            {
                string act = "Gift option 2 changed from:" + ogiftoptionDropDownList2 + "To:" + gifto2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftoptionDropDownList3, gifto3) != 0)
            {
                string act = "Gift option 3 changed from:" + ogiftoptionDropDownList3 + "To:" + gifto3;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox, voucher1) != 0)
            {
                string act = "voucher 1 changed from:" + ovouchernoTextBox + "To:" + voucher1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox2, voucher2) != 0)
            {
                string act = "voucher 2 changed from:" + ovouchernoTextBox2 + "To:" + voucher2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox3, voucher3) != 0)
            {
                string act = "voucher 3 changed from:" + ovouchernoTextBox3 + "To:" + voucher3;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }



            //update profile
            int updateprofile = Queries.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, "","","");
            int primary = Queries.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, tprimarydob, primarynationality, primarycountry,"","","");
            int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry,"","","");
            int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country,"");
            int sp2 = Queries.UpdateSubProfile1(profile, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country,"");
            int address = Queries.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);
            int phone = Queries.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate);
            int email = Queries.UpdateEmail(profile, pemail, semail, sp1email, sp2email);
            int stay = Queries.UpdateProfileStay(profile, resort, roomno, tarrivaldate, tdeparturedate);
            int tour = Queries.UpdateTourDetails(profile, gueststatus, salesrep, ttourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout);
            


            if (giftoptionDropDownList.SelectedItem.Text != "")
            {
                int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList,gifto1,voucher1,ProfileIDo);
            }
            if (giftoptionDropDownList2.SelectedItem.Text != "")
            {
                int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList2, gifto2, voucher2, ProfileIDo);
            }
            if (giftoptionDropDownList3.SelectedItem.Text != "")
            {
                int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList3, gifto3, voucher3, ProfileIDo);
            }




            string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
        }
        catch (Exception ex)
        {


            MessageBox.Show("Error while Updating profile " + ex.Message);

            //int delete = Queries2.Deleteprofileonerror(ProfileIDo);

             HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }
    }


    public class VenueType
    {
        public string VenueTypeID { get; set; }
        public string VenueTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<VenueType> listRes = new List<VenueType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select v.Venue_Name,v.Venue_ID  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID   where vc.Venue_Country_Name = '" + id + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        VenueType objst2 = new VenueType();

                        objst2.VenueTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueTypeName = Convert.ToString(dt.Rows[i]["Venue_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class VenueGroupType
    {
        public string VenueGroupTypeID { get; set; }
        public string VenueGroupTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueGroupDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<VenueGroupType> listRes = new List<VenueGroupType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        VenueGroupType objst2 = new VenueGroupType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueGroupTypeName = Convert.ToString(dt.Rows[i]["Venue_Group_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class MrktProgType
    {
        public string MrktProgTypeID { get; set; }
        public string MrktProgTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateMrktProgDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<MrktProgType> listRes = new List<MrktProgType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        MrktProgType objst2 = new MrktProgType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["Marketing_Program_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class AgentType
    {
        public string AgentTypeID { get; set; }
        public string AgentTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentDropDownList(string markid, string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<AgentType> listRes = new List<AgentType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        AgentType objst2 = new AgentType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentTypeName = Convert.ToString(dt.Rows[i]["Agent_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    public class AgentCodeType
    {
        public string AgentCodeTypeID { get; set; }
        public string AgentCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentCodeDropDownList(string markid, string agentid)
    {
        DataTable dt = new DataTable();
        List<AgentCodeType> listRes = new List<AgentCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '" + agentid + "' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "'))", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        AgentCodeType objst2 = new AgentCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentCodeTypeName = Convert.ToString(dt.Rows[i]["Agent_Code"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class CountryCodeType
    {
        public string CountryCodeTypeID { get; set; }
        public string CountryCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateCountryCodeDropDownList(string Countid)
    {
        DataTable dt = new DataTable();
        List<CountryCodeType> listRes = new List<CountryCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Country_Code from Country where Country_Name='" + Countid + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        CountryCodeType objst2 = new CountryCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Country_Code"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static int totalgift()
    {
        //return "Hello "+name;
         int finaInstI;

        finaInstI = Queries2.countgift(ProfileIDo);
        return finaInstI;

      //  return "hi";


    }

}