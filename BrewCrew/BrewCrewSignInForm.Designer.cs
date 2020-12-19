namespace BrewCrew
{
    partial class BrewCrewSignInForm
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
            this.labelBrewCrew = new System.Windows.Forms.Label();
            this.labelSignInEmail = new System.Windows.Forms.Label();
            this.textBoxUserEmail = new System.Windows.Forms.TextBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelRegisterToBrewCrew = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelBrewCrew
            // 
            this.labelBrewCrew.AutoSize = true;
            this.labelBrewCrew.Font = new System.Drawing.Font("Bodoni MT Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrewCrew.Location = new System.Drawing.Point(214, 40);
            this.labelBrewCrew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBrewCrew.Name = "labelBrewCrew";
            this.labelBrewCrew.Size = new System.Drawing.Size(656, 94);
            this.labelBrewCrew.TabIndex = 0;
            this.labelBrewCrew.Text = "Welcome To BrewCrew";
            // 
            // labelSignInEmail
            // 
            this.labelSignInEmail.AutoSize = true;
            this.labelSignInEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignInEmail.Location = new System.Drawing.Point(300, 252);
            this.labelSignInEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSignInEmail.Name = "labelSignInEmail";
            this.labelSignInEmail.Size = new System.Drawing.Size(169, 26);
            this.labelSignInEmail.TabIndex = 1;
            this.labelSignInEmail.Text = "Email Address:";
            // 
            // textBoxUserEmail
            // 
            this.textBoxUserEmail.Location = new System.Drawing.Point(477, 257);
            this.textBoxUserEmail.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUserEmail.Name = "textBoxUserEmail";
            this.textBoxUserEmail.Size = new System.Drawing.Size(292, 34);
            this.textBoxUserEmail.TabIndex = 0;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignIn.Location = new System.Drawing.Point(452, 345);
            this.buttonSignIn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(176, 38);
            this.buttonSignIn.TabIndex = 1;
            this.buttonSignIn.Text = "Sign In";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.Location = new System.Drawing.Point(724, 465);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(176, 36);
            this.buttonRegister.TabIndex = 2;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            // 
            // labelRegisterToBrewCrew
            // 
            this.labelRegisterToBrewCrew.AutoSize = true;
            this.labelRegisterToBrewCrew.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegisterToBrewCrew.Location = new System.Drawing.Point(157, 470);
            this.labelRegisterToBrewCrew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRegisterToBrewCrew.Name = "labelRegisterToBrewCrew";
            this.labelRegisterToBrewCrew.Size = new System.Drawing.Size(502, 26);
            this.labelRegisterToBrewCrew.TabIndex = 7;
            this.labelRegisterToBrewCrew.Text = "New to BrewCrew? Click the button to Register";
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.labelRegisterToBrewCrew);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.textBoxUserEmail);
            this.Controls.Add(this.labelSignInEmail);
            this.Controls.Add(this.labelBrewCrew);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SignInForm";
            this.Text = "BrewCrew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBrewCrew;
        private System.Windows.Forms.Label labelSignInEmail;
        private System.Windows.Forms.TextBox textBoxUserEmail;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelRegisterToBrewCrew;
    }
}

