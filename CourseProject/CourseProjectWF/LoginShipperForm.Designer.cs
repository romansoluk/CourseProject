namespace CourseProjectWF
{
    partial class LoginShipperForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.shipperLoginText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ShipperSignUPFormLink = new System.Windows.Forms.LinkLabel();
            this.shipperLoginButton = new System.Windows.Forms.Button();
            this.ShipperPasswordText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // shipperLoginText
            // 
            this.shipperLoginText.Location = new System.Drawing.Point(186, 73);
            this.shipperLoginText.Name = "shipperLoginText";
            this.shipperLoginText.Size = new System.Drawing.Size(154, 22);
            this.shipperLoginText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // ShipperSignUPFormLink
            // 
            this.ShipperSignUPFormLink.AutoSize = true;
            this.ShipperSignUPFormLink.Location = new System.Drawing.Point(103, 275);
            this.ShipperSignUPFormLink.Name = "ShipperSignUPFormLink";
            this.ShipperSignUPFormLink.Size = new System.Drawing.Size(158, 17);
            this.ShipperSignUPFormLink.TabIndex = 4;
            this.ShipperSignUPFormLink.TabStop = true;
            this.ShipperSignUPFormLink.Text = "Don\'t have an account?";
            this.ShipperSignUPFormLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ShipperLoginFormLink_LinkClicked);
            // 
            // shipperLoginButton
            // 
            this.shipperLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shipperLoginButton.Location = new System.Drawing.Point(123, 182);
            this.shipperLoginButton.Name = "shipperLoginButton";
            this.shipperLoginButton.Size = new System.Drawing.Size(122, 49);
            this.shipperLoginButton.TabIndex = 5;
            this.shipperLoginButton.Text = "Login";
            this.shipperLoginButton.UseVisualStyleBackColor = true;
            this.shipperLoginButton.Click += new System.EventHandler(this.shipperLoginButton_Click);
            // 
            // ShipperPasswordText
            // 
            this.ShipperPasswordText.Location = new System.Drawing.Point(186, 135);
            this.ShipperPasswordText.Name = "ShipperPasswordText";
            this.ShipperPasswordText.Size = new System.Drawing.Size(154, 22);
            this.ShipperPasswordText.TabIndex = 6;
            this.ShipperPasswordText.TextChanged += new System.EventHandler(this.ShipperPasswordText_TextChanged);
            // 
            // LoginShipperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 314);
            this.Controls.Add(this.ShipperPasswordText);
            this.Controls.Add(this.shipperLoginButton);
            this.Controls.Add(this.ShipperSignUPFormLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shipperLoginText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginShipperForm";
            this.Text = "Login as Shipper ";
            this.Load += new System.EventHandler(this.LoginShipperForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox shipperLoginText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel ShipperSignUPFormLink;
        private System.Windows.Forms.Button shipperLoginButton;
        private System.Windows.Forms.TextBox ShipperPasswordText;
    }
}