using System;
using System.Linq;
using System.Threading;

namespace Proyecto02GNV3_JoseRR
{
    internal class Program
    {    
        static void Main(string[] args)
        {
            //CONSTANTES
            //VARIABLES
            Employee employee = null;
            Payslip payslip = new Payslip();
            ConsoleKey key;// CAPTACION DE TECLA  
            byte op = 0; // OPCION A SELECCIONAR
            bool loop = true; // PARA SALIR DEL BUCLE PRINCIPAL PROGRAMA
            //ENTRADAS
            //Menú con teclas
            do
            {
                do
                {
                    Header("¿Qué desea hacer?"); // PRINT CABEZERA
                    if (op == 0) Options("Ingresar Empleado"); // SI LA OPCION ES 0 ENTRAMOS
                    else OptionsElse("Ingresar Empleado");
                    if (op == 1) Options("Ingresar Nómina"); // SI LA OPCION ES 1 ENTRAMOS
                    else OptionsElse("Ingresar Nómina");
                    if (op == 2) Options("Modificar Empleado");// SI LA OPCION ES 2 ENTRAMOS
                    else OptionsElse("Modificar Empleado");
                    if (op == 3) Options("Ver Empleado");// SI LA OPCION ES 3 ENTRAMOS
                    else OptionsElse("Ver Empleado");
                    if (op == 4) Options("Salir");// SI LA OPCION ES 4 ENTRAMOS
                    else OptionsElse("Salir");
                    key = Console.ReadKey(true).Key; // ARGUMENTO TRUE PARA QUE NO MUESTRE LA TECLA QUE PULSEMOS
                    if (key == ConsoleKey.UpArrow) // FLECHA ARRIBA, OP--
                    {
                        if (op == 0) op = 4;
                        else op--;
                    }
                    if (key == ConsoleKey.DownArrow) // FLECHA ABAJO OP++
                    {
                        if (op == 4) op = 0;
                        else op++;
                    }
                    Console.Clear();
                } while (key != ConsoleKey.Enter);
                //PROCESOS
                switch (op) // ELEGIR OPCION SEGUN MENU
                {
                    case 0:
                        employee = InsertEmployee(employee, payslip); // INSERTAR EMPLEADO
                        break;
                    case 1:
                        InsertPaySlip(employee, payslip); // INSERTAR NOMINA
                        break;
                    case 2:
                        ModifyEmployee(employee, payslip);//MODIFICAR EMPLEADO
                        break;
                    case 3:
                        EmployeeInformation(employee);//IMPRIMIR INFORMACION DEL EMPLEADO
                        break;
                    case 4:
                        Exit(); // SALIMOS DEL PROGRAMA
                        loop = false;
                        break;
                }
            } while (loop);           
            //SALIDAS         
        }
        //INSERTAR NOMINA
        static public void InsertPaySlip(Employee employee,Payslip payslip)
        {
            bool test;
            byte op=0;
            ConsoleKey key;// CAPTACION TECLA  

            if (employee==null)
            {
                Header("No existe ningún empleado");
                Console.WriteLine("Press ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {                
                do
                {
                    Header("¿De que semana quieres insertar la nómina?"); // CABEZERA
                    if (op == 0) Options("Semana 1"); // SI LA OPCION ES 0 ENTRAMOS 
                    else OptionsElse("Semana 1");
                    if (op == 1) Options("Semana 2");  // SI LA OPCION ES 1 ENTRAMOS
                    else OptionsElse("Semana 2");
                    if (op == 2) Options("Semana 3");  // SI LA OPCION ES 2 ENTRAMOS
                    else OptionsElse("Semana 3");
                    if (op == 3) Options("Semana 4");  // SI LA OPCION ES 3 ENTRAMOS
                    else OptionsElse("Semana 4");
                    if (op == 4) Options("Semana 5");  // SI LA OPCION ES 4 ENTRAMOS
                    else OptionsElse("Semana 5");
                    if (op == 5) Options("Salir");     // SI LA OPCION ES 5 ENTRAMOS
                    else OptionsElse("Salir");
                    key = Console.ReadKey(true).Key; // ARGUMENTO TRUE PARA QUE NO MUESTRE LA TECLA QUE PULSEMOS
                    if (key == ConsoleKey.UpArrow)   //FLECHA ARRIBA, OP--
                    {
                        if (op == 0) op = 5;
                        else op--;
                    }
                    if (key == ConsoleKey.DownArrow) //FLECHA ARRIBA, OP++
                    {
                        if (op == 5) op = 0;
                        else op++;
                    }
                    Console.Clear();
                } while (key != ConsoleKey.Enter);
                if (op != 5) // SI LA OPCION INTRODUCIDA ES DIFERENTE A 5 SIGNIFICA QUE QUEREMOS INTRODUCIR UNA NOMINA SEMANAL
                {
                    do
                    {
                        try
                        {
                            test = false;
                            payslip.HoursWorkeds = ReadFloat($"Introduce las horas trabajadas de la {op + 1}º semana  ");
                            employee.HoursWorkeds.Insert(op, payslip.HoursWorkeds);
                        }
                        catch (Exception e)
                        {
                            ErrorCatch(e.Message);
                            test = true;
                        }
                    } while (test);
                    do
                    {
                        try
                        {
                            test = false;
                            payslip.PricePerHours = ReadFloat($"Introduce el precio hora de la {op + 1}º semana  ");
                            employee.PricePerHours.Insert(op, payslip.PricePerHours);
                        }
                        catch (Exception e)
                        {
                            ErrorCatch(e.Message);
                            test = true;
                        }
                    } while (test);
                }
            }       
        }
        //INSERTAR EMPLEADO
        static public Employee InsertEmployee(Employee employee ,Payslip payslip)
        {
            //CONSTANTES
            //VARIABLES          
            bool test;
            if (employee != null) 
            {
                Header("Ya has introducido al empleado , modificalo");
                Console.WriteLine("Press ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                //ENTRADAS          
                do
                {
                    try
                    {
                        test = false;
                        employee = new Employee(ReadString("Introduzca el dni del empleado.")); //PEDIR DNI EMPLEADO
                    }
                    catch (Exception e)
                    {
                        ErrorCatch(e.Message);
                        test = true;
                    }
                } while (test);
                do
                {
                    try
                    {
                        test = false;
                        employee.Name = ReadString("Introduce el nombre del empleado."); //PEDIR NOMBRE EMPLEADO
                    }
                    catch (Exception e)
                    {
                        ErrorCatch(e.Message);
                        test = true;
                    }
                } while (test);
                do
                {
                    try
                    {
                        test = false;
                        employee.SurName = ReadString($"Introduce los apellidos de {employee.Name}."); //PEDIR APELLIDOS EMPLEADO
                    }
                    catch (Exception e)
                    {
                        ErrorCatch(e.Message);
                        test = true;
                    }
                } while (test);
                do
                {
                    try
                    {
                        test = false;
                        employee.Category = ReadString($"Introduce el puesto de {employee.Name} {employee.SurName}."); //PEDIR PUESTO EMPLEADO
                    }
                    catch (Exception e)
                    {
                        ErrorCatch(e.Message);
                        test = true;
                    }
                } while (test);
                //PROCESOS
                //SALIDAS                 
            }
            return employee;

        }
        //MODIFICAR EMPLEADO
        static public void ModifyEmployee(Employee employee,Payslip payslip)
        {
            //CONSTANTES PARA LA IMPRESION DEL VALOR CORRESPONDIENTE DEL METODO OPTIONELSE()
            const byte WEEK1 = 0; 
            const byte WEEK2 = 1;
            const byte WEEK3 = 2;
            const byte WEEK4 = 3;
            const byte WEEK5 = 4;
            ConsoleKey key;// CAPTACION DE TECLA  
            byte op = 0; // OPCION A SELECCIONAR
            bool test;
            bool loop=true;
            if (employee == null)        
            {
                Header("No existe ningun empleado para modificar");
                Console.WriteLine("Press ENTER para continuar");
                Console.ReadKey();
                Console.Clear();       
            }
            else
            {
                do
                {
                    do
                    {
                        Header("¿Que quieres modificar?");
                        if (op == 0) Options("Nombre"); // SI LA OPCION ES 0 ENTRAMOS           
                        else OptionsElse("Nombre");
                        if (op==1) Options("Puesto"); // SI LA OPCION ES 1 ENTRAMOS       
                        else OptionsElse("Puesto");
                        if (op == 2) Options("Apellidos");  // SI LA OPCION ES 2 ENTRAMOS       
                        else OptionsElse("Apellidos");
                        if (op == 3) Options("Precio Hora"); // SI LA OPCION ES 3 ENTRAMOS       
                        else OptionsElse("Precio Hora");
                        if (op == 4) Options("Horas Trabajadas");  // SI LA OPCION ES 4 ENTRAMOS       
                        else OptionsElse("Horas Trabajadas");
                        if (op==5) Options("Salir");  // SI LA OPCION ES 5 ENTRAMOS       
                        else OptionsElse("Salir");
                        key = Console.ReadKey(true).Key; // LO PONEMOS TRUE PARA QUE NO MUESTRE LA TECLA QUE PULSEMOS
                        if (key == ConsoleKey.UpArrow) // FLECHA ARRIBA OP--
                        {
                            if (op == 0) op = 5;
                            else op--;
                        }
                        if (key == ConsoleKey.DownArrow) // FLECHA ABAJO OP++
                        {
                            if (op == 5) op = 0;
                            else op++;
                        }
                        Console.Clear();
                    } while (key != ConsoleKey.Enter);
                    //ELEGIMOS LA OPCION
                    switch (op)
                    {
                        case 0:// MODIFICAR NOMBRE
                            do
                            {
                                try
                                {
                                    test = false;
                                    employee.Name = ReadString("Introduce el nombre del empleado."); 
                                }
                                catch (Exception e)
                                {
                                    ErrorCatch(e.Message);
                                    test = true;
                                }
                            } while (test);                        
                            break;
                        case 1:// MODIFICAR PUESTO
                            do
                            {
                                try
                                {
                                    test = false;
                                    employee.Category = ReadString($"Introduce el puesto de {employee.Name} {employee.SurName}.");
                                }
                                catch (Exception e)
                                {
                                    ErrorCatch(e.Message);
                                    test = true;
                                }
                            } while (test);                                                 
                            break;
                        case 2:// MODIFICAR APELLIDOS
                            do
                            {
                                try
                                {
                                    test = false;
                                    employee.SurName = ReadString($"Introduce los apellidos de {employee.Name}.");
                                }
                                catch (Exception e)
                                {
                                    ErrorCatch(e.Message);
                                    test = true;
                                }
                            } while (test);
                            
                            break;
                        case 3: //MODIFICAR PRECIO HORA
                            op = 0;
                            do
                            {
                                Header("¿De que semana quieres modificar el precio hora?");
                                if (op == 0) Options("Semana 1", employee, WEEK1, "$"); // SI LA OPCION ES 0 ENTRAMOS
                                else OptionsElse("Semana 1",employee,WEEK1,"$", op);

                                if (op == 1) Options("Semana 2", employee, WEEK2, "$"); // SI LA OPCION ES 1 ENTRAMOS
                                else OptionsElse("Semana 2", employee, WEEK2, "$", op);

                                if (op == 2) Options("Semana 3", employee, WEEK3, "$"); // SI LA OPCION ES 2 ENTRAMOS
                                else OptionsElse("Semana 3", employee, WEEK3, "$", op);

                                if (op == 3) Options("Semana 4", employee, WEEK4, "$"); // SI LA OPCION ES 3 ENTRAMOS
                                else OptionsElse("Semana 4", employee, WEEK4, "$", op);

                                if (op == 4) Options("Semana 5", employee, WEEK5, "$");// SI LA OPCION ES 4 ENTRAMOS
                                else OptionsElse("Semana 5", employee, WEEK5, "$", op);

                                if (op == 5) Options("Salir"); // SI LA OPCION ES 5 ENTRAMOS
                                else OptionsElse("Salir");
                                key = Console.ReadKey(true).Key; // LO PONEMOS TRUE PARA QUE NO MUESTRE LA TECLA QUE PULSEMOS
                                if (key == ConsoleKey.UpArrow) // FLECHA ARRIBA OP--
                                {
                                    if (op == 0) op = 5;
                                    else op--;
                                }
                                if (key == ConsoleKey.DownArrow) // FLECHA ABAJO OP++
                                {
                                    if (op == 5) op = 0;
                                    else op++;
                                }
                                Console.Clear();
                            } while (key != ConsoleKey.Enter);
                            if (op != 5)// SI LA OPCION INTRODUCIDA ES DIFERENTE A 5 SIGNIFICA QUE QUEREMOS INTRODUCIR PRECIO SEMANAL
                            {
                                do
                                {
                                    try
                                    {
                                        test = false;
                                        payslip.PricePerHours = ReadFloat($"Introduce el precio hora de la {op + 1}º semana  ");
                                        employee.PricePerHours.Insert(op, payslip.PricePerHours);
                                    }
                                    catch (Exception e)
                                    {
                                        ErrorCatch(e.Message);
                                        test = true;
                                    }
                                } while (test);                               
                            } 
                            break;
                        case 4://MODIFICAR HORAS TRABAJADAS
                            op = 0;
                            do
                            {
                                Header("¿De que semana quieres modificar las horas trabajadas?");
                                if (op == 0) Options2("Semana 1", employee, WEEK1,"Horas Trabajadas"); // SI LA OPCION ES 0 ENTRAMOS 
                                else OptionsElse2("Semana 1",employee, WEEK1, "Horas Trabajadas",op);

                                if (op == 1) Options2("Semana 2", employee, WEEK2, "Horas Trabajadas"); // SI LA OPCION ES 1 ENTRAMOS
                                else OptionsElse2("Semana 2", employee, WEEK2, "Horas Trabajadas", op);

                                if (op == 2) Options2("Semana 3", employee, WEEK3, "Horas Trabajadas"); // SI LA OPCION ES 2 ENTRAMOS
                                else OptionsElse2("Semana 3", employee, WEEK3, "Horas Trabajadas", op);

                                if (op == 3) Options2("Semana 4", employee, WEEK4, "Horas Trabajadas"); // SI LA OPCION ES 3 ENTRAMOS
                                else OptionsElse2("Semana 4", employee, WEEK4, "Horas Trabajadas", op);

                                if (op == 4) Options2("Semana 5", employee, WEEK5, "Horas Trabajadas"); // SI LA OPCION ES 4 ENTRAMOS
                                else OptionsElse2("Semana 5", employee, WEEK5, "Horas Trabajadas", op);

                                if (op == 5) Options("Salir"); // SI LA OPCION ES 5 ENTRAMOS
                                else OptionsElse("Salir");
                                key = Console.ReadKey(true).Key; // LO PONEMOS TRUE PARA QUE NO MUESTRE LA TECLA QUE PULSEMOS
                                if (key == ConsoleKey.UpArrow) // FLECHA ARRIBA OP--
                                {
                                    if (op == 0) op = 5;
                                    else op--;
                                }
                                if (key == ConsoleKey.DownArrow) // FLECHA ABAJO OP++
                                {
                                    if (op == 5) op = 0;
                                    else op++;
                                }
                                Console.Clear();
                            } while (key != ConsoleKey.Enter);
                            if (op != 5) // SI LA OPCION INTRODUCIDA ES DIFERENTE A 5 SIGNIFICA QUE QUEREMOS INTRODUCIR PRECIO SEMANAL
                            {
                                do
                                {
                                    try
                                    {
                                        test = false;
                                        payslip.HoursWorkeds = ReadFloat($"Introduce las horas trabajadas de la {op + 1}º semana  ");
                                        employee.HoursWorkeds.Insert(op, payslip.HoursWorkeds);
                                    }
                                    catch (Exception e)
                                    {
                                        ErrorCatch(e.Message);
                                        test = true;
                                    }
                                } while (test);
                            } 
                            Console.Clear();                           
                            break;
                        case 5: // SALIMOS
                            loop = false;
                            break;
                    }
                } while (loop) ;
            }          
             //return employee;
        }
        //IMPRIMIR EMPLEADO
        static public void EmployeeInformation(Employee employee)
        {
            if (employee == null) // SI NO ESTA INICIALIZADO 
            {
                Header("La base de datos está vacía");
                Console.WriteLine("Press ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Nombre: " + employee.Name);
                Console.WriteLine("Apellidos: " + employee.SurName);
                Console.WriteLine("Pueso: " + employee.Category);
                Console.WriteLine("DNI: " + employee.Dni);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t\tHoras\tEuros/Hora\tHoras Extra\tSal.Extra\tSal.Bruto\tImpuestos\tSal.Neto");
                for (int i = 0; i < employee.Week; i++)
                {
                    Console.WriteLine($"\tSemana{i + 1}\t  {employee.HoursWorkeds[i]}\t" +
                        $"    {employee.PricePerHours[i]}\t\t" +
                        $"     {employee.ExtraHours(i)}\t\t" +
                        $"   {employee.ExtraSalar(i)}\t\t" +
                        $"  {employee.BrutSalary(i)}\t\t" +
                        $"   {employee.Taxes(i)}\t\t {employee.NetSalary(i)}");
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"TOTAL MES:\t  {employee.HoursWorkeds.Sum()}\t" +
                    $"    \t\t" +
                    $"     {employee.ExtraHours()}\t\t" +
                    $"   {employee.ExtraSalar()}\t\t" +
                    $"  {employee.BrutSalary()}\t\t" +
                    $"   {employee.Taxes()}\t\t {employee.NetSalary()}");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("Press ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }          
        }
        // MENSAJE CUANDO SALE EL PROGRAMA
        static public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string title = "|  Saliendo del Proyecto NominasV3  |";
            string msg = "Gracias por utilizar el programa de nominas.\nProgramado por José Romero Roldan.\n.";
            string border = new string('-', title.Length);
            PrintSlow(border,30);
            PrintSlow(title,30);
            PrintSlow(border, 30);
            PrintSlow(msg,50);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Press ENTER para continuar");
            Console.ReadKey();
        }
        //IMPRIME MENSAJES POR CONSOLA CARACTER A CARACTER 
        static public void PrintSlow(string msg ,byte n)
        {
            Console.Write("\t");
            for (int i = 0; i < msg.Length; i++)
            {
                Console.Write(msg[i]);
                Thread.Sleep(n);
            }
            Console.WriteLine();
        }
        //LEER UN FLOAT
        static public float ReadFloat(string msg)
        {
            float n;
            Console.ForegroundColor = ConsoleColor.Blue;
            string title = $"|  {msg}  |";
            string border = new string('-', title.Length);
            Console.WriteLine("".PadLeft(30) + border);
            Console.WriteLine("".PadLeft(30) + title);
            Console.WriteLine("".PadLeft(30) + border);
            Console.ResetColor();
            n = Convert.ToByte(Console.ReadLine());
            Console.Clear();
            return n;
        }
        //LEER UN STRINIG
        static public string ReadString(string msg)
        {
            string msg2;
            Console.ForegroundColor = ConsoleColor.Blue;
            string title = $"|  {msg}  |";
            string border = new string('-', title.Length);
            Console.WriteLine("".PadLeft(30) + border);
            Console.WriteLine("".PadLeft(30) + title);
            Console.WriteLine("".PadLeft(30) + border);
            Console.ResetColor();
            msg2 = Console.ReadLine();
            Console.Clear();
            return msg2;
        }
        // CABEZERA DE MENSAJES STRINGS 
        static public void Header(string msg) 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string title = $"|  {msg}  |";
            string border = new string('-', title.Length);
            Console.WriteLine("".PadLeft(30) + border);
            Console.WriteLine("".PadLeft(30) + title);
            Console.WriteLine("".PadLeft(30) + border);
            Console.ResetColor();
        }
        //IMPRESION DE LOS VALORES DE LOS MENÚS
        static public void Options(string msg)
        {
            Console.Write($"".PadLeft(30));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write($"->{msg}");
            Console.Write("<-");
            Console.WriteLine();
            Console.ResetColor();
        }
        //@OVERRIDE IMPRESION DE LOS VALORES DE LOS MENÚS
        static public void Options(string msg, Employee employee, byte WEEK, string msg2) 
        {
            Console.Write($"".PadLeft(30));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("->");
            Console.Write($"{msg}\t{employee.PricePerHours[WEEK]} {msg2}");
            Console.Write("<-");
            Console.WriteLine();
            Console.ResetColor();
        }
        //@OVERRIDE IMPRESION DE LOS VALORES DE LOS MENÚS CUANDO ES ELSE HOURS WORKEDS
        static public void Options2(string msg, Employee employee, byte WEEK, string msg2)
        {
            Console.Write($"".PadLeft(30));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("->");
            Console.Write($"{msg}\t{employee.HoursWorkeds[WEEK]} {msg2}");
            Console.Write("<-");
            Console.WriteLine();
            Console.ResetColor();
        }
        //IMPRESION DE LOS VALORES DE LOS MENÚS CUANDO ES ELSE
        static public void OptionsElse(string msg)
        {
            Console.WriteLine("".PadLeft(30) + $"  {msg}");
        }
        //@OVERRIDE IMPRESION DE LOS VALORES DE LOS MENÚS CUANDO ES ELSE PRICE HOURS
        static public void OptionsElse(string msg, Employee employee, byte WEEK, string msg2,byte op) 
        {
            if (op > 4) op = 4;
            if (op < 0) op = 0;
            Console.WriteLine("".PadLeft(30) + $"  {msg}\t{employee.PricePerHours[WEEK]} {msg2}");
        }
        //@OVERRIDE IMPRESION DE LOS VALORES DE LOS MENÚS CUANDO ES ELSE HOURS WORKEDS
        static public void OptionsElse2(string msg, Employee employee, byte WEEK, string msg2, byte op)
        {
            if (op > 4) op = 4;
            if (op < 0) op = 0;
            Console.WriteLine("".PadLeft(30) + $"  {msg}\t{employee.HoursWorkeds[WEEK]} {msg2}");
        }
        //ERROR TRY CATCH
        public static void ErrorCatch(string e)
        {
            //SALIDAS
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR,{e}");
            Console.WriteLine("PRESS ENTER para continuar.");
            Console.ReadLine();
            Console.Clear();
            Console.ResetColor();
        } 

     

    }
}
