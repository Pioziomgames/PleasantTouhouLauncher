namespace PTL
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            GameLayoutPanel = new FlowLayoutPanel();
            ThcrapProfileBox = new ComboBox();
            ThcrapProfileLbl = new Label();
            SettingsBtn = new Button();
            GamesBtn = new Button();
            panel1 = new Panel();
            GithubBtn = new Button();
            FontPlusBtn = new Button();
            FontMinusBtn = new Button();
            PlusBtn = new Button();
            MinusBtn = new Button();
            RandomBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // GameLayoutPanel
            // 
            GameLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GameLayoutPanel.AutoScroll = true;
            GameLayoutPanel.BackColor = Color.FromArgb(32, 36, 35);
            GameLayoutPanel.Location = new Point(2, 29);
            GameLayoutPanel.Name = "GameLayoutPanel";
            GameLayoutPanel.Size = new Size(797, 515);
            GameLayoutPanel.TabIndex = 0;
            // 
            // ThcrapProfileBox
            // 
            ThcrapProfileBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ThcrapProfileBox.BackColor = Color.FromArgb(58, 65, 65);
            ThcrapProfileBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ThcrapProfileBox.FlatStyle = FlatStyle.System;
            ThcrapProfileBox.ForeColor = Color.White;
            ThcrapProfileBox.FormattingEnabled = true;
            ThcrapProfileBox.Location = new Point(553, 0);
            ThcrapProfileBox.Name = "ThcrapProfileBox";
            ThcrapProfileBox.Size = new Size(244, 23);
            ThcrapProfileBox.TabIndex = 1;
            ThcrapProfileBox.SelectionChangeCommitted += ThcrapProfileBox_SelectionChangeCommitted;
            // 
            // ThcrapProfileLbl
            // 
            ThcrapProfileLbl.AutoSize = true;
            ThcrapProfileLbl.ForeColor = Color.White;
            ThcrapProfileLbl.Location = new Point(444, 4);
            ThcrapProfileLbl.Name = "ThcrapProfileLbl";
            ThcrapProfileLbl.Size = new Size(92, 15);
            ThcrapProfileLbl.TabIndex = 3;
            ThcrapProfileLbl.Text = "THCRAP Profile:";
            // 
            // SettingsBtn
            // 
            SettingsBtn.BackColor = Color.FromArgb(58, 65, 65);
            SettingsBtn.FlatAppearance.BorderSize = 0;
            SettingsBtn.FlatStyle = FlatStyle.Flat;
            SettingsBtn.ForeColor = Color.White;
            SettingsBtn.Location = new Point(0, 0);
            SettingsBtn.Name = "SettingsBtn";
            SettingsBtn.Size = new Size(94, 23);
            SettingsBtn.TabIndex = 2;
            SettingsBtn.Text = "Settings";
            SettingsBtn.UseVisualStyleBackColor = false;
            SettingsBtn.Click += SettingsBtn_Click;
            // 
            // GamesBtn
            // 
            GamesBtn.BackColor = Color.FromArgb(58, 65, 65);
            GamesBtn.FlatAppearance.BorderSize = 0;
            GamesBtn.FlatStyle = FlatStyle.Flat;
            GamesBtn.ForeColor = Color.White;
            GamesBtn.Location = new Point(100, 0);
            GamesBtn.Name = "GamesBtn";
            GamesBtn.Size = new Size(94, 23);
            GamesBtn.TabIndex = 4;
            GamesBtn.Text = "Games";
            GamesBtn.UseVisualStyleBackColor = false;
            GamesBtn.Click += GamesBtn_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(32, 36, 35);
            panel1.Controls.Add(GithubBtn);
            panel1.Controls.Add(FontPlusBtn);
            panel1.Controls.Add(FontMinusBtn);
            panel1.Controls.Add(PlusBtn);
            panel1.Controls.Add(MinusBtn);
            panel1.Controls.Add(RandomBtn);
            panel1.Controls.Add(ThcrapProfileLbl);
            panel1.Controls.Add(ThcrapProfileBox);
            panel1.Controls.Add(GamesBtn);
            panel1.Controls.Add(SettingsBtn);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 23);
            panel1.TabIndex = 4;
            // 
            // GithubBtn
            // 
            GithubBtn.BackColor = Color.FromArgb(58, 65, 65);
            GithubBtn.FlatAppearance.BorderSize = 0;
            GithubBtn.FlatStyle = FlatStyle.Flat;
            GithubBtn.ForeColor = Color.White;
            GithubBtn.Location = new Point(200, 0);
            GithubBtn.Name = "GithubBtn";
            GithubBtn.Size = new Size(94, 23);
            GithubBtn.TabIndex = 10;
            GithubBtn.Text = "Github";
            GithubBtn.UseVisualStyleBackColor = false;
            GithubBtn.Click += GithubBtn_Click;
            // 
            // FontPlusBtn
            // 
            FontPlusBtn.BackColor = Color.Transparent;
            FontPlusBtn.BackgroundImage = Properties.Resources.FPlus;
            FontPlusBtn.BackgroundImageLayout = ImageLayout.Stretch;
            FontPlusBtn.FlatAppearance.BorderSize = 0;
            FontPlusBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(147, 159, 159);
            FontPlusBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 65, 65);
            FontPlusBtn.FlatStyle = FlatStyle.Flat;
            FontPlusBtn.Location = new Point(415, 0);
            FontPlusBtn.Name = "FontPlusBtn";
            FontPlusBtn.Size = new Size(23, 23);
            FontPlusBtn.TabIndex = 9;
            FontPlusBtn.UseVisualStyleBackColor = false;
            FontPlusBtn.Click += FontPlusBtn_Click;
            // 
            // FontMinusBtn
            // 
            FontMinusBtn.BackColor = Color.Transparent;
            FontMinusBtn.BackgroundImage = Properties.Resources.FMinus;
            FontMinusBtn.BackgroundImageLayout = ImageLayout.Stretch;
            FontMinusBtn.FlatAppearance.BorderSize = 0;
            FontMinusBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(147, 159, 159);
            FontMinusBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 65, 65);
            FontMinusBtn.FlatStyle = FlatStyle.Flat;
            FontMinusBtn.Location = new Point(386, 0);
            FontMinusBtn.Name = "FontMinusBtn";
            FontMinusBtn.Size = new Size(23, 23);
            FontMinusBtn.TabIndex = 8;
            FontMinusBtn.UseVisualStyleBackColor = false;
            FontMinusBtn.Click += FontMinusBtn_Click;
            // 
            // PlusBtn
            // 
            PlusBtn.BackColor = Color.Transparent;
            PlusBtn.BackgroundImage = Properties.Resources.plus;
            PlusBtn.BackgroundImageLayout = ImageLayout.Stretch;
            PlusBtn.FlatAppearance.BorderSize = 0;
            PlusBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(147, 159, 159);
            PlusBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 65, 65);
            PlusBtn.FlatStyle = FlatStyle.Flat;
            PlusBtn.Location = new Point(357, 0);
            PlusBtn.Name = "PlusBtn";
            PlusBtn.Size = new Size(23, 23);
            PlusBtn.TabIndex = 7;
            PlusBtn.UseVisualStyleBackColor = false;
            PlusBtn.Click += PlusBtn_Click;
            // 
            // MinusBtn
            // 
            MinusBtn.BackColor = Color.Transparent;
            MinusBtn.BackgroundImage = Properties.Resources.minus;
            MinusBtn.BackgroundImageLayout = ImageLayout.Stretch;
            MinusBtn.FlatAppearance.BorderSize = 0;
            MinusBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(147, 159, 159);
            MinusBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 65, 65);
            MinusBtn.FlatStyle = FlatStyle.Flat;
            MinusBtn.Location = new Point(328, 0);
            MinusBtn.Name = "MinusBtn";
            MinusBtn.Size = new Size(23, 23);
            MinusBtn.TabIndex = 6;
            MinusBtn.UseVisualStyleBackColor = false;
            MinusBtn.Click += MinusBtn_Click;
            // 
            // RandomBtn
            // 
            RandomBtn.BackColor = Color.Transparent;
            RandomBtn.BackgroundImage = Properties.Resources.dice;
            RandomBtn.BackgroundImageLayout = ImageLayout.Stretch;
            RandomBtn.FlatAppearance.BorderSize = 0;
            RandomBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(147, 159, 159);
            RandomBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 65, 65);
            RandomBtn.FlatStyle = FlatStyle.Flat;
            RandomBtn.Location = new Point(299, 0);
            RandomBtn.Name = "RandomBtn";
            RandomBtn.Size = new Size(23, 23);
            RandomBtn.TabIndex = 5;
            RandomBtn.UseVisualStyleBackColor = false;
            RandomBtn.Click += RandomBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 36, 35);
            ClientSize = new Size(802, 548);
            Controls.Add(panel1);
            Controls.Add(GameLayoutPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(563, 184);
            Name = "MainForm";
            Text = "Pleasant Touhou Launcher";
            Shown += MainForm_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel GameLayoutPanel;
        private ComboBox ThcrapProfileBox;
        private Label ThcrapProfileLbl;
        private Button SettingsBtn;
        private Button GamesBtn;
        private Panel panel1;
        private Button RandomBtn;
        private Button PlusBtn;
        private Button MinusBtn;
        private Button FontPlusBtn;
        private Button FontMinusBtn;
        private Button GithubBtn;
    }
}