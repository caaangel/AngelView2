namespace AngelView.WinForms
{
    partial class ViewerDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerDlg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.HUDLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textCenter = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textRight = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textLeft = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.playBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.delayBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.sec1Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.sec3Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.sec10Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.sec20Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.sec30Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.min1Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.shuffleBtn = new System.Windows.Forms.ToolStripButton();
            this.switchFolderBtn = new System.Windows.Forms.ToolStripButton();
            this.slideShowTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.picture);
            this.panel1.Controls.Add(this.HUDLabel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 501);
            this.panel1.TabIndex = 3;
            // 
            // picture
            // 
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(725, 476);
            this.picture.TabIndex = 4;
            this.picture.TabStop = false;
            // 
            // HUDLabel
            // 
            this.HUDLabel.AutoSize = true;
            this.HUDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HUDLabel.ForeColor = System.Drawing.Color.Yellow;
            this.HUDLabel.Location = new System.Drawing.Point(21, 22);
            this.HUDLabel.Name = "HUDLabel";
            this.HUDLabel.Size = new System.Drawing.Size(76, 25);
            this.HUDLabel.TabIndex = 6;
            this.HUDLabel.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 476);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 25);
            this.panel2.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textCenter);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(670, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 25);
            this.panel5.TabIndex = 2;
            // 
            // textCenter
            // 
            this.textCenter.AutoEllipsis = true;
            this.textCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCenter.Location = new System.Drawing.Point(0, 0);
            this.textCenter.Name = "textCenter";
            this.textCenter.Size = new System.Drawing.Size(0, 25);
            this.textCenter.TabIndex = 1;
            this.textCenter.Text = "textCenter";
            this.textCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textRight);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(501, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 25);
            this.panel4.TabIndex = 1;
            // 
            // textRight
            // 
            this.textRight.AutoEllipsis = true;
            this.textRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRight.Location = new System.Drawing.Point(0, 0);
            this.textRight.Name = "textRight";
            this.textRight.Size = new System.Drawing.Size(224, 25);
            this.textRight.TabIndex = 2;
            this.textRight.Text = "textRight";
            this.textRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textLeft);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(670, 25);
            this.panel3.TabIndex = 0;
            // 
            // textLeft
            // 
            this.textLeft.AutoEllipsis = true;
            this.textLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLeft.Location = new System.Drawing.Point(115, 0);
            this.textLeft.Name = "textLeft";
            this.textLeft.Size = new System.Drawing.Size(555, 25);
            this.textLeft.TabIndex = 0;
            this.textLeft.Text = "textLeft";
            this.textLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.toolStrip1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(115, 25);
            this.panel6.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playBtn,
            this.toolStripSeparator1,
            this.delayBtn,
            this.toolStripSeparator2,
            this.shuffleBtn,
            this.switchFolderBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(115, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // playBtn
            // 
            this.playBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playBtn.Image = ((System.Drawing.Image)(resources.GetObject("playBtn.Image")));
            this.playBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playBtn.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(23, 22);
            this.playBtn.Text = "Current: Paused";
            this.playBtn.Click += new System.EventHandler(this.SlideShowPlayPause_OnClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // delayBtn
            // 
            this.delayBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delayBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sec1Btn,
            this.sec3Btn,
            this.sec10Btn,
            this.sec20Btn,
            this.sec30Btn,
            this.min1Btn});
            this.delayBtn.Image = ((System.Drawing.Image)(resources.GetObject("delayBtn.Image")));
            this.delayBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delayBtn.Name = "delayBtn";
            this.delayBtn.Size = new System.Drawing.Size(32, 22);
            this.delayBtn.Text = "toolStripSplitButton1";
            // 
            // sec1Btn
            // 
            this.sec1Btn.Name = "sec1Btn";
            this.sec1Btn.Size = new System.Drawing.Size(133, 22);
            this.sec1Btn.Tag = "";
            this.sec1Btn.Text = "1 Second";
            this.sec1Btn.ToolTipText = "1000";
            this.sec1Btn.Click += new System.EventHandler(this.delayButtons_OnClick);
            // 
            // sec3Btn
            // 
            this.sec3Btn.Name = "sec3Btn";
            this.sec3Btn.Size = new System.Drawing.Size(133, 22);
            this.sec3Btn.Tag = "";
            this.sec3Btn.Text = "3 Seconds";
            this.sec3Btn.ToolTipText = "3000";
            this.sec3Btn.Click += new System.EventHandler(this.delayButtons_OnClick);
            // 
            // sec10Btn
            // 
            this.sec10Btn.Name = "sec10Btn";
            this.sec10Btn.Size = new System.Drawing.Size(133, 22);
            this.sec10Btn.Tag = "";
            this.sec10Btn.Text = "10 Seconds";
            this.sec10Btn.ToolTipText = "10000";
            this.sec10Btn.Click += new System.EventHandler(this.delayButtons_OnClick);
            // 
            // sec20Btn
            // 
            this.sec20Btn.Name = "sec20Btn";
            this.sec20Btn.Size = new System.Drawing.Size(133, 22);
            this.sec20Btn.Tag = "";
            this.sec20Btn.Text = "20 Seconds";
            this.sec20Btn.ToolTipText = "20000";
            this.sec20Btn.Click += new System.EventHandler(this.delayButtons_OnClick);
            // 
            // sec30Btn
            // 
            this.sec30Btn.Name = "sec30Btn";
            this.sec30Btn.Size = new System.Drawing.Size(133, 22);
            this.sec30Btn.Tag = "";
            this.sec30Btn.Text = "30 Seconds";
            this.sec30Btn.ToolTipText = "30000";
            this.sec30Btn.Click += new System.EventHandler(this.delayButtons_OnClick);
            // 
            // min1Btn
            // 
            this.min1Btn.Name = "min1Btn";
            this.min1Btn.Size = new System.Drawing.Size(133, 22);
            this.min1Btn.Tag = "";
            this.min1Btn.Text = "1 Minute";
            this.min1Btn.ToolTipText = "60000";
            this.min1Btn.Click += new System.EventHandler(this.delayButtons_OnClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // shuffleBtn
            // 
            this.shuffleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shuffleBtn.Image = ((System.Drawing.Image)(resources.GetObject("shuffleBtn.Image")));
            this.shuffleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shuffleBtn.Name = "shuffleBtn";
            this.shuffleBtn.Size = new System.Drawing.Size(23, 22);
            this.shuffleBtn.Text = "Sequential";
            this.shuffleBtn.Click += new System.EventHandler(this.Shuffle_OnClick);
            // 
            // switchFolderBtn
            // 
            this.switchFolderBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.switchFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("switchFolderBtn.Image")));
            this.switchFolderBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.switchFolderBtn.Name = "switchFolderBtn";
            this.switchFolderBtn.Size = new System.Drawing.Size(23, 22);
            this.switchFolderBtn.Text = "toolStripButton3";
            this.switchFolderBtn.Click += new System.EventHandler(this.SwitchFolderBtn_OnClick);
            // 
            // slideShowTimer
            // 
            this.slideShowTimer.Interval = 5000;
            this.slideShowTimer.Tick += new System.EventHandler(this.slideShowTimer_OnTick);
            // 
            // ViewerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(725, 501);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "ViewerDlg";
            this.Text = "ViewerDlg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewerDlg_OnFormClosing);
            this.Load += new System.EventHandler(this.ViewerDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewerDlg_OnKeyDown);
            this.Resize += new System.EventHandler(this.ViewerDlg_OnResize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label textCenter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label textRight;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label textLeft;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton playBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton shuffleBtn;
        private System.Windows.Forms.ToolStripButton switchFolderBtn;
        private System.Windows.Forms.Timer slideShowTimer;
        private System.Windows.Forms.ToolStripSplitButton delayBtn;
        private System.Windows.Forms.ToolStripMenuItem sec1Btn;
        private System.Windows.Forms.ToolStripMenuItem sec3Btn;
        private System.Windows.Forms.ToolStripMenuItem sec10Btn;
        private System.Windows.Forms.ToolStripMenuItem sec20Btn;
        private System.Windows.Forms.ToolStripMenuItem sec30Btn;
        private System.Windows.Forms.ToolStripMenuItem min1Btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label HUDLabel;
    }
}