namespace Consumption
{
    partial class Form1
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
            this.btnCreateWorld = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateWorld
            // 
            this.btnCreateWorld.Location = new System.Drawing.Point(346, 12);
            this.btnCreateWorld.Name = "btnCreateWorld";
            this.btnCreateWorld.Size = new System.Drawing.Size(77, 47);
            this.btnCreateWorld.TabIndex = 0;
            this.btnCreateWorld.Text = "Create World";
            this.btnCreateWorld.UseVisualStyleBackColor = true;
            this.btnCreateWorld.Click += new System.EventHandler(this.btnCreateWorld_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreateWorld);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateWorld;
        private System.Windows.Forms.Button button1;
    }
}

