namespace BrewCrew
{
    partial class BrewCrewCustomerOrderReceiptForm
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
            this.labelReceiptBrewCrew = new System.Windows.Forms.Label();
            this.labelReceipt = new System.Windows.Forms.Label();
            this.labelThankYou = new System.Windows.Forms.Label();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.labelTextOrderNumber = new System.Windows.Forms.Label();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.labelTextOrderDetails = new System.Windows.Forms.Label();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.labelTextOrderTotal = new System.Windows.Forms.Label();
            this.labelOrderTotal = new System.Windows.Forms.Label();
            this.labelTextOrderDate = new System.Windows.Forms.Label();
            this.labelOrderDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // labelReceiptBrewCrew
            // 
            this.labelReceiptBrewCrew.AutoSize = true;
            this.labelReceiptBrewCrew.Font = new System.Drawing.Font("Bodoni MT Condensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiptBrewCrew.Location = new System.Drawing.Point(279, 9);
            this.labelReceiptBrewCrew.Name = "labelReceiptBrewCrew";
            this.labelReceiptBrewCrew.Size = new System.Drawing.Size(246, 71);
            this.labelReceiptBrewCrew.TabIndex = 0;
            this.labelReceiptBrewCrew.Text = "Brew Crew";
            this.labelReceiptBrewCrew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelReceipt
            // 
            this.labelReceipt.AutoSize = true;
            this.labelReceipt.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceipt.Location = new System.Drawing.Point(317, 80);
            this.labelReceipt.Name = "labelReceipt";
            this.labelReceipt.Size = new System.Drawing.Size(124, 37);
            this.labelReceipt.TabIndex = 1;
            this.labelReceipt.Text = "Receipt";
            // 
            // labelThankYou
            // 
            this.labelThankYou.AutoSize = true;
            this.labelThankYou.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThankYou.Location = new System.Drawing.Point(145, 619);
            this.labelThankYou.Name = "labelThankYou";
            this.labelThankYou.Size = new System.Drawing.Size(538, 22);
            this.labelThankYou.TabIndex = 2;
            this.labelThankYou.Text = "Thank you for your order and we hope we’ll be seeing you again!";
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Location = new System.Drawing.Point(291, 424);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(201, 192);
            this.pictureBoxQRCode.TabIndex = 3;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // labelTextOrderNumber
            // 
            this.labelTextOrderNumber.AutoSize = true;
            this.labelTextOrderNumber.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextOrderNumber.Location = new System.Drawing.Point(24, 138);
            this.labelTextOrderNumber.Name = "labelTextOrderNumber";
            this.labelTextOrderNumber.Size = new System.Drawing.Size(175, 26);
            this.labelTextOrderNumber.TabIndex = 4;
            this.labelTextOrderNumber.Text = "Order Number:";
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderNumber.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelOrderNumber.Location = new System.Drawing.Point(199, 139);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(0, 27);
            this.labelOrderNumber.TabIndex = 5;
            // 
            // labelTextOrderDetails
            // 
            this.labelTextOrderDetails.AutoSize = true;
            this.labelTextOrderDetails.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextOrderDetails.Location = new System.Drawing.Point(24, 173);
            this.labelTextOrderDetails.Name = "labelTextOrderDetails";
            this.labelTextOrderDetails.Size = new System.Drawing.Size(162, 26);
            this.labelTextOrderDetails.TabIndex = 6;
            this.labelTextOrderDetails.Text = "Order Details:";
            // 
            // buttonSignOut
            // 
            this.buttonSignOut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignOut.Location = new System.Drawing.Point(333, 657);
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.Size = new System.Drawing.Size(97, 34);
            this.buttonSignOut.TabIndex = 13;
            this.buttonSignOut.Text = "Sign Out";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrderDetails
            // 
            this.dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(12, 202);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.RowHeadersWidth = 51;
            this.dataGridViewOrderDetails.RowTemplate.Height = 24;
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(723, 150);
            this.dataGridViewOrderDetails.TabIndex = 14;
            // 
            // labelTextOrderTotal
            // 
            this.labelTextOrderTotal.AutoSize = true;
            this.labelTextOrderTotal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextOrderTotal.Location = new System.Drawing.Point(29, 369);
            this.labelTextOrderTotal.Name = "labelTextOrderTotal";
            this.labelTextOrderTotal.Size = new System.Drawing.Size(143, 26);
            this.labelTextOrderTotal.TabIndex = 15;
            this.labelTextOrderTotal.Text = "Order Total:";
            // 
            // labelOrderTotal
            // 
            this.labelOrderTotal.AutoSize = true;
            this.labelOrderTotal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderTotal.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelOrderTotal.Location = new System.Drawing.Point(172, 369);
            this.labelOrderTotal.Name = "labelOrderTotal";
            this.labelOrderTotal.Size = new System.Drawing.Size(0, 27);
            this.labelOrderTotal.TabIndex = 16;
            // 
            // labelTextOrderDate
            // 
            this.labelTextOrderDate.AutoSize = true;
            this.labelTextOrderDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextOrderDate.Location = new System.Drawing.Point(459, 138);
            this.labelTextOrderDate.Name = "labelTextOrderDate";
            this.labelTextOrderDate.Size = new System.Drawing.Size(139, 26);
            this.labelTextOrderDate.TabIndex = 17;
            this.labelTextOrderDate.Text = "Order Date:";
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelOrderDate.Location = new System.Drawing.Point(598, 138);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(0, 27);
            this.labelOrderDate.TabIndex = 18;
            // 
            // BrewCrewCustomerOrderReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 703);
            this.Controls.Add(this.labelOrderDate);
            this.Controls.Add(this.labelTextOrderDate);
            this.Controls.Add(this.labelOrderTotal);
            this.Controls.Add(this.labelTextOrderTotal);
            this.Controls.Add(this.dataGridViewOrderDetails);
            this.Controls.Add(this.buttonSignOut);
            this.Controls.Add(this.labelTextOrderDetails);
            this.Controls.Add(this.labelOrderNumber);
            this.Controls.Add(this.labelTextOrderNumber);
            this.Controls.Add(this.pictureBoxQRCode);
            this.Controls.Add(this.labelThankYou);
            this.Controls.Add(this.labelReceipt);
            this.Controls.Add(this.labelReceiptBrewCrew);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BrewCrewCustomerOrderReceiptForm";
            this.Text = "Order Reciept";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelReceiptBrewCrew;
        private System.Windows.Forms.Label labelReceipt;
        private System.Windows.Forms.Label labelThankYou;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.Label labelTextOrderNumber;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.Label labelTextOrderDetails;
        private System.Windows.Forms.Button buttonSignOut;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private System.Windows.Forms.Label labelTextOrderTotal;
        private System.Windows.Forms.Label labelOrderTotal;
        private System.Windows.Forms.Label labelTextOrderDate;
        private System.Windows.Forms.Label labelOrderDate;
    }
}