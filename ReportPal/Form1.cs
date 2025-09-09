using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace ReportPal
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // build the menu
            BuildMenu();

            // wire up global change events
            AppSettings.LanguageChanged += (_, __) => ApplyLanguage();
            AppSettings.ThemeChanged += (_, __) => ApplyTheme();

            // first paint based on current global settings
            ApplyLanguage();
            ApplyTheme();


        }

        // ---------------- menu stuff----------------
        private void BuildMenu()
        {
            
            menuStrip1.Items.Clear();

            // Settings root
            var mSettings = new ToolStripMenuItem("&Settings");

            // Language submenu
            var mLang = new ToolStripMenuItem("&Language");
            var mLangEn = new ToolStripMenuItem("English", null, (s, e) => AppSettings.Language = AppLanguage.English);
            var mLangAf = new ToolStripMenuItem("Afrikaans", null, (s, e) => AppSettings.Language = AppLanguage.Afrikaans);
            var mLangZu = new ToolStripMenuItem("Zulu", null, (s, e) => AppSettings.Language = AppLanguage.Zulu);
            mLang.DropDownItems.AddRange(new ToolStripItem[] { mLangEn, mLangAf, mLangZu });

            // Theme submenu
            var mTheme = new ToolStripMenuItem("&Theme");
            var mThemeLight = new ToolStripMenuItem("Light", null, (s, e) => AppSettings.Theme = AppTheme.Light);
            var mThemeDark = new ToolStripMenuItem("Dark", null, (s, e) => AppSettings.Theme = AppTheme.Dark);
            var mThemeSystem = new ToolStripMenuItem("System", null, (s, e) => AppSettings.Theme = AppTheme.System);
            mTheme.DropDownItems.AddRange(new ToolStripItem[] { mThemeLight, mThemeDark, mThemeSystem });

            mSettings.DropDownItems.Add(mLang);
            mSettings.DropDownItems.Add(mTheme);

            // Help is dumb simple. just show a messagebox. no docs here
            var mHelp = new ToolStripMenuItem("&Help", null, (s, e) =>
            {
                MessageBox.Show(
                    "Main menu basics:\n- Report Issues opens the report screen.\n- View Submitted Issues shows what you captured.\n" +
                    "Use Settings to change language and theme. these choices stick across forms.",
                    "ReportPal — Help");
            });

            // exit
            var mExit = new ToolStripMenuItem("E&xit", null, (s, e) => Application.Exit());

            // attach to actual strip that already exists on  form
            menuStrip1.Items.AddRange(new ToolStripItem[] { mSettings, mHelp, mExit });
        }

        // ---------------- language text (just renaming labels/buttons) ----------------
        private void ApplyLanguage()
        {
            // visible text.
            string title, issues, eventsText, service, viewAll;
            // vars for main form stuff
            string tWelcome, tIntro, tFooter;

            switch (AppSettings.Language)
            {
                case AppLanguage.Afrikaans:
                    title = "Welkom by ReportPal";
                    issues = "Rapporteer Probleem";
                    eventsText = "Plaaslike Gebeure en Aankondigings";
                    service = "Diensversoekstatus";
                    viewAll = "Sien Ingesendde Probleme";
                    tIntro = "Hierdie app help jou om munisipale probleme in Pretoria te rapporteer. Jy kan ’n nuwe probleem aanmeld, vorige inskrywings nagaan, of ’n diensversoek stuur..";
                    tFooter = "Wenk: Gebruik Instellings bo om tema of taal te verander.";

                    break;

                case AppLanguage.Zulu:
                    title = "Siyakwamukela ku-ReportPal";
                    issues = "Bika Inkinga";
                    eventsText = "Imicimbi Yasendaweni Nezaziso";
                    service = "Isimo Sesicelo Sesevisi";
                    viewAll = "Buka Izinkinga Ezigciniwe";
                    tIntro = "Le app ikusiza ukubika izinkinga zikamasipala ePitoli. Ungabika inkinga entsha, uhlole ezedlule, noma uthumele isicelo sensizakalo.";
                    tFooter = "Ithiphu: Sebenzisa Izilungiselelo phezulu ukushintsha itimu noma ulimi.";

                    break;

                default: // English
                    title = "Welcome to ReportPal";
                    issues = "Report Issues";
                    eventsText = "Local Events and Announcements";
                    service = "Service Request Status";
                    viewAll = "View Submitted Issues";
                    tIntro = "This app helps you report municipal issues in Pretoria. You can log a new issue, check previous ones, or send a service request.\r\n";
                    tFooter = "Tip: Use Settings (top menu) to change theme or language.";

                    break;
            }

            label1.Text = title;
            btnIssues.Text = issues;
            btnEvents.Text = eventsText;
            btnServiceRequest.Text = service;
            btnViewIssues.Text = viewAll;
            // now set labels with text
            lblIntro.Text = tIntro;       // body intro
            lblFooter.Text = tFooter;     // footer tip

            // window title too
            this.Text = "Report Pal: " + title;
        }

        // ApplyTheme() sets background/foreground colours for consistency
        private void ApplyTheme()
        {
            Color bg, fg, btnBg, btnFg;

            switch (AppSettings.Theme)
            {
                case AppTheme.Dark:
                    bg = Color.FromArgb(10, 25, 50);    // dark navy
                    fg = Color.White;
                    btnBg = Color.FromArgb(20, 40, 80); // darker blue for buttons
                    btnFg = Color.White;
                    break;
                 
                case AppTheme.System:
                    bg = SystemColors.Control;
                    fg = SystemColors.ControlText;
                    btnBg = SystemColors.ControlLight;
                    btnFg = SystemColors.ControlText;
                    break;

                default: // Light
                    bg = Color.FromArgb(0, 51, 102);     // deep navy blue
                    fg = Color.White;
                    btnBg = Color.FromArgb(0, 76, 153);  // strong medium blue
                    btnFg = Color.White;
                    foreach (var lbl in new[] { lblIntro, lblFooter })
                        lbl.ForeColor = fg;

                    break;
            }

            // form + label
            this.BackColor = bg;
            label1.ForeColor = fg;

            // style buttons
            StyleButton(btnIssues, btnBg, btnFg);
            StyleButton(btnEvents, btnBg, btnFg);
            StyleButton(btnServiceRequest, btnBg, btnFg);
            StyleButton(btnViewIssues, btnBg, btnFg);


        }


        private static void StyleButton(Button b, Color bg, Color fg)
        {
            b.BackColor = bg;
            b.ForeColor = fg;
            b.FlatStyle = FlatStyle.Flat;     
            b.FlatAppearance.BorderSize = 0;  
        }

        // ----------------  click handlers  ----------------
        private void btnIssues_Click(object sender, EventArgs e)
        {
            using (var issues = new ReportIssuesForm())
            {
                issues.StartPosition = FormStartPosition.CenterParent;
                issues.ShowDialog(this); // modal,
            }
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
           
        }

        private void btnServiceRequest_Click(object sender, EventArgs e)
        {
            
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            if (ReportIssuesForm.Issues.Count == 0)
            {
                MessageBox.Show("No issues submitted yet.");
                return;
            }

            var allIssues = new StringBuilder();
            foreach (var issue in ReportIssuesForm.Issues)
            {
                allIssues.AppendLine($"Location: {issue.Location}");
                allIssues.AppendLine($"Category: {issue.Category}");
                allIssues.AppendLine($"Description: {issue.Description}");
                allIssues.AppendLine($"Attachments: {issue.Attachments?.Count ?? 0}");
                allIssues.AppendLine("---------------------------");
            }

            MessageBox.Show(allIssues.ToString(), "All Issues");
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            using (var demo = new UiDemo())
            {
                demo.StartPosition = FormStartPosition.CenterParent;
                demo.ShowDialog(this);
            }
        }


    }
}
