using System.Drawing;

namespace Supermarket.UI
{
    partial class UCMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMarquee = new System.Windows.Forms.Panel();
            this.tmrMarquee = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlMarquee
            // 
            this.pnlMarquee.Location = new System.Drawing.Point(0, 0);
            this.pnlMarquee.Name = "pnlMarquee";
            this.pnlMarquee.Size = new System.Drawing.Size(963, 685);
            this.pnlMarquee.TabIndex = 0;
            // 
            // tmrMarquee
            // 
            this.tmrMarquee.Interval = 30;
            // 
            // UCMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMarquee);
            this.Name = "UCMenu";
            this.Size = new System.Drawing.Size(963, 688);
            this.Load += new System.EventHandler(this.UCMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMarquee;
        private System.Windows.Forms.Timer tmrMarquee;
    }
}
