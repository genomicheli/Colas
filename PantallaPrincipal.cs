namespace ColasOficina
{
    public partial class PantallaPrincipal : Form
    {
        private int filasParaSimular;
        private int primeraFilaParaSimular;

        private double[] tasaLlegada;
        private double[] tasaAtenci�n;
        private double tasaAtenci�nAnalista;

        private bool sonClientesImpacientes;
        private bool despidieronAlEmpleado;
        private bool hayParoInspectores;
        private bool verServicioMasUtilizado;

        private int contadorClientes;

        private Fila actual;
        private Fila anterior;
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

            //Evento: Fin Atenci�n Cliente
            dgvSim.Columns.Add("RND_Fin_Atencion", "RND Fin Atenci�n");
            dgvSim.Columns.Add("Tiempo_Atencion", "Tiempo Atenci�n");

            for (int i = 1; i <= determinarCantidadEmpleados(); i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Empleado_{i}", $"Fin Atenci�n Empleado {i}");
            }

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Arquitecto_{i}", $"Fin Atenci�n Arquitecto {i}");
            }

            if (!hayParoInspectores)
            {
                for (int i = 1; i <= 3; i++)
                {
                    dgvSim.Columns.Add($"Fin_Atencion_Inspector_{i}", $"Fin Atenci�n Inspector {i}");
                }
                dgvSim.Columns.Add("RND_Satisfacci�n", "RND Pasa a Satisfacci�n");
                dgvSim.Columns.Add("�Pasa?", "�Pasa?");
                dgvSim.Columns.Add("RND_Fin_Satisfacci�n", "RND Fin Satisfacci�n");
                dgvSim.Columns.Add("Tiempo_Atencion_2", "Tiempo Atenci�n");

                for (int i = 1; i <= 2; i++)
                {
                    dgvSim.Columns.Add($"Fin_Atencion_Analista_{i}", $"Fin Atenci�n Analista {i}");
                }
            }
            

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Consultor_{i}", $"Fin Atenci�n Consultor {i}");
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

            dgvSim.Columns.Add($"Cola_Consultor�a", $"Cola Consultor�a");
            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Estado_Consultor_{i}", $"Estado Consultor {i}");
            }

            if (!hayParoInspectores)
            {
                dgvSim.Columns.Add($"Cola_Analisis", $"Cola An�lisis");
                for (int i = 1; i <= 2; i++)
                {
                    dgvSim.Columns.Add($"Estado_Analista_{i}", $"Estado Analista {i}");
                }
            }
            

            // Estadisticas.

            string[] servicios = ["Pedidos", "Planos", "Obras", "Consultor�a", "An�lisis" ];
            string[] estadisticas = ["Acumulador Espera", "Acumulador Cola", "Tiempo Espera Promedio", "Tiempo Ocupado", "Porcentaje Ocupaci�n" ];

            foreach (string servicio in servicios)
            {
                foreach (string estadistica in estadisticas)
                {
                    string columnName = $"acum{estadistica.Replace(" ", "")}{servicio}";
                    string columnHeader = $"{estadistica} ({servicio})";
                    dgvSim.Columns.Add(columnName, columnHeader);
                }
            }
        }
        private void AsignarValores()
        {
            filasParaSimular = (int)numFilas.Value;
            primeraFilaParaSimular = (int)numPrimeraFila.Value;
            tasaLlegada = [(double)numLlegadaPermisos.Value, (double)numLlegadaPlanos.Value, (double)numLlegadaObras.Value, (double)numLlegadaNormativa.Value];
            tasaAtenci�n = [(double)numFinPermisos.Value, (double)numFinPlanos.Value, (double)numFinObras.Value, (double)numFinNormativa.Value];
            tasaAtenci�nAnalista = (double)numFinSatisfacci�n.Value;
            sonClientesImpacientes = checkImpaciente.Checked;
            despidieronAlEmpleado = checkDespedir.Checked;
            hayParoInspectores = checkParo.Checked;
            verServicioMasUtilizado = checkMas.Checked;
            contadorClientes = 0;
            actual = new Fila(determinarCantidadEmpleados(), hayParoInspectores);
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
            AsignarValores();
            GenerarColumnasTabla();
            Iniciar();
        }
        private void Iniciar()
        {
            for(int i = 1; i <= filasParaSimular; i++)
            {
                actual.limpiarValoresNoRecurrentes();
                if (i == 1)
                {
                    actual.generarProximaLlegada(tasaLlegada);
                    
                }
                else
                {
                    actual.determinarProximoEvento(anterior, sonClientesImpacientes, hayParoInspectores, tasaLlegada, tasaAtenci�n, tasaAtenci�nAnalista);
                }
                anterior = actual;
                AgregarColumnasClientes(actual); 
                dgvSim.Rows.Add(actual.ConvertirAFila(hayParoInspectores));
            }
        }
        private void AgregarColumnasClientes(Fila fila)
        {
            if (fila.hayNuevosClientes(contadorClientes))
            {
                contadorClientes++;
                dgvSim.Columns.Add($"Estado_cliente_{contadorClientes}", $"Estado Cliente {contadorClientes}");
                dgvSim.Columns.Add($"Hora_Llegada_Cliente_{contadorClientes}", "Hora Llegada");
                dgvSim.Columns.Add($"Servicio_Cliente_{contadorClientes}", "Servicio");
                dgvSim.Columns.Add($"Numero_Servidor_{contadorClientes}", "Numero Servidor");
            }
        }
        private int determinarCantidadEmpleados()
        {
            return despidieronAlEmpleado? 3 : 4;
        }
        private void UpdateExplanationText()
        {
            // Lista para almacenar las explicaciones seleccionadas
            List<string> explanations = [];

            // Verificar cada checkbox y agregar la explicaci�n correspondiente si est� chequeado
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
                explanations.Add("se calcular� que servicio es el m�s utilizado");
            }
            if (checkParo.Checked)
            {
                explanations.Add("los inspectores no trabajaran");
            }

            // Construir la explicaci�n final
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
                // Combinar todas las explicaciones con comas y una "y" antes del �ltimo elemento
                string combinedExplanations = string.Join(",\n", explanations.Take(explanations.Count - 1)) + " \ny " + explanations.Last();
                finalExplanation = CapitalizeFirstLetter(combinedExplanations);
            }

            // Actualizar el texto del label
            txtExplicaci�n.Text = finalExplanation;

            AdjustLabelToCenter(txtExplicaci�n, groupBox1);
        }
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
            // Ajustar el tama�o del label al contenido
            label.AutoSize = true;

            // Obtener el tama�o del label despu�s de ajustar el texto
            label.Size = new Size(label.PreferredWidth, label.PreferredHeight);

            // Calcular las nuevas coordenadas para centrar el label dentro del groupBox
            int newX = (groupBox.Width - label.Width) / 2;
            int newY = (groupBox.Height - label.Height) / 2 + 4;

            // Establecer la nueva ubicaci�n del label
            label.Location = new Point(newX, newY);
        }
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
