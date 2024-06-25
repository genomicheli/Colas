namespace ColasOficina
{
    partial class PantallaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            groupBox2 = new GroupBox();
            numFinSatisfacción = new NumericUpDown();
            label3 = new Label();
            label1 = new Label();
            label7 = new Label();
            numFinPlanos = new NumericUpDown();
            label10 = new Label();
            numFinObras = new NumericUpDown();
            label9 = new Label();
            numFinNormativa = new NumericUpDown();
            label8 = new Label();
            numLlegadaPlanos = new NumericUpDown();
            label14 = new Label();
            numLlegadaObras = new NumericUpDown();
            label13 = new Label();
            numLlegadaNormativa = new NumericUpDown();
            label12 = new Label();
            numFinPermisos = new NumericUpDown();
            label11 = new Label();
            numLlegadaPermisos = new NumericUpDown();
            label6 = new Label();
            btnSimular = new Button();
            groupBox3 = new GroupBox();
            checkMas = new CheckBox();
            checkParo = new CheckBox();
            checkImpaciente = new CheckBox();
            checkDespedir = new CheckBox();
            label16 = new Label();
            numFilas = new NumericUpDown();
            label15 = new Label();
            numPrimeraFila = new NumericUpDown();
            dgvSim = new DataGridView();
            txtExplicación = new Label();
            groupBox1 = new GroupBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFinSatisfacción).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFinPlanos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFinObras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFinNormativa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaPlanos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaObras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaNormativa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFinPermisos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaPermisos).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFilas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrimeraFila).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSim).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(570, 232);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numFinSatisfacción);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(numFinPlanos);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(numFinObras);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(numFinNormativa);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(numLlegadaPlanos);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(numLlegadaObras);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(numLlegadaNormativa);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(numFinPermisos);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(numLlegadaPermisos);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(14, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1210, 191);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Eventos";
            // 
            // numFinSatisfacción
            // 
            numFinSatisfacción.Location = new Point(987, 132);
            numFinSatisfacción.Name = "numFinSatisfacción";
            numFinSatisfacción.Size = new Size(92, 23);
            numFinSatisfacción.TabIndex = 23;
            numFinSatisfacción.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(890, 129);
            label3.Name = "label3";
            label3.Size = new Size(91, 30);
            label3.TabIndex = 22;
            label3.Text = "fin_atención_\r\nsatisfacción";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.MediumTurquoise;
            label1.Location = new Point(62, 137);
            label1.Name = "label1";
            label1.Size = new Size(817, 15);
            label1.TabIndex = 26;
            label1.Text = "Se ha creado una oficina de analisis de satisfacción porque la gente se queja mucho de los empleados de inspección de obras. \r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.MediumTurquoise;
            label7.Location = new Point(183, 36);
            label7.Name = "label7";
            label7.Size = new Size(772, 15);
            label7.TabIndex = 4;
            label7.Text = "TODOS los eventos responden a una distribución exponencial negativa, con parámetro lambda, medido en clientes/hora.\r\n";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numFinPlanos
            // 
            numFinPlanos.Location = new Point(470, 95);
            numFinPlanos.Name = "numFinPlanos";
            numFinPlanos.Size = new Size(92, 23);
            numFinPlanos.TabIndex = 25;
            numFinPlanos.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(332, 99);
            label10.Name = "label10";
            label10.Size = new Size(133, 15);
            label10.TabIndex = 24;
            label10.Text = "fin_atención_planos";
            // 
            // numFinObras
            // 
            numFinObras.Location = new Point(716, 95);
            numFinObras.Name = "numFinObras";
            numFinObras.Size = new Size(92, 23);
            numFinObras.TabIndex = 23;
            numFinObras.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(584, 99);
            label9.Name = "label9";
            label9.Size = new Size(127, 15);
            label9.TabIndex = 22;
            label9.Text = "fin_atención_obras";
            // 
            // numFinNormativa
            // 
            numFinNormativa.Location = new Point(987, 93);
            numFinNormativa.Name = "numFinNormativa";
            numFinNormativa.Size = new Size(92, 23);
            numFinNormativa.TabIndex = 21;
            numFinNormativa.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(829, 97);
            label8.Name = "label8";
            label8.Size = new Size(153, 15);
            label8.TabIndex = 20;
            label8.Text = "fin_atención_normativa";
            // 
            // numLlegadaPlanos
            // 
            numLlegadaPlanos.Location = new Point(470, 60);
            numLlegadaPlanos.Name = "numLlegadaPlanos";
            numLlegadaPlanos.Size = new Size(92, 23);
            numLlegadaPlanos.TabIndex = 17;
            numLlegadaPlanos.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(318, 64);
            label14.Name = "label14";
            label14.Size = new Size(146, 15);
            label14.TabIndex = 16;
            label14.Text = "llegada_cliente_planos";
            // 
            // numLlegadaObras
            // 
            numLlegadaObras.Location = new Point(716, 60);
            numLlegadaObras.Name = "numLlegadaObras";
            numLlegadaObras.Size = new Size(92, 23);
            numLlegadaObras.TabIndex = 15;
            numLlegadaObras.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(570, 64);
            label13.Name = "label13";
            label13.Size = new Size(140, 15);
            label13.TabIndex = 14;
            label13.Text = "llegada_cliente_obras";
            // 
            // numLlegadaNormativa
            // 
            numLlegadaNormativa.Location = new Point(987, 60);
            numLlegadaNormativa.Name = "numLlegadaNormativa";
            numLlegadaNormativa.Size = new Size(92, 23);
            numLlegadaNormativa.TabIndex = 13;
            numLlegadaNormativa.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(815, 64);
            label12.Name = "label12";
            label12.Size = new Size(166, 15);
            label12.TabIndex = 12;
            label12.Text = "llegada_cliente_normativa";
            // 
            // numFinPermisos
            // 
            numFinPermisos.Location = new Point(220, 93);
            numFinPermisos.Name = "numFinPermisos";
            numFinPermisos.Size = new Size(92, 23);
            numFinPermisos.TabIndex = 11;
            numFinPermisos.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(66, 97);
            label11.Name = "label11";
            label11.Size = new Size(149, 15);
            label11.TabIndex = 10;
            label11.Text = "fin_atención_permisos";
            // 
            // numLlegadaPermisos
            // 
            numLlegadaPermisos.Location = new Point(220, 60);
            numLlegadaPermisos.Name = "numLlegadaPermisos";
            numLlegadaPermisos.Size = new Size(92, 23);
            numLlegadaPermisos.TabIndex = 1;
            numLlegadaPermisos.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 64);
            label6.Name = "label6";
            label6.Size = new Size(162, 15);
            label6.TabIndex = 0;
            label6.Text = "llegada_cliente_permisos";
            // 
            // btnSimular
            // 
            btnSimular.BackColor = Color.MediumTurquoise;
            btnSimular.Location = new Point(1665, 118);
            btnSimular.Name = "btnSimular";
            btnSimular.Size = new Size(226, 83);
            btnSimular.TabIndex = 4;
            btnSimular.Text = "Simular";
            btnSimular.UseVisualStyleBackColor = false;
            btnSimular.Click += btnSimular_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkMas);
            groupBox3.Controls.Add(checkParo);
            groupBox3.Controls.Add(checkImpaciente);
            groupBox3.Controls.Add(checkDespedir);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(numFilas);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(numPrimeraFila);
            groupBox3.Location = new Point(1230, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(660, 101);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Parámetros de simulación";
            // 
            // checkMas
            // 
            checkMas.AutoSize = true;
            checkMas.Location = new Point(491, 65);
            checkMas.Name = "checkMas";
            checkMas.Size = new Size(165, 19);
            checkMas.TabIndex = 13;
            checkMas.Text = "Servicio mas utilizado";
            checkMas.UseVisualStyleBackColor = true;
            checkMas.CheckedChanged += checkMas_CheckedChanged;
            // 
            // checkParo
            // 
            checkParo.AutoSize = true;
            checkParo.Location = new Point(329, 65);
            checkParo.Name = "checkParo";
            checkParo.Size = new Size(156, 19);
            checkParo.TabIndex = 12;
            checkParo.Text = "Paro de inspectores\r\n";
            checkParo.UseVisualStyleBackColor = true;
            checkParo.CheckedChanged += checkParo_CheckedChanged;
            // 
            // checkImpaciente
            // 
            checkImpaciente.AutoSize = true;
            checkImpaciente.Location = new Point(5, 65);
            checkImpaciente.Name = "checkImpaciente";
            checkImpaciente.Size = new Size(160, 19);
            checkImpaciente.TabIndex = 11;
            checkImpaciente.Text = "Clientes impacientes\r\n";
            checkImpaciente.UseVisualStyleBackColor = true;
            checkImpaciente.CheckedChanged += checkImpaciente_CheckedChanged;
            // 
            // checkDespedir
            // 
            checkDespedir.AutoSize = true;
            checkDespedir.Font = new Font("Lucida Bright", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkDespedir.Location = new Point(171, 65);
            checkDespedir.Name = "checkDespedir";
            checkDespedir.Size = new Size(152, 19);
            checkDespedir.TabIndex = 10;
            checkDespedir.Text = "Despedir empleado";
            checkDespedir.UseVisualStyleBackColor = true;
            checkDespedir.CheckedChanged += checkDespedir_CheckedChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(313, 30);
            label16.Name = "label16";
            label16.Size = new Size(140, 15);
            label16.TabIndex = 8;
            label16.Text = "Primera fila a mostrar";
            // 
            // numFilas
            // 
            numFilas.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            numFilas.Location = new Point(214, 27);
            numFilas.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numFilas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFilas.Name = "numFilas";
            numFilas.Size = new Size(88, 23);
            numFilas.TabIndex = 7;
            numFilas.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numFilas.ValueChanged += numFilas_ValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(94, 30);
            label15.Name = "label15";
            label15.Size = new Size(113, 15);
            label15.TabIndex = 6;
            label15.Text = "Filas para simular";
            // 
            // numPrimeraFila
            // 
            numPrimeraFila.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            numPrimeraFila.Location = new Point(459, 27);
            numPrimeraFila.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrimeraFila.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPrimeraFila.Name = "numPrimeraFila";
            numPrimeraFila.Size = new Size(88, 23);
            numPrimeraFila.TabIndex = 9;
            numPrimeraFila.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dgvSim
            // 
            dgvSim.AllowUserToAddRows = false;
            dgvSim.AllowUserToDeleteRows = false;
            dgvSim.AllowUserToResizeColumns = false;
            dgvSim.AllowUserToResizeRows = false;
            dgvSim.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSim.Location = new Point(14, 207);
            dgvSim.Name = "dgvSim";
            dgvSim.RowHeadersVisible = false;
            dgvSim.RowHeadersWidth = 51;
            dgvSim.Size = new Size(1876, 754);
            dgvSim.TabIndex = 6;
            // 
            // txtExplicación
            // 
            txtExplicación.AutoSize = true;
            txtExplicación.ForeColor = Color.MediumTurquoise;
            txtExplicación.Location = new Point(10, 25);
            txtExplicación.Name = "txtExplicación";
            txtExplicación.Size = new Size(7, 30);
            txtExplicación.TabIndex = 7;
            txtExplicación.Text = "\r\n\r\n";
            txtExplicación.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtExplicación);
            groupBox1.Location = new Point(1230, 113);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(429, 88);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Explicación";
            // 
            // PantallaPrincipal
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.IndianRed;
            ClientSize = new Size(1902, 973);
            Controls.Add(groupBox1);
            Controls.Add(btnSimular);
            Controls.Add(dgvSim);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label2);
            Font = new Font("Lucida Bright", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "PantallaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oficina de construcción";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFinSatisfacción).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFinPlanos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFinObras).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFinNormativa).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaPlanos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaObras).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaNormativa).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFinPermisos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLlegadaPermisos).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFilas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrimeraFila).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSim).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private GroupBox groupBox2;
        private NumericUpDown numLlegadaPlanos;
        private Label label14;
        private NumericUpDown numLlegadaObras;
        private Label label13;
        private NumericUpDown numLlegadaNormativa;
        private Label label12;
        private NumericUpDown numFinPermisos;
        private Label label11;
        private NumericUpDown numLlegadaPermisos;
        private Label label6;
        private NumericUpDown numFinPlanos;
        private Label label10;
        private NumericUpDown numFinObras;
        private Label label9;
        private NumericUpDown numFinNormativa;
        private Label label8;
        private Label label7;
        private Button btnSimular;
        private GroupBox groupBox3;
        private Label label15;
        private NumericUpDown numFilas;
        private NumericUpDown numPrimeraFila;
        private Label label16;
        private DataGridView dgvSim;
        private CheckBox checkDespedir;
        private CheckBox checkImpaciente;
        private Label label1;
        private NumericUpDown numFinSatisfacción;
        private Label label3;
        private CheckBox checkParo;
        private CheckBox checkMas;
        private Label txtExplicación;
        private GroupBox groupBox1;
    }
}
