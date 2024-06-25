using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColasOficina
{
    public class Fila
    {

        public Fila(int cantidadEmpleados, bool hayParoDeInspectores)
        {
            horaFinAtenciónPermisos = new double[cantidadEmpleados];
            estadoEmpleados = Enumerable.Repeat("Libre", cantidadEmpleados).ToArray();
            estadoArquitectos = Enumerable.Repeat("Libre", 2).ToArray();
            if (hayParoDeInspectores)
            {
                estadosInspectores = [];
                horaFinAtenciónObras = [];
            }
            else
            {
                estadosInspectores = Enumerable.Repeat("Libre", 3).ToArray();
            }
            estadosConsultores = Enumerable.Repeat("Libre", 2).ToArray();
            estadosAnalistas = Enumerable.Repeat("Libre", 2).ToArray();
            rndServicio = 0;
            servicio = "";
            rndLlegada = 0;
            tiempoHastaLlegada = 0;
            horaLlegada = 0;

        }
        // Atributos privados.

        private string[] servicios = ["Permisos", "Planos", "Obras", "Consultoría", "Análisis"];
        private double tasaElegida;
        private bool enLaCola;
        private int numeroServidor;
        private Random generador = new();

        // Evento y reloj.
        public string evento { get; private set; }
        public double reloj { get; private set; }

        // Evento llegada_cliente.
        public double rndServicio { get; private set; }
        public string servicio { get; private set; }
        public double rndLlegada { get; private set; }
        public double tiempoHastaLlegada { get; private set; }
        public double horaLlegada { get; private set; }

        // Evento fin_atención.
        public double rndFinAtención { get; private set; }
        public double tiempoDeAtención { get; private set; }
        public double[] horaFinAtenciónPermisos { get; private set; }
        public double[] horaFinAtenciónPlanos { get; private set; } = new double[2];
        public double[] horaFinAtenciónObras { get; private set; } = new double[3];
        public double[] horaFinAtenciónConsultoría { get; private set; } = new double[2];
        public double rndAnálisis { get; private set; }
        public string decisionCliente { get; private set; }
        public double rndFinAtenciónAnálisis { get; private set; }
        public double tiempoDeAtenciónAnálisis { get; private set; }
        public double[] horaFinAtenciónAnálisis { get; private set; } = new double[2];
        public int[] colasServicios { get; private set; } = new int[5];
        public string[] estadoEmpleados { get; private set; }
        public string[] estadoArquitectos { get; private set; } = new string[2];
        public string[] estadosInspectores { get; private set; } = new string[3];
        public string[] estadosConsultores { get; private set; } = new string[2];
        public string[] estadosAnalistas { get; private set; } = new string[2];
        public double[] acumuladoresTiempoEspera { get; private set; } = new double[5];
        public int[] acumuladorColasServicio { get; private set; } = new int[5];
        public double[] tiempoEsperaPromedio { get; private set; } = new double[5];
        public double[] tiempoOcupadoServicio { get; private set; } = new double[5];
        public double[] porcentajeOcupaciónServicio { get; private set; } = new double[5];
        public List<Cliente> clientes { get; private set; } = [];

        // Esta función devuelve un servicio de la lista 'servicios'.
        public string ObtenerServicio(double numeroAleatorio)
        {
            int indice = (int)(numeroAleatorio * (servicios.Length - 1));
            return servicios[indice];
        }

        // Esta función elige el servicio del proximo cliente que llegará al sistema de colas.
        public void determinarServicioProximaLlegada(double[] tasasLlegada)
        {
            rndServicio = Math.Round(generador.NextDouble(), 4); // Genera un número aleatorio entre 0 y 1
            servicio = ObtenerServicio(rndServicio); // Obtiene el servicio correspondiente al número aleatorio generado
            int indexTasa = determinarIndiceServicio(servicio); // Determina el índice de la tasa de llegada para ese servicio
            tasaElegida = tasasLlegada[indexTasa]; // Selecciona la tasa de llegada correspondiente al servicio elegido
        }

        // Esta función genera el tiempo de la próxima llegada de un servicio.
        public void generarProximaLlegada(double[] tasasLlegada)
        {
            determinarServicioProximaLlegada(tasasLlegada); // Determina el próximo servicio que llegará
            this.rndLlegada = Math.Round(generador.NextDouble(), 4); // Genera un número aleatorio para el cálculo del tiempo de llegada
            tiempoHastaLlegada = Math.Round(expNeg(rndLlegada), 4); // Calcula el tiempo hasta la próxima llegada usando una distribución exponencial
            horaLlegada = Math.Round(reloj + tiempoHastaLlegada, 4); // Establece la hora de llegada sumando el tiempo de llegada al reloj actual
        }

        // Esta función simula la llegada de un cliente al sistema de colas.
        public void llegada_cliente(bool hayclientesImpacientes, bool hayParoDeInspectores, double[] tasasLlegada, double[] tasaFin)
        {
            // Comprueba si hay un paro de inspectores en el servicio de "Obras"
            if (servicio == "Obras" && hayParoDeInspectores)
            {
                generarProximaLlegada(tasasLlegada); // Genera la próxima llegada si hay un paro de inspectores en "Obras"
                return; // Sale de la función
            }

            // Verifica la disponibilidad de servidores para el servicio actual
            averiguarDisponibilidadServidores(hayclientesImpacientes, this.servicio);
            int indiceClienteLibre = BuscarClientesQueSeFueron();
            // Si no hay clientes en la cola, se genera el fin de la atención para el cliente actual
            if (!enLaCola)
            {
                generarFinAtención(numeroServidor, this.servicio, tasaFin);
                
                if(indiceClienteLibre == -1)
                {
                    clientes.Add(new Cliente("SA", null, servicio, numeroServidor));
                }
                else
                {
                    clientes[indiceClienteLibre] = new Cliente("SA", null, servicio, numeroServidor);
                }
            }
            else
            {
                if(indiceClienteLibre == -1)
                {
                    clientes.Add(new Cliente("EA", horaLlegada, servicio, null));
                }
                else
                {
                    clientes[indiceClienteLibre] = new Cliente("EA", horaLlegada, servicio, null);
                }
                
            }
            // Genera la próxima llegada de un cliente al sistema
            generarProximaLlegada(tasasLlegada);
        }

        public int BuscarClientesQueSeFueron()
        {
            foreach (var item in clientes)
            {
                if (item == null)
                {
                    return clientes.IndexOf(item);
                }
            }
            return -1;
        }

        // Esta función determina el índice de un servicio dado en un arreglo de servicios, devuelve -1 si no se encuentra.
        public int determinarIndiceServicio(string servicio)
        {
            for (int i = 0; i < servicios.Length; i++)
            {
                if (servicios[i] == servicio)
                {
                    return i;
                }
            }
            return -1;
        }

        // Esta función marca como "Libre" el estado de un servidor de un servicio dado.
        public void liberarServidor(string servicio, int numeroServidor)
        {
            var estadosPorServicio = new Dictionary<string, string[]>
            {
                { servicios[0], estadoEmpleados },
                { servicios[1], estadoArquitectos },
                { servicios[2], estadosInspectores },
                { servicios[3], estadosConsultores },
                { servicios[4], estadosAnalistas }
            };

            if (estadosPorServicio.TryGetValue(servicio, out string[]? value))
            {
                value[numeroServidor - 1] = "Libre";
            }
        }

        // Genera el tiempo de finalización de atención para un servidor en un servicio específico.
        public void generarFinAtención(int numeroServidor, string servicio, double[] tasaFin)
        {
            int tasaIndex = determinarIndiceServicio(servicio);
            tasaElegida = tasaFin[tasaIndex];
            rndFinAtención = Math.Round(generador.NextDouble(), 4);
            tiempoDeAtención = Math.Round(expNeg(rndFinAtención), 4);
            double[] horasFinAtenciónServicio = obtenerHorasFinServicioElegido(servicio);
            horasFinAtenciónServicio[numeroServidor - 1] = Math.Round(reloj + tiempoDeAtención, 4);
        }

        // Gestiona la finalización de la atención en un servicio, manejando la cola y las decisiones de los clientes.
        public void fin_atención(string servicio, int numeroServidor, double[] tasasFin, double tasaAtenciónAnalista)
        {
            int colaIndex = determinarIndiceServicio(servicio);
            if (colasServicios[colaIndex] == 0)
            {
                liberarServidor(servicio, numeroServidor);
                liberarCliente(servicio, numeroServidor);
                return;
            }
            else
            {
                colasServicios[colaIndex]--;
            }
            if (servicio == "Obras")
            {
                rndAnálisis = Math.Round(generador.NextDouble(), 4);
                decisionCliente = rndAnálisis < 0.23 ? "Si" : "No";
                if (decisionCliente == "Si")
                {
                    generarFinAtenciónAnalista(tasaAtenciónAnalista, numeroServidor);
                }
                else
                {
                    liberarCliente(servicio, numeroServidor);
                }
                atenderNuevoCliente(servicio, numeroServidor);
                generarFinAtención(numeroServidor, servicio, tasasFin);
            }
            else
            {
                liberarCliente(servicio, numeroServidor);
                atenderNuevoCliente(servicio, numeroServidor);
                generarFinAtención(numeroServidor , servicio, tasasFin);
            }
        }

        // Cambia el estado del nuevo cliente a siendo atendido.
        private void atenderNuevoCliente(string servicio, int numeroServidor)
        {
            Cliente clienteSeleccionado = buscarPrimerClienteNoNulo();
            foreach(Cliente cliente in clientes)
            {
                if(cliente != null && cliente.estaEsperando() && cliente.soyElQueLlegoAntes(servicio, clienteSeleccionado))
                {
                    clienteSeleccionado = cliente;
                }
            }
            clienteSeleccionado.atender(numeroServidor);
        }

        private Cliente buscarPrimerClienteNoNulo()
        {
            foreach(Cliente cliente in clientes)
            {
                if (cliente != null && cliente.estaEsperando())
                {
                    return cliente;
                }
            }
            return new Cliente();
        }

        // Libera un cliente del sistema cuando ha terminado su atención.
        public void liberarCliente(string servicio, int numeroServidor)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i] != null && clientes[i].esElQueTermino(servicio, numeroServidor))
                {
                    clientes[i] = null;
                    break;
                }
            }
        }

        // Genera el tiempo de finalización de la atención por parte del analista.
        public void generarFinAtenciónAnalista(double tasaAtenciónAnalista, int numeroServidor)
        {
            tasaElegida = tasaAtenciónAnalista;
            rndFinAtenciónAnálisis = Math.Round(generador.NextDouble(), 4);
            tiempoDeAtenciónAnálisis = expNeg(rndFinAtenciónAnálisis);
            horaFinAtenciónAnálisis[numeroServidor - 1] = reloj + tiempoDeAtenciónAnálisis;
        }

        // Obtiene las horas de finalización de atención para el servicio específico elegido.
        public double[] obtenerHorasFinServicioElegido(string servicio)
        {
            return servicio switch
            {
                "Permisos" => horaFinAtenciónPermisos,
                "Planos" => horaFinAtenciónPlanos,
                "Obras" => horaFinAtenciónObras,
                "Consultoría" => horaFinAtenciónConsultoría,
                "Análisis" => horaFinAtenciónAnálisis
            };
        }

        // Calcula el tiempo de atención usando una distribución exponencial negativa a partir de un número aleatorio.
        public double expNeg(double rnd)
        {
            return -(1 / tasaElegida) * Math.Log(1 - rnd);
        }

        // Verifica la disponibilidad de servidores para un servicio y actualiza su estado o la cola en consecuencia.
        public void averiguarDisponibilidadServidores(bool hayClientesImpacientes, string servicio)
        {
            Dictionary<string, string[]> estadosServidores = new()
            {
                { "Permisos", estadoEmpleados },
                { "Planos", estadoArquitectos },
                { "Obras", estadosInspectores },
                { "Consultoría", estadosConsultores },
                { "Análisis", estadosAnalistas }
            };

            if (servicios.Contains(servicio) && estadosServidores.TryGetValue(servicio, out string[]? value))
            {
                string[] servidoresElegidos = value;
                int colaIndex = Array.IndexOf(servicios, servicio);
                bool todosOcupados = true;

                for (int i = 0; i < servidoresElegidos.Length; i++)
                {
                    if (servidoresElegidos[i] == "Libre")
                    {
                        servidoresElegidos[i] = "Ocupado";
                        numeroServidor = i + 1;
                        todosOcupados = false;
                        enLaCola = false;
                        break;
                    }
                }
                if (todosOcupados && ((hayClientesImpacientes && colasServicios[colaIndex] <= 3) || !hayClientesImpacientes))
                {
                    colasServicios[colaIndex]++;
                    enLaCola = true;
                }
            }
        }

        // Encuentra el valor mínimo entre la hora de llegada y los elementos de una lista de horas fin,
        // el indice del vector de servicios al que corresponde y el número de servidor particular.
        public static (double, int, int) EncontrarMinimo(double horaLlegada, List<double[]> vectores)
        {
            double minimo = double.MaxValue;
            int indiceVector = -1;
            int posicionVector = -1;

            for (int i = 0; i < vectores.Count; i++)
            {
                for (int j = 0; j < vectores[i].Length; j++)
                {
                    if (vectores[i][j] < minimo && vectores[i][j] != 0)
                    {
                        minimo = vectores[i][j];
                        indiceVector = i;
                        posicionVector = j;
                    }
                }
            }
            if(horaLlegada < minimo)
            {
                minimo = horaLlegada;
                posicionVector = -1;
                indiceVector = -1;
            }
            return (minimo, indiceVector, posicionVector);
        }

        // Determina el próximo evento en el sistema y actualiza el reloj en consecuencia.
        public void determinarProximoEvento(Fila anterior, bool hayClientesImpacientes, bool hayParoDeInspectores, double[] tasasLlegada, double[] tasasFin, double tasaAtenciónAnalista)
        {
            List<double[]> horasFinAtencion =
            [
                anterior.horaFinAtenciónPermisos,
                anterior.horaFinAtenciónPlanos,
                anterior.horaFinAtenciónObras,
                anterior.horaFinAtenciónConsultoría,
                anterior.horaFinAtenciónAnálisis
            ];
            var (proximaHora, tipoEvento, numeroServidor) = EncontrarMinimo(horaLlegada, horasFinAtencion);

            reloj = Math.Round(proximaHora, 4);

            switch (tipoEvento)
            {
                case -1:
                    evento = $"llegada_cliente";
                    llegada_cliente(hayClientesImpacientes, hayParoDeInspectores, tasasLlegada, tasasFin);
                    break;
                default:
                    evento = "fin_atención";
                    fin_atención(servicios[tipoEvento], numeroServidor + 1, tasasFin, tasaAtenciónAnalista);
                    obtenerHorasFinServicioElegido(servicios[tipoEvento])[numeroServidor] = 0;
                    break;
            }

        }

        // Verifica si hay nuevos clientes en el sistema desde la última verificación.
        public bool hayNuevosClientes(int cantidadClientesAnterior)
        {
            return clientes.Count > cantidadClientesAnterior;
        }
        public void limpiarValoresNoRecurrentes()
        {
            rndFinAtención = 0;
            rndLlegada = 0;
            rndServicio = 0;
            tiempoDeAtención = 0;
            tiempoHastaLlegada = 0;
            rndAnálisis = 0;
            rndFinAtenciónAnálisis = 0;
            decisionCliente = "";
        }

        public DataGridViewRow ConvertirAFila(bool hayParoDeInspectores)
        {
            DataGridViewRow row = new();

            row.Cells.Add(new DataGridViewTextBoxCell { Value = evento });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = reloj });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = rndServicio });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = servicio });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = rndLlegada });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = tiempoHastaLlegada });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = horaLlegada });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = rndFinAtención });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = tiempoDeAtención });

            foreach (var val in horaFinAtenciónPermisos)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            foreach (var val in horaFinAtenciónPlanos)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            foreach (var val in horaFinAtenciónObras)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            if (!hayParoDeInspectores)
            {
                row.Cells.Add(new DataGridViewTextBoxCell { Value = rndAnálisis });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = decisionCliente });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = rndFinAtenciónAnálisis });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = tiempoDeAtenciónAnálisis });

                foreach (var val in horaFinAtenciónAnálisis)
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = val });
            }
            foreach (var val in horaFinAtenciónConsultoría)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            row.Cells.Add(new DataGridViewTextBoxCell { Value = colasServicios[0] });
            foreach (var val in estadoEmpleados)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            row.Cells.Add(new DataGridViewTextBoxCell { Value = colasServicios[1] });
            foreach (var val in estadoArquitectos)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            if (!hayParoDeInspectores)
            {
                row.Cells.Add(new DataGridViewTextBoxCell { Value = colasServicios[2] });
            }
            foreach (var val in estadosInspectores)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            row.Cells.Add(new DataGridViewTextBoxCell { Value = colasServicios[3] });
            foreach (var val in estadosConsultores)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });
            if (!hayParoDeInspectores)
            {
                row.Cells.Add(new DataGridViewTextBoxCell { Value = colasServicios[4] });
                foreach (var val in estadosAnalistas)
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = val });
            }
            foreach (var val in acumuladoresTiempoEspera)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            foreach (var val in acumuladorColasServicio)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            foreach (var val in tiempoEsperaPromedio)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            foreach (var val in tiempoOcupadoServicio)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            foreach (var val in porcentajeOcupaciónServicio)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = val });

            foreach (var cliente in clientes)
            {
                if(cliente != null)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cliente.estado });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cliente.horaLlegada });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cliente.servicio });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cliente.numeroServidor });
                }
                else
                {
                    for(int i = 0; i < 4; i++)
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                    }
                }
                
            }
            return row;
        }
    }
}
