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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stopCar = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.comPortName = new System.Windows.Forms.TextBox();
            this.comPortRate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.worldMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // worldMap
            // 
            this.worldMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldMap.Location = new System.Drawing.Point(418, 12);
            this.worldMap.Name = "worldMap";
            this.worldMap.Size = new System.Drawing.Size(751, 501);
            this.worldMap.TabIndex = 0;
            this.worldMap.TabStop = false;
            this.worldMap.Click += new System.EventHandler(this.worldMap_Click);
            // 
            // startCar
            // 
            this.startCar.Location = new System.Drawing.Point(337, 418);
            this.startCar.Name = "startCar";
            this.startCar.Size = new System.Drawing.Size(75, 23);
            this.startCar.TabIndex = 1;
            this.startCar.Text = "Start car";
            this.startCar.UseVisualStyleBackColor = true;
            this.startCar.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // stopCar
            // 
            this.stopCar.Enabled = false;
            this.stopCar.Location = new System.Drawing.Point(337, 447);
            this.stopCar.Name = "stopCar";
            this.stopCar.Size = new System.Drawing.Size(75, 23);
            this.stopCar.TabIndex = 3;
            this.stopCar.Text = "Stop car";
            this.stopCar.UseVisualStyleBackColor = true;
            this.stopCar.Click += new System.EventHandler(this.stopCar_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(337, 476);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // comPortName
            // 
            this.comPortName.Location = new System.Drawing.Point(208, 421);
            this.comPortName.Name = "comPortName";
            this.comPortName.Size = new System.Drawing.Size(100, 20);
            this.comPortName.TabIndex = 5;
            // 
            // comPortRate
            // 
            this.comPortRate.Location = new System.Drawing.Point(208, 450);
            this.comPortRate.Name = "comPortRate";
            this.comPortRate.Size = new System.Drawing.Size(100, 20);
            this.comPortRate.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 522);
            this.Controls.Add(this.comPortRate);
            this.Controls.Add(this.comPortName);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.stopCar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.startCar);
            this.Controls.Add(this.worldMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.worldMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox worldMap;
        private System.Windows.Forms.Button startCar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button stopCar;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.TextBox comPortName;
        private System.Windows.Forms.TextBox comPortRate;
    }
}

