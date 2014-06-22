namespace UDPRequester
{
    partial class Form_Pivotes
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
            this.listBoxIPsPivotes = new System.Windows.Forms.ListBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonAgregarIP = new System.Windows.Forms.Button();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxIPsPivotes
            // 
            this.listBoxIPsPivotes.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxIPsPivotes.FormattingEnabled = true;
            this.listBoxIPsPivotes.ItemHeight = 18;
            this.listBoxIPsPivotes.Location = new System.Drawing.Point(12, 42);
            this.listBoxIPsPivotes.Name = "listBoxIPsPivotes";
            this.listBoxIPsPivotes.Size = new System.Drawing.Size(282, 166);
            this.listBoxIPsPivotes.TabIndex = 0;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.Location = new System.Drawing.Point(12, 8);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(120, 26);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Enter += new System.EventHandler(this.textBoxIP_Enter);
            // 
            // buttonAgregarIP
            // 
            this.buttonAgregarIP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarIP.Location = new System.Drawing.Point(138, 8);
            this.buttonAgregarIP.Name = "buttonAgregarIP";
            this.buttonAgregarIP.Size = new System.Drawing.Size(75, 26);
            this.buttonAgregarIP.TabIndex = 2;
            this.buttonAgregarIP.Text = "Agregar";
            this.buttonAgregarIP.UseVisualStyleBackColor = true;
            this.buttonAgregarIP.Click += new System.EventHandler(this.buttonAgregarIP_Click);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Enabled = false;
            this.buttonEnviar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnviar.Location = new System.Drawing.Point(219, 8);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 26);
            this.buttonEnviar.TabIndex = 3;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(9, 211);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(133, 18);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Esperando orden...";
            // 
            // Form_Pivotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 234);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.buttonAgregarIP);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.listBoxIPsPivotes);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(323, 268);
            this.Name = "Form_Pivotes";
            this.Text = "Enviar orden de inicio a pivotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIPsPivotes;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonAgregarIP;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Label labelStatus;
    }
}