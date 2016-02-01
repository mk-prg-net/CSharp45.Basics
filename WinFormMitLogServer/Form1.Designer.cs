namespace WinFormMitLogServer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxMeldung = new System.Windows.Forms.TextBox();
            this.btnFireEvents = new System.Windows.Forms.Button();
            this.rbtMsgBox = new System.Windows.Forms.RadioButton();
            this.rbtWithoutMsgBox = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblDasWichtigste = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rbtWithoutMsgBox);
            this.tabPage2.Controls.Add(this.rbtMsgBox);
            this.tabPage2.Controls.Add(this.btnFireEvents);
            this.tabPage2.Controls.Add(this.tbxMeldung);
            // 
            // tbxMeldung
            // 
            this.tbxMeldung.Location = new System.Drawing.Point(52, 60);
            this.tbxMeldung.Name = "tbxMeldung";
            this.tbxMeldung.Size = new System.Drawing.Size(359, 20);
            this.tbxMeldung.TabIndex = 0;
            // 
            // btnFireEvents
            // 
            this.btnFireEvents.Location = new System.Drawing.Point(52, 115);
            this.btnFireEvents.Name = "btnFireEvents";
            this.btnFireEvents.Size = new System.Drawing.Size(75, 23);
            this.btnFireEvents.TabIndex = 1;
            this.btnFireEvents.Text = "Feuer Event";
            this.btnFireEvents.UseVisualStyleBackColor = true;
            this.btnFireEvents.Click += new System.EventHandler(this.btnFireEvents_Click);
            // 
            // rbtMsgBox
            // 
            this.rbtMsgBox.AutoSize = true;
            this.rbtMsgBox.Location = new System.Drawing.Point(189, 99);
            this.rbtMsgBox.Name = "rbtMsgBox";
            this.rbtMsgBox.Size = new System.Drawing.Size(79, 17);
            this.rbtMsgBox.TabIndex = 2;
            this.rbtMsgBox.Text = "mit MsgBox";
            this.rbtMsgBox.UseVisualStyleBackColor = true;
            this.rbtMsgBox.CheckedChanged += new System.EventHandler(this.rbtMsgBox_CheckedChanged);
            // 
            // rbtWithoutMsgBox
            // 
            this.rbtWithoutMsgBox.AutoSize = true;
            this.rbtWithoutMsgBox.Checked = true;
            this.rbtWithoutMsgBox.Location = new System.Drawing.Point(189, 134);
            this.rbtWithoutMsgBox.Name = "rbtWithoutMsgBox";
            this.rbtWithoutMsgBox.Size = new System.Drawing.Size(99, 17);
            this.rbtWithoutMsgBox.TabIndex = 3;
            this.rbtWithoutMsgBox.TabStop = true;
            this.rbtWithoutMsgBox.Text = "ohne Mesg Box";
            this.rbtWithoutMsgBox.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblDasWichtigste);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(667, 190);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Char und Unicode";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblDasWichtigste
            // 
            this.lblDasWichtigste.AutoSize = true;
            this.lblDasWichtigste.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDasWichtigste.ForeColor = System.Drawing.Color.Red;
            this.lblDasWichtigste.Location = new System.Drawing.Point(38, 34);
            this.lblDasWichtigste.Name = "lblDasWichtigste";
            this.lblDasWichtigste.Size = new System.Drawing.Size(28, 37);
            this.lblDasWichtigste.TabIndex = 0;
            this.lblDasWichtigste.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(675, 262);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMeldung;
        private System.Windows.Forms.Button btnFireEvents;
        private System.Windows.Forms.RadioButton rbtWithoutMsgBox;
        private System.Windows.Forms.RadioButton rbtMsgBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblDasWichtigste;
    }
}
