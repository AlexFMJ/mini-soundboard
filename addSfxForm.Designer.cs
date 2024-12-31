namespace mini_soundboard
{
    partial class addSfxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addSfxForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sfxFilePathTxt = new System.Windows.Forms.TextBox();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.sfxNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sfxSetHotkeyBtn = new System.Windows.Forms.Button();
            this.addSfxCancelBtn = new System.Windows.Forms.Button();
            this.addSfxConfirmBtn = new System.Windows.Forms.Button();
            this.sfxVolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.volumeValLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.unsetHKBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfxVolumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // sfxFilePathTxt
            // 
            this.sfxFilePathTxt.AllowDrop = true;
            resources.ApplyResources(this.sfxFilePathTxt, "sfxFilePathTxt");
            this.sfxFilePathTxt.Name = "sfxFilePathTxt";
            // 
            // openFileBtn
            // 
            resources.ApplyResources(this.openFileBtn, "openFileBtn");
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.getSfxPath);
            // 
            // sfxNameTxt
            // 
            resources.ApplyResources(this.sfxNameTxt, "sfxNameTxt");
            this.sfxNameTxt.Name = "sfxNameTxt";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // sfxSetHotkeyBtn
            // 
            this.sfxSetHotkeyBtn.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.sfxSetHotkeyBtn, "sfxSetHotkeyBtn");
            this.sfxSetHotkeyBtn.ForeColor = System.Drawing.Color.Gray;
            this.sfxSetHotkeyBtn.Name = "sfxSetHotkeyBtn";
            this.sfxSetHotkeyBtn.UseVisualStyleBackColor = false;
            this.sfxSetHotkeyBtn.Enter += new System.EventHandler(this.sfxSetHotkeyBtn_Enter);
            this.sfxSetHotkeyBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sfxSetHotkeyBtn_KeyDown);
            this.sfxSetHotkeyBtn.Leave += new System.EventHandler(this.sfxSetHotkeyBtn_Leave);
            // 
            // addSfxCancelBtn
            // 
            this.addSfxCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.addSfxCancelBtn, "addSfxCancelBtn");
            this.addSfxCancelBtn.Name = "addSfxCancelBtn";
            this.addSfxCancelBtn.UseVisualStyleBackColor = true;
            this.addSfxCancelBtn.Click += new System.EventHandler(this.addSfxCancelBtn_Click);
            // 
            // addSfxConfirmBtn
            // 
            resources.ApplyResources(this.addSfxConfirmBtn, "addSfxConfirmBtn");
            this.addSfxConfirmBtn.Name = "addSfxConfirmBtn";
            this.addSfxConfirmBtn.UseVisualStyleBackColor = true;
            this.addSfxConfirmBtn.Click += new System.EventHandler(this.addSfxConfirmBtn_Click);
            // 
            // sfxVolumeTrackBar
            // 
            resources.ApplyResources(this.sfxVolumeTrackBar, "sfxVolumeTrackBar");
            this.sfxVolumeTrackBar.Maximum = 100;
            this.sfxVolumeTrackBar.Name = "sfxVolumeTrackBar";
            this.sfxVolumeTrackBar.TickFrequency = 25;
            this.sfxVolumeTrackBar.Value = 100;
            this.sfxVolumeTrackBar.ValueChanged += new System.EventHandler(this.sfxVolumeTrackBar_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // volumeValLbl
            // 
            resources.ApplyResources(this.volumeValLbl, "volumeValLbl");
            this.volumeValLbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.volumeValLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.volumeValLbl.Name = "volumeValLbl";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // unsetHKBtn
            // 
            resources.ApplyResources(this.unsetHKBtn, "unsetHKBtn");
            this.unsetHKBtn.Name = "unsetHKBtn";
            this.unsetHKBtn.UseVisualStyleBackColor = true;
            this.unsetHKBtn.Click += new System.EventHandler(this.unsetHKBtn_Click);
            // 
            // addSfxForm
            // 
            this.AcceptButton = this.addSfxConfirmBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.addSfxCancelBtn;
            this.Controls.Add(this.unsetHKBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.volumeValLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sfxVolumeTrackBar);
            this.Controls.Add(this.addSfxConfirmBtn);
            this.Controls.Add(this.addSfxCancelBtn);
            this.Controls.Add(this.sfxSetHotkeyBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sfxNameTxt);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.sfxFilePathTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "addSfxForm";
            ((System.ComponentModel.ISupportInitialize)(this.sfxVolumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox sfxFilePathTxt;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.TextBox sfxNameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sfxSetHotkeyBtn;
        private System.Windows.Forms.Button addSfxCancelBtn;
        private System.Windows.Forms.Button addSfxConfirmBtn;
        private System.Windows.Forms.TrackBar sfxVolumeTrackBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label volumeValLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button unsetHKBtn;
    }
}