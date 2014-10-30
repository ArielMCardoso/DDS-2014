namespace DDS_2014_Grupo4.Formularios
{
    partial class FormularioPrincipal
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
            this.Boton_buscar_jugador = new System.Windows.Forms.Button();
            this.Boton_generar_equipo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Boton_buscar_jugador
            // 
            this.Boton_buscar_jugador.Location = new System.Drawing.Point(33, 89);
            this.Boton_buscar_jugador.Name = "Boton_buscar_jugador";
            this.Boton_buscar_jugador.Size = new System.Drawing.Size(103, 23);
            this.Boton_buscar_jugador.TabIndex = 0;
            this.Boton_buscar_jugador.Text = "Buscar Jugador";
            this.Boton_buscar_jugador.UseVisualStyleBackColor = true;
            this.Boton_buscar_jugador.Click += new System.EventHandler(this.button1_Click);
            // 
            // Boton_generar_equipo
            // 
            this.Boton_generar_equipo.Location = new System.Drawing.Point(169, 89);
            this.Boton_generar_equipo.Name = "Boton_generar_equipo";
            this.Boton_generar_equipo.Size = new System.Drawing.Size(103, 23);
            this.Boton_generar_equipo.TabIndex = 1;
            this.Boton_generar_equipo.Text = "Generar Equipos";
            this.Boton_generar_equipo.UseVisualStyleBackColor = true;
            this.Boton_generar_equipo.Click += new System.EventHandler(this.Boton_generar_equipo_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Boton_generar_equipo);
            this.Controls.Add(this.Boton_buscar_jugador);
            this.Name = "FormularioPrincipal";
            this.Text = "FormularioPrincipal";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Boton_buscar_jugador;
        private System.Windows.Forms.Button Boton_generar_equipo;
        private System.Windows.Forms.Button button3;
    }
}