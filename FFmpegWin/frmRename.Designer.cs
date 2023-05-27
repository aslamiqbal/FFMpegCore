namespace FFmpegWin
{
    partial class frmRename
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
            label1 = new Label();
            txtPath = new TextBox();
            btnRename = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 0;
            label1.Text = "PATH: ";
            // 
            // txtPath
            // 
            txtPath.Location = new Point(68, 6);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(1296, 31);
            txtPath.TabIndex = 1;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(1380, 3);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(112, 34);
            btnRename.TabIndex = 2;
            btnRename.Text = "Rename";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // frmRename
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 350);
            Controls.Add(btnRename);
            Controls.Add(txtPath);
            Controls.Add(label1);
            Name = "frmRename";
            Text = "frmRename";
            Load += frmRename_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPath;
        private Button btnRename;
    }
}