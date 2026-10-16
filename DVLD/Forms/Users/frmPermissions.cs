using BusinessLayer;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public partial class frmPermissions : BaseForm
{
    private enPermissions _permissions;
    public Action RefreshData;
    private FlowLayoutPanel bannersPanel;
    private CheckBox chkSelectAll;
    private Button btnSave;

    private Dictionary<MenuBanner, bool> _bannerStates =
        new Dictionary<MenuBanner, bool>();


    private MenuBanner peopleBanner;
    private MenuBanner usersBanner;
    private MenuBanner driversBanner;
    private MenuBanner licensesBanner;
    private MenuBanner testTypes;
    private MenuBanner applicationsTypes;
    private MenuBanner localLicenses;
    private MenuBanner internationalLicenses;
    private MenuBanner manageApplicants;
    private MenuBanner replacement;
    private MenuBanner detainedLicenses;

    public int PermissionValue
    {
        get
        {
            return (int)_permissions;
        }
    }

    public enPermissions Permissions
    {
        get
        {
            return _permissions;
        }
    }



    public frmPermissions(enPermissions permissions = enPermissions.None)
    {
       



        _permissions = permissions;
           


        InitializeForm();

        InitializeControls();

        CreateBanners();

        LoadPermissions();
    }




    private void InitializeForm()
    {
        Text =
            "Permissions";


        Size =
            new Size(
                1200,
                800);


        StartPosition =
            FormStartPosition.CenterScreen;


        BackColor =
            Theme.AppBackground;
    }




    private void InitializeControls()
    {
        bannersPanel =
            new FlowLayoutPanel();


        bannersPanel.Dock =
            DockStyle.Fill;


        bannersPanel.AutoScroll =
            true;


        bannersPanel.FlowDirection =
            FlowDirection.LeftToRight;


        bannersPanel.WrapContents =
            true;


        bannersPanel.Padding =
            new Padding(20);


        Controls.Add(
            bannersPanel);




        chkSelectAll =
            new CheckBox();


        chkSelectAll.Text =
            "Select All";


        chkSelectAll.Dock =
            DockStyle.Top;


        chkSelectAll.Height =
            40;


        chkSelectAll.CheckedChanged +=
            chkSelectAll_CheckedChanged;


        Controls.Add(
            chkSelectAll);




        btnSave =
            new Button();


        btnSave.Text =
            "Save";


        btnSave.Height =
            45;


        btnSave.Dock =
            DockStyle.Bottom;


        btnSave.Click +=
            btnSave_Click;


        Controls.Add(
            btnSave);
    }





    private void SetupBanner(
        MenuBanner banner,
        string title,
        string description,
        enPermissions permission,
        string image)
    {
        banner.Title =
            title;


        banner.Description =
            description;


        banner.Permission =
            permission;


        banner.Size =
            new Size(
                250,
                180);


        banner.Margin =
            new Padding(20);


        banner.BannerImage =
            Image.FromFile(
                image);

        banner.KeepBorder = true;
        banner.BannerClick +=
            Banner_Click;



        bannersPanel.Controls.Add(
            banner);



        _bannerStates.Add(
            banner,
            false);
    }





    private void Banner_Click(
        object sender,
        EventArgs e)
    {
        MenuBanner banner =
            (MenuBanner)sender;


        
        bool selected =
            !_bannerStates[banner];



        _bannerStates[banner] =
            selected;



        if (selected)
        {
            _permissions |=
                banner.Permission;


            SetBannerBorder(
                banner,
                Color.Green);
        }
        else
        {
            _permissions &=
                ~banner.Permission;


            SetBannerBorder(
                banner,
                Color.Gray);
        }


        UpdateSelectAll();
    }





    private void LoadPermissions()
    {
        foreach (MenuBanner banner in _bannerStates.Keys.ToList())
        {
            bool selected =
                (_permissions &
                banner.Permission)
                ==
                banner.Permission;


            _bannerStates[banner] =
                selected;


            SetBannerBorder(
                banner,
                selected
                ? Color.Green
                : Color.Gray);
        }


        UpdateSelectAll();
    }





    private void chkSelectAll_CheckedChanged(
        object sender,
        EventArgs e)
    {
        _permissions =
            chkSelectAll.Checked
            ?
            enPermissions.All
            :
            enPermissions.None;



        foreach (MenuBanner banner in _bannerStates.Keys.ToList())
        {
            _bannerStates[banner] =
                chkSelectAll.Checked;



            SetBannerBorder(
                banner,
                chkSelectAll.Checked
                ? Color.Green
                : Color.Gray);
        }
    }





    private void UpdateSelectAll()
    {
        chkSelectAll.Checked =
            _permissions ==
            enPermissions.All;
    }





    private void btnSave_Click(
        object sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.OK;

        RefreshData?.Invoke();
        


        Close();
    }





    private void SetBannerBorder(
        MenuBanner banner,
        Color color)
    {
        banner.BackColor =
            color;
    }


    private void CreateBanners()
    {
        CreatePeopleBanner();

        CreateUsersBanner();

        CreateDrivers();

        CreateLicenses();

        CreateTestTypes();

        CreateApplicationsTypes();

   

        CreateLocalLicenses();

        CreateInternationalLicenses();

        CreateManageApplicants();

        CreateReplacementLicenses();

        CreateDetainedLicenses();
    }



    private void CreatePeopleBanner()
    {
        peopleBanner = new MenuBanner();

        SetupBanner(
            peopleBanner,
            "People",
            "Manage system people",
            enPermissions.People,
            @"C:\DVLD\images\People.jpg"
        );
    }



    private void CreateUsersBanner()
    {
        usersBanner = new MenuBanner();

        SetupBanner(
            usersBanner,
            "Manage Users",
            "Manage system users",
            enPermissions.ManageUsers,
            @"C:\DVLD\images\Users.jpg"
        );
    }



    private void CreateDrivers()
    {
        driversBanner = new MenuBanner();

        SetupBanner(
            driversBanner,
            "Drivers",
            "Manage drivers",
            enPermissions.Drivers,
            @"C:\DVLD\images\Drivers.png"
        );
    }



    private void CreateLicenses()
    {
        licensesBanner = new MenuBanner();

        SetupBanner(
            licensesBanner,
            "Licenses",
            "Manage licenses",
            enPermissions.Licenses,
            @"C:\DVLD\images\Licenses.png"
        );
    }



    private void CreateTestTypes()
    {
        testTypes = new MenuBanner();

        SetupBanner(
            testTypes,
            "Test Types",
            "Show and update test fees",
            enPermissions.Types,
            @"C:\DVLD\images\TestTypes.png"
        );
    }



    private void CreateApplicationsTypes()
    {
        applicationsTypes = new MenuBanner();

        SetupBanner(
            applicationsTypes,
            "Applications Types",
            "Show and update application types",
            enPermissions.ApplicationTypes,
            @"C:\DVLD\images\Applications.png"
        );
    }






    private void CreateLocalLicenses()
    {
        localLicenses = new MenuBanner();

        SetupBanner(
            localLicenses,
            "Local Licenses",
            "Apply for local licenses",
            enPermissions.AddAndRenewLocalLicense,
            @"C:\DVLD\images\locallicesnse.jpg"
        );
    }



    private void CreateInternationalLicenses()
    {
        internationalLicenses = new MenuBanner();

        SetupBanner(
            internationalLicenses,
            "International Licenses",
            "Apply for international licenses",
            enPermissions.AddInternationalLicense,
            @"C:\DVLD\images\InternationalLicenses.jpg"
        );
    }



    private void CreateManageApplicants()
    {
        manageApplicants = new MenuBanner();

        SetupBanner(
            manageApplicants,
            "Manage Local Applicants",
            "Manage applicants for local licenses",
            enPermissions.ManageLocal,
            @"C:\DVLD\images\ManageApplicants.png"
        );
    }



    private void CreateReplacementLicenses()
    {
        replacement = new MenuBanner();

        SetupBanner(
            replacement,
            "Replacement Licenses",
            "Apply for replacement licenses",
            enPermissions.ReplacementLicense,
            @"C:\DVLD\images\Replacement.jpg"
        );
    }



    private void CreateDetainedLicenses()
    {
        detainedLicenses = new MenuBanner();

        SetupBanner(
            detainedLicenses,
            "Detained Licenses",
            "Manage detained licenses",
            enPermissions.DetainedLicense,
            @"C:\DVLD\images\DetainedLicenses.jpg"
        );
    }
}