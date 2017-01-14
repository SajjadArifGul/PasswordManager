namespace PasswordManager.App
{
    partial class MasterPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterPasswordForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMasterNote = new System.Windows.Forms.Label();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.TitlePictureBox = new System.Windows.Forms.PictureBox();
            this.lblAppMotto = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picboxLoading = new System.Windows.Forms.PictureBox();
            this.chkHideConfirmMaster = new System.Windows.Forms.CheckBox();
            this.chkHideNewMaster = new System.Windows.Forms.CheckBox();
            this.chkHideMaster = new System.Windows.Forms.CheckBox();
            this.txtConfirmMaster = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewMaster = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMassege = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.lblMasterNote);
            this.panel1.Controls.Add(this.TitlePanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 461);
            this.panel1.TabIndex = 52;
            // 
            // lblMasterNote
            // 
            this.lblMasterNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMasterNote.BackColor = System.Drawing.Color.Transparent;
            this.lblMasterNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMasterNote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterNote.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblMasterNote.Location = new System.Drawing.Point(40, 75);
            this.lblMasterNote.Name = "lblMasterNote";
            this.lblMasterNote.Size = new System.Drawing.Size(376, 170);
            this.lblMasterNote.TabIndex = 78;
            // 
            // TitlePanel
            // 
            this.TitlePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitlePanel.Controls.Add(this.lblFormTitle);
            this.TitlePanel.Controls.Add(this.TitlePictureBox);
            this.TitlePanel.Controls.Add(this.lblAppMotto);
            this.TitlePanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TitlePanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TitlePanel.Location = new System.Drawing.Point(95, 2);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(321, 70);
            this.TitlePanel.TabIndex = 77;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Location = new System.Drawing.Point(63, 8);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(199, 32);
            this.lblFormTitle.TabIndex = 34;
            this.lblFormTitle.Text = "Master Password";
            // 
            // TitlePictureBox
            // 
            this.TitlePictureBox.Image = global::PasswordManager.App.Properties.Resources.flag_bear;
            this.TitlePictureBox.Location = new System.Drawing.Point(3, 5);
            this.TitlePictureBox.Name = "TitlePictureBox";
            this.TitlePictureBox.Size = new System.Drawing.Size(60, 60);
            this.TitlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TitlePictureBox.TabIndex = 10;
            this.TitlePictureBox.TabStop = false;
            // 
            // lblAppMotto
            // 
            this.lblAppMotto.AutoSize = true;
            this.lblAppMotto.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lblAppMotto.Location = new System.Drawing.Point(67, 38);
            this.lblAppMotto.Name = "lblAppMotto";
            this.lblAppMotto.Size = new System.Drawing.Size(247, 17);
            this.lblAppMotto.TabIndex = 89;
            this.lblAppMotto.Text = "BearPass - Personal Password Manager";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.picboxLoading);
            this.panel2.Controls.Add(this.chkHideConfirmMaster);
            this.panel2.Controls.Add(this.chkHideNewMaster);
            this.panel2.Controls.Add(this.chkHideMaster);
            this.panel2.Controls.Add(this.txtConfirmMaster);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNewMaster);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtMaster);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
            this.panel2.Location = new System.Drawing.Point(0, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 212);
            this.panel2.TabIndex = 60;
            // 
            // picboxLoading
            // 
            this.picboxLoading.Image = global::PasswordManager.App.Properties.Resources.loading_gear_anim;
            this.picboxLoading.Location = new System.Drawing.Point(164, 113);
            this.picboxLoading.Name = "picboxLoading";
            this.picboxLoading.Size = new System.Drawing.Size(45, 43);
            this.picboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxLoading.TabIndex = 86;
            this.picboxLoading.TabStop = false;
            this.picboxLoading.Visible = false;
            // 
            // chkHideConfirmMaster
            // 
            this.chkHideConfirmMaster.AutoSize = true;
            this.chkHideConfirmMaster.Checked = true;
            this.chkHideConfirmMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideConfirmMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHideConfirmMaster.Location = new System.Drawing.Point(332, 78);
            this.chkHideConfirmMaster.Name = "chkHideConfirmMaster";
            this.chkHideConfirmMaster.Size = new System.Drawing.Size(58, 25);
            this.chkHideConfirmMaster.TabIndex = 85;
            this.chkHideConfirmMaster.Text = "Hide";
            this.chkHideConfirmMaster.UseVisualStyleBackColor = true;
            this.chkHideConfirmMaster.CheckedChanged += new System.EventHandler(this.chkShowConfirmMaster_CheckedChanged);
            // 
            // chkHideNewMaster
            // 
            this.chkHideNewMaster.AutoSize = true;
            this.chkHideNewMaster.Checked = true;
            this.chkHideNewMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideNewMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHideNewMaster.Location = new System.Drawing.Point(332, 43);
            this.chkHideNewMaster.Name = "chkHideNewMaster";
            this.chkHideNewMaster.Size = new System.Drawing.Size(58, 25);
            this.chkHideNewMaster.TabIndex = 84;
            this.chkHideNewMaster.Text = "Hide";
            this.chkHideNewMaster.UseVisualStyleBackColor = true;
            this.chkHideNewMaster.CheckedChanged += new System.EventHandler(this.chkShowNewMaster_CheckedChanged);
            // 
            // chkHideMaster
            // 
            this.chkHideMaster.AutoSize = true;
            this.chkHideMaster.Checked = true;
            this.chkHideMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHideMaster.Location = new System.Drawing.Point(332, 8);
            this.chkHideMaster.Name = "chkHideMaster";
            this.chkHideMaster.Size = new System.Drawing.Size(58, 25);
            this.chkHideMaster.TabIndex = 83;
            this.chkHideMaster.Text = "Hide";
            this.chkHideMaster.UseVisualStyleBackColor = true;
            this.chkHideMaster.CheckedChanged += new System.EventHandler(this.chkShowMaster_CheckedChanged);
            // 
            // txtConfirmMaster
            // 
            this.txtConfirmMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.txtConfirmMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
            this.txtConfirmMaster.Location = new System.Drawing.Point(164, 78);
            this.txtConfirmMaster.Name = "txtConfirmMaster";
            this.txtConfirmMaster.Size = new System.Drawing.Size(162, 29);
            this.txtConfirmMaster.TabIndex = 82;
            this.txtConfirmMaster.UseSystemPasswordChar = true;
            this.txtConfirmMaster.TextChanged += new System.EventHandler(this.CheckSaveEnable);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 21);
            this.label4.TabIndex = 81;
            this.label4.Text = "Confirm Master :";
            // 
            // txtNewMaster
            // 
            this.txtNewMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.txtNewMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
            this.txtNewMaster.Location = new System.Drawing.Point(164, 43);
            this.txtNewMaster.Name = "txtNewMaster";
            this.txtNewMaster.Size = new System.Drawing.Size(162, 29);
            this.txtNewMaster.TabIndex = 80;
            this.txtNewMaster.UseSystemPasswordChar = true;
            this.txtNewMaster.TextChanged += new System.EventHandler(this.CheckSaveEnable);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 79;
            this.label1.Text = "New Master :";
            // 
            // txtMaster
            // 
            this.txtMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.txtMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
            this.txtMaster.Location = new System.Drawing.Point(164, 8);
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.Size = new System.Drawing.Size(162, 29);
            this.txtMaster.TabIndex = 32;
            this.txtMaster.UseSystemPasswordChar = true;
            this.txtMaster.TextChanged += new System.EventHandler(this.CheckSaveEnable);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 21);
            this.label7.TabIndex = 29;
            this.label7.Text = "Existing Master :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::PasswordManager.App.Properties.Resources.password_master_save_40;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(216, 113);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 42);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Change";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMassege
            // 
            this.lblMassege.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMassege.Image = global::PasswordManager.App.Properties.Resources.icon_blue;
            this.lblMassege.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMassege.Location = new System.Drawing.Point(0, 406);
            this.lblMassege.Name = "lblMassege";
            this.lblMassege.Size = new System.Drawing.Size(484, 55);
            this.lblMassege.TabIndex = 53;
            this.lblMassege.Text = " ";
            this.lblMassege.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MasterPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.lblMassege);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MasterPasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Password";
            this.Load += new System.EventHandler(this.MasterPasswordForm_Load);
            this.panel1.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox TitlePictureBox;
        private System.Windows.Forms.Label lblAppMotto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtConfirmMaster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewMaster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMasterNote;
        private System.Windows.Forms.CheckBox chkHideConfirmMaster;
        private System.Windows.Forms.CheckBox chkHideNewMaster;
        private System.Windows.Forms.CheckBox chkHideMaster;
        private System.Windows.Forms.Label lblMassege;
        private System.Windows.Forms.PictureBox picboxLoading;
    }
}