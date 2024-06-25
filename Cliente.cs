using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ColasOficina
{
    public class Cliente
    {
        public Cliente(string estado, double? horaLlegada, string servicio, int? numeroServidor)
        {
            this.estado = estado;
            this.horaLlegada = horaLlegada;
            this.servicio = servicio;
            this.numeroServidor = numeroServidor;
        }
        public Cliente()
        {

        }
        public string estado { get; private set; }
        public double? horaLlegada { get; private set; }
        public string servicio { get; private set; }
        public int? numeroServidor { get; private set; }

        public void cambiarEstado(string estado)
        {
            this.estado = estado;
        }

        public string obtenerServicio()
        {
            return this.servicio;
        }

        public int? obtenerNumeroServidor()
        {
            return this.numeroServidor;
        }

        public bool esElQueTermino(string servicio, int numeroServidor)
        {
            return (this.servicio == servicio && this.numeroServidor == numeroServidor);
        }

        public void atender(int numeroServidor)
        {
            estado = "SA";
            this.numeroServidor = numeroServidor;
            horaLlegada = null;
        }

        public bool soyElQueLlegoAntes(string servicio, Cliente clienteComparado)
        {
           return this.servicio == servicio && horaLlegada < clienteComparado.horaLlegada;
        }

        public bool estaEsperando()
        {
            return estado == "EA";
        }

    }
}
