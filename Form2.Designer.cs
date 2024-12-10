namespace soundboard_sandbox
{
    partial class OpenFileForm
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
            ((System.ComponentModel.ISupportInitialize)(this.sfxVolumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "\"Supported Files (.mp3, .m4a, .aac .wav)|*.mp3;*.MP3;*.m4a;*.M4A*.aac;*.AAC;*.wav" +
    ";*.WAV|aac Files|*.aac;*.AAC|mp3 Files|*.mp3;*.MP3|m4a Files|*m4a;.M4A|wav Files" +
    "|*.wav;*.WAV\"";
            // 
            // sfxFilePathTxt
            // 
            this.sfxFilePathTxt.AllowDrop = true;
            this.sfxFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfxFilePathTxt.Location = new System.Drawing.Point(82, 39);
            this.sfxFilePathTxt.MaxLength = 10000;
            this.sfxFilePathTxt.Name = "sfxFilePathTxt";
            this.sfxFilePathTxt.Size = new System.Drawing.Size(263, 26);
            this.sfxFilePathTxt.TabIndex = 0;
            this.sfxFilePathTxt.WordWrap = false;
            // 
            // openFileBtn
            // 
            this.openFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileBtn.Location = new System.Drawing.Point(351, 38);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(89, 28);
            this.openFileBtn.TabIndex = 1;
            this.openFileBtn.Text = "Browse";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.getSfxPath);
            // 
            // sfxNameTxt
            // 
            this.sfxNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfxNameTxt.Location = new System.Drawing.Point(82, 107);
            this.sfxNameTxt.MaxLength = 10000;
            this.sfxNameTxt.Name = "sfxNameTxt";
            this.sfxNameTxt.Size = new System.Drawing.Size(358, 26);
            this.sfxNameTxt.TabIndex = 2;
            this.sfxNameTxt.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hotkey:";
            // 
            // sfxSetHotkeyBtn
            // 
            this.sfxSetHotkeyBtn.BackColor = System.Drawing.Color.White;
            this.sfxSetHotkeyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sfxSetHotkeyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfxSetHotkeyBtn.ForeColor = System.Drawing.Color.Gray;
            this.sfxSetHotkeyBtn.Location = new System.Drawing.Point(82, 172);
            this.sfxSetHotkeyBtn.Name = "sfxSetHotkeyBtn";
            this.sfxSetHotkeyBtn.Size = new System.Drawing.Size(358, 28);
            this.sfxSetHotkeyBtn.TabIndex = 7;
            this.sfxSetHotkeyBtn.Text = "click to set Hotkey";
            this.sfxSetHotkeyBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sfxSetHotkeyBtn.UseVisualStyleBackColor = false;
            // 
            // addSfxCancelBtn
            // 
            this.addSfxCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addSfxCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSfxCancelBtn.Location = new System.Drawing.Point(97, 311);
            this.addSfxCancelBtn.Name = "addSfxCancelBtn";
            this.addSfxCancelBtn.Size = new System.Drawing.Size(123, 32);
            this.addSfxCancelBtn.TabIndex = 8;
            this.addSfxCancelBtn.Text = "Cancel";
            this.addSfxCancelBtn.UseVisualStyleBackColor = true;
            this.addSfxCancelBtn.Click += new System.EventHandler(this.addSfxCancelBtn_Click);
            // 
            // addSfxConfirmBtn
            // 
            this.addSfxConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSfxConfirmBtn.Location = new System.Drawing.Point(256, 311);
            this.addSfxConfirmBtn.Name = "addSfxConfirmBtn";
            this.addSfxConfirmBtn.Size = new System.Drawing.Size(123, 32);
            this.addSfxConfirmBtn.TabIndex = 9;
            this.addSfxConfirmBtn.Text = "Add";
            this.addSfxConfirmBtn.UseVisualStyleBackColor = true;
            this.addSfxConfirmBtn.Click += new System.EventHandler(this.addSfxConfirmBtn_Click);
            // 
            // sfxVolumeTrackBar
            // 
            this.sfxVolumeTrackBar.Location = new System.Drawing.Point(82, 231);
            this.sfxVolumeTrackBar.Maximum = 100;
            this.sfxVolumeTrackBar.Name = "sfxVolumeTrackBar";
            this.sfxVolumeTrackBar.Size = new System.Drawing.Size(358, 56);
            this.sfxVolumeTrackBar.TabIndex = 10;
            this.sfxVolumeTrackBar.TickFrequency = 25;
            this.sfxVolumeTrackBar.Value = 100;
            this.sfxVolumeTrackBar.ValueChanged += new System.EventHandler(this.sfxVolumeTrackBar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Volume:";
            // 
            // volumeValLbl
            // 
            this.volumeValLbl.AutoSize = true;
            this.volumeValLbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.volumeValLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.volumeValLbl.Location = new System.Drawing.Point(34, 257);
            this.volumeValLbl.Name = "volumeValLbl";
            this.volumeValLbl.Size = new System.Drawing.Size(30, 18);
            this.volumeValLbl.TabIndex = 12;
            this.volumeValLbl.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "50";
            // 
            // OpenFileForm
            // 
            this.AcceptButton = this.addSfxConfirmBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.addSfxCancelBtn;
            this.ClientSize = new System.Drawing.Size(469, 365);
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
            this.Name = "OpenFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add SFX";
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
    }
}