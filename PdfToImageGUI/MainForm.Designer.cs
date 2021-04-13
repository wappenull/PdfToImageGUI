
namespace PdfToImageGUI
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
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.browseInput = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.appendSourceOption = new System.Windows.Forms.CheckBox();
            this.sameOutputSourceOption = new System.Windows.Forms.CheckBox();
            this.dpiSelect = new System.Windows.Forms.ComboBox();
            this.formatSelect = new System.Windows.Forms.ComboBox();
            this.outputPathPreview = new System.Windows.Forms.TextBox();
            this.outputPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.browseOutput = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseInput
            // 
            this.browseInput.Location = new System.Drawing.Point(239, 27);
            this.browseInput.Name = "browseInput";
            this.browseInput.Size = new System.Drawing.Size(64, 20);
            this.browseInput.TabIndex = 0;
            this.browseInput.Text = "Browse";
            this.browseInput.UseVisualStyleBackColor = true;
            this.browseInput.Click += new System.EventHandler(this.browseInput_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputPath);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.browseInput);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source PDF file";
            // 
            // inputPath
            // 
            this.inputPath.Location = new System.Drawing.Point(15, 27);
            this.inputPath.Name = "inputPath";
            this.inputPath.Size = new System.Drawing.Size(220, 20);
            this.inputPath.TabIndex = 2;
            this.inputPath.TextChanged += new System.EventHandler(this.OnUiStateChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(292, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Convert all pages for now, I\'m too lazy for page range option.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Also accept drag and drop to this form";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.appendSourceOption);
            this.groupBox2.Controls.Add(this.sameOutputSourceOption);
            this.groupBox2.Controls.Add(this.dpiSelect);
            this.groupBox2.Controls.Add(this.formatSelect);
            this.groupBox2.Controls.Add(this.outputPathPreview);
            this.groupBox2.Controls.Add(this.outputPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.goButton);
            this.groupBox2.Controls.Add(this.browseOutput);
            this.groupBox2.Location = new System.Drawing.Point(10, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 259);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target output";
            // 
            // appendSourceOption
            // 
            this.appendSourceOption.AutoSize = true;
            this.appendSourceOption.Checked = true;
            this.appendSourceOption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendSourceOption.Location = new System.Drawing.Point(120, 19);
            this.appendSourceOption.Name = "appendSourceOption";
            this.appendSourceOption.Size = new System.Drawing.Size(140, 17);
            this.appendSourceOption.TabIndex = 4;
            this.appendSourceOption.Text = "Append source filename";
            this.appendSourceOption.UseVisualStyleBackColor = true;
            this.appendSourceOption.CheckedChanged += new System.EventHandler(this.OnUiStateChanged);
            // 
            // sameOutputSourceOption
            // 
            this.sameOutputSourceOption.AutoSize = true;
            this.sameOutputSourceOption.Checked = true;
            this.sameOutputSourceOption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sameOutputSourceOption.Location = new System.Drawing.Point(12, 19);
            this.sameOutputSourceOption.Name = "sameOutputSourceOption";
            this.sameOutputSourceOption.Size = new System.Drawing.Size(102, 17);
            this.sameOutputSourceOption.TabIndex = 4;
            this.sameOutputSourceOption.Text = "Same as source";
            this.sameOutputSourceOption.UseVisualStyleBackColor = true;
            this.sameOutputSourceOption.CheckedChanged += new System.EventHandler(this.OnUiStateChanged);
            // 
            // dpiSelect
            // 
            this.dpiSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpiSelect.FormattingEnabled = true;
            this.dpiSelect.Items.AddRange(new object[] {
            "50",
            "72",
            "200",
            "300"});
            this.dpiSelect.Location = new System.Drawing.Point(89, 153);
            this.dpiSelect.Name = "dpiSelect";
            this.dpiSelect.Size = new System.Drawing.Size(104, 21);
            this.dpiSelect.TabIndex = 3;
            // 
            // formatSelect
            // 
            this.formatSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatSelect.FormattingEnabled = true;
            this.formatSelect.Items.AddRange(new object[] {
            "jpg 80%",
            "jpg 50%",
            "png"});
            this.formatSelect.Location = new System.Drawing.Point(89, 126);
            this.formatSelect.Name = "formatSelect";
            this.formatSelect.Size = new System.Drawing.Size(104, 21);
            this.formatSelect.TabIndex = 3;
            // 
            // outputPathPreview
            // 
            this.outputPathPreview.Location = new System.Drawing.Point(12, 79);
            this.outputPathPreview.Multiline = true;
            this.outputPathPreview.Name = "outputPathPreview";
            this.outputPathPreview.ReadOnly = true;
            this.outputPathPreview.Size = new System.Drawing.Size(289, 39);
            this.outputPathPreview.TabIndex = 2;
            // 
            // outputPath
            // 
            this.outputPath.Location = new System.Drawing.Point(12, 38);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(220, 20);
            this.outputPath.TabIndex = 2;
            this.outputPath.TextChanged += new System.EventHandler(this.OnUiStateChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Effective output review";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Render DPI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Image format";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(216, 210);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(87, 36);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "GO!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // browseOutput
            // 
            this.browseOutput.Location = new System.Drawing.Point(237, 38);
            this.browseOutput.Name = "browseOutput";
            this.browseOutput.Size = new System.Drawing.Size(64, 20);
            this.browseOutput.TabIndex = 0;
            this.browseOutput.Text = "Browse";
            this.browseOutput.UseVisualStyleBackColor = true;
            this.browseOutput.Click += new System.EventHandler(this.browseOutput_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.linkLabel3);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(350, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 141);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Credit && Advertisement";
            // 
            // label9
            // 
            this.label9.Image = global::PdfToImageGUI.Properties.Resources.icon48;
            this.label9.Location = new System.Drawing.Point(263, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 57);
            this.label9.TabIndex = 2;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(5, 34);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(230, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/wappenull/PdfToImageGUI";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenUrlFromLinkLabel);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(5, 114);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(241, 13);
            this.linkLabel3.TabIndex = 1;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://github.com/wappenull/DLSiteDumperGUI";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenUrlFromLinkLabel);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 64);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(199, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/doxakis/PdfToImage";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenUrlFromLinkLabel);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ara Ara? Are you converting a comic/manga?\r\nGet this reader HTML generator tool!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thanks to original project!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Not satisfied? Mod it yourself! Fork this bad boy";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Wappen PDF to Image converter GUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button browseInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox inputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox dpiSelect;
        private System.Windows.Forms.ComboBox formatSelect;
        private System.Windows.Forms.TextBox outputPathPreview;
        private System.Windows.Forms.TextBox outputPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseOutput;
        private System.Windows.Forms.CheckBox appendSourceOption;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox sameOutputSourceOption;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button goButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label9;
    }
}

