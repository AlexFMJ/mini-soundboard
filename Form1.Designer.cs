namespace soundboard_sandbox
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.sfxGridViewCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedSFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSFXBtn = new System.Windows.Forms.Button();
            this.deleteSFXBtn = new System.Windows.Forms.Button();
            this.editSFXBtn = new System.Windows.Forms.Button();
            this.sfxGridView = new System.Windows.Forms.DataGridView();
            this.stop_audio_btn = new System.Windows.Forms.Button();
            this.play_audio_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSoundboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSoundboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSFXToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printListBtn = new System.Windows.Forms.Button();
            this.sfxGridViewCMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfxGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sfxGridViewCMS
            // 
            this.sfxGridViewCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sfxGridViewCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editSelectedSFXToolStripMenuItem,
            this.deleteSFXToolStripMenuItem});
            this.sfxGridViewCMS.Name = "sfxListItemCMS";
            this.sfxGridViewCMS.Size = new System.Drawing.Size(194, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 24);
            this.toolStripMenuItem1.Text = "Add SFX";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.AddSFX_Click);
            // 
            // editSelectedSFXToolStripMenuItem
            // 
            this.editSelectedSFXToolStripMenuItem.Name = "editSelectedSFXToolStripMenuItem";
            this.editSelectedSFXToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.editSelectedSFXToolStripMenuItem.Text = "Edit Selected SFX";
            // 
            // deleteSFXToolStripMenuItem
            // 
            this.deleteSFXToolStripMenuItem.Name = "deleteSFXToolStripMenuItem";
            this.deleteSFXToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.deleteSFXToolStripMenuItem.Text = "Delete SFX";
            this.deleteSFXToolStripMenuItem.Click += new System.EventHandler(this.DeleteSFX_Click);
            // 
            // addSFXBtn
            // 
            this.addSFXBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addSFXBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSFXBtn.Location = new System.Drawing.Point(541, 35);
            this.addSFXBtn.Name = "addSFXBtn";
            this.addSFXBtn.Size = new System.Drawing.Size(106, 39);
            this.addSFXBtn.TabIndex = 1;
            this.addSFXBtn.Text = "Add SFX";
            this.addSFXBtn.UseVisualStyleBackColor = true;
            this.addSFXBtn.Click += new System.EventHandler(this.AddSFX_Click);
            // 
            // deleteSFXBtn
            // 
            this.deleteSFXBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteSFXBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSFXBtn.Location = new System.Drawing.Point(541, 137);
            this.deleteSFXBtn.Name = "deleteSFXBtn";
            this.deleteSFXBtn.Size = new System.Drawing.Size(106, 39);
            this.deleteSFXBtn.TabIndex = 2;
            this.deleteSFXBtn.Text = "Delete SFX";
            this.deleteSFXBtn.UseVisualStyleBackColor = true;
            this.deleteSFXBtn.Click += new System.EventHandler(this.DeleteSFX_Click);
            // 
            // editSFXBtn
            // 
            this.editSFXBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editSFXBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSFXBtn.Location = new System.Drawing.Point(541, 86);
            this.editSFXBtn.Name = "editSFXBtn";
            this.editSFXBtn.Size = new System.Drawing.Size(106, 39);
            this.editSFXBtn.TabIndex = 3;
            this.editSFXBtn.Text = "Edit SFX";
            this.editSFXBtn.UseVisualStyleBackColor = true;
            this.editSFXBtn.Click += new System.EventHandler(this.editSFXBtn_Click);
            // 
            // sfxGridView
            // 
            this.sfxGridView.AllowDrop = true;
            this.sfxGridView.AllowUserToAddRows = false;
            this.sfxGridView.AllowUserToOrderColumns = true;
            this.sfxGridView.AllowUserToResizeRows = false;
            this.sfxGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfxGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sfxGridView.BackgroundColor = System.Drawing.Color.White;
            this.sfxGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sfxGridView.ContextMenuStrip = this.sfxGridViewCMS;
            this.sfxGridView.Location = new System.Drawing.Point(27, 35);
            this.sfxGridView.MultiSelect = false;
            this.sfxGridView.Name = "sfxGridView";
            this.sfxGridView.ReadOnly = true;
            this.sfxGridView.RowHeadersVisible = false;
            this.sfxGridView.RowHeadersWidth = 51;
            this.sfxGridView.RowTemplate.Height = 24;
            this.sfxGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sfxGridView.Size = new System.Drawing.Size(484, 353);
            this.sfxGridView.TabIndex = 4;
            this.sfxGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.sfxGridView_DragDrop);
            this.sfxGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.sfxGridView_DragOver);
            this.sfxGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sfxGridView_MouseDown);
            this.sfxGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sfxGridView_MouseMove);
            // 
            // stop_audio_btn
            // 
            this.stop_audio_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stop_audio_btn.BackgroundImage = global::soundboard_sandbox.Properties.Resources.stop_icon_64px;
            this.stop_audio_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stop_audio_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop_audio_btn.Location = new System.Drawing.Point(608, 211);
            this.stop_audio_btn.Name = "stop_audio_btn";
            this.stop_audio_btn.Size = new System.Drawing.Size(39, 39);
            this.stop_audio_btn.TabIndex = 6;
            this.stop_audio_btn.UseVisualStyleBackColor = true;
            this.stop_audio_btn.Click += new System.EventHandler(this.stopAudio);
            // 
            // play_audio_btn
            // 
            this.play_audio_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.play_audio_btn.BackgroundImage = global::soundboard_sandbox.Properties.Resources.play_icon_64px;
            this.play_audio_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.play_audio_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_audio_btn.Location = new System.Drawing.Point(541, 211);
            this.play_audio_btn.Name = "play_audio_btn";
            this.play_audio_btn.Size = new System.Drawing.Size(39, 39);
            this.play_audio_btn.TabIndex = 5;
            this.play_audio_btn.UseVisualStyleBackColor = true;
            this.play_audio_btn.Click += new System.EventHandler(this.playSelectedAudio);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSoundboardToolStripMenuItem,
            this.saveSoundboardToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.filesToolStripMenuItem.Text = "File";
            // 
            // loadSoundboardToolStripMenuItem
            // 
            this.loadSoundboardToolStripMenuItem.Name = "loadSoundboardToolStripMenuItem";
            this.loadSoundboardToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadSoundboardToolStripMenuItem.Text = "Load SFX Library";
            this.loadSoundboardToolStripMenuItem.Click += new System.EventHandler(this.loadSFXLibraryBtn);
            // 
            // saveSoundboardToolStripMenuItem
            // 
            this.saveSoundboardToolStripMenuItem.Name = "saveSoundboardToolStripMenuItem";
            this.saveSoundboardToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveSoundboardToolStripMenuItem.Text = "Save SFX Library";
            this.saveSoundboardToolStripMenuItem.Click += new System.EventHandler(this.saveSFXLibraryBtn);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSFXToolStripMenuItem,
            this.editSFXToolStripMenuItem,
            this.deleteSFXToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addSFXToolStripMenuItem
            // 
            this.addSFXToolStripMenuItem.Name = "addSFXToolStripMenuItem";
            this.addSFXToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.addSFXToolStripMenuItem.Text = "Add SFX";
            this.addSFXToolStripMenuItem.Click += new System.EventHandler(this.AddSFX_Click);
            // 
            // editSFXToolStripMenuItem
            // 
            this.editSFXToolStripMenuItem.Name = "editSFXToolStripMenuItem";
            this.editSFXToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.editSFXToolStripMenuItem.Text = "Edit Selected SFX";
            this.editSFXToolStripMenuItem.Click += new System.EventHandler(this.editSFXBtn_Click);
            // 
            // deleteSFXToolStripMenuItem1
            // 
            this.deleteSFXToolStripMenuItem1.Name = "deleteSFXToolStripMenuItem1";
            this.deleteSFXToolStripMenuItem1.Size = new System.Drawing.Size(225, 26);
            this.deleteSFXToolStripMenuItem1.Text = "Delete Selected SFX";
            this.deleteSFXToolStripMenuItem1.Click += new System.EventHandler(this.DeleteSFX_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"Supported Files (XML Files|*.xml;*.XML)\"";
            // 
            // printListBtn
            // 
            this.printListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printListBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printListBtn.Location = new System.Drawing.Point(541, 282);
            this.printListBtn.Name = "printListBtn";
            this.printListBtn.Size = new System.Drawing.Size(106, 39);
            this.printListBtn.TabIndex = 8;
            this.printListBtn.Text = "Print list";
            this.printListBtn.UseVisualStyleBackColor = true;
            this.printListBtn.Click += new System.EventHandler(this.printListBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(671, 417);
            this.Controls.Add(this.printListBtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.stop_audio_btn);
            this.Controls.Add(this.play_audio_btn);
            this.Controls.Add(this.sfxGridView);
            this.Controls.Add(this.editSFXBtn);
            this.Controls.Add(this.deleteSFXBtn);
            this.Controls.Add(this.addSFXBtn);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(689, 464);
            this.Name = "MainForm";
            this.Text = "sandbox";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sfxGridViewCMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfxGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addSFXBtn;
        private System.Windows.Forms.Button deleteSFXBtn;
        private System.Windows.Forms.ContextMenuStrip sfxGridViewCMS;
        private System.Windows.Forms.ToolStripMenuItem deleteSFXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editSelectedSFXToolStripMenuItem;
        private System.Windows.Forms.Button editSFXBtn;
        private System.Windows.Forms.DataGridView sfxGridView;
        private System.Windows.Forms.Button play_audio_btn;
        private System.Windows.Forms.Button stop_audio_btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSoundboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSoundboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSFXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSFXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSFXToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button printListBtn;
    }
}

