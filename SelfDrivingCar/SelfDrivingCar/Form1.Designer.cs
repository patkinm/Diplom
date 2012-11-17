namespace SelfDrivingCar
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
            this.worldMap = new System.Windows.Forms.PictureBox();
            this.startCar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.worldMap)).BeginInit();
            this.SuspendLayout();
            // 
            // worldMap
            // 
            this.worldMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldMap.Location = new System.Drawing.Point(270, 12);
            this.worldMap.Name = "worldMap";
            this.worldMap.Size = new System.Drawing.Size(751, 501);
            this.worldMap.TabIndex = 0;
            this.worldMap.TabStop = false;
            this.worldMap.Click += new System.EventHandler(this.worldMap_Click);
            // 
            // startCar
            // 
            this.startCar.Location = new System.Drawing.Point(12, 12);
            this.startCar.Name = "startCar";
            this.startCar.Size = new System.Drawing.Size(75, 23);
            this.startCar.TabIndex = 1;
            this.startCar.Text = "Start car";
            this.startCar.UseVisualStyleBackColor = true;
            this.startCar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 530);
            this.Controls.Add(this.startCar);
            this.Controls.Add(this.worldMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.worldMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox worldMap;
        private System.Windows.Forms.Button startCar;
    }
}

