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
    static string office;
    static string pointsamt, pointstax, poinstcgst, pointssgst,mrgcode;
    string IGSTrate, Interestrate,mcwaiver;
    string Finance_No, documentationfee, IGST_Amount, No_Emi, emiamt;
    public string getdata()
    {
        string htmlstr = "";
        SqlDataReader dr = Queries.LoadAffiliationType(office);//,currencyDropDownList.SelectedItem.Text);
        while (dr.Read())
        {

            int id = dr.GetInt32(0);
            string name = dr.GetString(1);
            double amt = dr.GetDouble(2);
            string addvalue = "dispplayvalue";
            string ca = "ca";

            htmlstr += " <input id=" + ca + "" + id + " type='checkbox' class='hello' name='aamt' onClick="  + addvalue + "() value='" + amt + "'>" + name + "";


        }

        return htmlstr;
    }
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!Page.IsPostBack)
        {



            dealdateTextBox.Text = DateTime.Today.ToString("yyyy/MM/dd");// dd/MM/yyyy");
            dealstatusDropDownList.Items.Clear();
            dealstatusDropDownList.Items.Add("");
            dealstatusDropDownList.Items.Add("Registered");
            dealstatusDropDownList.Items.Add("Unegistered");

            string ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);

              DataSet ds = Queries.LoadProfielDetailsFull(ProfileID);
            profileidTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();
             indateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"].ToString();
             TextBox3.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString(); 
            office = ds.Tables[0].Rows[0]["Office"].ToString();
            officeTextBox.Text= ds.Tables[0].Rows[0]["Office"].ToString();

            DataSet ds1 = Queries.LoadProfileVenueCountry(ProfileID);
              VenueCountryDropDownList.DataSource = ds1;
              VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
              VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
              VenueCountryDropDownList.AppendDataBoundItems = true;
              VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
              VenueCountryDropDownList.DataBind();

              DataSet ds2 = Queries.LoadProfileVenue(ProfileID);
              VenueDropDownList.DataSource = ds2;
              VenueDropDownList.DataTextField = "Venue_Name";
              VenueDropDownList.DataValueField = "Venue_Name";
              VenueDropDownList.AppendDataBoundItems = true;
              VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
              VenueDropDownList.DataBind();

              DataSet ds3 = Queries.LoadProfileVenueGroup(ProfileID);
              GroupVenueDropDownList.DataSource = ds3;
              GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
              GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
              GroupVenueDropDownList.AppendDataBoundItems = true;
              GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
              GroupVenueDropDownList.DataBind();

              DataSet ds4 = Queries.LoadProfileMktg(ProfileID);
              MarketingProgramDropDownList.DataSource = ds4;
              MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
              MarketingProgramDropDownList.DataValueField = "Marketing_Program_Name";
              MarketingProgramDropDownList.AppendDataBoundItems = true;
              MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
              MarketingProgramDropDownList.DataBind();
            //if (MarketingProgramDropDownList.SelectedItem.Text == "OWNER")
            //{
                
            //    mcRadioButtonList.Visible = true;
                
            //}
            //else
            //{
            //    mcRadioButtonList.Visible = false;
            //    //  mcRadioButtonList.Attributes.Add("style", "display:none");
               
            //}




            DataSet dsptitle = Queries.LoadPrimarySalutation(ProfileID);
            PrimaryTitleDropDownList.DataSource = dsptitle;
            PrimaryTitleDropDownList.DataTextField = "Salutation";
            PrimaryTitleDropDownList.DataValueField = "Salutation";
            PrimaryTitleDropDownList.AppendDataBoundItems = true;
            PrimaryTitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            PrimaryTitleDropDownList.DataBind();
                
            pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            primarydobdatepicker.Text = ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();


            DataSet dspnationality = Queries.LoadPrimaryNationality(ProfileID);
            PrimarynationalityDropDownList.DataSource = dspnationality;
            PrimarynationalityDropDownList.DataTextField = "Nationality_Name";
            PrimarynationalityDropDownList.DataValueField = "Nationality_Name";
            PrimarynationalityDropDownList.AppendDataBoundItems = true;
            PrimarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            PrimarynationalityDropDownList.DataBind();

            DataSet dspcountry = Queries.LoadCountryPrimary(ProfileID);
            primarycountryDropDownList.DataSource = dspcountry;
            primarycountryDropDownList.DataTextField = "country_name";
            primarycountryDropDownList.DataValueField = "country_name";
            primarycountryDropDownList.AppendDataBoundItems = true;
            primarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            primarycountryDropDownList.DataBind();

           

            pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();

            DataSet dspm = Queries.LoadCountryWithCodePrimaryMobile(ProfileID);
            primarymobileDropDownList.DataSource = dspm;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();                     
            
            pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();

            DataSet dspalt = Queries.LoadCountryWithCodePrimaryAlt(ProfileID);
            primaryalternateDropDownList.DataSource = dspalt;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();                      
            palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();



            //secondary details
            DataSet dsstitle = Queries.LoadSecondarySalutation(ProfileID);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();

            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Lname"].ToString();
            secondarydobdatepicker.Text = ds.Tables[0].Rows[0]["Profile_secondary_DOB"].ToString();


            DataSet dssnationality = Queries.LoadSecondaryNationality(ProfileID);
            secondarynationalityDropDownList.DataSource = dssnationality;
            secondarynationalityDropDownList.DataTextField = "Nationality_Name";
            secondarynationalityDropDownList.DataValueField = "Nationality_Name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();

            DataSet dsscountry = Queries.LoadCountrySecondary(ProfileID);
            secondarycountryDropDownList.DataSource = dsscountry;
            secondarycountryDropDownList.DataTextField = "country_name";
            secondarycountryDropDownList.DataValueField = "country_name";
            secondarycountryDropDownList.AppendDataBoundItems = true;
            secondarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString(), ""));
            secondarycountryDropDownList.DataBind();



            semailTextBox.Text = ds.Tables[0].Rows[0]["secondary_Email"].ToString();

            DataSet dssm = Queries.LoadCountryWithCodeSecondaryMobile(ProfileID);
            secondarymobileDropDownList.DataSource = dssm;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();

            smobileTextBox.Text = ds.Tables[0].Rows[0]["secondary_Mobile"].ToString();

            DataSet dssalt = Queries.LoadCountryWithCodeSecondaryAlt(ProfileID);
            secondaryalternateDropDownList.DataSource = dssalt;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();
            salternateTextBox.Text = ds.Tables[0].Rows[0]["secondary_Alternate"].ToString();

            //address
            address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            livingyrsTextBox.Text = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
           

            DataSet dsemploy= Queries.LoadEmploymentStatusNotInProfile(ProfileID);
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();


            DataSet dsmart = Queries.LoadMaritalStatusNotInProfile(ProfileID);
            maritalstatusDropDownList.DataSource = dsmart;
            maritalstatusDropDownList.DataTextField = "MaritalStatus";
            maritalstatusDropDownList.DataValueField = "MaritalStatus";
            maritalstatusDropDownList.AppendDataBoundItems = true;
            maritalstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            maritalstatusDropDownList.DataBind();
                     


            DataSet dssp1title = Queries.LoadSub_Profile1Salutation(ProfileID);
            sp1titleDropDownList.DataSource = dssp1title;
            sp1titleDropDownList.DataTextField = "Salutation";
            sp1titleDropDownList.DataValueField = "Salutation";
            sp1titleDropDownList.AppendDataBoundItems = true;
            sp1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            sp1titleDropDownList.DataBind();

            sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            sp1dobdatepicker.Text = ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString();


            DataSet dssp1nationality = Queries.LoadSub_Profile1Nationality(ProfileID);  
            sp1nationalityDropDownList.DataSource = dssp1nationality;
            sp1nationalityDropDownList.DataTextField = "Nationality_Name";
            sp1nationalityDropDownList.DataValueField = "Nationality_Name";
            sp1nationalityDropDownList.AppendDataBoundItems = true;
            sp1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            sp1nationalityDropDownList.DataBind();

            DataSet dssp1country = Queries.LoadCountrySP1(ProfileID);
            sp1countryDropDownList.DataSource = dssp1country;
            sp1countryDropDownList.DataTextField = "country_name";
            sp1countryDropDownList.DataValueField = "country_name";
            sp1countryDropDownList.AppendDataBoundItems = true;
            sp1countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            sp1countryDropDownList.DataBind();



            sp1pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();

            DataSet dssp1m = Queries.LoadCountryWithCodeSP1Mobile(ProfileID);
            sp1mobileDropDownList.DataSource = dssp1m;
            sp1mobileDropDownList.DataTextField = "name";
            sp1mobileDropDownList.DataValueField = "name";
            sp1mobileDropDownList.AppendDataBoundItems = true;
            sp1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            sp1mobileDropDownList.DataBind();

            sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();

            DataSet dssp1alt = Queries.LoadCountryWithCodeSP1Alt(ProfileID);
            sp1alternateDropDownList.DataSource = dssp1alt;
            sp1alternateDropDownList.DataTextField = "name";
            sp1alternateDropDownList.DataValueField = "name";
            sp1alternateDropDownList.AppendDataBoundItems = true;
            sp1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            sp1alternateDropDownList.DataBind();
            sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();



            DataSet dssp2title = Queries.LoadSub_Profile2Salutation(ProfileID);
            sp2titleDropDownList.DataSource = dssp2title;
            sp2titleDropDownList.DataTextField = "Salutation";
            sp2titleDropDownList.DataValueField = "Salutation";
            sp2titleDropDownList.AppendDataBoundItems = true;
            sp2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            sp2titleDropDownList.DataBind();

            sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            sp2dobdatepicker.Text = ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString();


            DataSet dssp2nationality = Queries.LoadSub_Profile2Nationality(ProfileID);
            sp2nationalityDropDownList.DataSource = dssp2nationality;
            sp2nationalityDropDownList.DataTextField = "Nationality_Name";
            sp2nationalityDropDownList.DataValueField = "Nationality_Name";
            sp2nationalityDropDownList.AppendDataBoundItems = true;
            sp2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            sp2nationalityDropDownList.DataBind();

            DataSet dssp2country = Queries.LoadCountrySP2(ProfileID);
            sp2countryDropDownList.DataSource = dssp2country;
            sp2countryDropDownList.DataTextField = "country_name";
            sp2countryDropDownList.DataValueField = "country_name";
            sp2countryDropDownList.AppendDataBoundItems = true;
            sp2countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            sp2countryDropDownList.DataBind();



            sp2pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

            DataSet dssp2m = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            sp2mobileDropDownList.DataSource = dssp2m;
            sp2mobileDropDownList.DataTextField = "name";
            sp2mobileDropDownList.DataValueField = "name";
            sp2mobileDropDownList.AppendDataBoundItems = true;
            sp2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            sp2mobileDropDownList.DataBind();

            sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();

            DataSet dssp2alt = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            sp2alternateDropDownList.DataSource = dssp2alt;
            sp2alternateDropDownList.DataTextField = "name";
            sp2alternateDropDownList.DataValueField = "name";
            sp2alternateDropDownList.AppendDataBoundItems = true;
            sp2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            sp2alternateDropDownList.DataBind();
            sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
               

            resortTextBox.Text= ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();

            roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            arrivaldatedatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToShortDateString();
            departuredatedatepicker.Text= Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToShortDateString();
            tourdatedatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToShortDateString();
            timeinTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
           timeoutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            inpriceTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            inrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            outpriceTextBox.Text= ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            outrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
                
                 
                  

             DataSet dsqual = Queries.LoadGuestStatusInProfile(ProfileID);
            guestatusDropDownList.DataSource = dsqual;
            guestatusDropDownList.DataTextField = "Guest_Status_name";
            guestatusDropDownList.DataValueField = "Guest_Status_name";
            guestatusDropDownList.AppendDataBoundItems = true;
            guestatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            guestatusDropDownList.DataBind();

            DataSet dstour = Queries.LoadSalesRepsInProfile1(office, ProfileID,VenueDropDownList.SelectedItem.Text);
            toursalesrepDropDownList.DataSource = dstour;
            toursalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            toursalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            toursalesrepDropDownList.AppendDataBoundItems = true;
            toursalesrepDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            toursalesrepDropDownList.DataBind();

            

            //  load all sales rep based on office
            contsalesrepDropDownList.Items.Clear();
            DataSet ds7 = Queries.LoadSalesRepsInProfile1(office, ProfileID,VenueDropDownList.SelectedItem.Text);// LoadSalesReps(office);
            contsalesrepDropDownList.DataSource = ds7;
            contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            contsalesrepDropDownList.AppendDataBoundItems = true;
            contsalesrepDropDownList.Items.Insert(0, new ListItem("", ""));
            contsalesrepDropDownList.DataBind();

          ///  load TO based on office

            TOManagerDropDownList.Items.Clear();
            DataSet dsto = Queries.LoadTOManagerOnVenue(office, VenueDropDownList.SelectedItem.Text);// LoadTOManager(office);
            TOManagerDropDownList.DataSource = dsto;
            TOManagerDropDownList.DataTextField = "TO_Manager_Name";
            TOManagerDropDownList.DataValueField = "TO_Manager_Name";
            TOManagerDropDownList.AppendDataBoundItems = true;
            TOManagerDropDownList.Items.Insert(0, new ListItem("", ""));
            TOManagerDropDownList.DataBind();

            ButtonUpDropDownList.Items.Clear();
            DataSet dsbu = Queries.LoadButtonUpOnVenue(office, VenueDropDownList.SelectedItem.Text);// LoadButtonUp(office);
            ButtonUpDropDownList.DataSource = dsbu;
            ButtonUpDropDownList.DataTextField = "ButtonUp_Name";
            ButtonUpDropDownList.DataValueField = "ButtonUp_Name";
            ButtonUpDropDownList.AppendDataBoundItems = true;
            ButtonUpDropDownList.Items.Insert(0, new ListItem("", ""));
            ButtonUpDropDownList.DataBind(); 

            
          
            //Contract tab
            //load contract type

            DataSet dsct = Queries.LoadContractType(office);
            contracttypeDropDownList.DataSource = dsct;
            contracttypeDropDownList.DataTextField = "ContractType_name";
            contracttypeDropDownList.DataValueField = "ContractType_name";
            contracttypeDropDownList.AppendDataBoundItems = true;
            contracttypeDropDownList.Items.Insert(0, new ListItem("Choose Contract Type", ""));
            contracttypeDropDownList.DataBind();



            DataSet dsfc = Queries.LoadFinanceOffice(office);
            currencyDropDownList.DataSource = dsfc;
            currencyDropDownList.DataTextField = "Finance_Currency_Name";
            currencyDropDownList.DataValueField = "Finance_Currency_Name";
            currencyDropDownList.AppendDataBoundItems = true;
            currencyDropDownList.Items.Insert(0, new ListItem("", ""));
            currencyDropDownList.DataBind();



            //load club based on contract type
            //type=points
            //Request.Form[VenueDropDownList.UniqueID]

          DataSet dsc = Queries.LoadPointsClub(office,Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text,Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));
           
            pointsclubDropDownList.DataSource = dsc;
            pointsclubDropDownList.DataTextField = "Contract_Club_Name";
            pointsclubDropDownList.DataValueField = "Contract_Club_Name";
            pointsclubDropDownList.AppendDataBoundItems = true;
            pointsclubDropDownList.Items.Insert(0, new ListItem("Select Club", ""));
            pointsclubDropDownList.DataBind();

            nmclubDropDownList.DataSource = dsc;
            nmclubDropDownList.DataTextField = "Contract_Club_Name";
            nmclubDropDownList.DataValueField = "Contract_Club_Name";
            nmclubDropDownList.AppendDataBoundItems = true;
            nmclubDropDownList.Items.Insert(0, new ListItem("Select Club", ""));
            nmclubDropDownList.DataBind();

            ntipclubDropDownList.DataSource = dsc;
            ntipclubDropDownList.DataTextField = "Contract_Club_Name";
            ntipclubDropDownList.DataValueField = "Contract_Club_Name";
            ntipclubDropDownList.AppendDataBoundItems = true;
            ntipclubDropDownList.Items.Insert(0, new ListItem("Select Club", ""));
            ntipclubDropDownList.DataBind();


            DataSet dspym = Queries.LoadPaymentMethod(office);
            PayMethodDropDownList.DataSource = dspym;
            PayMethodDropDownList.DataTextField = "pay_method_name";
            PayMethodDropDownList.DataValueField = "pay_method_name";
            PayMethodDropDownList.AppendDataBoundItems = true;
            PayMethodDropDownList.Items.Insert(0, new ListItem("Select Payment Method", ""));
            PayMethodDropDownList.DataBind();

            DataSet dsfm = Queries.LoadFinanceMethod(office);
            financemethodDropDownList.DataSource = dsfm;
            financemethodDropDownList.DataTextField = "Finance_Name";
            financemethodDropDownList.DataValueField = "Finance_Name";
            financemethodDropDownList.AppendDataBoundItems = true;
            financemethodDropDownList.Items.Insert(0, new ListItem("", ""));
            financemethodDropDownList.DataBind();

            DataSet dsseason = Queries.LoadSeason();

            tnmseasonDropDownList.DataSource = dsseason;
            tnmseasonDropDownList.DataTextField = "season_name";
            tnmseasonDropDownList.DataValueField = "season_name";
            tnmseasonDropDownList.AppendDataBoundItems = true;
            tnmseasonDropDownList.Items.Insert(0, new ListItem("", ""));
            tnmseasonDropDownList.DataBind();

            fwseasonDropDownList.DataSource = dsseason;
            fwseasonDropDownList.DataTextField = "season_name";
            fwseasonDropDownList.DataValueField = "season_name";
            fwseasonDropDownList.AppendDataBoundItems = true;
            fwseasonDropDownList.Items.Insert(0, new ListItem("", ""));
            fwseasonDropDownList.DataBind();

            //load alt or full
            DataSet dsen = Queries.LoadMembershipEntitlement();
            EntitlementPoinDropDownList.DataSource = dsen;
            EntitlementPoinDropDownList.DataTextField = "Entitlement_Name";
            EntitlementPoinDropDownList.DataValueField = "Entitlement_Name";
            EntitlementPoinDropDownList.AppendDataBoundItems = true;
            EntitlementPoinDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementPoinDropDownList.DataBind();


            tipmtypeDropDownList.DataSource = dsen;
            tipmtypeDropDownList.DataTextField = "Entitlement_Name";
            tipmtypeDropDownList.DataValueField = "Entitlement_Name";
            tipmtypeDropDownList.AppendDataBoundItems = true;
            tipmtypeDropDownList.Items.Insert(0, new ListItem("", ""));
            tipmtypeDropDownList.DataBind();

            nmembtypeDropDownList.DataSource = dsen;
            nmembtypeDropDownList.DataTextField = "Entitlement_Name";
            nmembtypeDropDownList.DataValueField = "Entitlement_Name";
            nmembtypeDropDownList.AppendDataBoundItems = true;
            nmembtypeDropDownList.Items.Insert(0, new ListItem("", ""));
            nmembtypeDropDownList.DataBind();

            EntitlementFracDropDownList.DataSource = dsen;
            EntitlementFracDropDownList.DataTextField = "Entitlement_Name";
            EntitlementFracDropDownList.DataValueField = "Entitlement_Name";
            EntitlementFracDropDownList.AppendDataBoundItems = true;
            EntitlementFracDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementFracDropDownList.DataBind();

            fwentitlementDropDownList.DataSource = dsen;
            fwentitlementDropDownList.DataTextField = "Entitlement_Name";
            fwentitlementDropDownList.DataValueField = "Entitlement_Name";
            fwentitlementDropDownList.AppendDataBoundItems = true;
            fwentitlementDropDownList.Items.Insert(0, new ListItem("", ""));
            fwentitlementDropDownList.DataBind();

            fptsentitlementDropDownList.DataSource = dsen;
            fptsentitlementDropDownList.DataTextField = "Entitlement_Name";
            fptsentitlementDropDownList.DataValueField = "Entitlement_Name";
            fptsentitlementDropDownList.AppendDataBoundItems = true;
            fptsentitlementDropDownList.Items.Insert(0, new ListItem("", ""));
            fptsentitlementDropDownList.DataBind();
            
                

            if (PrimarynationalityDropDownList.SelectedItem.Text=="Indian")
            {
                //load alt or full
                DataSet dsres = Queries.LoadFractionalResortIndia();
                resortDropDownList.DataSource = dsres;
                resortDropDownList.DataTextField = "Contract_Resort_Name";
                resortDropDownList.DataValueField = "Contract_Resort_Name";
                resortDropDownList.AppendDataBoundItems = true;
                resortDropDownList.Items.Insert(0, new ListItem("", ""));
                resortDropDownList.DataBind();
                //weeks
                fwresortDropDownList.DataSource = dsres;
                fwresortDropDownList.DataTextField = "Contract_Resort_Name";
                fwresortDropDownList.DataValueField = "Contract_Resort_Name";
                fwresortDropDownList.AppendDataBoundItems = true;
                fwresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fwresortDropDownList.DataBind();
                //pts
                fptsresortDropDownList.DataSource = dsres;
                fptsresortDropDownList.DataTextField = "Contract_Resort_Name";
                fptsresortDropDownList.DataValueField = "Contract_Resort_Name";
                fptsresortDropDownList.AppendDataBoundItems = true;
                fptsresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fptsresortDropDownList.DataBind();
                

                  
                 
            }
            else
            {
                //load alt or full
                DataSet dsres1 = Queries.LoadFractionalResortNonIndia();
                resortDropDownList.DataSource = dsres1;
                resortDropDownList.DataTextField = "Contract_Resort_Name";
                resortDropDownList.DataValueField = "Contract_Resort_Name";
                resortDropDownList.AppendDataBoundItems = true;
                resortDropDownList.Items.Insert(0, new ListItem("", ""));
                resortDropDownList.DataBind();

                //weeks
                fwresortDropDownList.DataSource = dsres1;
                fwresortDropDownList.DataTextField = "Contract_Resort_Name";
                fwresortDropDownList.DataValueField = "Contract_Resort_Name";
                fwresortDropDownList.AppendDataBoundItems = true;
                fwresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fwresortDropDownList.DataBind();
                //pts
                fptsresortDropDownList.DataSource = dsres1;
                fptsresortDropDownList.DataTextField = "Contract_Resort_Name";
                fptsresortDropDownList.DataValueField = "Contract_Resort_Name";
                fptsresortDropDownList.AppendDataBoundItems = true;
                fptsresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fptsresortDropDownList.DataBind();



            }
            DataSet dsfint = Queries.LoadFractionalInterest();
            FractionalInterestDropDownList.DataSource = dsfint;
            FractionalInterestDropDownList.DataTextField = "Contract_Fractional_Int_Name";
            FractionalInterestDropDownList.DataValueField = "Contract_Fractional_Int_Name";
            FractionalInterestDropDownList.AppendDataBoundItems = true;
            FractionalInterestDropDownList.Items.Insert(0, new ListItem("", ""));
            FractionalInterestDropDownList.DataBind();

            //weeks

            fwfractIntDropDownList.DataSource = dsfint;
            fwfractIntDropDownList.DataTextField = "Contract_Fractional_Int_Name";
            fwfractIntDropDownList.DataValueField = "Contract_Fractional_Int_Name";
            fwfractIntDropDownList.AppendDataBoundItems = true;
            fwfractIntDropDownList.Items.Insert(0, new ListItem("", ""));
            fwfractIntDropDownList.DataBind();

            //pts

            fptsfracintDropDownList.DataSource = dsfint;
            fptsfracintDropDownList.DataTextField = "Contract_Fractional_Int_Name";
            fptsfracintDropDownList.DataValueField = "Contract_Fractional_Int_Name";
            fptsfracintDropDownList.AppendDataBoundItems = true;
            fptsfracintDropDownList.Items.Insert(0, new ListItem("", ""));
            fptsfracintDropDownList.DataBind();


        }

        oldcontracttypeDropDownList.Items.Clear();
        oldcontracttypeDropDownList.Items.Add("");
        oldcontracttypeDropDownList.Items.Add("Points");
        oldcontracttypeDropDownList.Items.Add("Weeks");



    }
   
    public void CreateButton_Click(object sender, EventArgs e)
    {
         
        int i;
        string inst = "Installment No";
        string iamt, idate,ia,idt;
      

        string user =(string)Session["username"];// "Caroline";
        string propertyfee, memberfee;

        if (financeradiobuttonlist.SelectedIndex ==-1)
        {

        }
        else
        {

            string contracttype = contracttypeDropDownList.SelectedItem.Text;
            string contractno = contractnoTextBox.Text;
            string profileid = profileidTextBox.Text;
            string Finance_Details_Id = Queries.GetFinance_Details_Indian();
            string financeradio = financeradiobuttonlist.SelectedItem.Text;
            string currency = currencyDropDownList.SelectedItem.Text;
            string Affiliate_Type = AffiliationvalueTextBox.Text;
            string Total_Price_Including_Tax = totalfinpriceIntaxTextBox.Text;
            string Initial_Deposit_Percent = intialdeppercentTextBox.Text;
            string Initial_Deposit_Amount = initaldepamtTextBox.Text;
            string Balance_Payable = baldepamtTextBox.Text;
            string Total_Inital_Deposit = firstdepamtTextBox.Text;
            string Initial_Deposit_Balance = balinitialdepamtTextBox.Text;
            string Bal_Amount_Payable = balamtpayableTextBox.Text;
            string Payment_Method = PayMethodDropDownList.SelectedItem.Text;
            string No_Installments = NoinstallmentTextBox.Text;
            string Installment_Amount = installmentamtTextBox.Text;
            string Finance_Type = financemethodDropDownList.SelectedItem.Text;
          
         
         
            if(mcRadioButtonList.Checked==true)
            {
                mcwaiver = "Yes";
            }
            else
            {
                mcwaiver = "No";

            }
            
            if (contracttype == "Fractional")
            {
                if (financeradio == "Finance")
                {
                    if (Finance_Type == "Pashuram Finance")
                    {
                        IGSTrate = "18";
                        Interestrate = "11";
                    }
                    else
                    {
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    Finance_No = FinancenoTextBox.Text;
                    documentationfee = findocfeeTextBox.Text;
                    IGST_Amount = igstamtTextBox.Text;
                    No_Emi = noemiTextBox.Text;
                    emiamt = emiamtTextBox.Text;
                }
                else if (financeradio == "Non Finance")
                {

                    Finance_No = "0";
                    documentationfee = "0";
                    IGST_Amount = "0";
                    No_Emi = "0";
                    emiamt = "0";
                    IGSTrate = "0";
                    Interestrate = "0";
                }
                string resort = resortDropDownList.SelectedItem.Text;
                string yr = ffirstyrTextBox.Text;
                string cur = currencyDropDownList.SelectedItem.Text;
                string res = testresTextBox.Text;
                string farr = FractionalInterestDropDownList.SelectedItem.Text;
                //lease back saved on mcfeestextbox
              
                //get mc charges
                DataSet dsmc = Queries.LoadMCChartfractional(resort,yr ,cur,farr ,res );
                if(dsmc.Tables[0].Rows.Count==0)
                {
                    propertyfee = "0";
                    memberfee = "0";

                }
                else
                {
                    propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                    memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                }
                
                int occyr = Convert.ToInt32(ffirstyrTextBox.Text) - 1;
                string mcstartdate = "01/10/" + occyr;

                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text,"",pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee);
               string log1="Contract Created:" +" "+"with Contract # : "+ "contractno" +" "+"for profile ID:"+ profileid+"  "+ "SalesRep:"+contsalesrepDropDownList.SelectedItem.Text + "," +"TO Manager:"+ TOManagerDropDownList.SelectedItem.Text+","+"Button Up:"+ ButtonUpDropDownList.SelectedItem.Text+","+"Deal Date:"+ dealdateTextBox.Text+","+"Deal Status:"+ dealstatusDropDownList.SelectedItem.Text+","+"Contract Created DAte:"+ DateTime.Now.ToShortDateString()+","+ ""+"Contract type:"+ contracttypeDropDownList.SelectedItem.Text+","+"MC Waiver Applicable:"+mcwaiver+","+"Mode:"+ financeradiobuttonlist.SelectedItem.Text+","+"Remark:"+ ""+"Pancard:"+pancardnoTextBox.Text+","+"Adhar card:"+adharcardTextBox.Text+","+"Property fee:"+ propertyfee+","+"MC First Yr:"+mcstartdate+","+"Memberfee:"+memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileid, contractno, log1, user, DateTime.Now.ToString());

                string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian();
                int insertfractional = Queries.InsertContract_Fractional_Indian(ContractFractionalIndian_ID, profileid, contractno, resortDropDownList.SelectedItem.Text, testresnoTextBox.Text, testresTextBox.Text, FractionalInterestDropDownList.SelectedItem.Text, EntitlementFracDropDownList.SelectedItem.Text, ffirstyrTextBox.Text, ftenureTextBox.Text, flastyrTextBox.Text, MCFeesTextBox.Text, propertyfee);
                string log2="Fractional Details:"+"ContractFractionalIndian_ID:"+ ContractFractionalIndian_ID+","+"profileid:"+ profileid+","+"contractno:"+ contractno+","+"Resort:"+ resortDropDownList.SelectedItem.Text+","+"Residence No:"+ testresnoTextBox.Text+","+"Residence type:"+ testresTextBox.Text+","+"Fractional Interest:"+ FractionalInterestDropDownList.SelectedItem.Text+","+"Entitlement:"+ EntitlementFracDropDownList.SelectedItem.Text+","+"1st Yr Occ:"+ ffirstyrTextBox.Text+","+"Tenure:"+ ftenureTextBox.Text+","+"last Yr Occ:"+ flastyrTextBox.Text+","+"Lease Back:"+ MCFeesTextBox.Text+","+"Profperty fee:"+ propertyfee;
                int insertlog2 = Queries.InsertContractLogs_India(profileid, contractno, log2, user, DateTime.Now.ToString());


                int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "");

                string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian();
                int insertpointsPA = Queries.InsertContract_Fractional_PA_Indian(Contract_Fractional_PA_Id, profileid, contractno, AdmissionFeesTextBox.Text, AdministrationFeesTextBox.Text, fcgstTextBox.Text, fsgstTextBox.Text, TotalPurchasePriceTextBox.Text, Total_Price_Including_Tax, fractionaldepositTextBox.Text, fractionalbalanceTextBox.Text, fractionalbalduedateTextBox.Text, remarksTextBox.Text);
                string log4 = "Fractional PA Details:" + "Fractional_PA_Id:" + Contract_Fractional_PA_Id + "," + "Profile:" + profileid + "," + "Contract no:" + contractno + "," + "AdmissionFees:" + AdmissionFeesTextBox.Text + "," + " AdministrationFees:" + AdministrationFeesTextBox.Text + "," + "CGST:" + fcgstTextBox.Text + "," + "SGST:" + fsgstTextBox.Text + "," + "total Purchase price:" + TotalPurchasePriceTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "Deposit Amt:" + fractionaldepositTextBox.Text + "," + "balance:" + fractionalbalanceTextBox.Text + "," + "Balance due dates:" + fractionalbalduedateTextBox.Text + "," + "Remarks:" + remarksTextBox.Text;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractno, log4, user, DateTime.Now.ToString());

                for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                {
                    string installemnt_No = inst + " " + i;
                    ia = "textBox_" + i + "1";
                    iamt = Request.Form[ia];
                    idt = "textBox_" + i + "2";
                    idate = Request.Form[idt];

                   int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate,Queries.GetInstallmentInvoiceNo(office));
                    string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate;
                    int insertlog5 = Queries.InsertContractLogs_India(profileid, contractno, log5, user, DateTime.Now.ToString());
                    //update instalmentno
                    int update = Queries.UpdateInstallmentInvoiceNo(office);
                }
                if (financeradio == "Finance")
                {
                    //get max installmentdate n update finance startdate
                    int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno);
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());
                }
                else if (financeradio == "Non Finance")
                {
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "";
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());

                }

                // update contractno n finance no
                if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian")
                {
                    int updatecontno = Queries.UpdateResortNoInd(VenueDropDownList.SelectedItem.Text, resortDropDownList.SelectedItem.Text);
                }
                else
                {
                    int updatecontno = Queries.UpdateResortNoNonInd(VenueDropDownList.SelectedItem.Text, resortDropDownList.SelectedItem.Text);

                }


                int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type);

             
             
                PrintPdfDropDownList.Items.Clear();
                DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, resortDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text,financeradiobuttonlist.SelectedItem.Text);
                PrintPdfDropDownList.DataSource = ds21;
                PrintPdfDropDownList.DataTextField = "printname";
                PrintPdfDropDownList.DataValueField = "printname";
                PrintPdfDropDownList.AppendDataBoundItems = true;
                PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                PrintPdfDropDownList.DataBind();
                string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);


            }
            else if (contracttype == "Points")
            {
                if (financeradio == "Finance")
                {
                    if (Finance_Type == "Pashuram Finance")
                    {
                        IGSTrate = "18";
                        Interestrate = "19";
                    }
                    else
                    {
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    Finance_No = FinancenoTextBox.Text;
                    documentationfee = findocfeeTextBox.Text;
                    IGST_Amount = igstamtTextBox.Text;
                    No_Emi = noemiTextBox.Text;
                    emiamt = emiamtTextBox.Text;
                }
                else if (financeradio == "Non Finance")
                {

                    Finance_No = "0";
                    documentationfee = "0";
                    IGST_Amount = "0";
                    No_Emi = "0";
                    emiamt = "0";
                    IGSTrate = "0";
                    Interestrate = "0";
                }
                //get mc charges
                DataSet dsmc = Queries.LoadMCChart(pointsclubDropDownList.SelectedItem.Text, firstyrTextBox.Text, currencyDropDownList.SelectedItem.Text);

              
                if (dsmc.Tables[0].Rows.Count == 0)
                {
                    propertyfee = "0";
                    memberfee = "0";

                }
                else
                {
                    propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                    memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                }

                int occyr = Convert.ToInt32(firstyrTextBox.Text) - 1;
                string mcstartdate = "01/10/" + occyr;

                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee);
                 string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileid, contractno, log1, user, DateTime.Now.ToString());



                int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt,"");

                string ContractPoints_ID = Queries.GetContract_Points_Indian();
                int insertpoints = Queries.InsertContract_Points_Indian(ContractPoints_ID, profileid, contractno, pointsclubDropDownList.SelectedItem.Text, newpointsrightTextBox.Text, EntitlementPoinDropDownList.SelectedItem.Text, totalptrightsTextBox.Text, firstyrTextBox.Text, tenureTextBox.Text, lastyrTextBox.Text);
                string  log2="New Points Details:"+"Points ID:"+ContractPoints_ID+","+"Profileid:"+ profileid+","+"ContractNO:"+ contractno+","+"Club:"+ pointsclubDropDownList.SelectedItem.Text+","+"New Points:"+ newpointsrightTextBox.Text+","+"Entitlement:"+ EntitlementPoinDropDownList.SelectedItem.Text+","+"total Points Right:"+ totalptrightsTextBox.Text+","+"1st Yr Occ:"+ firstyrTextBox.Text+","+"Tenure:"+ tenureTextBox.Text+","+"Last Yr Occ:"+ lastyrTextBox.Text;
                int insertlog2 = Queries.InsertContractLogs_India(profileid, contractno, log2, user, DateTime.Now.ToString());

                string Contract_PA_Id = Queries.GetContract_PA_Indian();
                int insertpointsPA = Queries.InsertContract_PA_Indian(Contract_PA_Id, profileid, contractno, newpointsTextBox.Text, conversionfeeTextBox.Text, adminfeeTextBox.Text, totpurchpriceTextBox.Text, cgstTextBox.Text, sgstTextBox.Text, Total_Price_Including_Tax, depositTextBox.Text, balanceTextBox.Text, balancedueTextBox.Text, remarksTextBox.Text);
                string log4="New Points PA:"+"PA_ID:"+Contract_PA_Id+"," + "Profileid:" + profileid + "," + "ContractNO:" + contractno+","+"New Points:"+newpointsTextBox.Text+","+"Conversion Fee:"+ conversionfeeTextBox.Text+","+"Admin Fee:"+ adminfeeTextBox.Text+","+"Total Purchase price:"+ totpurchpriceTextBox.Text+","+"CGST:"+ cgstTextBox.Text+","+"SGST:"+ sgstTextBox.Text+","+"Total Price Incl. Tax:"+ Total_Price_Including_Tax+","+"Deposit Amt:"+ depositTextBox.Text+","+"balance Amt:"+ balanceTextBox.Text+","+"Balance Due date:"+ balancedueTextBox.Text+","+"remark:"+ remarksTextBox.Text;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractno, log4, user, DateTime.Now.ToString());

                for (i = 1; i <=Convert.ToInt32(No_Installments); i++)
                {
                    string installemnt_No = inst + " " + i;
                    ia = "textBox_" + i + "1";
                    iamt = Request.Form [ia];
                    idt = "textBox_" + i + "2";
                    idate = Request.Form[idt];

                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office));
                    string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate;
                    int insertlog5 = Queries.InsertContractLogs_India(profileid, contractno, log5, user, DateTime.Now.ToString());
                    //update instalmentno
                    int update = Queries.UpdateInstallmentInvoiceNo(office);
                }
                 

                if (financeradio == "Finance")
                {
                    //get max installmentdate n update finance startdate
                    int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno);
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());
                }
                else if (financeradio == "Non Finance")
                {
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "";
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());

                }

                //update contractno n finance no 
                //int updatecontno = Queries.UpdateContractNo(VenueDropDownList.SelectedItem.Text, pointsclubDropDownList.SelectedItem.Text, PrimarynationalityDropDownList.SelectedItem.Text);
                if (PrimarynationalityDropDownList.SelectedItem.Text=="Indian")
                {
                    int updatecontno = Queries.UpdateContractNoInd(VenueDropDownList.SelectedItem.Text, pointsclubDropDownList.SelectedItem.Text);

                }
                else
                {
                    int updatecontno = Queries.UpdateContractNoNInd(VenueDropDownList.SelectedItem.Text, pointsclubDropDownList.SelectedItem.Text);
                }

                int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type);
                PrintPdfDropDownList.Items.Clear();

                DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, pointsclubDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text);
                PrintPdfDropDownList.DataSource = ds21;
                PrintPdfDropDownList.DataTextField = "printname";
                PrintPdfDropDownList.DataValueField = "printname";
                PrintPdfDropDownList.AppendDataBoundItems = true;
                PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                PrintPdfDropDownList.DataBind();

                string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            }
            else if (contracttype == "Trade-In-Points")
            {
                if (financeradio == "Finance")
                {
                    if (Finance_Type == "Pashuram Finance")
                    {
                        IGSTrate = "18";
                        Interestrate = "19";
                    }
                    else
                    {
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    Finance_No = FinancenoTextBox.Text;
                    documentationfee = findocfeeTextBox.Text;
                    IGST_Amount = igstamtTextBox.Text;
                    No_Emi = noemiTextBox.Text;
                    emiamt = emiamtTextBox.Text;
                }
                else if (financeradio == "Non Finance")
                {

                    Finance_No = "0";
                    documentationfee = "0";
                    IGST_Amount = "0";
                    No_Emi = "0";
                    emiamt = "0";
                    IGSTrate = "0";
                    Interestrate = "0";
                }
                DataSet dsmc = Queries.LoadMCChart(ntipclubDropDownList.SelectedItem.Text, tipfirstyrTextBox.Text, currencyDropDownList.SelectedItem.Text);

                if (dsmc.Tables[0].Rows.Count == 0)
                {
                    propertyfee = "0";
                    memberfee = "0";

                }
                else
                {
                    propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                    memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                }
                int occyr = Convert.ToInt32(tipfirstyrTextBox.Text) - 1;
                string mcstartdate = "01/10/" + occyr;

                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee);
                string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileid, contractno, log1, user, DateTime.Now.ToString());


                string ContractTradeInPoint_ID = Queries.GetContract_Trade_In_Points_Indian();
                int inserttradeinpoints = Queries.InsertContract_Trade_In_Points_Indian(ContractTradeInPoint_ID, profileid, contractno, tipresortTextBox.Text, tipnopointsTextBox.Text, tipcontnoTextBox.Text, tipptsvalueTextBox.Text, ntipclubDropDownList.SelectedItem.Text, tipnewpointsTextBox.Text, tipmtypeDropDownList.SelectedItem.Text, tiptotalpointsTextBox.Text, tipfirstyrTextBox.Text, tiptenureTextBox.Text, tiplastyrTextBox.Text);

                 string log2="Trade In Points:"+ "Tradeinpoints id:"+ContractTradeInPoint_ID+","+"Profile:"+ profileid+ ","+"Contractno:"+contractno + "," + "Resort:"+ tipresortTextBox.Text + "," + "Points:"+ tipnopointsTextBox.Text + "," + "Cont.No:"+ tipcontnoTextBox.Text + "," + "Points Value:"+ tipptsvalueTextBox.Text + "," + "Club:"+ ntipclubDropDownList.SelectedItem.Text+","+"New Points:"+ tipnewpointsTextBox.Text + "," + "Entitlement:"+ tipmtypeDropDownList.SelectedItem.Text + "," + "Total Points:"+ tiptotalpointsTextBox.Text + "," + "1st Yr Occ:"+ tipfirstyrTextBox.Text + "," + "Tenure:"+ tiptenureTextBox.Text + "," + "Last Yr Occ:"+ tiplastyrTextBox.Text;
                int insertlog2 = Queries.InsertContractLogs_India(profileid, contractno, log2, user, DateTime.Now.ToString());
                int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt,"");

                string Contract_PA_Id = Queries.GetContract_PA_Indian();
                int insertpointsPA = Queries.InsertContract_PA_Indian(Contract_PA_Id, profileid, contractno, newpointsTextBox.Text, conversionfeeTextBox.Text, adminfeeTextBox.Text, totpurchpriceTextBox.Text, cgstTextBox.Text, sgstTextBox.Text, Total_Price_Including_Tax, depositTextBox.Text, balanceTextBox.Text, balancedueTextBox.Text, remarksTextBox.Text);
                string log4 = "Trade in Points PA:" + "PA_ID:" + Contract_PA_Id + "," + "Profileid:" + profileid + "," + "ContractNO:" + contractno + "," + "New Points:" + newpointsTextBox.Text + "," + "Conversion Fee:" + conversionfeeTextBox.Text + "," + "Admin Fee:" + adminfeeTextBox.Text + "," + "Total Purchase price:" + totpurchpriceTextBox.Text + "," + "CGST:" + cgstTextBox.Text + "," + "SGST:" + sgstTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Deposit Amt:" + depositTextBox.Text + "," + "balance Amt:" + balanceTextBox.Text + "," + "Balance Due date:" + balancedueTextBox.Text + "," + "remark:" + remarksTextBox.Text;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractno, log4, user, DateTime.Now.ToString());

                for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                {
                    string installemnt_No = inst + " " + i;
                    ia = "textBox_" + i + "1";
                    iamt = Request.Form[ia];
                    idt = "textBox_" + i + "2";
                    idate = Request.Form[idt];


                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office));
                    string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate;
                    int insertlog5 = Queries.InsertContractLogs_India(profileid, contractno, log5, user, DateTime.Now.ToString());
                    //update instalmentno
                    int update = Queries.UpdateInstallmentInvoiceNo(office);
                }
                //get max installmentdate n update finance startdate
                // int updatefin = Queries.UpdatefinanceStartdate(contractno);
                if (financeradio == "Finance")
                {
                    //get max installmentdate n update finance startdate
                    int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno);
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());
                }
                else if (financeradio == "Non Finance")
                {
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "";
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());

                }
                //update contractno n finance no 
                //  int updatecontno = Queries.UpdateContractNo(VenueDropDownList.SelectedItem.Text, ntipclubDropDownList.SelectedItem.Text, PrimarynationalityDropDownList.SelectedItem.Text);
                if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian")
                {
                    int updatecontno = Queries.UpdateContractNoInd(VenueDropDownList.SelectedItem.Text, ntipclubDropDownList.SelectedItem.Text);

                }
                else
                {
                    int updatecontno = Queries.UpdateContractNoNInd(VenueDropDownList.SelectedItem.Text, ntipclubDropDownList.SelectedItem.Text);
                }
                int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type);
                PrintPdfDropDownList.Items.Clear();
                DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, ntipclubDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text);
                PrintPdfDropDownList.DataSource = ds21;
                PrintPdfDropDownList.DataTextField = "printname";
                PrintPdfDropDownList.DataValueField = "printname";
                PrintPdfDropDownList.AppendDataBoundItems = true;
                PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                PrintPdfDropDownList.DataBind();

                string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            }
            else if (contracttype == "Trade-In-Weeks")
            {
                if (financeradio == "Finance")
                {
                    if (Finance_Type == "Pashuram Finance")
                    {
                        IGSTrate = "18";
                        Interestrate = "19";
                    }
                    else
                    {
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    Finance_No = FinancenoTextBox.Text;
                    documentationfee = findocfeeTextBox.Text;
                    IGST_Amount = igstamtTextBox.Text;
                    No_Emi = noemiTextBox.Text;
                    emiamt = emiamtTextBox.Text;
                }
                else if (financeradio == "Non Finance")
                {

                    Finance_No = "0";
                    documentationfee = "0";
                    IGST_Amount = "0";
                    No_Emi = "0";
                    emiamt = "0";
                    IGSTrate = "0";
                    Interestrate = "0";
                }
                DataSet dsmc = Queries.LoadMCChart(nmclubDropDownList.SelectedItem.Text, nmfirstyrTextBox.Text, currencyDropDownList.SelectedItem.Text);

                if (dsmc.Tables[0].Rows.Count == 0)
                {
                    propertyfee = "0";
                    memberfee = "0";

                }
                else
                {
                    propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                    memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                }
                int occyr = Convert.ToInt32(nmfirstyrTextBox.Text) - 1;
                string mcstartdate = "01/10/" + occyr;
                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate,memberfee);
                string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee;
                int insertlog1 = Queries.InsertContractLogs_India(profileid, contractno, log1, user, DateTime.Now.ToString());

                string ContractTradeInWeeks_ID = Queries.GetContract_Trade_In_Points_Indian();
                int inserttradeinweeks = Queries.InsertContract_Trade_In_Weeks_Indian(ContractTradeInWeeks_ID, profileid, contractno, tnmresortTextBox.Text, tnmapttypeTextBox.Text, tnmseasonDropDownList.SelectedItem.Text, nmnowksTextBox.Text, nmcontrcinoTextBox.Text, nmpointsvalueTextBox.Text, nmclubDropDownList.SelectedItem.Text, nmnewpointsrightsTextBox.Text, nmembtypeDropDownList.SelectedItem.Text, nmtotalpointsTextBox.Text, nmfirstyrTextBox.Text, nmtenureTextBox.Text, nmlastyrTextBox.Text);
                string log2 = "Trade in weeks details:" + "tradeinweeks id:" + ContractTradeInWeeks_ID + "," + "Profile id:" + profileid + "," + "ContractNo:" + contractno + "," + "Resort:" + tnmresortTextBox.Text + "," + "Apt Type:" + tnmapttypeTextBox.Text + "," + "Season:" + tnmseasonDropDownList.SelectedItem.Text + "," + "No Wks:" + nmnowksTextBox.Text + "," + "Cont.No:" + nmcontrcinoTextBox.Text + "," + "PointsValue:" + nmpointsvalueTextBox.Text + "," + "Club:" + nmclubDropDownList.SelectedItem.Text + "," + "New Points:" + nmnewpointsrightsTextBox.Text + "," + "Entitlement:" + nmembtypeDropDownList.SelectedItem.Text + "," + "Total Points:" + nmtotalpointsTextBox.Text + "," + "1st Yr Occ:" + nmfirstyrTextBox.Text + "," + "Tenure:" + nmtenureTextBox.Text + "," + "Last Yr Occ:" + nmlastyrTextBox.Text;
                int insertlog2 = Queries.InsertContractLogs_India(profileid, contractno, log2, user, DateTime.Now.ToString());

                int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt,"");

                string Contract_PA_Id = Queries.GetContract_PA_Indian();
                int insertpointsPA = Queries.InsertContract_PA_Indian(Contract_PA_Id, profileid, contractno, newpointsTextBox.Text, conversionfeeTextBox.Text, adminfeeTextBox.Text, totpurchpriceTextBox.Text, cgstTextBox.Text, sgstTextBox.Text, Total_Price_Including_Tax, depositTextBox.Text, balanceTextBox.Text, balancedueTextBox.Text, remarksTextBox.Text);
                string log4 = "Trade in weeks:" + "PA_ID:" + Contract_PA_Id + "," + "Profileid:" + profileid + "," + "ContractNO:" + contractno + "," + "New Points:" + newpointsTextBox.Text + "," + "Conversion Fee:" + conversionfeeTextBox.Text + "," + "Admin Fee:" + adminfeeTextBox.Text + "," + "Total Purchase price:" + totpurchpriceTextBox.Text + "," + "CGST:" + cgstTextBox.Text + "," + "SGST:" + sgstTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Deposit Amt:" + depositTextBox.Text + "," + "balance Amt:" + balanceTextBox.Text + "," + "Balance Due date:" + balancedueTextBox.Text + "," + "remark:" + remarksTextBox.Text;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractno, log4, user, DateTime.Now.ToString());

                for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                {
                    string installemnt_No = inst + " " + i;
                    ia = "textBox_" + i + "1";
                    iamt = Request.Form[ia];
                    idt = "textBox_" + i + "2";
                    idate = Request.Form[idt];

                    int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office));
                    string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate;
                    int insertlog5 = Queries.InsertContractLogs_India(profileid, contractno, log5, user, DateTime.Now.ToString());
                    //update instalmentno
                    int update = Queries.UpdateInstallmentInvoiceNo(office);
                }
                //get max installmentdate n update finance startdate
                //  int updatefin = Queries.UpdatefinanceStartdate(contractno);
                if (financeradio == "Finance")
                {
                    //get max installmentdate n update finance startdate
                    int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno);
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());
                }
                else if (financeradio == "Non Finance")
                {
                    string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "";
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());

                }
                //update contractno n finance no 
                //   int updatecontno = Queries.UpdateContractNo(VenueDropDownList.SelectedItem.Text, nmclubDropDownList.SelectedItem.Text, PrimarynationalityDropDownList.SelectedItem.Text);
                if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian")
                {
                    int updatecontno = Queries.UpdateContractNoInd(VenueDropDownList.SelectedItem.Text, nmclubDropDownList.SelectedItem.Text);

                }
                else
                {
                    int updatecontno = Queries.UpdateContractNoNInd(VenueDropDownList.SelectedItem.Text, nmclubDropDownList.SelectedItem.Text);
                }
                int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type);
                PrintPdfDropDownList.Items.Clear();

                PrintPdfDropDownList.Items.Clear();

                DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, nmclubDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text);
                PrintPdfDropDownList.DataSource = ds21;
                PrintPdfDropDownList.DataTextField = "printname";
                PrintPdfDropDownList.DataValueField = "printname";
                PrintPdfDropDownList.AppendDataBoundItems = true;
                PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                PrintPdfDropDownList.DataBind();

                string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            }
            else if (contracttype == "Trade-In-Fractionals")
            {
          
                if (oldcontracttypeTextBox.Text == "Weeks")
                {
                    if (financeradio == "Finance")
                    {
                        if (Finance_Type == "Pashuram Finance")
                        {
                            IGSTrate = "18";
                            Interestrate = "11";
                        }
                        else
                        {
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                        Finance_No = FinancenoTextBox.Text;
                        documentationfee = findocfeeTextBox.Text;
                        IGST_Amount = igstamtTextBox.Text;
                        No_Emi = noemiTextBox.Text;
                        emiamt = emiamtTextBox.Text;
                    }
                    else if (financeradio == "Non Finance")
                    {

                        Finance_No = "0";
                        documentationfee = "0";
                        IGST_Amount = "0";
                        No_Emi = "0";
                        emiamt = "0";
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    string resort = fwresortDropDownList.SelectedItem.Text;
                    string yr = fwfirstyrTextBox.Text;
                    string cur = currencyDropDownList.SelectedItem.Text;
                    string res = fwresidencetype1TextBox.Text;
                    string farr = fwfractIntDropDownList.SelectedItem.Text;
                    //lease back saved on mcfeestextbox

                    //get mc charges
                    DataSet dsmc = Queries.LoadMCChartfractional(resort, yr, cur, farr, res);
                    if (dsmc.Tables[0].Rows.Count == 0)
                    {
                        propertyfee = "0";
                        memberfee = "0";

                    }
                    else
                    {
                        propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                        memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                    }

                    int occyr = Convert.ToInt32(fwfirstyrTextBox.Text) - 1;
                    string mcstartdate = "01/10/" + occyr;

                    int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee);
                    string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee;
                    int insertlog1 = Queries.InsertContractLogs_India(profileid, contractno, log1, user, DateTime.Now.ToString());


                    string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian();
                    int insertfractional = Queries.InsertContract_Fractional_Indian(ContractFractionalIndian_ID, profileid, contractno, fwresortDropDownList.SelectedItem.Text, fwresidenceno1TextBox.Text, fwresidencetype1TextBox.Text, fwfractIntDropDownList.SelectedItem.Text, fwentitlementDropDownList.SelectedItem.Text,fwfirstyrTextBox.Text, fwtenureTextBox.Text, fwlastyrTextBox.Text, MCFeesTextBox.Text, propertyfee);
                    string log2 = "Fractional Details:" + "ContractFractionalIndian_ID:" + ContractFractionalIndian_ID + "," + "profileid:" + profileid + "," + "contractno:" + contractno + "," + "Resort:" + fwresortDropDownList.SelectedItem.Text + "," + "Residence No:" + testresnoTextBox.Text + "," + "Residence type:" + testresTextBox.Text + "," + "Fractional Interest:" + FractionalInterestDropDownList.SelectedItem.Text + "," + "Entitlement:" + EntitlementFracDropDownList.SelectedItem.Text + "," + "1st Yr Occ:" + ffirstyrTextBox.Text + "," + "Tenure:" + ftenureTextBox.Text + "," + "last Yr Occ:" + flastyrTextBox.Text + "," + "Lease Back:" + MCFeesTextBox.Text + "," + "Profperty fee:" + propertyfee;
                    int insertlog2 = Queries.InsertContractLogs_India(profileid, contractno, log2, user, DateTime.Now.ToString());

                    string ContractTradeInFractionalIndian_ID = Queries.GetContract_Trade_In_Fractional_Indian();
                    int inserttradeinfractweeks = Queries.InsertContract_Trade_In_Fractional_Indian(ContractTradeInFractionalIndian_ID, profileid, contractno, oldcontracttypeTextBox.Text, fwresorttradeTextBox.Text, fwaptTextBox.Text, fwnowksTextBox.Text, fwseasonDropDownList.SelectedItem.Text, "", fwptsvalueTextBox.Text, fwconnoTextBox.Text);

                    string log6 = "trade in weks to Fractional:" + "TradeInFractionalIndian_ID:" + ContractTradeInFractionalIndian_ID + "," + "Profile ID:" + profileid + "," + "Contract No:" + contractno + "," + "Old Contract No:" + oldcontracttypeTextBox.Text + "," + "Club:" + fwresorttradeTextBox.Text + "," +"Apt:"+ fwaptTextBox.Text+","+"No.Weeks:"+ fwnowksTextBox.Text+","+"Resort:"+ fwseasonDropDownList.SelectedItem.Text+","+ "" + "Points Value:" + fptsvalTextBox.Text + "," + "Cont.No:" + fptscontnoTextBox.Text;
                    int insertlog6 = Queries.InsertContractLogs_India(profileid, contractno, log6, user, DateTime.Now.ToString());

                    int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "");

                    string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian();
                    int insertpointsPA = Queries.InsertContract_Fractional_PA_Indian(Contract_Fractional_PA_Id, profileid, contractno, AdmissionFeesTextBox.Text, AdministrationFeesTextBox.Text, fcgstTextBox.Text, fsgstTextBox.Text, TotalPurchasePriceTextBox.Text, Total_Price_Including_Tax, fractionaldepositTextBox.Text, fractionalbalanceTextBox.Text, fractionalbalduedateTextBox.Text, remarksTextBox.Text);
                    string log4 = "Fractional PA Details:" + "Fractional_PA_Id:" + Contract_Fractional_PA_Id + "," + "Profile:" + profileid + "," + "Contract no:" + contractno + "," + "AdmissionFees:" + AdmissionFeesTextBox.Text + "," + " AdministrationFees:" + AdministrationFeesTextBox.Text + "," + "CGST:" + fcgstTextBox.Text + "," + "SGST:" + fsgstTextBox.Text + "," + "total Purchase price:" + TotalPurchasePriceTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "Deposit Amt:" + fractionaldepositTextBox.Text + "," + "balance:" + fractionalbalanceTextBox.Text + "," + "Balance due dates:" + fractionalbalduedateTextBox.Text + "," + "Remarks:" + remarksTextBox.Text;
                    int insertlog4 = Queries.InsertContractLogs_India(profileid, contractno, log4, user, DateTime.Now.ToString());
                    for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office));
                        string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate;
                        int insertlog5 = Queries.InsertContractLogs_India(profileid, contractno, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                    //get max installmentdate n update finance startdate
                    //    int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    if (financeradio == "Finance")
                    {
                        //get max installmentdate n update finance startdate
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno);
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());
                    }
                    else if (financeradio == "Non Finance")
                    {
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());

                    }
                    // update contractno n finance no
                    if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian")
                    {
                        int updatecontno = Queries.UpdateResortNoInd(VenueDropDownList.SelectedItem.Text, fwresortDropDownList.SelectedItem.Text);
                    }
                    else
                    {
                        int updatecontno = Queries.UpdateResortNoNonInd(VenueDropDownList.SelectedItem.Text, fwresortDropDownList.SelectedItem.Text);

                    }


                    int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type);
                    PrintPdfDropDownList.Items.Clear();
                    DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, fwresortDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                }
                else if (oldcontracttypeTextBox.Text == "Points")
                {
                    if (financeradio == "Finance")
                    {
                        if (Finance_Type == "Pashuram Finance")
                        {
                            IGSTrate = "18";
                            Interestrate = "11";
                        }
                        else
                        {
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                        Finance_No = FinancenoTextBox.Text;
                        documentationfee = findocfeeTextBox.Text;
                        IGST_Amount = igstamtTextBox.Text;
                        No_Emi = noemiTextBox.Text;
                        emiamt = emiamtTextBox.Text;
                    }
                    else if (financeradio == "Non Finance")
                    {

                        Finance_No = "0";
                        documentationfee = "0";
                        IGST_Amount = "0";
                        No_Emi = "0";
                        emiamt = "0";
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    string resort = fptsresortDropDownList.SelectedItem.Text;
                    string yr = fptsfirstyrTextBox.Text;
                    string cur = currencyDropDownList.SelectedItem.Text;
                    string res = fptsresidencetype1TextBox.Text;
                    string farr = fptsfracintDropDownList.SelectedItem.Text;
                    //lease back saved on mcfeestextbox

                    //get mc charges
                    DataSet dsmc = Queries.LoadMCChartfractional(resort, yr, cur, farr, res);
                    if (dsmc.Tables[0].Rows.Count == 0)
                    {
                        propertyfee = "0";
                        memberfee = "0";

                    }
                    else
                    {
                        propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                        memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                    }

                    int occyr = Convert.ToInt32(fptsfirstyrTextBox.Text) - 1;
                    string mcstartdate = "01/10/" + occyr;

                    int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee);
                    string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee;
                    int insertlog1 = Queries.InsertContractLogs_India(profileid, contractno, log1, user, DateTime.Now.ToString());

                    string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian();
                    int insertfractional = Queries.InsertContract_Fractional_Indian(ContractFractionalIndian_ID, profileid, contractno, fptsresortDropDownList.SelectedItem.Text, fptsResidenceno1TextBox.Text, fptsresidencetype1TextBox.Text, fptsfracintDropDownList.SelectedItem.Text, fptsentitlementDropDownList.SelectedItem.Text, fptsfirstyrTextBox.Text, fptstenureTextBox.Text, fptslastyrTextBox.Text, MCFeesTextBox.Text, propertyfee);
                    string log2 = "Fractional Details:" + "ContractFractionalIndian_ID:" + ContractFractionalIndian_ID + "," + "profileid:" + profileid + "," + "contractno:" + contractno + "," + "Resort:" + fptsresortDropDownList.SelectedItem.Text + "," + "Residence No:" + testresnoTextBox.Text + "," + "Residence type:" + testresTextBox.Text + "," + "Fractional Interest:" + FractionalInterestDropDownList.SelectedItem.Text + "," + "Entitlement:" + EntitlementFracDropDownList.SelectedItem.Text + "," + "1st Yr Occ:" + ffirstyrTextBox.Text + "," + "Tenure:" + ftenureTextBox.Text + "," + "last Yr Occ:" + flastyrTextBox.Text + "," + "Lease Back:" + MCFeesTextBox.Text + "," + "Profperty fee:" + propertyfee;
                    int insertlog2 = Queries.InsertContractLogs_India(profileid, contractno, log2, user, DateTime.Now.ToString());


                    string ContractTradeInFractionalIndian_ID = Queries.GetContract_Trade_In_Fractional_Indian();
                    int inserttradeinfractpoints = Queries.InsertContract_Trade_In_Fractional_Indian(ContractTradeInFractionalIndian_ID, profileid, contractno, oldcontracttypeTextBox.Text, fptsclubTextBox.Text, "", "", "", fptsnoptsTextBox.Text, fptsvalTextBox.Text, fptscontnoTextBox.Text);

                    string log6="trade in points to Fractional:"+ "TradeInFractionalIndian_ID:"+ ContractTradeInFractionalIndian_ID+","+ "Profile ID:"+profileid + "," + "Contract No:"+contractno + "," +"Old Contract No:"+ oldcontracttypeTextBox.Text + "," +"Club:"+ fptsclubTextBox.Text + "," + "Points:"+fptsnoptsTextBox.Text + "," +"Points Value:"+ fptsvalTextBox.Text + "," +"Cont.No:"+ fptscontnoTextBox.Text;
                    int insertlog6 = Queries.InsertContractLogs_India(profileid, contractno, log6, user, DateTime.Now.ToString());

                    int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "");

                    string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian();
                    int insertpointsPA = Queries.InsertContract_Fractional_PA_Indian(Contract_Fractional_PA_Id, profileid, contractno, AdmissionFeesTextBox.Text, AdministrationFeesTextBox.Text, fcgstTextBox.Text, fsgstTextBox.Text, TotalPurchasePriceTextBox.Text, Total_Price_Including_Tax, fractionaldepositTextBox.Text, fractionalbalanceTextBox.Text, fractionalbalduedateTextBox.Text, remarksTextBox.Text);
                    string log4 = "Fractional PA Details:" + "Fractional_PA_Id:" + Contract_Fractional_PA_Id + "," + "Profile:" + profileid + "," + "Contract no:" + contractno + "," + "AdmissionFees:" + AdmissionFeesTextBox.Text + "," + " AdministrationFees:" + AdministrationFeesTextBox.Text + "," + "CGST:" + fcgstTextBox.Text + "," + "SGST:" + fsgstTextBox.Text + "," + "total Purchase price:" + TotalPurchasePriceTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "Deposit Amt:" + fractionaldepositTextBox.Text + "," + "balance:" + fractionalbalanceTextBox.Text + "," + "Balance due dates:" + fractionalbalduedateTextBox.Text + "," + "Remarks:" + remarksTextBox.Text;
                    int insertlog4 = Queries.InsertContractLogs_India(profileid, contractno, log4, user, DateTime.Now.ToString());

                    for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office));
                        string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate;
                        int insertlog5 = Queries.InsertContractLogs_India(profileid, contractno, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                    //get max installmentdate n update finance startdate
                    //     int updatefin = Queries.UpdatefinanceStartdate(contractno);
                    if (financeradio == "Finance")
                    {
                        //get max installmentdate n update finance startdate
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno);
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());
                    }
                    else if (financeradio == "Non Finance")
                    {
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractno, log3, user, DateTime.Now.ToString());

                    }
                    // update contractno n finance no
                    if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian")
                    {
                        int updatecontno = Queries.UpdateResortNoInd(VenueDropDownList.SelectedItem.Text, fptsresortDropDownList.SelectedItem.Text);
                    }
                    else
                    {
                        int updatecontno = Queries.UpdateResortNoNonInd(VenueDropDownList.SelectedItem.Text, fptsresortDropDownList.SelectedItem.Text);

                    }


                    int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type);
                    PrintPdfDropDownList.Items.Clear();
                    DataSet ds21 = Queries.LoadPrintPDFFiles_Indian(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, fptsresortDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });   $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                

            }

           


        }


       // string script = "<script> $(function() { $('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
       // ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (financeradiobuttonlist.SelectedItem.Text == "Finance")
        {
            if (contracttypeDropDownList.SelectedItem.Text == "Fractionals")
            {
                DataTable datatable = Queries.Fractional_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();


            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Points")
            {
                DataTable datatable = Queries.NewPoints_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();



            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Points")
            {
                DataTable datatable = Queries.TradeInPoints_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();



            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Weeks")
            {
                DataTable datatable = Queries.TradeInWeeks_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();



            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Fractionals")
                {



                }
        }
        else if (financeradiobuttonlist.SelectedItem.Text == "Non Finance")
        {
            if (contracttypeDropDownList.SelectedItem.Text == "Fractionals")
            {
                DataTable datatable = Queries.Fractional_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();


            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Points")
            {
                DataTable datatable = Queries.NewPoints_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();



            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Points")
            {
                DataTable datatable = Queries.TradeInPoints_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();


            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Weeks")
            {
                DataTable datatable = Queries.TradeInWeeks_PA(contractnoTextBox.Text);
                string printr = PrintPdfDropDownList.SelectedItem.Text;
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);
                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/pdf");
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                Response.Close();



            }
            else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Fractionals")
            {



            }

        }
       

       
      





      
    }


    [WebMethod]
    public static string getPointsAmoountTax(string currency)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string JSON = "{\n \"names\":[";
        string query = "select amount,taxValue from PointsContract where currency='"+currency+"' and status='Active' ;";
        SqlCommand sql =new SqlCommand(query,sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            double amount = reader.GetDouble(0);
            double tax = reader.GetDouble(1);
            JSON += "[\"" + amount + "\",\"" + tax + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    //Code commented by gaurav 8-12-2017
    //[WebMethod]
    //public static string getContractnoOnClub(string venue, string venuegrp, string club,string nationality)
    //{

    //    string JSON = "{\n \"names\":[";
    //    if(nationality=="Indian")
    //    {
    //        SqlDataReader reader = Queries.GetIncrementValueofContractClubIndian(venue, venuegrp, club, nationality);
    //        while (reader.Read())
    //        {
    //            string code = reader.GetString(0);
    //            //  string src = reader.GetString(1);
    //            //  string inc = reader.GetString(2);
    //            //JSON += "[\"" + code + "\",\"" + src + "\",\"" + inc + "\"],";

    //            JSON += "[\"" + code + "\"],";
    //        }
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";

    //    }

    //    else
    //    {
    //        SqlDataReader reader = Queries.GetIncrementValueofContractClubNonIndian(venue, venuegrp, club, nationality);
    //        while (reader.Read())
    //        {
    //            string code = reader.GetString(0);
    //            //  string src = reader.GetString(1);
    //            //  string inc = reader.GetString(2);
    //            //JSON += "[\"" + code + "\",\"" + src + "\",\"" + inc + "\"],";
    //            JSON += "[\"" + code + "\"],";
    //        }
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";

    //    }


    //    return JSON;

    //}




        // new code gaurav
    [WebMethod]
        public static string getContractnoOnClub(string venue,string venuegrp,string club,string nationality)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string JSON = "{\n \"names\":[";
        if (nationality == "Indian")
        {
            string query = "SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and cc.Nationality ='Indian'";
            SqlCommand sql = new SqlCommand(query, sqlcon);

            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                string code = reader.GetString(0);
                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            string query = "SELECT Contract_Code + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + Increment_Value + vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and cc.Nationality !='Indian'";
            SqlCommand sql = new SqlCommand(query, sqlcon);

            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                string code = reader.GetString(0);
                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
           

        return JSON;
    }



    [WebMethod]
    public static string getFinanceNo(string venue, string finance,string type)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.GetFinanceNoIncrementValue(venue,finance,type);
        while (reader.Read())
        {
            string code = reader.GetString(0);
             
            JSON += "[\"" + code + "\"],";
           
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string GetfractionalResidenceType(string resort)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadfractionalResidencetype(resort);
        while (reader.Read())
        {
            string type = reader.GetString(0);

            JSON += "[\"" + type + "\"],";

        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadfractionalResidenceNo(string resort)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadfractionalResidenceNo(resort);
        while (reader.Read())
        {
            string mn = reader.GetString(0);

            JSON += "[\"" + mn + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }



    [WebMethod]
    public static string getContractnoOnResort(string venue, string club, string nationality)
    {

        string JSON = "{\n \"names\":[";
        if (nationality == "Indian")

        {
            SqlDataReader reader = Queries.GetIncrementValueofContractResortIndian(venue, club);//, nationality);
            while (reader.Read())
            {
                string code = reader.GetString(0);
                 
                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetIncrementValueofContractResortNonIndian(venue, club);//, nationality);
            while (reader.Read())
            {
                string code = reader.GetString(0);

                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        return JSON;

    }







}



