namespace ColasOficina
{
    public partial class PantallaPrincipal : Form
    {
        private int filasParaSimular;
        private int primeraFilaParaSimular;

        private double[] tasaLlegada;
        private double[] tasaAtención;

        private bool sonClientesImpacientes;
        private bool despidieronAlEmpleado;
        private bool hayParoInspectores;
        private bool verServicioMasUtilizado;
        public PantallaPrincipal()
        {
            InitializeComponent();
        }
        private void numFilas_ValueChanged(object sender, EventArgs e)
        {
            numPrimeraFila.Maximum = (int)numFilas.Value;
        }
        public void GenerarColumnasTabla()
        {
            dgvSim.Columns.Clear();

            // Evento y Reloj.
            dgvSim.Columns.Add("Evento", "Evento");
            dgvSim.Columns.Add("Reloj", "Reloj");

            // Evento: Llegadas de clientes.
            dgvSim.Columns.Add("RND_Servicio", "RND Servicio");
            dgvSim.Columns.Add("Servicio", "Servicio");
            dgvSim.Columns.Add("RND_Llegada", "RND Llegada");
            dgvSim.Columns.Add("Tiempo_Hasta_Llegada", "Tiempo hasta llegada");
            dgvSim.Columns.Add("Hora_Llegada_Pedidos", "Hora Llegada");

            //Evento: Fin Atención Cliente
            dgvSim.Columns.Add("RND_Fin_Atencion", "RND Fin Atención");
            dgvSim.Columns.Add("Tiempo_Atencion", "Tiempo Atención");

            for (int i = 1; i <= determinarCantidadEmpleados(); i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Empleado_{i}", $"Fin Atención Empleado {i}");
            }

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Arquitecto_{i}", $"Fin Atención Arquitecto {i}");
            }

            if (!hayParoInspectores)
            {
                for (int i = 1; i <= 3; i++)
                {
                    dgvSim.Columns.Add($"Fin_Atencion_Inspector_{i}", $"Fin Atención Inspector {i}");
                }
                dgvSim.Columns.Add("RND_Satisfacción", "RND Pasa a Satisfacción");
                dgvSim.Columns.Add("¿Pasa?", "¿Pasa?");
                dgvSim.Columns.Add("RND_Fin_Satisfacción", "RND Fin Satisfacción");
                dgvSim.Columns.Add("Tiempo_Atencion_2", "Tiempo Atención");

                for (int i = 1; i <= 2; i++)
                {
                    dgvSim.Columns.Add($"Fin_Atencion_Analista_{i}", $"Fin Atención Analista {i}");
                }
            }
            

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Consultor_{i}", $"Fin Atención Consultor {i}");
            }

            

            dgvSim.Columns.Add($"Cola_Permisos", $"Cola Permisos");
            for (int i = 1; i <= determinarCantidadEmpleados(); i++)
            {
                dgvSim.Columns.Add($"Estado_Empleado_{i}", $"Estado Empleado {i}");
            }

