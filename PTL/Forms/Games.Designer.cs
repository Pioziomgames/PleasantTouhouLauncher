namespace PTL
{
    partial class Games
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Games));
            RemoveBtn = new Button();
            EditBtn = new Button();
            AddBtn = new Button();
            GamesListBox = new ListBox();
            SuspendLayout();
            // 
            // RemoveBtn
            // 
            RemoveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RemoveBtn.BackColor = Color.FromArgb(58, 65, 65);
            RemoveBtn.FlatAppearance.BorderSize = 0;
            RemoveBtn.FlatStyle = FlatStyle.Flat;
            RemoveBtn.ForeColor = Color.White;
            RemoveBtn.Location = new Point(12, 415);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(90, 23);
            RemoveBtn.TabIndex = 5;
            RemoveBtn.Text = "Remove";
            RemoveBtn.UseVisualStyleBackColor = false;
            RemoveBtn.Click += RemoveBtn_Click;
            // 
            // EditBtn
            // 
            EditBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EditBtn.BackColor = Color.FromArgb(58, 65, 65);
            EditBtn.FlatAppearance.BorderSize = 0;
            EditBtn.FlatStyle = FlatStyle.Flat;
            EditBtn.ForeColor = Color.White;
            EditBtn.Location = new Point(118, 415);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(90, 23);
            EditBtn.TabIndex = 6;
            EditBtn.Text = "Edit";
            EditBtn.UseVisualStyleBackColor = false;
            EditBtn.Click += EditBtn_Click;
            // 
            // AddBtn
            // 
            AddBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddBtn.BackColor = Color.FromArgb(58, 65, 65);
            AddBtn.FlatAppearance.BorderSize = 0;
            AddBtn.FlatStyle = FlatStyle.Flat;
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(225, 415);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(90, 23);
            AddBtn.TabIndex = 7;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // GamesListBox
            // 
            GamesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GamesListBox.BackColor = Color.FromArgb(32, 36, 35);
            GamesListBox.BorderStyle = BorderStyle.FixedSingle;
            GamesListBox.ForeColor = Color.White;
            GamesListBox.FormattingEnabled = true;
            GamesListBox.ItemHeight = 15;
            GamesListBox.Location = new Point(12, 12);
            GamesListBox.Name = "GamesListBox";
            GamesListBox.Size = new Size(303, 392);
            GamesListBox.TabIndex = 8;
            // 
            // Games
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 36, 35);
            ClientSize = new Size(327, 450);
            Controls.Add(GamesListBox);
            Controls.Add(AddBtn);
            Controls.Add(EditBtn);
            Controls.Add(RemoveBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(343, 489);
            Name = "Games";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Games";
            ResumeLayout(false);
        }

        #endregion

        private Button RemoveBtn;
        private Button EditBtn;
        private Button AddBtn;
        private ListBox GamesListBox;
    }
}