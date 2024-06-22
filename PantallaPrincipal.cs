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
            dgvSim.Columns.Add("RND_Llegada", "RND Llegada");
            dgvSim.Columns.Add("Tiempo_Hasta_Llegada", "Tiempo hasta llegada");
            dgvSim.Columns.Add("Hora_Llegada_Pedidos", "Hora Llegada (Pedidos)");
            dgvSim.Columns.Add("Hora_Llegada_Planos", "Hora Llegada (Planos)");
            dgvSim.Columns.Add("Hora_Llegada_Obras", "Hora Llegada (Obras)");
            dgvSim.Columns.Add("Hora_Llegada_Consultoría", "Hora Llegada (Consultoría)");

            GenerarColumnasEventoFin();

            GenerarColumnasServidores();

            GenerarColumnasEstadisticas();

            GenerarColumnasClientes();
        }
        private void GenerarColumnasEventoFin()
        {
            dgvSim.Columns.Add("RND_Fin_Atencion", "RND Fin Atención");
            dgvSim.Columns.Add("Tiempo_Atencion", "Tiempo Atención");

            for (int i = 1; i <= 4; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Empleado_{i}", $"Fin Atención Empleado {i}");
            }

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Arquitecto_{i}", $"Fin Atención Arquitecto {i}");
            }

            for (int i = 1; i <= 3; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Inspector_{i}", $"Fin Atención Inspector {i}");
            }

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Consultor_{i}", $"Fin Atención Consultor {i}");
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
        private void GenerarColumnasServidores()
        {
            dgvSim.Columns.Add($"Cola_Permisos", $"Cola Permisos");
            for (int i = 1; i <= 4; i++)
            {
                dgvSim.Columns.Add($"Estado_Empleado_{i}", $"Estado Empleado {i}");
            }

            dgvSim.Columns.Add($"Cola_Planos", $"Cola Planos");
            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Estado_Arquitecto_{i}", $"Estado Arquitecto {i}");

            }
            dgvSim.Columns.Add($"Cola_Obras", $"Cola Obras");
            for (int i = 1; i <= 3; i++)
            {
                dgvSim.Columns.Add($"Estado_Inspector_{i}", $"Estado Inspector {i}");
            }

            dgvSim.Columns.Add($"Cola_Consultoría", $"Cola Consultoría");
            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Estado_Consultor_{i}", $"Estado Consultor {i}");
            }
        }
        private void GenerarColumnasEstadisticas()
        {
            dgvSim.Columns.Add("acumTiempoEsperaPedidos", "Acumulador Espera (Pedidos)");
            dgvSim.Columns.Add("acumPersonasColaPedidos", "Acumulador Cola (Pedidos)");
            dgvSim.Columns.Add("tiempoEsperaPromedioPedidos", "Tiempo Espera Promedio (Pedidos)");
            dgvSim.Columns.Add("tiempoOciosoPedidos", "Tiempo Ocioso (Pedidos)");
            dgvSim.Columns.Add("porcOcupaciónPedidos", "Porcentaje Ocupación (Pedidos)");

            dgvSim.Columns.Add("acumTiempoEsperaPlanos", "Acumulador Espera (Planos)");
            dgvSim.Columns.Add("acumPersonasColaPlanos", "Acumulador Cola (Planos)");
            dgvSim.Columns.Add("tiempoEsperaPromedioPlanos", "Tiempo Espera Promedio (Planos)");
            dgvSim.Columns.Add("tiempoOciosoPlanos", "Tiempo Ocioso (Planos)");
            dgvSim.Columns.Add("porcOcupaciónPlanos", "Porcentaje Ocupación (Planos)");

            dgvSim.Columns.Add("acumTiempoEsperaObras", "Acumulador Espera (Obras)");
            dgvSim.Columns.Add("acumPersonasColaObras", "Acumulador Cola (Obras)");
            dgvSim.Columns.Add("tiempoEsperaPromedioObras", "Tiempo espera promedio (Obras)");
            dgvSim.Columns.Add("tiempoOciosoObras", "Tiempo Ocioso (Obras)");
            dgvSim.Columns.Add("porcOcupaciónObras", "Porcentaje Ocupación (Obras)");

            dgvSim.Columns.Add("acumTiempoEsperaConsultoria", "Acumulador Espera (Consultoría)");
            dgvSim.Columns.Add("acumPersonasColaConsultoria", "Acumulador Cola (Consultoría)");
            dgvSim.Columns.Add("tiempoEsperaPromedioConsultoria", "Tiempo Espera Promedio (Consultoría)");
            dgvSim.Columns.Add("tiempoOciosoConsultoría", "Tiempo Ocioso (Consultoría)");
            dgvSim.Columns.Add("porcOcupaciónConsultoría", "Porcentaje Ocupación (Consultoría)");

            dgvSim.Columns.Add("acumTiempoEsperaAnálisis", "Acumulador Espera (Análisis)");
            dgvSim.Columns.Add("acumPersonasColaAnálisis", "Acumulador Cola (Análisis)");
            dgvSim.Columns.Add("tiempoEsperaPromedioAnálisis", "Tiempo Espera Promedio (Análisis)");
            dgvSim.Columns.Add("tiempoOciosoAnálisis", "Tiempo Ocioso (Análisis)");
            dgvSim.Columns.Add("porcOcupaciónAnálisis", "Porcentaje Ocupación (Análisis)");


        }
        private void GenerarColumnasClientes()
        {
            for (int i = 1; i <= 10; i++)
            {
                dgvSim.Columns.Add($"Estado_Cliente_{i}", $"Estado Cliente {i}");
                dgvSim.Columns.Add($"Hora_Llegada_Cliente{i}", $"Hora Llegada");
            }
        }
        private void AsignarValores()
        {
            filasParaSimular = (int)numFilas.Value;
            primeraFilaParaSimular = (int)numPrimeraFila.Value;
            tasaLlegada = new double[4] { (double)numLlegadaPermisos.Value, (double)numLlegadaPlanos.Value, (double)numLlegadaObras.Value, (double)numLlegadaNormativa.Value };
            tasaAtención = new double[5] { (double)numFinPermisos.Value, (double)numFinPlanos.Value, (double)numFinObras.Value, (double)numFinNormativa.Value, (double)numFinSatisfacción.Value };
            sonClientesImpacientes = checkImpaciente.Checked;
            despidieronAlEmpleado = checkDespedir.Checked;
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
            AsignarValores();
            GenerarColumnasTabla();
        }

       

        




    }
}
