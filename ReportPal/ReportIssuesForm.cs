using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace ReportPal
{
    public partial class ReportIssuesForm : Form
    {
        public static List<Issue> Issues = new List<Issue>();

        // i keep placeholders here but i take their text from ApplyLanguage() so it matches global language
        private string phName = "Enter your name...";
        private string phEmail = "Enter your email...";

        private string phLocation = "Enter issue location...";
        private string phDescription = "Type a short description...";

        // suburbs source. i just localize the first item to Select/Kies/Khetha
        private static readonly string[] PretoriaSuburbs = new[]
        {
            "Select",
            "Arcadia","Brooklyn","Centurion","Claremont","Colbyn","Erasmuskloof","Faerie Glen",
            "Garsfontein","Hatfield","Lynnwood","Mamelodi","Menlyn","Menlo Park","Montana",
            "Moreleta Park","Pretoria CBD","Queenswood","Rietfontein","Silver Lakes","Sunnyside",
            "Waterkloof","Waverley","Wonderboom"
        };

        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // these exist in Designer already. i’m not creating new ones here
            txtReporter1 = this.Controls.Find("txtReporter1", true).FirstOrDefault() as TextBox;
            cmbSuburb1 = this.Controls.Find("cmbSuburb1", true).FirstOrDefault() as ComboBox;

            // i build the menu here and make it write to AppSettings so all forms follow it
            BuildMenu();

            // listen to global changes so this form updates live if user flips settings elsewhere
            AppSettings.LanguageChanged += (_, __) => { ApplyLanguage(); PopulateSuburbs(); SetPlaceholderIfEmpty(); };
            AppSettings.ThemeChanged += (_, __) => ApplyTheme();

            // first paint + data
            ApplyLanguage();
            ApplyTheme();
            PopulateSuburbs();
            SetPlaceholders();       // wire got/lost focus for fake placeholders
            ApplyResponsiveLayout(); // anchors etc

            // progress + enablement
            if (txtReporter1 != null) txtReporter1.TextChanged += (s, a) => { UpdateSubmitEnabled(); UpdateProgress(); };
            if (cmbSuburb1 != null) cmbSuburb1.SelectedIndexChanged += (s, a) => { UpdateSubmitEnabled(); UpdateProgress(); };
            txtEmail.TextChanged += (s, a) => { UpdateSubmitEnabled(); UpdateProgress(); };

            txtLocation.TextChanged += (s, a) => { UpdateSubmitEnabled(); UpdateProgress(); };
            cmbCategory.SelectedIndexChanged += (s, a) => { UpdateSubmitEnabled(); UpdateProgress(); };
            rtbDescription.TextChanged += (s, a) => { UpdateSubmitEnabled(); UpdateProgress(); };

            UpdateSubmitEnabled();
            UpdateProgress();
        }

        // ---------------- menu writes to AppSettings so it’s global ----------------
        private void BuildMenu()
        {
            var ms = new MenuStrip { Dock = DockStyle.Top };
            this.MainMenuStrip = ms;

            var mSettings = new ToolStripMenuItem("&Settings");

            var mLang = new ToolStripMenuItem("&Language");
            mLang.DropDownItems.Add(new ToolStripMenuItem("English", null, (s, e) => AppSettings.Language = AppLanguage.English));
            mLang.DropDownItems.Add(new ToolStripMenuItem("Afrikaans", null, (s, e) => AppSettings.Language = AppLanguage.Afrikaans));
            mLang.DropDownItems.Add(new ToolStripMenuItem("Zulu", null, (s, e) => AppSettings.Language = AppLanguage.Zulu));

            var mTheme = new ToolStripMenuItem("&Theme");
            mTheme.DropDownItems.Add(new ToolStripMenuItem("Light", null, (s, e) => AppSettings.Theme = AppTheme.Light));
            mTheme.DropDownItems.Add(new ToolStripMenuItem("Dark", null, (s, e) => AppSettings.Theme = AppTheme.Dark));
            mTheme.DropDownItems.Add(new ToolStripMenuItem("System", null, (s, e) => AppSettings.Theme = AppTheme.System));

            mSettings.DropDownItems.Add(mLang);
            mSettings.DropDownItems.Add(mTheme);

            var mHelp = new ToolStripMenuItem("&Help", null, (s, e) =>
                MessageBox.Show("Fill in Name, Suburb, Full Address, pick Category, describe the issue. you can upload images/PDF. progress bar shows how far i am. submit returns to main menu.",
                                "Help — Report Issue", MessageBoxButtons.OK, MessageBoxIcon.Information));

            var mExit = new ToolStripMenuItem("E&xit", null, (s, e) => Application.Exit());

            ms.Items.AddRange(new ToolStripItem[] { mSettings, mHelp, mExit });
            Controls.Add(ms);
            ms.BringToFront();
        }

        // ---------------- language: read AppSettings.Language and set all texts ----------------
        private void ApplyLanguage()
        {
            string tMain, tName, tSuburb, tLoc, tCat, tDesc, tUpload, tSubmit, tReturn, tUploadLbl, tEmail;
            string sel, wtr, elec, rds, sani;
            string phNameLocal, phLocLocal, phDescLocal, phEmailLocal;

            switch (AppSettings.Language)
            {
                case AppLanguage.Afrikaans:
                    // Afrikaans
                    tEmail = "&E-posadres"; phEmailLocal = "Tik jou e-pos in...";
                    tMain = "Rapporteer probleem"; tName = "&Naam"; tSuburb = "&Voorstad"; tLoc = "&Volle Adres";
                    tCat = "&Kategorie"; tDesc = "&Beskrywing"; tUpload = "&Laai op"; tSubmit = "&Dien in"; tReturn = "&Terug";
                    tUploadLbl = "Laai beeld of dokument op";
                    sel = "Kies"; wtr = "Water"; elec = "Elektrisiteit"; rds = "Paaie"; sani = "Sanitasie";
                    phNameLocal = "Tik jou naam in..."; phLocLocal = "Tik die ligging van die probleem in..."; phDescLocal = "Tik ’n kort beskrywing in...";
                    break;

                case AppLanguage.Zulu:
                    // Zulu
                    tEmail = "&Ikheli le-imeyili"; phEmailLocal = "Faka i-imeyili yakho...";
                    tMain = "Bika Inkinga"; tName = "&Igama"; tSuburb = "&Isifunda"; tLoc = "&Ikheli Eligcwele";
                    tCat = "&Isigaba"; tDesc = "&Incazelo"; tUpload = "&Layisha"; tSubmit = "&Hambisa"; tReturn = "&Buyela";
                    tUploadLbl = "Layisha isithombe noma idokhumenti";
                    sel = "Khetha"; wtr = "Amanzi"; elec = "Ugesi"; rds = "Imigwaqo"; sani = "Uhlanzeko";
                    phNameLocal = "Faka igama lakho..."; phLocLocal = "Faka indawo yenkinga..."; phDescLocal = "Chaza kafushane inkinga...";
                    break;

                default:
                    // Default (English)
                    tEmail = "&Email Address"; phEmailLocal = "Enter your email...";
                    tMain = "Report Issue"; tName = "&Name"; tSuburb = "&Suburb"; tLoc = "&Full Address";
                    tCat = "&Category"; tDesc = "&Description"; tUpload = "&Upload"; tSubmit = "&Submit"; tReturn = "&Return";
                    tUploadLbl = "Upload Image or Document";
                    sel = "Select"; wtr = "Water"; elec = "Electricity"; rds = "Roads"; sani = "Sanitation";
                    phNameLocal = "Enter your name..."; phLocLocal = "Enter issue location..."; phDescLocal = "Type a short description...";
                    break;
            }

            // labels/buttons
            label1.Text = tMain + ":";
            label2.Text = tName;
            label3.Text = tSuburb;
            lblEmail.Text = tEmail;
            phEmail = phEmailLocal;
            lblLocation.Text = tLoc;
            lblCategory.Text = tCat;
            lblDescription.Text = tDesc;
            lblImages.Text = tUploadLbl;
            btnAttach.Text = tUpload;
            btnSubmit.Text = tSubmit;
            btnReturn.Text = tReturn;
            this.Text = "Report Pal: " + tMain;

            // category list. keep previous valid selection if any
            var prevCat = (cmbCategory.SelectedIndex > 0) ? cmbCategory.SelectedIndex : -1;
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new object[] { sel, wtr, elec, rds, sani });
            cmbCategory.SelectedIndex = (prevCat > 0 && prevCat < cmbCategory.Items.Count) ? prevCat : 0;

            // placeholders text (only swap text if still showing placeholder gray)
            phName = phNameLocal; phLocation = phLocLocal; phDescription = phDescLocal;
            if (txtReporter1 != null && txtReporter1.ForeColor == Color.Gray) txtReporter1.Text = phName;
            if (txtEmail.ForeColor == Color.Gray) txtEmail.Text = phEmail;
            if (txtLocation.ForeColor == Color.Gray) txtLocation.Text = phLocation;
            if (rtbDescription.ForeColor == Color.Gray) rtbDescription.Text = phDescription;
        }

        // fill suburb list and localize the first item (Select/Kies/Khetha)
        private void PopulateSuburbs()
        {
            if (cmbSuburb1 == null) return;

            string selectWord =
                AppSettings.Language == AppLanguage.Afrikaans ? "Kies" :
                AppSettings.Language == AppLanguage.Zulu ? "Khetha" : "Select";

            var items = PretoriaSuburbs.ToList();
            items[0] = selectWord;

            int keep = cmbSuburb1.SelectedIndex;
            cmbSuburb1.Items.Clear();
            cmbSuburb1.Items.AddRange(items.Cast<object>().ToArray());
            cmbSuburb1.SelectedIndex = (keep > 0 && keep < cmbSuburb1.Items.Count) ? keep : 0;
        }

        // ApplyTheme() sets background/foreground colours for consistency
        private void ApplyTheme()
        {
            progressBarIssue.ForeColor = Color.FromArgb(0, 76, 153);  // blue fill
            progressBarIssue.BackColor = Color.White;                 // white background
            Color bg, fg, btnBg, btnFg;

            switch (AppSettings.Theme)
            {
                case AppTheme.Dark:
                    bg = Color.FromArgb(10, 25, 50);    // dark navy
                    fg = Color.White;
                    btnBg = Color.FromArgb(20, 40, 80); // darker blue
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
                    break;
            }

            this.BackColor = bg;
            foreach (var lbl in new[] { label1, label2, label3, lblLocation, lblCategory, lblDescription, lblImages })
                lbl.ForeColor = fg;

            if (txtReporter1 != null) { txtReporter1.BackColor = Color.White; txtReporter1.ForeColor = (txtReporter1.ForeColor == Color.Gray) ? Color.Gray : fg; }
            txtLocation.BackColor = Color.White; txtLocation.ForeColor = (txtLocation.ForeColor == Color.Gray) ? Color.Gray : fg;
            if (cmbSuburb1 != null) { cmbSuburb1.BackColor = Color.Black; cmbSuburb1.ForeColor = fg; }
            cmbCategory.BackColor = Color.Black; cmbCategory.ForeColor = fg;
            rtbDescription.BackColor = Color.White; rtbDescription.ForeColor = (rtbDescription.ForeColor == Color.Gray) ? Color.Gray : fg;
            lblEmail.ForeColor = fg;

            txtEmail.BackColor = Color.White;
            txtEmail.ForeColor = (txtEmail.ForeColor == Color.Gray) ? Color.Gray : fg;



            foreach (var b in new[] { btnAttach, btnSubmit, btnReturn })
            { b.BackColor = btnBg; b.ForeColor = btnFg; b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0; }
            

        }


        // fake placeholders. i keep the got/lost focus wiring here
        private void SetPlaceholders()
        {
            SetPlaceholderIfEmpty();

            if (txtReporter1 != null)
            {
                txtReporter1.GotFocus += (s, e) => { if (txtReporter1.ForeColor == Color.Gray) { txtReporter1.Text = ""; txtReporter1.ForeColor = Color.Black; } };
                txtReporter1.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtReporter1.Text)) { txtReporter1.Text = phName; txtReporter1.ForeColor = Color.Gray; } };
            }

            txtEmail.GotFocus += (s, e) => { if (txtEmail.ForeColor == Color.Gray) { txtEmail.Text = ""; txtEmail.ForeColor = Color.Black; } };
            txtEmail.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtEmail.Text)) { txtEmail.Text = phEmail; txtEmail.ForeColor = Color.Gray; } };


            txtLocation.GotFocus += (s, e) => { if (txtLocation.ForeColor == Color.Gray) { txtLocation.Text = ""; txtLocation.ForeColor = Color.Black; } };
            txtLocation.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtLocation.Text)) { txtLocation.Text = phLocation; txtLocation.ForeColor = Color.Gray; } };

            rtbDescription.GotFocus += (s, e) => { if (rtbDescription.ForeColor == Color.Gray) { rtbDescription.Text = ""; rtbDescription.ForeColor = Color.Black; } };
            rtbDescription.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(rtbDescription.Text)) { rtbDescription.Text = phDescription; rtbDescription.ForeColor = Color.Gray; } };
        }

        private void SetPlaceholderIfEmpty()
        {
            if (txtReporter1 != null && string.IsNullOrWhiteSpace(txtReporter1.Text)) { txtReporter1.Text = phName; txtReporter1.ForeColor = Color.Gray; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { txtEmail.Text = phEmail; txtEmail.ForeColor = Color.Gray; }
            if (string.IsNullOrWhiteSpace(txtLocation.Text)) { txtLocation.Text = phLocation; txtLocation.ForeColor = Color.Gray; }
            if (string.IsNullOrWhiteSpace(rtbDescription.Text)) { rtbDescription.Text = phDescription; rtbDescription.ForeColor = Color.Gray; }
        }

        // anchors so the form behaves on resize. not overdoing it
        private void ApplyResponsiveLayout()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.MinimumSize = new Size(540, 520);
            this.StartPosition = FormStartPosition.CenterScreen;

            txtReporter1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSuburb1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            cmbCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lstAttachments.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAttach.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            progressBarIssue.Dock = DockStyle.Bottom;

            this.Resize += (s, e) => { label1.Left = (this.ClientSize.Width - label1.Width) / 2; };
        }

        // validation. same rules as before just tidy
        private bool ValidateForm()
        {
            bool ok = true; errorProvider1.Clear();

            if (txtReporter1 != null)
            {
                var name = txtReporter1.Text?.Trim();
                if (string.IsNullOrWhiteSpace(name) || txtReporter1.ForeColor == Color.Gray || name.Length < 2)
                { errorProvider1.SetError(txtReporter1, "Enter your name (min 2 chars)."); ok = false; }
            }

            if (cmbSuburb1 != null)
            {
                var first = cmbSuburb1.Items.Count > 0 ? cmbSuburb1.Items[0].ToString() : "Select";
                if (cmbSuburb1.SelectedIndex <= 0 || (cmbSuburb1.SelectedItem?.ToString() ?? "") == first)
                { errorProvider1.SetError(cmbSuburb1, "Choose a suburb."); ok = false; }
            }

            var loc = txtLocation.Text?.Trim();
            if (string.IsNullOrWhiteSpace(loc) || loc.Length < 5 || !Regex.IsMatch(loc, @"^[\w\s\-.,/]+$") || txtLocation.ForeColor == Color.Gray)
            { errorProvider1.SetError(txtLocation, "Enter a valid address (min 5 chars)."); ok = false; }

            var firstCat = cmbCategory.Items.Count > 0 ? cmbCategory.Items[0].ToString() : "Select";
            if (cmbCategory.SelectedIndex <= 0 || (cmbCategory.SelectedItem?.ToString() ?? "") == firstCat)
            { errorProvider1.SetError(cmbCategory, "Choose a category."); ok = false; }

            var desc = rtbDescription.Text?.Trim();
            if (string.IsNullOrWhiteSpace(desc) || desc.Length < 15 || desc.Length > 500 || rtbDescription.ForeColor == Color.Gray)
            { errorProvider1.SetError(rtbDescription, "Describe the issue (15–500 chars)."); ok = false; }
            var email = txtEmail.Text?.Trim();
            bool emailLooksEmpty = string.IsNullOrWhiteSpace(email) || txtEmail.ForeColor == Color.Gray;

            bool emailLooksValid = false;
            try { var _ = new System.Net.Mail.MailAddress(email); emailLooksValid = true; } catch { emailLooksValid = false; }

            if (emailLooksEmpty || !emailLooksValid)
            { errorProvider1.SetError(txtEmail, "Enter a valid email."); ok = false; }

            return ok;
        }

        // enable submit when i got enough fields
        private void UpdateSubmitEnabled()
        {
            bool nameOk = (txtReporter1 == null) || (txtReporter1.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(txtReporter1.Text));
            bool emailOk = txtEmail.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(txtEmail.Text);

            bool suburbOk = (cmbSuburb1 == null) || (cmbSuburb1.SelectedIndex > 0);
            bool locationOk = txtLocation.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(txtLocation.Text);
            bool categoryOk = cmbCategory.SelectedIndex > 0;
            bool descOk = rtbDescription.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(rtbDescription.Text);

            btnSubmit.Enabled = nameOk && emailOk && suburbOk && locationOk && categoryOk && descOk;
        }

        // progress. 6 steps (name, suburb, category, address, desc, attachments)
        private void UpdateProgress()
        {
            int steps = 7, p = 0;
            if (txtReporter1 == null || (txtReporter1.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(txtReporter1.Text))) p += 100 / steps;
            if (txtEmail.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(txtEmail.Text)) p += 100 / steps;
            if (cmbSuburb1 == null || (cmbSuburb1.SelectedIndex > 0)) p += 100 / steps;
            if (cmbCategory == null || (cmbCategory.SelectedIndex > 0)) p += 100 / steps;
            if (txtLocation.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(txtLocation.Text)) p += 100 / steps;
            if (rtbDescription.ForeColor != Color.Gray && !string.IsNullOrWhiteSpace(rtbDescription.Text)) p += 100 / steps;
            if (lstAttachments.Items.Count > 0) p += 100 / steps;

            progressBarIssue.Maximum = 100;
            progressBarIssue.Value = Math.Max(progressBarIssue.Minimum, Math.Min(100, p));
        }

        // attach files with simple guards
        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog { Multiselect = true, Filter = "Images or PDF|*.png;*.jpg;*.jpeg;*.pdf|All files|*.*" })
                {
                    if (ofd.ShowDialog() != DialogResult.OK) return;
                    foreach (var f in ofd.FileNames)
                    {
                        try
                        {
                            var ext = Path.GetExtension(f)?.ToLowerInvariant();
                            if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".pdf") continue;
                            var fi = new FileInfo(f);
                            if (fi.Length > 5 * 1024 * 1024) continue;
                            lstAttachments.Items.Add(f);
                        }
                        catch { /* ignore this file */ }
                    }
                    lstAttachments.Visible = lstAttachments.Items.Count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not attach files.\n" + ex.Message, "Attachment Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UpdateProgress();
            UpdateSubmitEnabled();
        }

        // submit -> validate -> add -> reset -> close
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Please fix the highlighted fields.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSubmit.Enabled = false;
            try
            {
                var issue = new Issue
                {
                    Reporter = txtReporter1?.Text.Trim() ?? "",
                    Email = txtEmail.Text.Trim(),
                    Suburb = cmbSuburb1?.SelectedItem?.ToString() ?? "",
                    Location = txtLocation.Text.Trim(),
                    Category = cmbCategory.Text,
                    Description = rtbDescription.Text.Trim(),
                    Attachments = lstAttachments.Items.Cast<string>().ToList()
                };
                Issues.Add(issue);

                MessageBox.Show("Issue submitted. Thank you!", "ReportPal",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // reset then bounce back to main
                if (txtReporter1 != null) txtReporter1.Clear();
                if (cmbSuburb1 != null) cmbSuburb1.SelectedIndex = 0;
                txtLocation.Clear(); cmbCategory.SelectedIndex = 0;
                rtbDescription.Clear(); lstAttachments.Items.Clear(); lstAttachments.Visible = false;

                UpdateSubmitEnabled(); UpdateProgress();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while saving your issue.\n" + ex.Message,
                    "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSubmit.Enabled = true;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e) => this.Close();
    }
}
