namespace UDPRequester
{
    partial class FormBase
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelThreadMaximo = new System.Windows.Forms.Label();
            this.labelPeticionesAEnviar = new System.Windows.Forms.Label();
            this.labelIPspoofeada = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonControlarPivotes = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPaquetesPeticionesRestantes = new System.Windows.Forms.Label();
            this.labelPaquetesEnviados = new System.Windows.Forms.Label();
            this.labelThreadsErrores = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonCargarJSON = new System.Windows.Forms.Button();
            this.comboBoxInterfaces = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelEscuchaEnUDP = new System.Windows.Forms.Label();
            this.buttonEmpezar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelThreadMaximo);
            this.groupBox2.Controls.Add(this.labelPeticionesAEnviar);
            this.groupBox2.Controls.Add(this.labelIPspoofeada);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de configuración";
            // 
            // labelThreadMaximo
            // 
            this.labelThreadMaximo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThreadMaximo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelThreadMaximo.Location = new System.Drawing.Point(184, 64);
            this.labelThreadMaximo.Name = "labelThreadMaximo";
            this.labelThreadMaximo.Size = new System.Drawing.Size(151, 18);
            this.labelThreadMaximo.TabIndex = 7;
            this.labelThreadMaximo.Text = "(ninguno)";
            // 
            // labelPeticionesAEnviar
            // 
            this.labelPeticionesAEnviar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeticionesAEnviar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPeticionesAEnviar.Location = new System.Drawing.Point(184, 43);
            this.labelPeticionesAEnviar.Name = "labelPeticionesAEnviar";
            this.labelPeticionesAEnviar.Size = new System.Drawing.Size(151, 18);
            this.labelPeticionesAEnviar.TabIndex = 5;
            this.labelPeticionesAEnviar.Text = "(ninguna)";
            // 
            // labelIPspoofeada
            // 
            this.labelIPspoofeada.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPspoofeada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelIPspoofeada.Location = new System.Drawing.Point(184, 23);
            this.labelIPspoofeada.Name = "labelIPspoofeada";
            this.labelIPspoofeada.Size = new System.Drawing.Size(151, 18);
            this.labelIPspoofeada.TabIndex = 4;
            this.labelIPspoofeada.Text = "(ninguna)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Threads máximo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Peticiones a enviar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP origen (spoofeada):";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonControlarPivotes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(365, 26);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonControlarPivotes
            // 
            this.toolStripButtonControlarPivotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonControlarPivotes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonControlarPivotes.Image")));
            this.toolStripButtonControlarPivotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonControlarPivotes.Name = "toolStripButtonControlarPivotes";
            this.toolStripButtonControlarPivotes.Size = new System.Drawing.Size(134, 23);
            this.toolStripButtonControlarPivotes.Text = "Controlar pivotes";
            this.toolStripButtonControlarPivotes.Click += new System.EventHandler(this.toolStripButtonControlarPivotes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPaquetesPeticionesRestantes);
            this.groupBox1.Controls.Add(this.labelPaquetesEnviados);
            this.groupBox1.Controls.Add(this.labelThreadsErrores);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // labelPaquetesPeticionesRestantes
            // 
            this.labelPaquetesPeticionesRestantes.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaquetesPeticionesRestantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPaquetesPeticionesRestantes.Location = new System.Drawing.Point(184, 68);
            this.labelPaquetesPeticionesRestantes.Name = "labelPaquetesPeticionesRestantes";
            this.labelPaquetesPeticionesRestantes.Size = new System.Drawing.Size(151, 18);
            this.labelPaquetesPeticionesRestantes.TabIndex = 7;
            this.labelPaquetesPeticionesRestantes.Text = "(ninguno)";
            // 
            // labelPaquetesEnviados
            // 
            this.labelPaquetesEnviados.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaquetesEnviados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPaquetesEnviados.Location = new System.Drawing.Point(184, 47);
            this.labelPaquetesEnviados.Name = "labelPaquetesEnviados";
            this.labelPaquetesEnviados.Size = new System.Drawing.Size(151, 18);
            this.labelPaquetesEnviados.TabIndex = 5;
            this.labelPaquetesEnviados.Text = "(ninguno)";
            // 
            // labelThreadsErrores
            // 
            this.labelThreadsErrores.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThreadsErrores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelThreadsErrores.Location = new System.Drawing.Point(184, 27);
            this.labelThreadsErrores.Name = "labelThreadsErrores";
            this.labelThreadsErrores.Size = new System.Drawing.Size(151, 18);
            this.labelThreadsErrores.TabIndex = 4;
            this.labelThreadsErrores.Text = "(ninguno)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Paquetes restantes:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Paquetes enviados:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Threads / Errores:";
            // 
            // buttonCargarJSON
            // 
            this.buttonCargarJSON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCargarJSON.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCargarJSON.Location = new System.Drawing.Point(9, 22);
            this.buttonCargarJSON.Name = "buttonCargarJSON";
            this.buttonCargarJSON.Size = new System.Drawing.Size(148, 27);
            this.buttonCargarJSON.TabIndex = 9;
            this.buttonCargarJSON.Text = "Cargar JSON";
            this.buttonCargarJSON.UseVisualStyleBackColor = true;
            this.buttonCargarJSON.Click += new System.EventHandler(this.buttonCargarJSON_Click);
            // 
            // comboBoxInterfaces
            // 
            this.comboBoxInterfaces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterfaces.DropDownWidth = 600;
            this.comboBoxInterfaces.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxInterfaces.FormattingEnabled = true;
            this.comboBoxInterfaces.IntegralHeight = false;
            this.comboBoxInterfaces.Location = new System.Drawing.Point(9, 55);
            this.comboBoxInterfaces.MaxDropDownItems = 100;
            this.comboBoxInterfaces.Name = "comboBoxInterfaces";
            this.comboBoxInterfaces.Size = new System.Drawing.Size(148, 26);
            this.comboBoxInterfaces.TabIndex = 11;
            this.comboBoxInterfaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterfaces_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelEscuchaEnUDP);
            this.groupBox3.Controls.Add(this.buttonEmpezar);
            this.groupBox3.Controls.Add(this.comboBoxInterfaces);
            this.groupBox3.Controls.Add(this.buttonCargarJSON);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 92);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acciones";
            // 
            // labelEscuchaEnUDP
            // 
            this.labelEscuchaEnUDP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEscuchaEnUDP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscuchaEnUDP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEscuchaEnUDP.Location = new System.Drawing.Point(187, 55);
            this.labelEscuchaEnUDP.Name = "labelEscuchaEnUDP";
            this.labelEscuchaEnUDP.Size = new System.Drawing.Size(148, 26);
            this.labelEscuchaEnUDP.TabIndex = 14;
            this.labelEscuchaEnUDP.Text = "Escuchando: ...";
            this.labelEscuchaEnUDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEmpezar
            // 
            this.buttonEmpezar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEmpezar.Enabled = false;
            this.buttonEmpezar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmpezar.Location = new System.Drawing.Point(187, 22);
            this.buttonEmpezar.Name = "buttonEmpezar";
            this.buttonEmpezar.Size = new System.Drawing.Size(148, 27);
            this.buttonEmpezar.TabIndex = 12;
            this.buttonEmpezar.Text = "Empezar";
            this.buttonEmpezar.UseVisualStyleBackColor = true;
            this.buttonEmpezar.Click += new System.EventHandler(this.buttonEmpezar_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 331);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(381, 365);
            this.Name = "FormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "r2dr2: UDP DRDoS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelThreadMaximo;
        private System.Windows.Forms.Label labelPeticionesAEnviar;
        private System.Windows.Forms.Label labelIPspoofeada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPaquetesPeticionesRestantes;
        private System.Windows.Forms.Label labelPaquetesEnviados;
        private System.Windows.Forms.Label labelThreadsErrores;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripButton toolStripButtonControlarPivotes;
        private System.Windows.Forms.Button buttonCargarJSON;
        private System.Windows.Forms.ComboBox comboBoxInterfaces;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonEmpezar;
        private System.Windows.Forms.Label labelEscuchaEnUDP;
    }
}

