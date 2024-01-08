namespace UI
{
    partial class FormFolder
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
            this.bgLoadFile = new System.ComponentModel.BackgroundWorker();
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSelectFolderInput = new System.Windows.Forms.Button();
            this.txtFolderInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_detect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grFolder = new System.Windows.Forms.GroupBox();
            this.txt_CCCDChipbackDir = new System.Windows.Forms.TextBox();
            this.chkMoveCCCDChipback = new System.Windows.Forms.CheckBox();
            this.txt_CCCDBarcodeDir = new System.Windows.Forms.TextBox();
            this.chkMoveCCCDbarcode = new System.Windows.Forms.CheckBox();
            this.txt_CMND12dir = new System.Windows.Forms.TextBox();
            this.chkMoveCMND12 = new System.Windows.Forms.CheckBox();
            this.txt_CCCDChipdir = new System.Windows.Forms.TextBox();
            this.chkMoveCCCDChip = new System.Windows.Forms.CheckBox();
            this.txt_CMND9dir = new System.Windows.Forms.TextBox();
            this.chkMoveCMND9 = new System.Windows.Forms.CheckBox();
            this.txtFailedDir = new System.Windows.Forms.TextBox();
            this.chkMoveFail = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstImage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spinningCircles1 = new AltoControls.SpinningCircles();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.grFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bgLoadFile
            // 
            this.bgLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadFile_DoWork);
            this.bgLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadFile_RunWorkerCompleted);
            // 
            // bgWorker1
            // 
            this.bgWorker1.WorkerReportsProgress = true;
            this.bgWorker1.WorkerSupportsCancellation = true;
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // btnSelectFolderInput
            // 
            this.btnSelectFolderInput.Location = new System.Drawing.Point(293, 44);
            this.btnSelectFolderInput.Name = "btnSelectFolderInput";
            this.btnSelectFolderInput.Size = new System.Drawing.Size(24, 27);
            this.btnSelectFolderInput.TabIndex = 17;
            this.btnSelectFolderInput.Text = "...";
            this.btnSelectFolderInput.UseVisualStyleBackColor = true;
            this.btnSelectFolderInput.Click += new System.EventHandler(this.btnSelectFolderInput_Click);
            // 
            // txtFolderInput
            // 
            this.txtFolderInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderInput.Location = new System.Drawing.Point(16, 45);
            this.txtFolderInput.Name = "txtFolderInput";
            this.txtFolderInput.Size = new System.Drawing.Size(273, 25);
            this.txtFolderInput.TabIndex = 16;
            this.txtFolderInput.TextChanged += new System.EventHandler(this.txtFolderInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Input folder";
            // 
            // btnDetect
            // 
            this.btnDetect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetect.Location = new System.Drawing.Point(864, 14);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(114, 50);
            this.btnDetect.TabIndex = 18;
            this.btnDetect.Text = "Detect (F5)";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(498, 214);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(480, 298);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 32;
            this.picResult.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_detect,
            this.btnCopyPath,
            this.btnCopyImage,
            this.btnOpenImage,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 114);
            this.contextMenuStrip1.Text = "Copy path";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btn_detect
            // 
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Size = new System.Drawing.Size(171, 22);
            this.btn_detect.Text = "Detect";
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopyPath.Size = new System.Drawing.Size(171, 22);
            this.btnCopyPath.Text = "Copy path";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(171, 22);
            this.btnCopyImage.Text = "Copy image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(171, 22);
            this.btnOpenImage.Text = "Open image";
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 22);
            this.btnDelete.Text = "Delete image";
            // 
            // grFolder
            // 
            this.grFolder.Controls.Add(this.spinningCircles1);
            this.grFolder.Controls.Add(this.txt_CCCDChipbackDir);
            this.grFolder.Controls.Add(this.chkMoveCCCDChipback);
            this.grFolder.Controls.Add(this.txt_CCCDBarcodeDir);
            this.grFolder.Controls.Add(this.chkMoveCCCDbarcode);
            this.grFolder.Controls.Add(this.txt_CMND12dir);
            this.grFolder.Controls.Add(this.chkMoveCMND12);
            this.grFolder.Controls.Add(this.txt_CCCDChipdir);
            this.grFolder.Controls.Add(this.chkMoveCCCDChip);
            this.grFolder.Controls.Add(this.txt_CMND9dir);
            this.grFolder.Controls.Add(this.btnDetect);
            this.grFolder.Controls.Add(this.chkMoveCMND9);
            this.grFolder.Controls.Add(this.btnSelectFolderInput);
            this.grFolder.Controls.Add(this.txtFolderInput);
            this.grFolder.Controls.Add(this.txtFailedDir);
            this.grFolder.Controls.Add(this.label2);
            this.grFolder.Controls.Add(this.chkMoveFail);
            this.grFolder.Controls.Add(this.label4);
            this.grFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grFolder.Location = new System.Drawing.Point(0, 0);
            this.grFolder.Name = "grFolder";
            this.grFolder.Size = new System.Drawing.Size(1008, 195);
            this.grFolder.TabIndex = 33;
            this.grFolder.TabStop = false;
            // 
            // txt_CCCDChipbackDir
            // 
            this.txt_CCCDChipbackDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CCCDChipbackDir.Location = new System.Drawing.Point(578, 154);
            this.txt_CCCDChipbackDir.Name = "txt_CCCDChipbackDir";
            this.txt_CCCDChipbackDir.Size = new System.Drawing.Size(273, 25);
            this.txt_CCCDChipbackDir.TabIndex = 25;
            // 
            // chkMoveCCCDChipback
            // 
            this.chkMoveCCCDChipback.AutoSize = true;
            this.chkMoveCCCDChipback.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveCCCDChipback.Location = new System.Drawing.Point(401, 155);
            this.chkMoveCCCDChipback.Name = "chkMoveCCCDChipback";
            this.chkMoveCCCDChipback.Size = new System.Drawing.Size(181, 23);
            this.chkMoveCCCDChipback.TabIndex = 24;
            this.chkMoveCCCDChipback.Text = "Move CCCD Chipback to";
            this.chkMoveCCCDChipback.UseVisualStyleBackColor = true;
            this.chkMoveCCCDChipback.CheckedChanged += new System.EventHandler(this.chkMoveCCCDChipback_CheckedChanged);
            // 
            // txt_CCCDBarcodeDir
            // 
            this.txt_CCCDBarcodeDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CCCDBarcodeDir.Location = new System.Drawing.Point(578, 99);
            this.txt_CCCDBarcodeDir.Name = "txt_CCCDBarcodeDir";
            this.txt_CCCDBarcodeDir.Size = new System.Drawing.Size(273, 25);
            this.txt_CCCDBarcodeDir.TabIndex = 23;
            // 
            // chkMoveCCCDbarcode
            // 
            this.chkMoveCCCDbarcode.AutoSize = true;
            this.chkMoveCCCDbarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveCCCDbarcode.Location = new System.Drawing.Point(401, 100);
            this.chkMoveCCCDbarcode.Name = "chkMoveCCCDbarcode";
            this.chkMoveCCCDbarcode.Size = new System.Drawing.Size(174, 23);
            this.chkMoveCCCDbarcode.TabIndex = 22;
            this.chkMoveCCCDbarcode.Text = "Move CCCD Barcode to";
            this.chkMoveCCCDbarcode.UseVisualStyleBackColor = true;
            this.chkMoveCCCDbarcode.CheckedChanged += new System.EventHandler(this.chkMoveCCCDbarcode_CheckedChanged);
            // 
            // txt_CMND12dir
            // 
            this.txt_CMND12dir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CMND12dir.Location = new System.Drawing.Point(578, 71);
            this.txt_CMND12dir.Name = "txt_CMND12dir";
            this.txt_CMND12dir.Size = new System.Drawing.Size(273, 25);
            this.txt_CMND12dir.TabIndex = 21;
            // 
            // chkMoveCMND12
            // 
            this.chkMoveCMND12.AutoSize = true;
            this.chkMoveCMND12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveCMND12.Location = new System.Drawing.Point(401, 72);
            this.chkMoveCMND12.Name = "chkMoveCMND12";
            this.chkMoveCMND12.Size = new System.Drawing.Size(142, 23);
            this.chkMoveCMND12.TabIndex = 20;
            this.chkMoveCMND12.Text = "Move CMND12 to";
            this.chkMoveCMND12.UseVisualStyleBackColor = true;
            this.chkMoveCMND12.CheckedChanged += new System.EventHandler(this.chkMoveCMND12_CheckedChanged);
            // 
            // txt_CCCDChipdir
            // 
            this.txt_CCCDChipdir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CCCDChipdir.Location = new System.Drawing.Point(578, 126);
            this.txt_CCCDChipdir.Name = "txt_CCCDChipdir";
            this.txt_CCCDChipdir.Size = new System.Drawing.Size(273, 25);
            this.txt_CCCDChipdir.TabIndex = 17;
            // 
            // chkMoveCCCDChip
            // 
            this.chkMoveCCCDChip.AutoSize = true;
            this.chkMoveCCCDChip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveCCCDChip.Location = new System.Drawing.Point(401, 127);
            this.chkMoveCCCDChip.Name = "chkMoveCCCDChip";
            this.chkMoveCCCDChip.Size = new System.Drawing.Size(153, 23);
            this.chkMoveCCCDChip.TabIndex = 16;
            this.chkMoveCCCDChip.Text = "Move CCCD Chip to";
            this.chkMoveCCCDChip.UseVisualStyleBackColor = true;
            this.chkMoveCCCDChip.CheckedChanged += new System.EventHandler(this.chkMoveCCCDChip_CheckedChanged);
            // 
            // txt_CMND9dir
            // 
            this.txt_CMND9dir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CMND9dir.Location = new System.Drawing.Point(578, 43);
            this.txt_CMND9dir.Name = "txt_CMND9dir";
            this.txt_CMND9dir.Size = new System.Drawing.Size(273, 25);
            this.txt_CMND9dir.TabIndex = 15;
            // 
            // chkMoveCMND9
            // 
            this.chkMoveCMND9.AutoSize = true;
            this.chkMoveCMND9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveCMND9.Location = new System.Drawing.Point(401, 44);
            this.chkMoveCMND9.Name = "chkMoveCMND9";
            this.chkMoveCMND9.Size = new System.Drawing.Size(134, 23);
            this.chkMoveCMND9.TabIndex = 14;
            this.chkMoveCMND9.Text = "Move CMND9 to";
            this.chkMoveCMND9.UseVisualStyleBackColor = true;
            this.chkMoveCMND9.CheckedChanged += new System.EventHandler(this.chkMoveCMND9_CheckedChanged);
            // 
            // txtFailedDir
            // 
            this.txtFailedDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFailedDir.Location = new System.Drawing.Point(578, 15);
            this.txtFailedDir.Name = "txtFailedDir";
            this.txtFailedDir.Size = new System.Drawing.Size(273, 25);
            this.txtFailedDir.TabIndex = 13;
            // 
            // chkMoveFail
            // 
            this.chkMoveFail.AutoSize = true;
            this.chkMoveFail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveFail.Location = new System.Drawing.Point(401, 15);
            this.chkMoveFail.Name = "chkMoveFail";
            this.chkMoveFail.Size = new System.Drawing.Size(176, 23);
            this.chkMoveFail.TabIndex = 12;
            this.chkMoveFail.Text = "Move file can\'t detect to";
            this.chkMoveFail.UseVisualStyleBackColor = true;
            this.chkMoveFail.CheckedChanged += new System.EventHandler(this.chkMoveFail_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lstImage
            // 
            this.lstImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstImage.ContextMenuStrip = this.contextMenuStrip1;
            this.lstImage.FullRowSelect = true;
            this.lstImage.GridLines = true;
            this.lstImage.HideSelection = false;
            this.lstImage.Location = new System.Drawing.Point(2, 214);
            this.lstImage.MultiSelect = false;
            this.lstImage.Name = "lstImage";
            this.lstImage.Size = new System.Drawing.Size(486, 298);
            this.lstImage.TabIndex = 34;
            this.lstImage.UseCompatibleStateImageBehavior = false;
            this.lstImage.View = System.Windows.Forms.View.Details;
            this.lstImage.SelectedIndexChanged += new System.EventHandler(this.lstImage_SelectedIndexChanged);
            this.lstImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstImage_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image name";
            this.columnHeader1.Width = 272;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Number";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 108;
            // 
            // spinningCircles1
            // 
            this.spinningCircles1.BackColor = System.Drawing.Color.Transparent;
            this.spinningCircles1.ForeColor = System.Drawing.Color.DarkCyan;
            this.spinningCircles1.FullTransparent = true;
            this.spinningCircles1.Increment = 1F;
            this.spinningCircles1.Interval = 50;
            this.spinningCircles1.Location = new System.Drawing.Point(876, 79);
            this.spinningCircles1.N = 8;
            this.spinningCircles1.Name = "spinningCircles1";
            this.spinningCircles1.Radius = 2F;
            this.spinningCircles1.Size = new System.Drawing.Size(90, 100);
            this.spinningCircles1.TabIndex = 26;
            this.spinningCircles1.Text = "spinningCircles1";
            this.spinningCircles1.Visible = false;
            // 
            // FormFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 548);
            this.Controls.Add(this.lstImage);
            this.Controls.Add(this.grFolder);
            this.Controls.Add(this.picResult);
            this.Name = "FormFolder";
            this.Text = "FormFolder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFolder_FormClosed);
            this.Load += new System.EventHandler(this.FormFolder_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormFolder_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grFolder.ResumeLayout(false);
            this.grFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgLoadFile;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.Button btnSelectFolderInput;
        private System.Windows.Forms.TextBox txtFolderInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.ToolStripMenuItem btnCopyImage;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.GroupBox grFolder;
        private System.Windows.Forms.TextBox txt_CCCDChipdir;
        private System.Windows.Forms.CheckBox chkMoveCCCDChip;
        private System.Windows.Forms.TextBox txt_CMND9dir;
        private System.Windows.Forms.CheckBox chkMoveCMND9;
        private System.Windows.Forms.TextBox txtFailedDir;
        private System.Windows.Forms.CheckBox chkMoveFail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ListView lstImage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem btn_detect;
        private System.Windows.Forms.TextBox txt_CMND12dir;
        private System.Windows.Forms.CheckBox chkMoveCMND12;
        private System.Windows.Forms.TextBox txt_CCCDBarcodeDir;
        private System.Windows.Forms.CheckBox chkMoveCCCDbarcode;
        private System.Windows.Forms.TextBox txt_CCCDChipbackDir;
        private System.Windows.Forms.CheckBox chkMoveCCCDChipback;
        private AltoControls.SpinningCircles spinningCircles1;
    }
}