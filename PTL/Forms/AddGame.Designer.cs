namespace PTL.Forms
{
    partial class AddGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGame));
            SaveBtn = new Button();
            CancelBtn = new Button();
            GameCmbx = new ComboBox();
            GameLbl = new Label();
            UseThcrapChk = new CheckBox();
            GamePathLbl = new Label();
            AdminChk = new CheckBox();
            ConfigChk = new CheckBox();
            ConfigPathLbl = new Label();
            ConfigPathTextBox = new TextBox();
            NameLbl = new Label();
            NameTextBox = new TextBox();
            GamePathTextBox = new TextBox();
            HiddenGameTextBox = new TextBox();
            GameImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)GameImage).BeginInit();
            SuspendLayout();
            // 
            // SaveBtn
            // 
            SaveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SaveBtn.BackColor = Color.FromArgb(58, 65, 65);
            SaveBtn.FlatAppearance.BorderSize = 0;
            SaveBtn.FlatStyle = FlatStyle.Flat;
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(108, 231);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(90, 23);
            SaveBtn.TabIndex = 8;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelBtn.BackColor = Color.FromArgb(58, 65, 65);
            CancelBtn.FlatAppearance.BorderSize = 0;
            CancelBtn.FlatStyle = FlatStyle.Flat;
            CancelBtn.ForeColor = Color.White;
            CancelBtn.Location = new Point(12, 231);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(90, 23);
            CancelBtn.TabIndex = 9;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // GameCmbx
            // 
            GameCmbx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GameCmbx.BackColor = Color.FromArgb(58, 65, 65);
            GameCmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            GameCmbx.FlatStyle = FlatStyle.System;
            GameCmbx.ForeColor = Color.White;
            GameCmbx.Location = new Point(121, 6);
            GameCmbx.Name = "GameCmbx";
            GameCmbx.Size = new Size(235, 23);
            GameCmbx.TabIndex = 10;
            GameCmbx.SelectionChangeCommitted += GameCmbx_SelectionChangeCommitted;
            // 
            // GameLbl
            // 
            GameLbl.AutoSize = true;
            GameLbl.BackColor = Color.Transparent;
            GameLbl.ForeColor = Color.White;
            GameLbl.Location = new Point(12, 9);
            GameLbl.Name = "GameLbl";
            GameLbl.Size = new Size(41, 15);
            GameLbl.TabIndex = 11;
            GameLbl.Text = "Game:";
            // 
            // UseThcrapChk
            // 
            UseThcrapChk.AutoSize = true;
            UseThcrapChk.FlatStyle = FlatStyle.Flat;
            UseThcrapChk.ForeColor = Color.White;
            UseThcrapChk.Location = new Point(12, 173);
            UseThcrapChk.Name = "UseThcrapChk";
            UseThcrapChk.Size = new Size(125, 19);
            UseThcrapChk.TabIndex = 13;
            UseThcrapChk.Text = "Launch with thcrap";
            UseThcrapChk.UseVisualStyleBackColor = true;
            // 
            // GamePathLbl
            // 
            GamePathLbl.AutoSize = true;
            GamePathLbl.BackColor = Color.Transparent;
            GamePathLbl.ForeColor = Color.White;
            GamePathLbl.Location = new Point(12, 67);
            GamePathLbl.Name = "GamePathLbl";
            GamePathLbl.Size = new Size(68, 15);
            GamePathLbl.TabIndex = 14;
            GamePathLbl.Text = "Game path:";
            // 
            // AdminChk
            // 
            AdminChk.AutoSize = true;
            AdminChk.FlatStyle = FlatStyle.Flat;
            AdminChk.ForeColor = Color.White;
            AdminChk.Location = new Point(12, 148);
            AdminChk.Name = "AdminChk";
            AdminChk.Size = new Size(150, 19);
            AdminChk.TabIndex = 15;
            AdminChk.Text = "Launch as administrator";
            AdminChk.UseVisualStyleBackColor = true;
            // 
            // ConfigChk
            // 
            ConfigChk.AutoSize = true;
            ConfigChk.FlatStyle = FlatStyle.Flat;
            ConfigChk.ForeColor = Color.White;
            ConfigChk.Location = new Point(12, 94);
            ConfigChk.Name = "ConfigChk";
            ConfigChk.Size = new Size(128, 19);
            ConfigChk.TabIndex = 16;
            ConfigChk.Text = "Use Config/Custom";
            ConfigChk.UseVisualStyleBackColor = true;
            ConfigChk.CheckedChanged += ConfigChk_CheckedChanged;
            // 
            // ConfigPathLbl
            // 
            ConfigPathLbl.AutoSize = true;
            ConfigPathLbl.BackColor = Color.Transparent;
            ConfigPathLbl.Enabled = false;
            ConfigPathLbl.ForeColor = Color.White;
            ConfigPathLbl.Location = new Point(12, 121);
            ConfigPathLbl.Name = "ConfigPathLbl";
            ConfigPathLbl.Size = new Size(79, 15);
            ConfigPathLbl.TabIndex = 18;
            ConfigPathLbl.Text = "Custom path:";
            // 
            // ConfigPathTextBox
            // 
            ConfigPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ConfigPathTextBox.BackColor = Color.FromArgb(58, 65, 65);
            ConfigPathTextBox.BorderStyle = BorderStyle.FixedSingle;
            ConfigPathTextBox.Enabled = false;
            ConfigPathTextBox.ForeColor = Color.White;
            ConfigPathTextBox.Location = new Point(121, 119);
            ConfigPathTextBox.Name = "ConfigPathTextBox";
            ConfigPathTextBox.ReadOnly = true;
            ConfigPathTextBox.Size = new Size(235, 23);
            ConfigPathTextBox.TabIndex = 17;
            ConfigPathTextBox.Click += ConfigPathTextBox_Click;
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.BackColor = Color.Transparent;
            NameLbl.Enabled = false;
            NameLbl.ForeColor = Color.White;
            NameLbl.Location = new Point(12, 38);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(42, 15);
            NameLbl.TabIndex = 19;
            NameLbl.Text = "Name:";
            // 
            // NameTextBox
            // 
            NameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NameTextBox.BackColor = Color.FromArgb(30, 30, 30);
            NameTextBox.BorderStyle = BorderStyle.FixedSingle;
            NameTextBox.Enabled = false;
            NameTextBox.ForeColor = Color.White;
            NameTextBox.Location = new Point(121, 36);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(235, 23);
            NameTextBox.TabIndex = 20;
            // 
            // GamePathTextBox
            // 
            GamePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GamePathTextBox.BackColor = Color.FromArgb(58, 65, 65);
            GamePathTextBox.BorderStyle = BorderStyle.FixedSingle;
            GamePathTextBox.ForeColor = Color.White;
            GamePathTextBox.Location = new Point(121, 65);
            GamePathTextBox.Name = "GamePathTextBox";
            GamePathTextBox.ReadOnly = true;
            GamePathTextBox.Size = new Size(235, 23);
            GamePathTextBox.TabIndex = 12;
            GamePathTextBox.Click += GamePathTextBox_Click;
            // 
            // HiddenGameTextBox
            // 
            HiddenGameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HiddenGameTextBox.BackColor = Color.FromArgb(58, 65, 65);
            HiddenGameTextBox.BorderStyle = BorderStyle.FixedSingle;
            HiddenGameTextBox.ForeColor = Color.White;
            HiddenGameTextBox.Location = new Point(121, 7);
            HiddenGameTextBox.Name = "HiddenGameTextBox";
            HiddenGameTextBox.ReadOnly = true;
            HiddenGameTextBox.Size = new Size(235, 23);
            HiddenGameTextBox.TabIndex = 21;
            HiddenGameTextBox.Visible = false;
            // 
            // GameImage
            // 
            GameImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GameImage.BorderStyle = BorderStyle.FixedSingle;
            GameImage.Location = new Point(256, 154);
            GameImage.Name = "GameImage";
            GameImage.Size = new Size(100, 100);
            GameImage.SizeMode = PictureBoxSizeMode.StretchImage;
            GameImage.TabIndex = 23;
            GameImage.TabStop = false;
            GameImage.Click += GameImage_Click;
            // 
            // AddGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 36, 35);
            ClientSize = new Size(370, 266);
            Controls.Add(GameImage);
            Controls.Add(GameCmbx);
            Controls.Add(NameTextBox);
            Controls.Add(NameLbl);
            Controls.Add(ConfigPathLbl);
            Controls.Add(ConfigPathTextBox);
            Controls.Add(ConfigChk);
            Controls.Add(AdminChk);
            Controls.Add(GamePathLbl);
            Controls.Add(UseThcrapChk);
            Controls.Add(GamePathTextBox);
            Controls.Add(GameLbl);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(HiddenGameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(339, 305);
            Name = "AddGame";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Game";
            ((System.ComponentModel.ISupportInitialize)GameImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveBtn;
        private Button CancelBtn;
        private ComboBox GameCmbx;
        private Label GameLbl;
        private CheckBox UseThcrapChk;
        private Label GamePathLbl;
        private CheckBox AdminChk;
        private CheckBox ConfigChk;
        private Label ConfigPathLbl;
        private TextBox ConfigPathTextBox;
        private Label NameLbl;
        private TextBox NameTextBox;
        private TextBox GamePathTextBox;
        private TextBox HiddenGameTextBox;
        private PictureBox GameImage;
    }
}