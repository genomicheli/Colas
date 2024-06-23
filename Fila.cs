using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ColasOficina
{
    public class Fila
    {

        public Fila(int cantidadEmpleados)
        {
            horaFinAtenciónPermisos = new double[cantidadEmpleados];
            estadoEmpleados = new string[cantidadEmpleados];
        }
        // Atributos privados.

        private string[] servicios = ["Permisos", "Planos", "Obras", "Consultoría"];
        private double tasaElegida;
        private bool enLaCola;
        private int numeroServidor;

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

        public string ObtenerServicio(double numeroAleatorio)
        {
            int indice = (int)(numeroAleatorio * servicios.Length);
            return servicios[indice];
        }

        public void determinarServicio(double rnd, double[] tasasLlegada)
        {
            rndServicio = rnd;
            servicio = ObtenerServicio(rnd);
            seleccionarTasa(tasasLlegada, rndServicio);
        }

        public void seleccionarTasa(double[] tasasLlegada, double rnd)
        {
            int indice = (int)(rnd * tasasLlegada.Length);
            tasaElegida = tasasLlegada[indice];
        }

        public void generarProximaLlegada(double rndServicio, double rndLlegada, double[] tasasLlegada)
        {
            determinarServicio(rndServicio, tasasLlegada);
            this.rndLlegada = rndLlegada;
            tiempoHastaLlegada = expNeg(rndLlegada);
            horaLlegada = reloj + tiempoHastaLlegada;
        }

        public void llegada_cliente(bool clientesImpacientes)
        {
            averiguarDisponibilidadServidores(clientesImpacientes);
            servicio = "";
            if (enLaCola)
            {

            }
        }

        public double expNeg(double rnd)
        {
            return -(1 / tasaElegida) * Math.Log(1 - rnd);
        }

        public void averiguarDisponibilidadServidores(bool clientesImpacientes)
        {
            int colaIndex;
            string[]? servidoresElegidos;

            // Vemos los estados de los servidores segun el servicio seleccionado en la llegada
            switch (servicio)
            {
                case "Permisos":
                    servidoresElegidos = estadoEmpleados;
                    colaIndex = 0;
                    break;
                case "Planos":
                    servidoresElegidos = estadoArquitectos;
                    colaIndex = 1;
                    break;
                case "Obras":
                    servidoresElegidos = estadosInspectores;
                    colaIndex = 2;
                    break;
                case "Consultoría":
                    servidoresElegidos = estadosConsultores;
                    colaIndex = 3;
                    break;
                default:
                    servidoresElegidos = null;
                    colaIndex = -1;
                    break;
            }

            if (servidoresElegidos != null)
            {
                bool todosOcupados = true;

                for (int i = 0; i < servidoresElegidos.Length; i++)
                {
                    if (servidoresElegidos[i] != "Ocupado")
                    {
                        servidoresElegidos[i] = "Ocupado";
                        numeroServidor = i + 1;
                        todosOcupados = false;
                        enLaCola = false;
                    }
                }
                if (todosOcupados & ((clientesImpacientes & colasServicios[colaIndex] <= 3) | !clientesImpacientes))
                {
                    colasServicios[colaIndex]++;
                    enLaCola = true;
                }
            }
        }



    }
}
