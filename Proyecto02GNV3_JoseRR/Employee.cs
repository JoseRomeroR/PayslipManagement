using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02GNV3_JoseRR
{
    internal class Employee
    {
        //CONSTANTES
        const byte DNI_LETTER = 8;
        private const byte WEEK = 5;
        private const float TAXES = 0.16f;
        //MIEMBROS
        private string name;
        private string surName;
        private string category;
        private string dni;
        private List<float> hoursWorkeds;
        private List<float> pricePerHours;
        //CONSTRUCTOR OBLIGATORIO DNI
        public Employee(string dni)
        {
            this.name = "Empty";
            this.surName = "Empty";
            this.category = "Empty";
            ValidateDni(dni);
            this.hoursWorkeds=new List<float>();
            for (int i = 0; i < Week; i++) this.hoursWorkeds.Insert(i, 0); // inicializo a 0 todas las posiciones
            this.pricePerHours= new List<float>();
            for (int i = 0; i < Week; i++) this.pricePerHours.Insert(i, 0); // inicializo a 0 todas las posiciones
        }
        //PROPIEDADES
        public string Name
        {
            get { return this.name; }
            set
            {
                value = value.ToUpper();
                if(String.IsNullOrWhiteSpace(value)) throw new Exception("Introduce algo loco!"); // si esta lleno de espacios peta
                if (String.IsNullOrEmpty(value)) throw new Exception("Introduce algo loco!"); // si esta vacio peta
                if(value.Length>15) throw new Exception("No existe un nombre tan largo!"); // nombre muy largo peta
                for (int i = 0; i < value.Length; i++) if (!(value[i] >= 65 && value[i] <= 90 || value[i] == 32))
                        throw new Exception("No has introducido caracteres válidos"); // Excepcion si no mete caracteres validos
                this.name = value;
            }
        }
        public string SurName
        {
            get { return this.surName; }
            set 
            {
                value = value.ToUpper();
                if (String.IsNullOrWhiteSpace(value)) throw new Exception("Introduce algo loco!"); // si esta lleno de espacios peta
                if (String.IsNullOrEmpty(value)) throw new Exception("Introduce algo loco!"); // si esta vacio peta
                if (value.Length > 30) throw new Exception("No existe un nombre tan largo!"); // apellido muy largo peta
                for (int i = 0; i < value.Length; i++) if (!(value[i] >= 65 && value[i] <= 90 || value[i] == 32))
                        throw new Exception("No has introducido caracteres válidos"); // Excepcion si no mete caracteres validos
                this.surName = value;
            }
        }
        public List<float> HoursWorkeds
        {
            get 
            {
                return this.hoursWorkeds;
            }
            set
            {
                this.hoursWorkeds = value;
            }
        }        //NO INTRODUZCO VALIDACIONES PORQUE YA ESTAN VALIDADAS EN PAYSLIP , POR LO QUE SERIA REDUNDANTE
        public List<float> PricePerHours
        {
            get { return this.pricePerHours; }
            set 
            {              
                this.pricePerHours = value;
            }
        }        //NO INTRODUZCO VALIDACIONES PORQUE YA ESTAN VALIDADAS EN PAYSLIP , POR LO QUE SERIA REDUNDANTE
        public string Category
        {
            get { return this.category; }
            set
            {
                value = value.ToUpper();
                if (String.IsNullOrWhiteSpace(value)) throw new Exception("Introduce algo loco!"); // si esta lleno de espacios peta
                if (String.IsNullOrEmpty(value)) throw new Exception("Introduce algo loco!"); // si esta vacio peta
                if (value.Length > 30) throw new Exception("No existe un nombre tan largo!"); // puesto muy largo peta
                for (int i = 0; i < value.Length; i++) if (value[i] < 65 || value[i] > 90 && value[i] != 32)
                        throw new Exception("No has introducido caracteres válidos"); // Excepcion si no mete caracteres validos
                this.category = value;
            }
        }
        public string Dni
        {
            get { return this.dni;}
        }
        public byte Week
        {
            get { return WEEK; }
        }     
        //METODOS
        public float ExtraHours(int i) // HORAS EXTRAS
        {
            float hours = 0;
            if (hoursWorkeds[i] > 40) hours =hoursWorkeds[i] - 40;
                else hours = 0;
            return hours;
        }
        public float ExtraHours() //@OVERRIDE TOTAL HORAS EXTRAS
        {
            float hours = 0;
            for (int i = 0; i < hoursWorkeds.Count(); i++)
            {
                if (hoursWorkeds[i] > 40) hours += hoursWorkeds[i] - 40;
            }           
            //else hours = 0;
            return hours;
        }
        public float ExtraSalar(int i) // SALARIO EXTRA
        {
            float hours = 0;
            if (hoursWorkeds[i] > 40) hours = (float)(ExtraHours(i)* (pricePerHours[i] * 1.5));
            else hours = 0;
            return hours;
        }
        public float ExtraSalar() //@OVERRIDE TOTAL SALARIO EXTRA
        {
            float hours = 0;
            for (int i = 0; i < WEEK; i++)
            {
                if (hoursWorkeds[i] > 40) hours += (float)(ExtraHours(i) * (pricePerHours[i] * 1.5));
            }
            
            //else hours = 0;
            return hours;
        }
        public float BrutSalary(int i) // SALARIO BRUTO
        {
            float hours = 0;
            hours= (hoursWorkeds[i]*pricePerHours[i]) + ExtraSalar(i);
            return hours;
        }
        public float BrutSalary() //@OVERRIDE TOTAL SALARIO BRUTO
        {
            float hours = 0;
            for (int i = 0; i < WEEK; i++)
            {
                hours += (hoursWorkeds[i] * pricePerHours[i]) + ExtraSalar(i);
            }        
            return hours;
        }
        public float Taxes(int i) // IMPUESTOS
        {
            float taxes=0;
            taxes= BrutSalary(i)*TAXES;
            taxes= (float)decimal.Round((decimal)taxes,2); // TRUNCAMOS DECIMALES
            return taxes;
        }
        public float Taxes() //@OVERRIDE TOTAL IMPUESTOS
        {
            float taxes = 0;
            for (int i = 0; i < WEEK; i++)
            {
                taxes += BrutSalary(i) * TAXES;
            }           
            taxes = (float)decimal.Round((decimal)taxes, 2); // truncamos los decimales
            return taxes;
        }
        public float NetSalary(int i) // SALARIO NETO
        {
            float netSalary=0;
            netSalary = BrutSalary(i) - Taxes(i);
            netSalary= (float)decimal.Round((decimal)netSalary,2);
            return netSalary;
        }
        public float NetSalary() //@OVERRIDE TOTAL SALARIO NETO
        {
            float netSalary = 0;
            for (int i = 0; i < WEEK; i++)
            {
                netSalary += BrutSalary(i) - Taxes(i);
            }           
            netSalary = (float)decimal.Round((decimal)netSalary, 2);
            return netSalary;
        }
        private void ValidateDni(string dni) // VALIDAR DNI
        {
            //48=0
            //57=9
            byte counter = 0;
            int letterNumber =0;
            int numbersDni=0;
            string letterDni = "";
            dni = dni.ToUpper();
            if (dni.Length != 9) throw new Exception("DNI debe de contener 8 digitos y 1 letra"); // Excepcion si no mete caracteres validos
            for (int i = 0; i < dni.Length; i++) if (dni[i] >= 48 && dni[i] <= 57) counter++;
            if (counter != 8) throw new Exception("DNI debe de contener 8 digitos y 1 letra"); // Excepcion si no mete caracteres validos
            if (dni[DNI_LETTER] < 65 || dni[DNI_LETTER] > 90) throw new Exception("DNI debe de contener 8 digitos y 1 letra"); // Excepcion si no mete caracteres validos;


            numbersDni =Convert.ToInt32( dni.Substring(0, 8)); // los numeros del DNI
            letterDni = dni.Substring(8); // letra introducida por usuario
            letterNumber = numbersDni % 23; // modulo 23 para sacar el valor de los 8 numeros del dni para sacar la letra

            switch (letterNumber)// SWICH PARA COMPROBAR QUE LA LETRA INTRODUCIDA DEL DNI CORRESPONDE CON UNA VERDADERA, SI NO PETA
            {
                case 0:
                    if (letterDni != "T") throw new Exception("DNI no válido");
                    break;
                case 1:
                    if (letterDni != "R") throw new Exception("DNI no válido");
                    break;
                case 2:
                    if (letterDni != "W") throw new Exception("DNI no válido");
                    break;
                case 3:
                    if (letterDni != "A") throw new Exception("DNI no válido");
                    break;
                case 4:
                    if (letterDni != "G") throw new Exception("DNI no válido");
                    break;
                case 5:
                    if (letterDni != "M") throw new Exception("DNI no válido");
                    break;
                case 6:
                    if (letterDni != "Y") throw new Exception("DNI no válido");
                    break;
                case 7:
                    if (letterDni != "F") throw new Exception("DNI no válido");
                    break;
                case 8:
                    if (letterDni != "P") throw new Exception("DNI no válido");
                    break;
                case 9:
                    if (letterDni != "D") throw new Exception("DNI no válido");
                    break;
                case 10:
                    if (letterDni != "X") throw new Exception("DNI no válido");
                    break;
                case 11:
                    if (letterDni != "B") throw new Exception("DNI no válido");
                    break;
                case 12:
                    if (letterDni != "N") throw new Exception("DNI no válido");
                    break;
                case 13:
                    if (letterDni != "J") throw new Exception("DNI no válido");
                    break;
                case 14:
                    if (letterDni != "Z") throw new Exception("DNI no válido");
                    break;
                case 15:
                    if (letterDni != "S") throw new Exception("DNI no válido");
                    break;
                case 16:
                    if (letterDni != "Q") throw new Exception("DNI no válido");
                    break;
                case 17:
                    if (letterDni != "V") throw new Exception("DNI no válido");
                    break;
                case 18:
                    if (letterDni != "H") throw new Exception("DNI no válido");
                    break;
                case 19:
                    if (letterDni != "L") throw new Exception("DNI no válido");
                    break;
                case 20:
                    if (letterDni != "C") throw new Exception("DNI no válido");
                    break;
                case 21:
                    if (letterDni != "K") throw new Exception("DNI no válido");
                    break;
                case 22:
                    if (letterDni != "E") throw new Exception("DNI no válido");
                    break;
            } 

            this.dni = dni;
        }
     
     }
}

