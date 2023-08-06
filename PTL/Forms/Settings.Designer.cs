namespace PTL
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            ThcrapPathLbl = new Label();
            UseThcrapChk = new CheckBox();
            ThcrapTextBox = new TextBox();
            UseNekoChk = new CheckBox();
            NekoTextBox = new TextBox();
            NekoLbl = new Label();
            NameCmbx = new ComboBox();
            NamePresetLbl = new Label();
            ImportThcrapBtn = new Button();
            ReimportChk = new CheckBox();
            CloseOnLaunchChk = new CheckBox();
            CustomFirstChk = new CheckBox();
            LanguageLbl = new Label();
            LanguageCmbx = new ComboBox();
            SuspendLayout();
            // 
            // ThcrapPathLbl
            // 
            ThcrapPathLbl.AutoSize = true;
            ThcrapPathLbl.BackColor = Color.Transparent;
            ThcrapPathLbl.Enabled = false;
            ThcrapPathLbl.ForeColor = Color.White;
            ThcrapPathLbl.Location = new Point(12, 55);
            ThcrapPathLbl.Name = "ThcrapPathLbl";
            ThcrapPathLbl.Size = new Size(73, 15);
            ThcrapPathLbl.TabIndex = 0;
            ThcrapPathLbl.Text = "Thcrap Path:";
            // 
            // UseThcrapChk
            // 
            UseThcrapChk.AutoSize = true;
            UseThcrapChk.FlatStyle = FlatStyle.Flat;
            UseThcrapChk.ForeColor = Color.White;
            UseThcrapChk.Location = new Point(12, 33);
            UseThcrapChk.Name = "UseThcrapChk";
            UseThcrapChk.Size = new Size(166, 19);
            UseThcrapChk.TabIndex = 1;
            UseThcrapChk.Text = "Launch Games with Thcrap";
            UseThcrapChk.UseVisualStyleBackColor = true;
            UseThcrapChk.CheckedChanged += UseThcrapChk_CheckedChanged;
            // 
            // ThcrapTextBox
            // 
            ThcrapTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ThcrapTextBox.BackColor = Color.FromArgb(58, 65, 65);
            ThcrapTextBox.BorderStyle = BorderStyle.FixedSingle;
            ThcrapTextBox.Enabled = false;
            ThcrapTextBox.ForeColor = Color.White;
            ThcrapTextBox.Location = new Point(152, 51);
            ThcrapTextBox.Name = "ThcrapTextBox";
            ThcrapTextBox.ReadOnly = true;
            ThcrapTextBox.Size = new Size(288, 23);
            ThcrapTextBox.TabIndex = 2;
            ThcrapTextBox.Click += ThcrapTextBox_Click;
            // 
            // UseNekoChk
            // 
            UseNekoChk.AutoSize = true;
            UseNekoChk.FlatStyle = FlatStyle.Flat;
            UseNekoChk.ForeColor = Color.White;
            UseNekoChk.Location = new Point(12, 80);
            UseNekoChk.Name = "UseNekoChk";
            UseNekoChk.Size = new Size(134, 19);
            UseNekoChk.TabIndex = 3;
            UseNekoChk.Text = "Support PC98 Games";
            UseNekoChk.UseVisualStyleBackColor = true;
            UseNekoChk.CheckedChanged += UseNekoChk_CheckedChanged;
            // 
            // NekoTextBox
            // 
            NekoTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NekoTextBox.BackColor = Color.FromArgb(58, 65, 65);
            NekoTextBox.BorderStyle = BorderStyle.FixedSingle;
            NekoTextBox.Enabled = false;
            NekoTextBox.ForeColor = Color.White;
            NekoTextBox.Location = new Point(152, 105);
            NekoTextBox.Name = "NekoTextBox";
            NekoTextBox.ReadOnly = true;
            NekoTextBox.Size = new Size(288, 23);
            NekoTextBox.TabIndex = 5;
            NekoTextBox.Click += NekoTextBox_Click;
            // 
            // NekoLbl
            // 
            NekoLbl.AutoSize = true;
            NekoLbl.BackColor = Color.Transparent;
            NekoLbl.Enabled = false;
            NekoLbl.ForeColor = Color.White;
            NekoLbl.Location = new Point(12, 109);
            NekoLbl.Name = "NekoLbl";
            NekoLbl.Size = new Size(96, 15);
            NekoLbl.TabIndex = 4;
            NekoLbl.Text = "Neko II Location:";
            // 
            // NameCmbx
            // 
            NameCmbx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NameCmbx.BackColor = Color.FromArgb(58, 65, 65);
            NameCmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            NameCmbx.FlatStyle = FlatStyle.System;
            NameCmbx.ForeColor = Color.White;
            NameCmbx.Items.AddRange(new object[] { "Touhou 6: Embodiment of Scarlet Devil", "Touhou 6: EOSD", "Touhou 6", "TH6: Embodiment of Scarlet Devil", "TH6: EOSD", "TH6", "Th6: Embodiment of Scarlet Devil", "Th6: EOSD", "Th6", "th6: Embodiment of Scarlet Devil", "th6: EOSD", "th6", "Embodiment of Scarlet Devil", "EOSD" });
            NameCmbx.Location = new Point(152, 138);
            NameCmbx.Name = "NameCmbx";
            NameCmbx.Size = new Size(288, 23);
            NameCmbx.TabIndex = 6;
            // 
            // NamePresetLbl
            // 
            NamePresetLbl.AutoSize = true;
            NamePresetLbl.BackColor = Color.Transparent;
            NamePresetLbl.ForeColor = Color.White;
            NamePresetLbl.Location = new Point(8, 141);
            NamePresetLbl.Name = "NamePresetLbl";
            NamePresetLbl.Size = new Size(77, 15);
            NamePresetLbl.TabIndex = 7;
            NamePresetLbl.Text = "Name Preset:";
            // 
            // ImportThcrapBtn
            // 
            ImportThcrapBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ImportThcrapBtn.BackColor = Color.FromArgb(58, 65, 65);
            ImportThcrapBtn.FlatAppearance.BorderSize = 0;
            ImportThcrapBtn.FlatStyle = FlatStyle.Flat;
            ImportThcrapBtn.ForeColor = Color.White;
            ImportThcrapBtn.Location = new Point(12, 219);
            ImportThcrapBtn.Name = "ImportThcrapBtn";
            ImportThcrapBtn.Size = new Size(134, 33);
            ImportThcrapBtn.TabIndex = 8;
            ImportThcrapBtn.Text = "Import Thcrap games";
            ImportThcrapBtn.UseVisualStyleBackColor = false;
            ImportThcrapBtn.Click += ImportThcrapBtn_Click;
            // 
            // ReimportChk
            // 
            ReimportChk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ReimportChk.AutoSize = true;
            ReimportChk.Enabled = false;
            ReimportChk.FlatStyle = FlatStyle.Flat;
            ReimportChk.ForeColor = Color.White;
            ReimportChk.Location = new Point(152, 226);
            ReimportChk.Name = "ReimportChk";
            ReimportChk.Size = new Size(203, 19);
            ReimportChk.TabIndex = 9;
            ReimportChk.Text = "Reimport thcrap games on launch";
            ReimportChk.UseVisualStyleBackColor = true;
            ReimportChk.CheckedChanged += ReimportChk_CheckedChanged;
            // 
            // CloseOnLaunchChk
            // 
            CloseOnLaunchChk.AutoSize = true;
            CloseOnLaunchChk.FlatStyle = FlatStyle.Flat;
            CloseOnLaunchChk.ForeColor = Color.White;
            CloseOnLaunchChk.Location = new Point(12, 167);
            CloseOnLaunchChk.Name = "CloseOnLaunchChk";
            CloseOnLaunchChk.Size = new Size(197, 19);
            CloseOnLaunchChk.TabIndex = 10;
            CloseOnLaunchChk.Text = "Close Launcher on Game Launch";
            CloseOnLaunchChk.UseVisualStyleBackColor = true;
            CloseOnLaunchChk.CheckedChanged += CloseOnLaunchChk_CheckedChanged;
            // 
            // CustomFirstChk
            // 
            CustomFirstChk.AutoSize = true;
            CustomFirstChk.FlatStyle = FlatStyle.Flat;
            CustomFirstChk.ForeColor = Color.White;
            CustomFirstChk.Location = new Point(12, 192);
            CustomFirstChk.Name = "CustomFirstChk";
            CustomFirstChk.Size = new Size(253, 19);
            CustomFirstChk.TabIndex = 11;
            CustomFirstChk.Text = "Display Custom Games Before Official Ones";
            CustomFirstChk.UseVisualStyleBackColor = true;
            CustomFirstChk.CheckedChanged += CustomFirstChk_CheckedChanged;
            // 
            // LanguageLbl
            // 
            LanguageLbl.AutoSize = true;
            LanguageLbl.BackColor = Color.Transparent;
            LanguageLbl.ForeColor = Color.White;
            LanguageLbl.Location = new Point(8, 9);
            LanguageLbl.Name = "LanguageLbl";
            LanguageLbl.Size = new Size(119, 15);
            LanguageLbl.TabIndex = 12;
            LanguageLbl.Text = "Language\\Language:";
            // 
            // LanguageCmbx
            // 
            LanguageCmbx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LanguageCmbx.BackColor = Color.FromArgb(58, 65, 65);
            LanguageCmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            LanguageCmbx.FlatStyle = FlatStyle.System;
            LanguageCmbx.ForeColor = Color.White;
            LanguageCmbx.Location = new Point(152, 6);
            LanguageCmbx.Name = "LanguageCmbx";
            LanguageCmbx.Size = new Size(288, 23);
            LanguageCmbx.TabIndex = 13;
            LanguageCmbx.SelectedIndexChanged += LanguageCmbx_SelectedIndexChanged;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 36, 35);
            ClientSize = new Size(452, 264);
            Controls.Add(LanguageCmbx);
            Controls.Add(LanguageLbl);
            Controls.Add(CustomFirstChk);
            Controls.Add(CloseOnLaunchChk);
            Controls.Add(ReimportChk);
            Controls.Add(ImportThcrapBtn);
            Controls.Add(NamePresetLbl);
            Controls.Add(NameCmbx);
            Controls.Add(NekoTextBox);
            Controls.Add(NekoLbl);
            Controls.Add(UseNekoChk);
            Controls.Add(ThcrapTextBox);
            Controls.Add(UseThcrapChk);
            Controls.Add(ThcrapPathLbl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(402, 303);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosing += Settings_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ThcrapPathLbl;
        private CheckBox UseThcrapChk;
        private TextBox ThcrapTextBox;
        private CheckBox UseNekoChk;
        private TextBox NekoTextBox;
        private Label NekoLbl;
        private ComboBox NameCmbx;
        private Label NamePresetLbl;
        private Button ImportThcrapBtn;
        private CheckBox ReimportChk;
        private CheckBox CloseOnLaunchChk;
        private CheckBox CustomFirstChk;
        private Label LanguageLbl;
        private ComboBox LanguageCmbx;
    }
}