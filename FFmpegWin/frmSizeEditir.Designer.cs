namespace FFmpegWin
{
    partial class frmSizeEditir
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            txtExt = new TextBox();
            label2 = new Label();
            txtImgSrc = new TextBox();
            button3 = new Button();
            rdoL = new RadioButton();
            rdoTop = new RadioButton();
            rdoB = new RadioButton();
            rdoR = new RadioButton();
            btnMake = new Button();
            txtImgFolder = new TextBox();
            txtAudioPath = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(27, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1065, 1149);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // button1
            // 
            button1.Location = new Point(2683, 45);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(2689, 118);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 25);
            label1.Name = "label1";
            label1.Size = new Size(118, 25);
            label1.TabIndex = 3;
            label1.Text = "File Extension";
            // 
            // txtExt
            // 
            txtExt.Location = new Point(151, 22);
            txtExt.Name = "txtExt";
            txtExt.Size = new Size(150, 31);
            txtExt.TabIndex = 4;
            txtExt.Text = "jpg";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 25);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 3;
            label2.Text = "Image source:";
            // 
            // txtImgSrc
            // 
            txtImgSrc.Location = new Point(491, 25);
            txtImgSrc.Name = "txtImgSrc";
            txtImgSrc.Size = new Size(412, 31);
            txtImgSrc.TabIndex = 4;
            txtImgSrc.Text = "Z:\\frames";
            // 
            // button3
            // 
            button3.Location = new Point(2692, 458);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 5;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // rdoL
            // 
            rdoL.AutoSize = true;
            rdoL.Location = new Point(2521, 1437);
            rdoL.Name = "rdoL";
            rdoL.Size = new Size(66, 29);
            rdoL.TabIndex = 6;
            rdoL.TabStop = true;
            rdoL.Text = "Left";
            rdoL.UseVisualStyleBackColor = true;
            // 
            // rdoTop
            // 
            rdoTop.AutoSize = true;
            rdoTop.Checked = true;
            rdoTop.Location = new Point(2611, 1378);
            rdoTop.Name = "rdoTop";
            rdoTop.Size = new Size(66, 29);
            rdoTop.TabIndex = 6;
            rdoTop.TabStop = true;
            rdoTop.Text = "Top";
            rdoTop.UseVisualStyleBackColor = true;
            // 
            // rdoB
            // 
            rdoB.AutoSize = true;
            rdoB.Location = new Point(2611, 1482);
            rdoB.Name = "rdoB";
            rdoB.Size = new Size(96, 29);
            rdoB.TabIndex = 6;
            rdoB.TabStop = true;
            rdoB.Text = "Buttom";
            rdoB.UseVisualStyleBackColor = true;
            // 
            // rdoR
            // 
            rdoR.AutoSize = true;
            rdoR.Location = new Point(2701, 1423);
            rdoR.Name = "rdoR";
            rdoR.Size = new Size(79, 29);
            rdoR.TabIndex = 6;
            rdoR.TabStop = true;
            rdoR.Text = "Right";
            rdoR.UseVisualStyleBackColor = true;
            // 
            // btnMake
            // 
            btnMake.Location = new Point(1827, 1469);
            btnMake.Name = "btnMake";
            btnMake.Size = new Size(112, 34);
            btnMake.TabIndex = 7;
            btnMake.Text = "Make";
            btnMake.UseVisualStyleBackColor = true;
            btnMake.Click += btnMake_Click;
            // 
            // txtImgFolder
            // 
            txtImgFolder.Location = new Point(29, 1472);
            txtImgFolder.Name = "txtImgFolder";
            txtImgFolder.Size = new Size(852, 31);
            txtImgFolder.TabIndex = 8;
            txtImgFolder.Text = "Z:\\out";
            // 
            // txtAudioPath
            // 
            txtAudioPath.Location = new Point(908, 1472);
            txtAudioPath.Name = "txtAudioPath";
            txtAudioPath.Size = new Size(852, 31);
            txtAudioPath.TabIndex = 8;
            txtAudioPath.Text = "Z:\\audio.aac";
            // 
            // frmSizeEditir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2853, 1565);
            Controls.Add(txtAudioPath);
            Controls.Add(txtImgFolder);
            Controls.Add(btnMake);
            Controls.Add(rdoR);
            Controls.Add(rdoTop);
            Controls.Add(rdoB);
            Controls.Add(rdoL);
            Controls.Add(button3);
            Controls.Add(txtImgSrc);
            Controls.Add(label2);
            Controls.Add(txtExt);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "frmSizeEditir";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox txtExt;
        private Label label2;
        private TextBox txtImgSrc;
        private Button button3;
        private RadioButton rdoL;
        private RadioButton rdoTop;
        private RadioButton rdoB;
        private RadioButton rdoR;
        private Button btnMake;
        private TextBox txtImgFolder;
        private TextBox txtAudioPath;
    }
}
