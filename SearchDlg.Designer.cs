namespace AngelView.WinForms
{
    partial class SearchDlg
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.browseFolderBtn = new System.Windows.Forms.Button();
            this.subFolders = new System.Windows.Forms.CheckBox();
            this.folderBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateValue = new System.Windows.Forms.DateTimePicker();
            this.sizeMultiplier = new System.Windows.Forms.ComboBox();
            this.sizeValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateCondition = new System.Windows.Forms.ComboBox();
            this.sizeCondition = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.browseFolderBtn);
            this.groupBox1.Controls.Add(this.subFolders);
            this.groupBox1.Controls.Add(this.folderBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " File Search ";
            // 
            // maskBox
            // 
            this.maskBox.Location = new System.Drawing.Point(91, 23);
            this.maskBox.Name = "maskBox";
            this.maskBox.Size = new System.Drawing.Size(330, 20);
            this.maskBox.TabIndex = 0;
            this.maskBox.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "File Mask";
            // 
            // browseFolderBtn
            // 
            this.browseFolderBtn.Location = new System.Drawing.Point(397, 49);
            this.browseFolderBtn.Name = "browseFolderBtn";
            this.browseFolderBtn.Size = new System.Drawing.Size(24, 24);
            this.browseFolderBtn.TabIndex = 3;
            this.browseFolderBtn.TabStop = false;
            this.browseFolderBtn.Text = "...";
            this.browseFolderBtn.UseVisualStyleBackColor = true;
            this.browseFolderBtn.Click += new System.EventHandler(this.BrowseFolderBtn_Click);
            // 
            // subFolders
            // 
            this.subFolders.AutoSize = true;
            this.subFolders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.subFolders.Location = new System.Drawing.Point(29, 78);
            this.subFolders.Name = "subFolders";
            this.subFolders.Size = new System.Drawing.Size(76, 17);
            this.subFolders.TabIndex = 2;
            this.subFolders.Text = "Subfolders";
            this.subFolders.UseVisualStyleBackColor = true;
            // 
            // folderBox
            // 
            this.folderBox.Location = new System.Drawing.Point(91, 52);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(305, 20);
            this.folderBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Folder";
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Search Folder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateValue);
            this.groupBox2.Controls.Add(this.sizeMultiplier);
            this.groupBox2.Controls.Add(this.sizeValue);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateCondition);
            this.groupBox2.Controls.Add(this.sizeCondition);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " File Options ";
            // 
            // dateValue
            // 
            this.dateValue.CustomFormat = "";
            this.dateValue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateValue.Location = new System.Drawing.Point(206, 61);
            this.dateValue.Name = "dateValue";
            this.dateValue.Size = new System.Drawing.Size(109, 20);
            this.dateValue.TabIndex = 4;
            // 
            // sizeMultiplier
            // 
            this.sizeMultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeMultiplier.FormattingEnabled = true;
            this.sizeMultiplier.Items.AddRange(new object[] {
            "Bytes",
            "Kilobytes",
            "Megabytes",
            "Gigabytes"});
            this.sizeMultiplier.Location = new System.Drawing.Point(90, 87);
            this.sizeMultiplier.Name = "sizeMultiplier";
            this.sizeMultiplier.Size = new System.Drawing.Size(110, 21);
            this.sizeMultiplier.TabIndex = 2;
            // 
            // sizeValue
            // 
            this.sizeValue.Location = new System.Drawing.Point(91, 61);
            this.sizeValue.Name = "sizeValue";
            this.sizeValue.Size = new System.Drawing.Size(109, 20);
            this.sizeValue.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date";
            // 
            // dateCondition
            // 
            this.dateCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateCondition.FormattingEnabled = true;
            this.dateCondition.Items.AddRange(new object[] {
            "Dont care",
            "Older Than",
            "Equal To",
            "Newer Than"});
            this.dateCondition.Location = new System.Drawing.Point(206, 35);
            this.dateCondition.Name = "dateCondition";
            this.dateCondition.Size = new System.Drawing.Size(109, 21);
            this.dateCondition.TabIndex = 3;
            // 
            // sizeCondition
            // 
            this.sizeCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCondition.FormattingEnabled = true;
            this.sizeCondition.Items.AddRange(new object[] {
            "Dont Care",
            "Smaller than",
            "Equal to",
            "Larger than"});
            this.sizeCondition.Location = new System.Drawing.Point(91, 35);
            this.sizeCondition.Name = "sizeCondition";
            this.sizeCondition.Size = new System.Drawing.Size(109, 21);
            this.sizeCondition.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Condition";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(364, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Location = new System.Drawing.Point(283, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "&OK";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // SearchDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 271);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SearchDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchDlg";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseFolderBtn;
        private System.Windows.Forms.CheckBox subFolders;
        private System.Windows.Forms.TextBox folderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox sizeMultiplier;
        private System.Windows.Forms.TextBox sizeValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dateCondition;
        private System.Windows.Forms.ComboBox sizeCondition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maskBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateValue;
    }
}