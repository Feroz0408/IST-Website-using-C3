namespace Client3
{
    partial class facimage
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
            this.facimages = new System.Windows.Forms.PictureBox();
            this.facinfoview = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.facimages)).BeginInit();
            this.SuspendLayout();
            // 
            // facimages
            // 
            this.facimages.Location = new System.Drawing.Point(87, 141);
            this.facimages.Name = "facimages";
            this.facimages.Size = new System.Drawing.Size(128, 121);
            this.facimages.TabIndex = 0;
            this.facimages.TabStop = false;
            // 
            // facinfoview
            // 
            this.facinfoview.Location = new System.Drawing.Point(297, 79);
            this.facinfoview.Name = "facinfoview";
            this.facinfoview.Size = new System.Drawing.Size(250, 266);
            this.facinfoview.TabIndex = 1;
            this.facinfoview.UseCompatibleStateImageBehavior = false;
            // 
            // facimage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 419);
            this.Controls.Add(this.facinfoview);
            this.Controls.Add(this.facimages);
            this.Name = "facimage";
            this.Text = "facimage";
            this.Load += new System.EventHandler(this.facimage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facimages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox facimages;
        private System.Windows.Forms.ListView facinfoview;
    }
}