namespace TibiaBestHealer2k20
{
    partial class FORM_Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.L_Running = new System.Windows.Forms.Label();
            this.B_Run = new System.Windows.Forms.Button();
            this.B_Calibration = new System.Windows.Forms.Button();
            this.L_Calibration = new System.Windows.Forms.Label();
            this.TB_HealthPercent = new System.Windows.Forms.TextBox();
            this.L_HealthPercent = new System.Windows.Forms.Label();
            this.L_Error = new System.Windows.Forms.Label();
            this.TB_ManaPercent = new System.Windows.Forms.TextBox();
            this.L_ManaPercent = new System.Windows.Forms.Label();
            this.L_Version = new System.Windows.Forms.Label();
            this.CB_HealthKey = new System.Windows.Forms.ComboBox();
            this.CB_ManaKey = new System.Windows.Forms.ComboBox();
            this.FBDialog_TibiaFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.B_ResetPath = new System.Windows.Forms.Button();
            this.CheckB_SecureHeal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // L_Running
            // 
            this.L_Running.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L_Running.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.L_Running.Location = new System.Drawing.Point(12, 258);
            this.L_Running.Name = "L_Running";
            this.L_Running.Size = new System.Drawing.Size(91, 33);
            this.L_Running.TabIndex = 0;
            this.L_Running.Text = "Not working...";
            this.L_Running.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // B_Run
            // 
            this.B_Run.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.B_Run.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.B_Run.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.B_Run.Location = new System.Drawing.Point(107, 258);
            this.B_Run.Name = "B_Run";
            this.B_Run.Size = new System.Drawing.Size(118, 33);
            this.B_Run.TabIndex = 1;
            this.B_Run.Text = "Toggle";
            this.B_Run.UseVisualStyleBackColor = true;
            this.B_Run.Click += new System.EventHandler(this.B_Run_Click);
            // 
            // B_Calibration
            // 
            this.B_Calibration.Location = new System.Drawing.Point(107, 230);
            this.B_Calibration.Name = "B_Calibration";
            this.B_Calibration.Size = new System.Drawing.Size(118, 22);
            this.B_Calibration.TabIndex = 2;
            this.B_Calibration.Text = "Get Calibration";
            this.B_Calibration.UseVisualStyleBackColor = true;
            this.B_Calibration.Click += new System.EventHandler(this.B_Calibration_Click);
            // 
            // L_Calibration
            // 
            this.L_Calibration.Location = new System.Drawing.Point(12, 28);
            this.L_Calibration.Name = "L_Calibration";
            this.L_Calibration.Size = new System.Drawing.Size(213, 35);
            this.L_Calibration.TabIndex = 3;
            this.L_Calibration.Text = "Not Calibrated!";
            this.L_Calibration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_HealthPercent
            // 
            this.TB_HealthPercent.Location = new System.Drawing.Point(84, 177);
            this.TB_HealthPercent.MaxLength = 2;
            this.TB_HealthPercent.Name = "TB_HealthPercent";
            this.TB_HealthPercent.Size = new System.Drawing.Size(36, 20);
            this.TB_HealthPercent.TabIndex = 4;
            // 
            // L_HealthPercent
            // 
            this.L_HealthPercent.AutoSize = true;
            this.L_HealthPercent.Location = new System.Drawing.Point(35, 180);
            this.L_HealthPercent.Name = "L_HealthPercent";
            this.L_HealthPercent.Size = new System.Drawing.Size(33, 13);
            this.L_HealthPercent.TabIndex = 5;
            this.L_HealthPercent.Text = "HP %";
            // 
            // L_Error
            // 
            this.L_Error.ForeColor = System.Drawing.Color.Red;
            this.L_Error.Location = new System.Drawing.Point(12, 118);
            this.L_Error.Name = "L_Error";
            this.L_Error.Size = new System.Drawing.Size(213, 33);
            this.L_Error.TabIndex = 6;
            this.L_Error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_ManaPercent
            // 
            this.TB_ManaPercent.Location = new System.Drawing.Point(84, 204);
            this.TB_ManaPercent.Name = "TB_ManaPercent";
            this.TB_ManaPercent.Size = new System.Drawing.Size(36, 20);
            this.TB_ManaPercent.TabIndex = 7;
            // 
            // L_ManaPercent
            // 
            this.L_ManaPercent.AutoSize = true;
            this.L_ManaPercent.Location = new System.Drawing.Point(35, 207);
            this.L_ManaPercent.Name = "L_ManaPercent";
            this.L_ManaPercent.Size = new System.Drawing.Size(34, 13);
            this.L_ManaPercent.TabIndex = 8;
            this.L_ManaPercent.Text = "MP %";
            // 
            // L_Version
            // 
            this.L_Version.AutoSize = true;
            this.L_Version.Location = new System.Drawing.Point(33, 235);
            this.L_Version.Name = "L_Version";
            this.L_Version.Size = new System.Drawing.Size(43, 13);
            this.L_Version.TabIndex = 9;
            this.L_Version.Text = "v. 1.0.0";
            // 
            // CB_HealthKey
            // 
            this.CB_HealthKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_HealthKey.FormattingEnabled = true;
            this.CB_HealthKey.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.CB_HealthKey.Location = new System.Drawing.Point(153, 177);
            this.CB_HealthKey.Name = "CB_HealthKey";
            this.CB_HealthKey.Size = new System.Drawing.Size(40, 21);
            this.CB_HealthKey.TabIndex = 10;
            // 
            // CB_ManaKey
            // 
            this.CB_ManaKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ManaKey.FormattingEnabled = true;
            this.CB_ManaKey.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.CB_ManaKey.Location = new System.Drawing.Point(153, 204);
            this.CB_ManaKey.Name = "CB_ManaKey";
            this.CB_ManaKey.Size = new System.Drawing.Size(40, 21);
            this.CB_ManaKey.TabIndex = 11;
            // 
            // FBDialog_TibiaFolder
            // 
            this.FBDialog_TibiaFolder.Description = "Wybierz folder instalacji Tibii";
            // 
            // B_ResetPath
            // 
            this.B_ResetPath.Location = new System.Drawing.Point(128, 2);
            this.B_ResetPath.Name = "B_ResetPath";
            this.B_ResetPath.Size = new System.Drawing.Size(97, 23);
            this.B_ResetPath.TabIndex = 12;
            this.B_ResetPath.Text = "Reset Tibia Path";
            this.B_ResetPath.UseVisualStyleBackColor = true;
            this.B_ResetPath.Click += new System.EventHandler(this.B_ResetPath_Click);
            // 
            // CheckB_SecureHeal
            // 
            this.CheckB_SecureHeal.AutoSize = true;
            this.CheckB_SecureHeal.Checked = true;
            this.CheckB_SecureHeal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckB_SecureHeal.Location = new System.Drawing.Point(96, 154);
            this.CheckB_SecureHeal.Name = "CheckB_SecureHeal";
            this.CheckB_SecureHeal.Size = new System.Drawing.Size(85, 17);
            this.CheckB_SecureHeal.TabIndex = 13;
            this.CheckB_SecureHeal.Text = "Secure Heal";
            this.CheckB_SecureHeal.UseVisualStyleBackColor = true;
            // 
            // FORM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 303);
            this.Controls.Add(this.CheckB_SecureHeal);
            this.Controls.Add(this.B_ResetPath);
            this.Controls.Add(this.CB_ManaKey);
            this.Controls.Add(this.CB_HealthKey);
            this.Controls.Add(this.L_Version);
            this.Controls.Add(this.L_ManaPercent);
            this.Controls.Add(this.TB_ManaPercent);
            this.Controls.Add(this.L_Error);
            this.Controls.Add(this.L_HealthPercent);
            this.Controls.Add(this.TB_HealthPercent);
            this.Controls.Add(this.L_Calibration);
            this.Controls.Add(this.B_Calibration);
            this.Controls.Add(this.B_Run);
            this.Controls.Add(this.L_Running);
            this.Name = "FORM_Main";
            this.Text = "TBH2020";
            this.Load += new System.EventHandler(this.FORM_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Running;
        private System.Windows.Forms.Button B_Run;
        private System.Windows.Forms.Button B_Calibration;
        private System.Windows.Forms.Label L_Calibration;
        private System.Windows.Forms.TextBox TB_HealthPercent;
        private System.Windows.Forms.Label L_HealthPercent;
        private System.Windows.Forms.Label L_Error;
        private System.Windows.Forms.TextBox TB_ManaPercent;
        private System.Windows.Forms.Label L_ManaPercent;
        private System.Windows.Forms.Label L_Version;
        private System.Windows.Forms.ComboBox CB_HealthKey;
        private System.Windows.Forms.ComboBox CB_ManaKey;
        private System.Windows.Forms.FolderBrowserDialog FBDialog_TibiaFolder;
        private System.Windows.Forms.Button B_ResetPath;
        private System.Windows.Forms.CheckBox CheckB_SecureHeal;
    }
}

