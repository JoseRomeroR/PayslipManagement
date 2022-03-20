using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02GNV3_JoseRR
{
    internal class Payslip
    {
        //CONSTANTES
        const byte MAX_PRIZE = 15;
        const byte MAX_HOURS = 55;
        //MIEMBROS
        private float hoursWorkeds;
        private float pricePerHours;
        //CONSTRUCTOR POR DEFECTO, NO LO INCLUYO YA QUE AUTOMATICAMENTE LO INICIALIZA
        //PROPIEDADES
        public float HoursWorkeds
        {
            get { return hoursWorkeds; }
            set 
            {
                if (value > MAX_HOURS) throw new Exception($"Lo máximo permitido en esta empresa son {MAX_HOURS} Horas semanales!"); //MAXIMO HORAS SEMANALES
                hoursWorkeds = value;
            }
        }
        public float PricePerHours
        {
            get { return pricePerHours; }
            set
            {
                if (value > MAX_PRIZE) throw new Exception($"Nuestra empresa paga como máximo {MAX_PRIZE}$/Hora"); //MAXIMO PRECIO HORA PERMITIDO
                pricePerHours = value;
            }
        }
    }
}
