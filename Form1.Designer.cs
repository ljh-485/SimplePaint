namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAppName = new Label();
            groupBox1 = new GroupBox();
            btnCircle = new Button();
            btnRactangle = new Button();
            btnLine = new Button();
            groupBox3 = new GroupBox();
            trbLineWidth = new TrackBar();
            groupBox2 = new GroupBox();
            cmbColor = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            panelCanvas = new Panel();
            picCanvas = new PictureBox();
            saveFileDialog1 = new SaveFileDialog();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            groupBox2.SuspendLayout();
            panelCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.Blue;
            lblAppName.Location = new Point(40, 40);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(283, 59);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCircle);
            groupBox1.Controls.Add(btnRactangle);
            groupBox1.Controls.Add(btnLine);
            groupBox1.Location = new Point(29, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 126);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "도형 선택";
            // 
            // btnCircle
            // 
            btnCircle.Font = new Font("맑은 고딕", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnCircle.Image = Properties.Resources.원;
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(194, 38);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(88, 77);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnRactangle
            // 
            btnRactangle.Font = new Font("맑은 고딕", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnRactangle.Image = Properties.Resources.사각형;
            btnRactangle.ImageAlign = ContentAlignment.TopCenter;
            btnRactangle.Location = new Point(100, 38);
            btnRactangle.Name = "btnRactangle";
            btnRactangle.Size = new Size(88, 77);
            btnRactangle.TabIndex = 1;
            btnRactangle.Text = "사각형";
            btnRactangle.TextAlign = ContentAlignment.BottomCenter;
            btnRactangle.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.Font = new Font("맑은 고딕", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnLine.Image = Properties.Resources.직선;
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(6, 38);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(88, 77);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trbLineWidth);
            groupBox3.Location = new Point(557, 125);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(294, 126);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "선 두께";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(6, 54);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(282, 90);
            trbLineWidth.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Location = new Point(329, 125);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(222, 126);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black 검정", "Red 빨강", "Blue 파랑", "Green 녹색" });
            cmbColor.Location = new Point(30, 62);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(156, 40);
            cmbColor.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.LemonChiffon;
            btnOpenFile.Location = new Point(857, 143);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(118, 110);
            btnOpenFile.TabIndex = 4;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.LightBlue;
            btnSaveFile.Location = new Point(981, 143);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(117, 110);
            btnSaveFile.TabIndex = 5;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // panelCanvas
            // 
            panelCanvas.AutoScroll = true;
            panelCanvas.BorderStyle = BorderStyle.FixedSingle;
            panelCanvas.Controls.Add(picCanvas);
            panelCanvas.Location = new Point(40, 275);
            panelCanvas.Name = "panelCanvas";
            panelCanvas.Size = new Size(1083, 627);
            panelCanvas.TabIndex = 7;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.White;
            picCanvas.Location = new Point(0, 0);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(1083, 627);
            picCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
            picCanvas.TabIndex = 6;
            picCanvas.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 925);
            Controls.Add(panelCanvas);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblAppName);
            Name = "Form1";
            Text = "SimplePaint v1.0";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            groupBox2.ResumeLayout(false);
            panelCanvas.ResumeLayout(false);
            panelCanvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox cmbColor;
        private Button btnLine;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private Button btnCircle;
        private Button btnRactangle;
        private Panel panelCanvas;
        private PictureBox picCanvas;
        private SaveFileDialog saveFileDialog1;
    }
}
