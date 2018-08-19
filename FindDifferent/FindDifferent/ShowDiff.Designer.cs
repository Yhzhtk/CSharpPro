namespace FindDifferent
{
    partial class ShowDiff
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
            this.SuspendLayout();
            // 
            // ShowDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 415);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowDiff";
            this.Opacity = 0.5D;
            this.Text = "ShowDiff";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowDiff_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowDiff_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowDiff_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowDiff_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}