            dgvSim.Columns.Add($"Cola_Planos", $"Cola Planos");
            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Estado_Arquitecto_{i}", $"Estado Arquitecto {i}");

            }
            if (!hayParoInspectores)
            {
                dgvSim.Columns.Add($"Cola_Obras", $"Cola Obras");
                for (int i = 1; i <= 3; i++)
                {
                    dgvSim.Columns.Add($"Estado_Inspector_{i}", $"Estado Inspector {i}");
                }
            }
            dgvSim.Columns.Add($"Cola_Consultoría", $"Cola Consultoría");
            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Estado_Consultor_{i}", $"Estado Consultor {i}");
            }

            // Estadisticas.

            string[] servicios = ["Pedidos", "Planos", "Obras", "Consultoría", "Análisis" ];
            string[] estadisticas = ["Acumulador Espera", "Acumulador Cola", "Tiempo Espera Promedio", "Tiempo Ocupado", "Porcentaje Ocupación" ];

            foreach (string servicio in servicios)
            {
                foreach (string estadistica in estadisticas)
                {
                    string columnName = $"acum{estadistica.Replace(" ", "")}{servicio}";
                    string columnHeader = $"{estadistica} ({servicio})";
                    dgvSim.Columns.Add(columnName, columnHeader);
                }
            }

            // Clientes.

            for (int i = 1; i <= 20; i++)
            {
                dgvSim.Columns.Add($"Estado_Cliente_{i}", $"Estado Cliente {i}");
                dgvSim.Columns.Add($"Hora_Llegada_Cliente{i}", $"Hora Llegada");
                dgvSim.Columns.Add($"Tipo_Servidor_Cliente{i}", $"Tipo Servidor");
                dgvSim.Columns.Add($"Numero_Servidor_Cliente{i}", $"Numero Servidor");
            }

        }
        private void AsignarValores()
        {
            filasParaSimular = (int)numFilas.Value;
            primeraFilaParaSimular = (int)numPrimeraFila.Value;
            tasaLlegada = [(double)numLlegadaPermisos.Value, (double)numLlegadaPlanos.Value, (double)numLlegadaObras.Value, (double)numLlegadaNormativa.Value];
            tasaAtención = [(double)numFinPermisos.Value, (double)numFinPlanos.Value, (double)numFinObras.Value, (double)numFinNormativa.Value, (double)numFinSatisfacción.Value];
            sonClientesImpacientes = checkImpaciente.Checked;
            despidieronAlEmpleado = checkDespedir.Checked;
            hayParoInspectores = checkParo.Checked;
            verServicioMasUtilizado = checkMas.Checked;
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
            AsignarValores();
            GenerarColumnasTabla();
        }

        private int determinarCantidadEmpleados()
        {
            return despidieronAlEmpleado? 3 : 4;
        }

        private void UpdateExplanationText()
        {
            // Lista para almacenar las explicaciones seleccionadas
            List<string> explanations = [];

            // Verificar cada checkbox y agregar la explicación correspondiente si está chequeado
            if (checkDespedir.Checked)
            {
                explanations.Add("se despedira un empleado");
            }
            if (checkImpaciente.Checked)
            {
                explanations.Add("los clientes se iran si hay mas de 3 clientes en cola");
            }
            if (checkMas.Checked)
            {
                explanations.Add("se calculará que servicio es el más utilizado");
            }
            if (checkParo.Checked)
            {
                explanations.Add("los inspectores no trabajaran");
            }

            // Construir la explicación final
            string finalExplanation;
            if (explanations.Count == 0)
            {
                finalExplanation = string.Empty;
            }
            else if (explanations.Count == 1)
            {
                finalExplanation = CapitalizeFirstLetter(explanations[0]);
            }
            else
            {
                // Combinar todas las explicaciones con comas y una "y" antes del último elemento
                string combinedExplanations = string.Join(",\n", explanations.Take(explanations.Count - 1)) + " \ny " + explanations.Last();
                finalExplanation = CapitalizeFirstLetter(combinedExplanations);
            }

            // Actualizar el texto del label
            txtExplicación.Text = finalExplanation;

            AdjustLabelToCenter(txtExplicación, groupBox1);
        }

        // Método para capitalizar la primera letra de una oración
        private static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            return char.ToUpper(text[0]) + text.Substring(1);
        }

        private static void AdjustLabelToCenter(Label label, GroupBox groupBox)
        {
            // Ajustar el tamaño del label al contenido
            label.AutoSize = true;

            // Obtener el tamaño del label después de ajustar el texto
            label.Size = new Size(label.PreferredWidth, label.PreferredHeight);

            // Calcular las nuevas coordenadas para centrar el label dentro del groupBox
            int newX = (groupBox.Width - label.Width) / 2;
            int newY = (groupBox.Height - label.Height) / 2 + 4;

            // Establecer la nueva ubicación del label
            label.Location = new Point(newX, newY);
        }

        // Llamar a este método en el evento CheckedChanged de cada checkbox
        private void checkDespedir_CheckedChanged(object sender, EventArgs e)
        {
            UpdateExplanationText();
        }

        private void checkImpaciente_CheckedChanged(object sender, EventArgs e)
        {
            UpdateExplanationText();
        }

        private void checkMas_CheckedChanged(object sender, EventArgs e)
        {
            UpdateExplanationText();
        }

        private void checkParo_CheckedChanged(object sender, EventArgs e)
        {
            UpdateExplanationText();
        }








    }
}
