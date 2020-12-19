namespace BrewCrew
{
    partial class BrewCrewAdminDashboardOrdersSubForm
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
            this.labelAdminBrewCrew = new System.Windows.Forms.Label();
            this.dataGridViewAllOrders = new System.Windows.Forms.DataGridView();
            this.labelAllOrders = new System.Windows.Forms.Label();
            this.labelOrderFilters = new System.Windows.Forms.Label();
            this.labelTextTotalOrders = new System.Windows.Forms.Label();
            this.labelTotalOrders = new System.Windows.Forms.Label();
            this.labelFilterDrinkName = new System.Windows.Forms.Label();
            this.labelFilterByDate = new System.Windows.Forms.Label();
            this.dateTimePickerFilterByDate = new System.Windows.Forms.DateTimePicker();
            this.labelTextTotalProfit = new System.Windows.Forms.Label();
            this.labelTotalProfit = new System.Windows.Forms.Label();
            this.listBoxAllDrinks = new System.Windows.Forms.ListBox();
            this.labelFilterByToppingName = new System.Windows.Forms.Label();
            this.listBoxAllToppings = new System.Windows.Forms.ListBox();
            this.labelFilterByCustomerEmail = new System.Windows.Forms.Label();
            this.textBoxCustomerEmail = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelFilterByOrderID = new System.Windows.Forms.Label();
            this.textBoxOrderID = new System.Windows.Forms.TextBox();
            this.groupBoxFilterByDate = new System.Windows.Forms.GroupBox();
            this.radioButtonFilterByDate = new System.Windows.Forms.RadioButton();
            this.radioButtonFilterDataByDateToday = new System.Windows.Forms.RadioButton();
            this.checkBoxFilterByOrderID = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllOrders)).BeginInit();
            this.groupBoxFilterByDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAdminBrewCrew
            // 
            this.labelAdminBrewCrew.AutoSize = true;
            this.labelAdminBrewCrew.Font = new System.Drawing.Font("Bodoni MT Condensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdminBrewCrew.Location = new System.Drawing.Point(470, 9);
            this.labelAdminBrewCrew.Name = "labelAdminBrewCrew";
            this.labelAdminBrewCrew.Size = new System.Drawing.Size(234, 71);
            this.labelAdminBrewCrew.TabIndex = 2;
            this.labelAdminBrewCrew.Text = "BrewCrew";
            this.labelAdminBrewCrew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewAllOrders
            // 
            this.dataGridViewAllOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllOrders.Location = new System.Drawing.Point(26, 118);
            this.dataGridViewAllOrders.Name = "dataGridViewAllOrders";
            this.dataGridViewAllOrders.RowHeadersWidth = 51;
            this.dataGridViewAllOrders.RowTemplate.Height = 24;
            this.dataGridViewAllOrders.Size = new System.Drawing.Size(1093, 179);
            this.dataGridViewAllOrders.TabIndex = 3;
            // 
            // labelAllOrders
            // 
            this.labelAllOrders.AutoSize = true;
            this.labelAllOrders.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllOrders.Location = new System.Drawing.Point(24, 86);
            this.labelAllOrders.Name = "labelAllOrders";
            this.labelAllOrders.Size = new System.Drawing.Size(131, 26);
            this.labelAllOrders.TabIndex = 4;
            this.labelAllOrders.Text = "All Orders:";
            // 
            // labelOrderFilters
            // 
            this.labelOrderFilters.AutoSize = true;
            this.labelOrderFilters.Location = new System.Drawing.Point(26, 311);
            this.labelOrderFilters.Name = "labelOrderFilters";
            this.labelOrderFilters.Size = new System.Drawing.Size(50, 17);
            this.labelOrderFilters.TabIndex = 5;
            this.labelOrderFilters.Text = "Filters:";
            // 
            // labelTextTotalOrders
            // 
            this.labelTextTotalOrders.AutoSize = true;
            this.labelTextTotalOrders.Location = new System.Drawing.Point(882, 311);
            this.labelTextTotalOrders.Name = "labelTextTotalOrders";
            this.labelTextTotalOrders.Size = new System.Drawing.Size(92, 17);
            this.labelTextTotalOrders.TabIndex = 6;
            this.labelTextTotalOrders.Text = "Total Orders:";
            // 
            // labelTotalOrders
            // 
            this.labelTotalOrders.AutoSize = true;
            this.labelTotalOrders.Location = new System.Drawing.Point(980, 311);
            this.labelTotalOrders.Name = "labelTotalOrders";
            this.labelTotalOrders.Size = new System.Drawing.Size(0, 17);
            this.labelTotalOrders.TabIndex = 7;
            // 
            // labelFilterDrinkName
            // 
            this.labelFilterDrinkName.AutoSize = true;
            this.labelFilterDrinkName.Location = new System.Drawing.Point(29, 438);
            this.labelFilterDrinkName.Name = "labelFilterDrinkName";
            this.labelFilterDrinkName.Size = new System.Drawing.Size(106, 17);
            this.labelFilterDrinkName.TabIndex = 8;
            this.labelFilterDrinkName.Text = "By Drink Name:";
            // 
            // labelFilterByDate
            // 
            this.labelFilterByDate.AutoSize = true;
            this.labelFilterByDate.Location = new System.Drawing.Point(29, 360);
            this.labelFilterByDate.Name = "labelFilterByDate";
            this.labelFilterByDate.Size = new System.Drawing.Size(62, 17);
            this.labelFilterByDate.TabIndex = 9;
            this.labelFilterByDate.Text = "By Date:";
            // 
            // dateTimePickerFilterByDate
            // 
            this.dateTimePickerFilterByDate.Location = new System.Drawing.Point(32, 391);
            this.dateTimePickerFilterByDate.Name = "dateTimePickerFilterByDate";
            this.dateTimePickerFilterByDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFilterByDate.TabIndex = 10;
            // 
            // labelTextTotalProfit
            // 
            this.labelTextTotalProfit.AutoSize = true;
            this.labelTextTotalProfit.Location = new System.Drawing.Point(882, 359);
            this.labelTextTotalProfit.Name = "labelTextTotalProfit";
            this.labelTextTotalProfit.Size = new System.Drawing.Size(81, 17);
            this.labelTextTotalProfit.TabIndex = 12;
            this.labelTextTotalProfit.Text = "Total Profit:";
            // 
            // labelTotalProfit
            // 
            this.labelTotalProfit.AutoSize = true;
            this.labelTotalProfit.Location = new System.Drawing.Point(973, 359);
            this.labelTotalProfit.Name = "labelTotalProfit";
            this.labelTotalProfit.Size = new System.Drawing.Size(0, 17);
            this.labelTotalProfit.TabIndex = 13;
            // 
            // listBoxAllDrinks
            // 
            this.listBoxAllDrinks.FormattingEnabled = true;
            this.listBoxAllDrinks.ItemHeight = 16;
            this.listBoxAllDrinks.Location = new System.Drawing.Point(29, 479);
            this.listBoxAllDrinks.Name = "listBoxAllDrinks";
            this.listBoxAllDrinks.Size = new System.Drawing.Size(253, 116);
            this.listBoxAllDrinks.TabIndex = 14;
            // 
            // labelFilterByToppingName
            // 
            this.labelFilterByToppingName.AutoSize = true;
            this.labelFilterByToppingName.Location = new System.Drawing.Point(418, 438);
            this.labelFilterByToppingName.Name = "labelFilterByToppingName";
            this.labelFilterByToppingName.Size = new System.Drawing.Size(125, 17);
            this.labelFilterByToppingName.TabIndex = 15;
            this.labelFilterByToppingName.Text = "By Topping Name:";
            // 
            // listBoxAllToppings
            // 
            this.listBoxAllToppings.FormattingEnabled = true;
            this.listBoxAllToppings.ItemHeight = 16;
            this.listBoxAllToppings.Location = new System.Drawing.Point(412, 479);
            this.listBoxAllToppings.Name = "listBoxAllToppings";
            this.listBoxAllToppings.Size = new System.Drawing.Size(194, 116);
            this.listBoxAllToppings.TabIndex = 16;
            // 
            // labelFilterByCustomerEmail
            // 
            this.labelFilterByCustomerEmail.AutoSize = true;
            this.labelFilterByCustomerEmail.Location = new System.Drawing.Point(729, 438);
            this.labelFilterByCustomerEmail.Name = "labelFilterByCustomerEmail";
            this.labelFilterByCustomerEmail.Size = new System.Drawing.Size(130, 17);
            this.labelFilterByCustomerEmail.TabIndex = 17;
            this.labelFilterByCustomerEmail.Text = "By Customer Email:";
            // 
            // textBoxCustomerEmail
            // 
            this.textBoxCustomerEmail.Location = new System.Drawing.Point(732, 467);
            this.textBoxCustomerEmail.Name = "textBoxCustomerEmail";
            this.textBoxCustomerEmail.Size = new System.Drawing.Size(130, 22);
            this.textBoxCustomerEmail.TabIndex = 18;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(874, 616);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 19;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // labelFilterByOrderID
            // 
            this.labelFilterByOrderID.AutoSize = true;
            this.labelFilterByOrderID.Location = new System.Drawing.Point(729, 512);
            this.labelFilterByOrderID.Name = "labelFilterByOrderID";
            this.labelFilterByOrderID.Size = new System.Drawing.Size(86, 17);
            this.labelFilterByOrderID.TabIndex = 22;
            this.labelFilterByOrderID.Text = "By Order ID:";
            // 
            // textBoxOrderID
            // 
            this.textBoxOrderID.Location = new System.Drawing.Point(732, 532);
            this.textBoxOrderID.Name = "textBoxOrderID";
            this.textBoxOrderID.Size = new System.Drawing.Size(100, 22);
            this.textBoxOrderID.TabIndex = 23;
            // 
            // groupBoxFilterByDate
            // 
            this.groupBoxFilterByDate.Controls.Add(this.radioButtonFilterDataByDateToday);
            this.groupBoxFilterByDate.Controls.Add(this.radioButtonFilterByDate);
            this.groupBoxFilterByDate.Location = new System.Drawing.Point(286, 380);
            this.groupBoxFilterByDate.Name = "groupBoxFilterByDate";
            this.groupBoxFilterByDate.Size = new System.Drawing.Size(418, 38);
            this.groupBoxFilterByDate.TabIndex = 25;
            this.groupBoxFilterByDate.TabStop = false;
            // 
            // radioButtonFilterByDate
            // 
            this.radioButtonFilterByDate.AutoSize = true;
            this.radioButtonFilterByDate.Location = new System.Drawing.Point(7, 10);
            this.radioButtonFilterByDate.Name = "radioButtonFilterByDate";
            this.radioButtonFilterByDate.Size = new System.Drawing.Size(162, 21);
            this.radioButtonFilterByDate.TabIndex = 0;
            this.radioButtonFilterByDate.TabStop = true;
            this.radioButtonFilterByDate.Text = "Display Data by Date";
            this.radioButtonFilterByDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonFilterDataByDateToday
            // 
            this.radioButtonFilterDataByDateToday.AutoSize = true;
            this.radioButtonFilterDataByDateToday.Location = new System.Drawing.Point(242, 10);
            this.radioButtonFilterDataByDateToday.Name = "radioButtonFilterDataByDateToday";
            this.radioButtonFilterDataByDateToday.Size = new System.Drawing.Size(170, 21);
            this.radioButtonFilterDataByDateToday.TabIndex = 1;
            this.radioButtonFilterDataByDateToday.TabStop = true;
            this.radioButtonFilterDataByDateToday.Text = "Display Data till Today";
            this.radioButtonFilterDataByDateToday.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterByOrderID
            // 
            this.checkBoxFilterByOrderID.AutoSize = true;
            this.checkBoxFilterByOrderID.Location = new System.Drawing.Point(918, 532);
            this.checkBoxFilterByOrderID.Name = "checkBoxFilterByOrderID";
            this.checkBoxFilterByOrderID.Size = new System.Drawing.Size(187, 21);
            this.checkBoxFilterByOrderID.TabIndex = 26;
            this.checkBoxFilterByOrderID.Text = "Display Data by Order ID";
            this.checkBoxFilterByOrderID.UseVisualStyleBackColor = true;
            // 
            // AdminDashboardOrdersSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 651);
            this.Controls.Add(this.checkBoxFilterByOrderID);
            this.Controls.Add(this.groupBoxFilterByDate);
            this.Controls.Add(this.textBoxOrderID);
            this.Controls.Add(this.labelFilterByOrderID);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxCustomerEmail);
            this.Controls.Add(this.labelFilterByCustomerEmail);
            this.Controls.Add(this.listBoxAllToppings);
            this.Controls.Add(this.labelFilterByToppingName);
            this.Controls.Add(this.listBoxAllDrinks);
            this.Controls.Add(this.labelTotalProfit);
            this.Controls.Add(this.labelTextTotalProfit);
            this.Controls.Add(this.dateTimePickerFilterByDate);
            this.Controls.Add(this.labelFilterByDate);
            this.Controls.Add(this.labelFilterDrinkName);
            this.Controls.Add(this.labelTotalOrders);
            this.Controls.Add(this.labelTextTotalOrders);
            this.Controls.Add(this.labelOrderFilters);
            this.Controls.Add(this.labelAllOrders);
            this.Controls.Add(this.dataGridViewAllOrders);
            this.Controls.Add(this.labelAdminBrewCrew);
            this.Name = "AdminDashboardOrdersSubForm";
            this.Text = "AdminDashboardOrdersSubForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllOrders)).EndInit();
            this.groupBoxFilterByDate.ResumeLayout(false);
            this.groupBoxFilterByDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAdminBrewCrew;
        private System.Windows.Forms.DataGridView dataGridViewAllOrders;
        private System.Windows.Forms.Label labelAllOrders;
        private System.Windows.Forms.Label labelOrderFilters;
        private System.Windows.Forms.Label labelTextTotalOrders;
        private System.Windows.Forms.Label labelTotalOrders;
        private System.Windows.Forms.Label labelFilterDrinkName;
        private System.Windows.Forms.Label labelFilterByDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFilterByDate;
        private System.Windows.Forms.Label labelTextTotalProfit;
        private System.Windows.Forms.Label labelTotalProfit;
        private System.Windows.Forms.ListBox listBoxAllDrinks;
        private System.Windows.Forms.Label labelFilterByToppingName;
        private System.Windows.Forms.ListBox listBoxAllToppings;
        private System.Windows.Forms.Label labelFilterByCustomerEmail;
        private System.Windows.Forms.TextBox textBoxCustomerEmail;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelFilterByOrderID;
        private System.Windows.Forms.TextBox textBoxOrderID;
        private System.Windows.Forms.GroupBox groupBoxFilterByDate;
        private System.Windows.Forms.RadioButton radioButtonFilterDataByDateToday;
        private System.Windows.Forms.RadioButton radioButtonFilterByDate;
        private System.Windows.Forms.CheckBox checkBoxFilterByOrderID;
    }
}