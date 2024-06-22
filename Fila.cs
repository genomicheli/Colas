using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColasOficina
{
    public class Fila
    {
        public string evento { get; private set; }
        public double reloj { get; private set; }
        public double rndLlegada { get; private set; }
        public double tiempoHastaLlegada { get; private set; }
        public double[] horasLlegada { get; private set; } = new double[4];
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
        public double[] tiempoOciosoServicios { get; private set; } = new double[5];
        public double[] porcentajeOcupaciónServicio { get; private set; } = new double[5];

    }
}
