namespace ColasOficina
{
    public partial class PantallaPrincipal : Form
    {
        private int filasParaSimular;
        private int primeraFilaParaSimular;

        private double[] tasaLlegada;
        private double[] tasaAtenci�n;

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
            dgvSim.Columns.Add("Hora_Llegada_Consultor�a", "Hora Llegada (Consultor�a)");

            GenerarColumnasEventoFin();

            GenerarColumnasServidores();

            GenerarColumnasEstadisticas();

            GenerarColumnasClientes();
        }
        private void GenerarColumnasEventoFin()
        {
            dgvSim.Columns.Add("RND_Fin_Atencion", "RND Fin Atenci�n");
            dgvSim.Columns.Add("Tiempo_Atencion", "Tiempo Atenci�n");

            for (int i = 1; i <= 4; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Empleado_{i}", $"Fin Atenci�n Empleado {i}");
            }

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Arquitecto_{i}", $"Fin Atenci�n Arquitecto {i}");
            }

            for (int i = 1; i <= 3; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Inspector_{i}", $"Fin Atenci�n Inspector {i}");
            }

            for (int i = 1; i <= 2; i++)
            {
                dgvSim.Columns.Add($"Fin_Atencion_Consultor_{i}", $"Fin Atenci�n Consultor {i}");
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

            dgvSim.Columns.Add($"Cola_Consultor�a", $"Cola Consultor�a");
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
            dgvSim.Columns.Add("porcOcupaci�nPedidos", "Porcentaje Ocupaci�n (Pedidos)");

            dgvSim.Columns.Add("acumTiempoEsperaPlanos", "Acumulador Espera (Planos)");
            dgvSim.Columns.Add("acumPersonasColaPlanos", "Acumulador Cola (Planos)");
            dgvSim.Columns.Add("tiempoEsperaPromedioPlanos", "Tiempo Espera Promedio (Planos)");
            dgvSim.Columns.Add("tiempoOciosoPlanos", "Tiempo Ocioso (Planos)");
            dgvSim.Columns.Add("porcOcupaci�nPlanos", "Porcentaje Ocupaci�n (Planos)");

            dgvSim.Columns.Add("acumTiempoEsperaObras", "Acumulador Espera (Obras)");
            dgvSim.Columns.Add("acumPersonasColaObras", "Acumulador Cola (Obras)");
            dgvSim.Columns.Add("tiempoEsperaPromedioObras", "Tiempo espera promedio (Obras)");
            dgvSim.Columns.Add("tiempoOciosoObras", "Tiempo Ocioso (Obras)");
            dgvSim.Columns.Add("porcOcupaci�nObras", "Porcentaje Ocupaci�n (Obras)");

            dgvSim.Columns.Add("acumTiempoEsperaConsultoria", "Acumulador Espera (Consultor�a)");
            dgvSim.Columns.Add("acumPersonasColaConsultoria", "Acumulador Cola (Consultor�a)");
            dgvSim.Columns.Add("tiempoEsperaPromedioConsultoria", "Tiempo Espera Promedio (Consultor�a)");
            dgvSim.Columns.Add("tiempoOciosoConsultor�a", "Tiempo Ocioso (Consultor�a)");
            dgvSim.Columns.Add("porcOcupaci�nConsultor�a", "Porcentaje Ocupaci�n (Consultor�a)");

            dgvSim.Columns.Add("acumTiempoEsperaAn�lisis", "Acumulador Espera (An�lisis)");
            dgvSim.Columns.Add("acumPersonasColaAn�lisis", "Acumulador Cola (An�lisis)");
            dgvSim.Columns.Add("tiempoEsperaPromedioAn�lisis", "Tiempo Espera Promedio (An�lisis)");
            dgvSim.Columns.Add("tiempoOciosoAn�lisis", "Tiempo Ocioso (An�lisis)");
            dgvSim.Columns.Add("porcOcupaci�nAn�lisis", "Porcentaje Ocupaci�n (An�lisis)");


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
            tasaAtenci�n = new double[5] { (double)numFinPermisos.Value, (double)numFinPlanos.Value, (double)numFinObras.Value, (double)numFinNormativa.Value, (double)numFinSatisfacci�n.Value };
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
