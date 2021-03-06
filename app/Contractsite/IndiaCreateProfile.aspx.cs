﻿using System;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        string user =(string) Session["username"];

        if (!Page.IsPostBack)
        {
           // string user = "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);
       
            ProfileIDTextBox.ReadOnly = true;
            ProfileIDTextBox.Text = Queries.GetProfileID(office);// VenueCountryDropDownList.SelectedItem.Text);

            // ProfileIDTextBox.Text = Queries.GetProfileID(office);

            //load values in respective dropdown listbox

            DataSet ds = Queries.LoadVenueCountry();
        VenueCountryDropDownList.DataSource = ds;
        VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
        VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
        VenueCountryDropDownList.AppendDataBoundItems = true;
        VenueCountryDropDownList.Items.Insert(0, new ListItem("", ""));
        VenueCountryDropDownList.DataBind();

            GroupVenueDropDownList.Items.Clear();
            VenueDropDownList.Items.Clear();
            MarketingPrgmDropDownList.Items.Clear();

            //load agent code
        //    DataSet ds5 = Queries.LoadAgentCode();
        //TONameDropDownList.DataSource = ds5;
        //TONameDropDownList.DataTextField = "Agent_Code_Name";
        //TONameDropDownList.DataValueField = "Agent_Code_Name";
        //TONameDropDownList.AppendDataBoundItems = true;
        //TONameDropDownList.Items.Insert(0, new ListItem("", ""));
        //TONameDropDownList.DataBind();

        //load membertype
        DataSet ds6 = Queries.LoadMemberType();
        MemType1DropDownList.DataSource = ds6;
        MemType1DropDownList.DataTextField = "Member_Type_name";
        MemType1DropDownList.DataValueField = "Member_Type_name";
        MemType1DropDownList.AppendDataBoundItems = true;
        MemType1DropDownList.Items.Insert(0, new ListItem("", ""));
        MemType1DropDownList.DataBind();

        DataSet ds7 = Queries.LoadMemberType();
        MemType2DropDownList.DataSource = ds7;
        MemType2DropDownList.DataTextField = "Member_Type_name";
        MemType2DropDownList.DataValueField = "Member_Type_name";
        MemType2DropDownList.AppendDataBoundItems = true;
        MemType2DropDownList.Items.Insert(0, new ListItem("", ""));
        MemType2DropDownList.DataBind();


        //load country names in respective country dropdowns
        DataSet ds8 = Queries.LoadCountryName();
        PrimaryCountryDropDownList.DataSource = ds8;
        PrimaryCountryDropDownList.DataTextField = "country_name";
        PrimaryCountryDropDownList.DataValueField = "country_name";
        PrimaryCountryDropDownList.AppendDataBoundItems = true;
        PrimaryCountryDropDownList.Items.Insert(0, new ListItem("", ""));
        PrimaryCountryDropDownList.DataBind();

        DataSet ds9 = Queries.LoadCountryName();
        SecondaryCountryDropDownList.DataSource = ds9;
        SecondaryCountryDropDownList.DataTextField = "country_name";
        SecondaryCountryDropDownList.DataValueField = "country_name";
        SecondaryCountryDropDownList.AppendDataBoundItems = true;
        SecondaryCountryDropDownList.Items.Insert(0, new ListItem("", ""));
        SecondaryCountryDropDownList.DataBind();

        DataSet ds10 = Queries.LoadCountryName();
        SubProfile1CountryDropDownList.DataSource = ds10;
        SubProfile1CountryDropDownList.DataTextField = "country_name";
        SubProfile1CountryDropDownList.DataValueField = "country_name";
        SubProfile1CountryDropDownList.AppendDataBoundItems = true;
        SubProfile1CountryDropDownList.Items.Insert(0, new ListItem("", ""));
        SubProfile1CountryDropDownList.DataBind();

        DataSet ds11 = Queries.LoadCountryName();
        SubProfile2CountryDropDownList.DataSource = ds11;
        SubProfile2CountryDropDownList.DataTextField = "country_name";
        SubProfile2CountryDropDownList.DataValueField = "country_name";
        SubProfile2CountryDropDownList.AppendDataBoundItems = true;
        SubProfile2CountryDropDownList.Items.Insert(0, new ListItem("", ""));
        SubProfile2CountryDropDownList.DataBind();


           // load country with code for mobile nos n alternate nos
            DataSet ds12 = Queries.LoadCountryWithCode();
        primarymobileDropDownList.DataSource = ds12;
        primarymobileDropDownList.DataTextField = "name";
        primarymobileDropDownList.DataValueField = "name";
        primarymobileDropDownList.AppendDataBoundItems = true;
        primarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
        primarymobileDropDownList.DataBind(); 

            DataSet ds12a = Queries.LoadCountryWithCode();
        primaryalternateDropDownList.DataSource = ds12a;
        primaryalternateDropDownList.DataTextField = "name";
        primaryalternateDropDownList.DataValueField = "name";
        primaryalternateDropDownList.AppendDataBoundItems = true;
        primaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
        primaryalternateDropDownList.DataBind();

        DataSet ds13 = Queries.LoadCountryWithCode();
        secondarymobileDropDownList.DataSource = ds13;
        secondarymobileDropDownList.DataTextField = "name";
        secondarymobileDropDownList.DataValueField = "name";
        secondarymobileDropDownList.AppendDataBoundItems = true;
        secondarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
        secondarymobileDropDownList.DataBind(); 
        DataSet ds13a = Queries.LoadCountryWithCode();
        secondaryalternateDropDownList.DataSource = ds13a;
        secondaryalternateDropDownList.DataTextField = "name";
        secondaryalternateDropDownList.DataValueField = "name";
        secondaryalternateDropDownList.AppendDataBoundItems = true;
        secondaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
        secondaryalternateDropDownList.DataBind();

        DataSet ds14 = Queries.LoadCountryWithCode();
        subprofile1mobileDropDownList.DataSource = ds14;
        subprofile1mobileDropDownList.DataTextField = "name";
        subprofile1mobileDropDownList.DataValueField = "name";
        subprofile1mobileDropDownList.AppendDataBoundItems = true;
        subprofile1mobileDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile1mobileDropDownList.DataBind(); 
        DataSet ds14a = Queries.LoadCountryWithCode();
        subprofile1alternateDropDownList.DataSource = ds14a;
        subprofile1alternateDropDownList.DataTextField = "name";
        subprofile1alternateDropDownList.DataValueField = "name";
        subprofile1alternateDropDownList.AppendDataBoundItems = true;
        subprofile1alternateDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile1alternateDropDownList.DataBind();

        DataSet ds15 = Queries.LoadCountryWithCode();
        subprofile2mobileDropDownList.DataSource = ds15;
        subprofile2mobileDropDownList.DataTextField = "name";
        subprofile2mobileDropDownList.DataValueField = "name";
        subprofile2mobileDropDownList.AppendDataBoundItems = true;
        subprofile2mobileDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile2mobileDropDownList.DataBind();
        DataSet ds15a = Queries.LoadCountryWithCode();
        subprofile2alternateDropDownList.DataSource = ds15a;
        subprofile2alternateDropDownList.DataTextField = "name";
        subprofile2alternateDropDownList.DataValueField = "name";
        subprofile2alternateDropDownList.AppendDataBoundItems = true;
        subprofile2alternateDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile2alternateDropDownList.DataBind();

        //load nationality

        DataSet ds16 = Queries.LoadNationality();
        primarynationalityDropDownList.DataSource = ds16;
        primarynationalityDropDownList.DataTextField = "nationality_name";
        primarynationalityDropDownList.DataValueField = "nationality_name";
        primarynationalityDropDownList.AppendDataBoundItems = true;
        primarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        primarynationalityDropDownList.DataBind();

        DataSet ds17 = Queries.LoadNationality();
        secondarynationalityDropDownList.DataSource = ds17;
        secondarynationalityDropDownList.DataTextField = "nationality_name";
        secondarynationalityDropDownList.DataValueField = "nationality_name";
        secondarynationalityDropDownList.AppendDataBoundItems = true;
        secondarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        secondarynationalityDropDownList.DataBind();

        DataSet ds18 = Queries.LoadNationality();
        subprofile1nationalityDropDownList.DataSource = ds18;
        subprofile1nationalityDropDownList.DataTextField = "nationality_name";
        subprofile1nationalityDropDownList.DataValueField = "nationality_name";
        subprofile1nationalityDropDownList.AppendDataBoundItems = true;
        subprofile1nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile1nationalityDropDownList.DataBind();

        DataSet ds19 = Queries.LoadNationality();
        subprofile2nationalityDropDownList.DataSource = ds19;
        subprofile2nationalityDropDownList.DataTextField = "nationality_name";
        subprofile2nationalityDropDownList.DataValueField = "nationality_name";
        subprofile2nationalityDropDownList.AppendDataBoundItems = true;
        subprofile2nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile2nationalityDropDownList.DataBind();


        //load guest status
        DataSet ds20 = Queries.LoadGuestStatus();
        gueststatusDropDownList.DataSource = ds20;
        gueststatusDropDownList.DataTextField = "Guest_Status_name";
        gueststatusDropDownList.DataValueField = "Guest_Status_name";
        gueststatusDropDownList.AppendDataBoundItems = true;
        gueststatusDropDownList.Items.Insert(0, new ListItem("", ""));
        gueststatusDropDownList.DataBind();

 

            //load Employment status
            DataSet dsemploy = Queries.LoadEmploymentStatus();
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem("", ""));
            employmentstatusDropDownList.DataBind();

         

            //load marital status
            DataSet dsmart = Queries.LoadMaritalStatus();
            MaritalStatusDropDownList.DataSource = dsmart;
            MaritalStatusDropDownList.DataTextField = "MaritalStatus";
            MaritalStatusDropDownList.DataValueField = "MaritalStatus";
            MaritalStatusDropDownList.AppendDataBoundItems = true;
            MaritalStatusDropDownList.Items.Insert(0, new ListItem("", ""));
            MaritalStatusDropDownList.DataBind();

            //load gift

            DataSet dsgift = Queries.LoadGiftOption();
            giftListBox.DataSource = dsgift;
            giftListBox.DataTextField = "item";
            giftListBox.DataValueField = "item";
            giftListBox.DataBind();

            //load title dropdown

            createddateTextBox.Text = DateTime.Today.ToString("yyyy/MM/dd");

            DataSet dsptitle = Queries.LoadSalutations();
            primarytitleDropDownList.DataSource = dsptitle;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
            primarytitleDropDownList.DataBind();

            DataSet dsstitle = Queries.LoadSalutations();
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
            secondarytitleDropDownList.DataBind();


            DataSet dssp1title = Queries.LoadSalutations();
            subprofile1titleDropDownList.DataSource = dssp1title;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile1titleDropDownList.DataBind();


            DataSet dssp2title = Queries.LoadSalutations();
            subprofile2titleDropDownList.DataSource = dssp2title;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile2titleDropDownList.DataBind();


            DataSet ds21 = Queries.LoadCountryName();
            AddCountryDropDownList.DataSource = ds21;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem("", ""));
            AddCountryDropDownList.DataBind();

            /*    primarytitleDropDownList.Items.Add("");
            primarytitleDropDownList.Items.Add("Mr");
            primarytitleDropDownList.Items.Add("Ms");
            primarytitleDropDownList.Items.Add("Mrs");
            primarytitleDropDownList.Items.Add("Adv");
            primarytitleDropDownList.Items.Add("Dr");


            secondarytitleDropDownList.Items.Add("");
            secondarytitleDropDownList.Items.Add("Mr");
            secondarytitleDropDownList.Items.Add("Ms");
            secondarytitleDropDownList.Items.Add("Mrs");
            secondarytitleDropDownList.Items.Add("Adv");
            secondarytitleDropDownList.Items.Add("Dr");


            subprofile1titleDropDownList.Items.Add("");
            subprofile1titleDropDownList.Items.Add("Mr");
            subprofile1titleDropDownList.Items.Add("Ms");
            subprofile1titleDropDownList.Items.Add("Mrs");
            subprofile1titleDropDownList.Items.Add("Adv");
            subprofile1titleDropDownList.Items.Add("Dr");

            subprofile2titleDropDownList.Items.Add("");
            subprofile2titleDropDownList.Items.Add("Mr");
            subprofile2titleDropDownList.Items.Add("Ms");
            subprofile2titleDropDownList.Items.Add("Mrs");
            subprofile2titleDropDownList.Items.Add("Adv");
            subprofile2titleDropDownList.Items.Add("Dr");*/
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

       //display username
        string user = CreatedByTextBox.Text;  
       
            //get office of user
            string office = Queries.GetOffice(user);
        int year = DateTime.Now.Year;
            //venue details

            string createdby = CreatedByTextBox.Text;
        string venuecountry = Request.Form[VenueCountryDropDownList.UniqueID];// .SelectedItem.Text;
        string venue = Request.Form[VenueDropDownList.UniqueID];//.SelectedItem.Text;
        string venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];// GroupVenueDropDownList.SelectedItem.Text;
        string mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];// MarketingPrgmDropDownList.SelectedItem.Text;
        string agents = Request.Form[AgentsDropDownList.UniqueID];// AgentsDropDownList.SelectedItem.Text;
        string agentcode = Request.Form[TONameDropDownList.UniqueID];// TONameDropDownList.SelectedItem.Text;
        string mgr = Request.Form[ManagerDropDownList.UniqueID];// .SelectedItem.Text;
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
        if (PrimaryCountryDropDownList.SelectedIndex == 0)
        {
            pcc = "";
            paltrcc = "";
            pmobile = "0";
            palternate = "0";
        }
        else
        {
            //if (primarymobileDropDownList.SelectedIndex == 0)
            //{
            //    pcc = "";

            //}
            //else
            //{
                pcc = primarymobileDropDownList.SelectedItem.Text;

            //  }
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
        if (SecondaryCountryDropDownList.SelectedIndex == 0)
        {
            scc = "";
            saltcc = "";
            smobile = "0";
            salternate = "0";
        }
        else
        {
            //if (secondarymobileDropDownList.SelectedIndex == 0)
            //{
            //    scc = "";
            //}
            //else
            //{

                scc = secondarymobileDropDownList.SelectedItem.Text;
                //}

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
        if (SubProfile1CountryDropDownList.SelectedIndex == 0)
        {
            sp1cc = "";
            sp1altcc = "";
            sp1mobile = "0";
            sp1alternate = "0";
        }
        else
        {
            //if (subprofile1mobileDropDownList.SelectedIndex == 0)
            //{
            //    sp1cc = "";
            //}
            //else
            //{

                sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;
                //}

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
        if (SubProfile2CountryDropDownList.SelectedIndex == 0)
        {
            sp2cc = "";
            sp2altccc = "";
            sp2mobile = "0";
            sp2alternate = "0";
        }
        else
        {

            //if (subprofile2mobileDropDownList.SelectedIndex == 0)
            //{
            //    sp2cc = "";
            //}
            //else
            //{

                sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;
                //}

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
        string salesrep;
        string salesrep1 = Request.Form[salesrepDropDownList.UniqueID];//salesrepDropDownList.SelectedItem.Text;
        if (salesrep1=="" || salesrep1== null)
        {
            salesrep = "";
        }
        else
        {
             salesrep = Request.Form[salesrepDropDownList.UniqueID];
        }
        string timeIn = deckcheckintimeTextBox.Text;
        string timeOut = deckcheckouttimeTextBox.Text;
        string tourdate = tourdatedatepicker.Text;
        string taxin = taxipriceInTextBox.Text;
        string taxirefin = TaxiRefInTextBox.Text;
        string taxiout = TaxiPriceOutTextBox.Text;
        string taxirefout = TaxiRefOutTextBox.Text;

        int exists = Queries.ProfileExists(ProfileIDTextBox.Text);
        if (exists == 0)
        {


            //insert  profile
          //  if (VenueCountryDropDownList.SelectedIndex == 0 || VenueDropDownList.SelectedIndex == 0)
          if(venuecountry=="")
            { }
            else
            {
                int profile = Queries.InsertProfile(ProfileIDTextBox.Text, DateTime.Now, createdby, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs,office,commentTextBox.Text,mgr);
                string log1 = "Profile Details:" + " " + "Profile ID:" + ProfileIDTextBox.Text + "," + "Created date:" + createddateTextBox.Text + "," + CreatedByTextBox.Text + "," + "venue country:" + venuecountry + "," + "mktg prgm:" + mktg + "," + "Agent:" + agents + "," + "TO Name:" + agentcode + "," +"Manager:"+mgr+","+ "membertype1:" + membertype1 + "," + "memno1:" + memno1 + "," + "membertype2:" + membertype2 + "," + "memno2:" + memno2 + "," + "Employmentstatus:" + employmentstatus + "," + "Maritalstatus:" + maritalstatus + "," + "Living Yrs:" + livingyrs + "," + "Office:" + office + "," + "Comments:" + commentTextBox.Text;
                int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text , "", log1, user, DateTime.Now.ToString());
                //insert into primary profile
                string primaryprofileid = Queries.GetPrimaryProfileID(office);
                int primary = Queries.InsertPrimaryProfile(primaryprofileid, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry, ProfileIDTextBox.Text);

                string log2="Primary details:"+" "+"primary id:"+ primaryprofileid+","+"title:"+ primarytitle+","+"Fname:"+ primaryfname+","+"Lname:"+ primaylname+","+"DOB:"+ primarydob+","+"nationality:"+primarynationality+","+"Country:"+ primarycountry+","+"Profile ID:"+ ProfileIDTextBox.Text;
                int insertlog2 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log2, user, DateTime.Now.ToString());
                
                //insert secondaryprofileid
                string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                int secondary = Queries.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, ProfileIDTextBox.Text);
                string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + ProfileIDTextBox.Text;
                int insertlog3 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log3, user, DateTime.Now.ToString());

                //insert address details
                string addressID = Queries.GetAddressProfileID(office);
                int address = Queries.InsertProfileAddress(addressID, address1, address2, state, city, pincode, DateTime.Now, "", ProfileIDTextBox.Text, acountry);

                string log4 = "Address details:" + " " + "address  id:" + addressID + "," + "address1:" + address1 + "," + "address2:" + address2 + "," + "state:" + state + "," + "city:" + city + "," + "pincode:" + pincode + ","+ "Country: " + acountry + "," + "Created Date:" + DateTime.Now + "," + "Profile ID:" + ProfileIDTextBox.Text;
                int insertlog4 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log4, user, DateTime.Now.ToString());


                //insert into sub profile1

                string subprofile1id = Queries.GetSubProfile1ID(office);
                int subprofielid = Queries.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, ProfileIDTextBox.Text);

                string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + ProfileIDTextBox.Text;
                int insertlog5 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log5, user, DateTime.Now.ToString());
                //insert into sub profile2

                string subprofile2id = Queries.GetSubProfile2ID(office);
                int subprofielid2 = Queries.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, ProfileIDTextBox.Text);
                string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" +sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + ProfileIDTextBox.Text;
                int insertlog6 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log6, user, DateTime.Now.ToString());



                //  insert phone
                string phid = Queries.GetPhoneID(office);
                int phone = Queries.InsertPhone(phid, ProfileIDTextBox.Text, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate);
                string log7 = "Phone Details:" + " " + "Phone id:" + phid + "," + "Profile id:" + ProfileIDTextBox.Text + "," + "Primary mobile:" + pcc + "" + pmobile + "," + "primary alternate:" + paltrcc + "" + palternate + "," + "Secondary mobile:" + scc + "" + smobile + "," + "Secondary alternate:" + saltcc + "" + salternate + "," + "Subprofile1 mobile:" + sp1cc + " " + sp1mobile + "," + "Subprofile1 alternate:" + sp1altcc + "" + sp1alternate + "," + "Subprofile2 mobile:" + sp2cc + "" + sp2mobile + "," + "subprofile2 alternate:" + sp2altccc + "" + sp2alternate;
                int insertlog7 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log7, user, DateTime.Now.ToString());
                //email
                string emid = Queries.GetEmailID(office);
                int email = Queries.InsertEmail(emid, ProfileIDTextBox.Text, pemail, semail, sp1email, sp2email);
                string log8="Email Details:"+" "+"Email id:"+ emid+","+"profile id:"+ ProfileIDTextBox.Text+","+"Primary email:"+ pemail+","+"Secondary email:"+ semail+","+"Subprofile1 email:"+ sp1email+","+"subprofile2 email:"+ sp2email;
                int insertlog8 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log8, user, DateTime.Now.ToString());

                //insert  stay details
                string stayid = Queries.GetStayDetailsID(office);
                int staydetails = Queries.InsertProfileStay(stayid, resort, roomno, arrivaldate, departuredate, ProfileIDTextBox.Text);
                string log9 = "Stay details:" + " " + "Stay ID:" + stayid + "," + "Resort:" + resort + "," + "room#:" + roomno + "," + "Arrival date:" + arrivaldate + "," + "Departure date:" + departuredate + "," + "Profile id:" + ProfileIDTextBox.Text;
                int insertlog9 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log9, user, DateTime.Now.ToString());
                //tour details

                string tourid = Queries.GetTourDetailsID(office);
                int tourdetails = Queries.InsertTourDetails(tourid, gueststatus, salesrep, tourdate , timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout, ProfileIDTextBox.Text);
                string log10 = "Tour Details:" + "Tour ID:" + tourid + "," + "Guest status:" + gueststatus + "," + "Sales rep:" + salesrep + "," + "tour date:" + tourdate + "," + "Time in:" + timeIn + "," + "Time out:" + timeOut + "," + "Taxi In:" + taxin + "," + "Taxi Ref In:" + taxirefin + "," + "taxi out:" + taxiout + "," + "taxi Ref out:" + taxirefout + "," + "Profile id:" + ProfileIDTextBox.Text;
                int insertlog10 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log10, user, DateTime.Now.ToString());

                //update profile id to 1
                int update = Queries.UpdateProfileValue(office, year);
                int updatep = Queries.UpdatePrimaryValue(office, year);
                int updates = Queries.UpdateSecondaryValue(office, year);
                int updatesp1 = Queries.UpdateSubprofile1Value(office, year);

                int updatesp2 = Queries.UpdateSubprofile2Value(office, year);
                int updateadd = Queries.UpdateAddressValue(office, year);
                int updatestay = Queries.UpdateStayValue(office, year);
                int updatetour = Queries.UpdateTourValue(office, year);
                int updatephone = Queries.UpdatePhoneValue(office, year);
                int updateemail = Queries.UpdateEmailValue(office, year);
                int x = 0;
                foreach (ListItem item in giftListBox.Items)
                {
                   
                    string gift = item.ToString();
                    string[] giftlist = gift.Split('-');
                    string giftoption = giftlist[0];
                    string giftitem = giftlist[1];
                    if (item.Selected==true)
                    {

                        string giftid = Queries.GetProfileGift(office);

                        int insert = Queries.InsertGiftOption(giftid, giftoption, vouchernoTextBox.Text, commentTextBox.Text, ProfileIDTextBox.Text, giftitem);
                        int updategift = Queries.UpdateGiftValue(office, year);
                        string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftoption + "," + "Voucherno:" + vouchernoTextBox.Text + "," + "Comments:" + commentTextBox.Text + "," + "Profile id:" + ProfileIDTextBox.Text + "," + "Item:" + giftitem;
                        int insertlog11 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", log11, user, DateTime.Now.ToString());
                        x++;
                    }
                }

                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Profile created succesfully');", true);

            }
            //Queries.ProfileView(ProfileIDTextBox.Text);
            DataTable datatable = Queries2.loadregcard(ProfileIDTextBox.Text);
            var printr = "Guest REg form india";
            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
            crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
            crystalReport.SetDataSource(datatable);

            System.IO.FileStream fs = null;
            long FileSize = 0;
            DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
            //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
            string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
            crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            oDest.DiskFileName = ExportFileName;
            crystalReport.ExportOptions.DestinationOptions = oDest;
            crystalReport.Export();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Type", "application/pdf");
            string fn = "Guest Reg Form" + ".pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

            fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
            FileSize = fs.Length;
            byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
            fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            fs.Close();
            Response.BinaryWrite(bBuffer);
            Response.Flush();
            string script = "<script>$(function() {alert('hi')});}</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            //Response.Close();

         

        }
        else if(exists==1)
        {
            //Queries.ProfileView(ProfileIDTextBox.Text);

            DataTable datatable = Queries2.loadregcard(ProfileIDTextBox.Text);
            var printr = "Guest REg form india";
            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
            crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
            crystalReport.SetDataSource(datatable);

            System.IO.FileStream fs = null;
            long FileSize = 0;
            DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
            //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
            string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
            crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            oDest.DiskFileName = ExportFileName;
            crystalReport.ExportOptions.DestinationOptions = oDest;
            crystalReport.Export();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Type", "application/pdf");
            string fn = "Guest Reg Form" + ".pdf";
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
        



    }


    protected void VenueCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////get code
        //string venuecountry =Queries.GetVenueCountryCode( VenueCountryDropDownList.SelectedItem.Text);
        ////ProfileIDTextBox.ReadOnly = true;
        ////ProfileIDTextBox.Text = Queries.GetProfileID(VenueCountryDropDownList.SelectedItem.Text);

        //DataSet ds1 = Queries.LoadVenuebasedOnCountryID(venuecountry);
        //VenueDropDownList.DataSource = ds1;
        //VenueDropDownList.DataTextField = "Venue_Name";
        //VenueDropDownList.DataValueField = "Venue_Name";
        //VenueDropDownList.AppendDataBoundItems = true;
        //VenueDropDownList.Items.Insert(0, new ListItem("", ""));
        //VenueDropDownList.DataBind();
    }
    protected void VenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GroupVenueDropDownList.Items.Clear();
        ////get venue code based on venue 
        //string venuecode= Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));

        
        //DataSet ds1 = Queries.LoadVenueGroup(venuecode);
        //GroupVenueDropDownList.DataSource = ds1;
        //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        //GroupVenueDropDownList.AppendDataBoundItems = true;
        //GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        //GroupVenueDropDownList.DataBind();

        //load sales rep

        //DataSet ds21 = Queries.LoadSalesRep();
        //salesrepDropDownList.DataSource = ds21;
        //salesrepDropDownList.DataTextField = "sales_rep_name";
        //salesrepDropDownList.DataValueField = "sales_rep_name";
        //salesrepDropDownList.AppendDataBoundItems = true;
        //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
        //salesrepDropDownList.DataBind();

        //DataSet ds21 = Queries.LoadSalesReponVenue(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));
        //salesrepDropDownList.DataSource = ds21;
        //salesrepDropDownList.DataTextField = "sales_rep_name";
        //salesrepDropDownList.DataValueField = "sales_rep_name";
        //salesrepDropDownList.AppendDataBoundItems = true;
        //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
        //salesrepDropDownList.DataBind();


    }

    protected void GroupVenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //MarketingPrgmDropDownList.Items.Clear();
        //AgentsDropDownList.Items.Clear();
        //TONameDropDownList.Items.Clear();
        //ManagerDropDownList.Items.Clear();
        ////get code
        //string venuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);


        //// DataSet ds1 = Queries.LoadMarketingProgram(venuecode);
        //DataSet ds1 = Queries.LoadMarketingProgramOnVenueNVGroup(VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
        //MarketingPrgmDropDownList.DataSource = ds1;
        //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.AppendDataBoundItems = true;
        //MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        //MarketingPrgmDropDownList.DataBind();

        ////load agents based on venue n venue group
        //DataSet ds2 = Queries.LoadAgentsOnVenue(VenueDropDownList.SelectedItem.Text);//, GroupVenueDropDownList.SelectedItem.Text);
        //AgentsDropDownList.DataSource = ds2;
        //AgentsDropDownList.DataTextField = "Agent_Name";
        //AgentsDropDownList.DataValueField = "Agent_Name";
        //AgentsDropDownList.AppendDataBoundItems = true;
        //AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
        //AgentsDropDownList.DataBind();

        ////load to based on venue n venue group
        //DataSet ds3 = Queries.LoadTOOPCOnVenue(VenueDropDownList.SelectedItem.Text);//, GroupVenueDropDownList.SelectedItem.Text);
        //TONameDropDownList.DataSource = ds3;
        //TONameDropDownList.DataTextField = "to_name";
        //TONameDropDownList.DataValueField = "to_name";
        //TONameDropDownList.AppendDataBoundItems = true;
        //TONameDropDownList.Items.Insert(0, new ListItem("", ""));
        //TONameDropDownList.DataBind();



        ////load manager based on venue n venue group
        //DataSet ds4 = Queries.LoadManagersOnVenue(VenueDropDownList.SelectedItem.Text);//, GroupVenueDropDownList.SelectedItem.Text);

        //ManagerDropDownList.DataSource = ds4;
        //ManagerDropDownList.DataTextField = "Manager_Name";
        //ManagerDropDownList.DataValueField = "Manager_Name";
        //ManagerDropDownList.AppendDataBoundItems = true;
        //ManagerDropDownList.Items.Insert(0, new ListItem("", ""));
        //ManagerDropDownList.DataBind();
    }

    protected void PrimaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //primarymobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(PrimaryCountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //primarymobileDropDownList.DataSource = ds12;
        //primarymobileDropDownList.DataTextField = "name";
        //primarymobileDropDownList.DataValueField = "name";
        //primarymobileDropDownList.AppendDataBoundItems = true;
        //primarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //primarymobileDropDownList.DataBind();

    }

    protected void SecondaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //secondarymobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(SecondaryCountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //secondarymobileDropDownList.DataSource = ds12;
        //secondarymobileDropDownList.DataTextField = "name";
        //secondarymobileDropDownList.DataValueField = "name";
        //secondarymobileDropDownList.AppendDataBoundItems = true;
        //secondarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //secondarymobileDropDownList.DataBind();
    }

    protected void SubProfile1CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //subprofile1mobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(SubProfile1CountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //subprofile1mobileDropDownList.DataSource = ds12;
        //subprofile1mobileDropDownList.DataTextField = "name";
        //subprofile1mobileDropDownList.DataValueField = "name";
        //subprofile1mobileDropDownList.AppendDataBoundItems = true;
        //subprofile1mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //subprofile1mobileDropDownList.DataBind();
    }
    protected void SubProfile2CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //subprofile2mobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(SubProfile2CountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //subprofile2mobileDropDownList.DataSource = ds12;
        //subprofile2mobileDropDownList.DataTextField = "name";
        //subprofile2mobileDropDownList.DataValueField = "name";
        //subprofile2mobileDropDownList.AppendDataBoundItems = true;
        //subprofile2mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //subprofile2mobileDropDownList.DataBind();
    }

    protected void MarketingPrgmDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
         
    //    DataSet ds4 = Queries.LoadAgents(MarketingPrgmDropDownList.SelectedItem.Text);
    //    AgentsDropDownList.DataSource = ds4;
    //    AgentsDropDownList.DataTextField = "Agent_Name";
    //    AgentsDropDownList.DataValueField = "Agent_Name";
    //    AgentsDropDownList.AppendDataBoundItems = true;
    //    AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
    //    AgentsDropDownList.DataBind();
    }

    
    [WebMethod]
    
    public static string LoadVenueOnVenueCountry(string venuecountry)
    {


        //String conn = "Data Source=192.168.20.7;Initial Catalog=Contractapp;user id=sa;pwd=c10h12n2o";
        //SqlConnection sqlcon = new SqlConnection(conn);
        //sqlcon.Open();
        string JSON = "{\n \"names\":[";
        //string query = "select amount,taxValue from PointsContract where currency='" + venuecountry + "' and status='Active' ;";
        //SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = Queries.LoadVenueonVCountry(venuecountry);       
        while (reader.Read())
        {
            string venue = reader.GetString(0);
            
            JSON += "[\"" + venue + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadGroupVenueOnVenue(string venue)
    {


        
        string JSON = "{\n \"names\":[";
        //string query = "select amount,taxValue from PointsContract where currency='" + venuecountry + "' and status='Active' ;";
        //SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = Queries.GetVgroupOnVenue(venue);
        while (reader.Read())
        {
            string gvenue = reader.GetString(0);

            JSON += "[\"" + gvenue + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadSalesRepOnVenue(string venue,string country)
    {



        string JSON = "{\n \"names\":[";
        

        SqlDataReader reader = Queries.GetSalesRepOnVenue(venue, country);
        while (reader.Read())
        {
            string sr = reader.GetString(0);

            JSON += "[\"" + sr + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadAgents(string venue)
    {

        string JSON = "{\n \"names\":[";

       
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
    
        return JSON;
    }
    [WebMethod]
    public static string LoadAgentsOnVenuegrp(string venue,string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetSalesRepOnlyVenue(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        return JSON;
    }
    [WebMethod]
    public static string LoadTO(string venue)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadTOOPCOnVenue1(venue);
        while (reader.Read())
        {
            string tom = reader.GetString(0);

            JSON += "[\"" + tom + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }
    [WebMethod]
    public static string LoadTOOnVenueNVGrp(string venue,string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenue1(venue);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;
        }
        else
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenueNGrp(venue);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;

        }
    }
    [WebMethod]
    public static string LoadManagersOnVenue(string venue)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadManagersOnVenue1(venue);
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
    public static string LoadMktgOnVenuenVenueGrp(string venue,string venuegrp)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadMarketingProgramOnVenueNVGroup1(venue, venuegrp);
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
    public static string LoadCountryCode(string country)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadCodeOnCountry(country);
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
    public static string LoadAllCountryCode(string country)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadAllCodeOnCountry(country);
        while (reader.Read())
        {
            string mn = reader.GetString(0);

            JSON += "[\"" + mn + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }







}