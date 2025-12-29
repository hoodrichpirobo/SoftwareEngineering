using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManteHos.Entities;
using ManteHos.Persistence;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                new Program();
            }
            catch (Exception e)
            {
                printError(e);
            }
            Console.WriteLine("\nPulse una tecla para salir");
            Console.ReadLine();
        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                if (e is DbEntityValidationException)
                {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }


        Program()
        {
            IDAL dal = new EntityFrameworkDAL(new ManteHosDbContext());

            CreateSampleDB(dal);
            PrintSampleDB(dal);
        }


        private void CreateSampleDB(IDAL dal)
        {
            dal.RemoveAllData();

            Console.WriteLine("CREANDO LOS DATOS Y ALMACENANDOLOS EN LA BD");
            Console.WriteLine("===========================================");

            Console.WriteLine("\n// CREACIÓN DE PERSONAS");

            Head head = new Head("Ibañez", "h1", "h1");
            dal.Insert<Head>(head);
            dal.Commit();

            Master master1 = new Master("Bárcenas", "m1", "m1");
            dal.Insert<Master>(master1);
            dal.Commit();

            Master master2 = new Master("He-Man", "m2", "m2");
            dal.Insert<Master>(master2);
            dal.Commit();

            Operator op1 = new Operator("Pepe Gotera", "o1", "o1", Shift.Morning);
            dal.Insert<Operator>(op1);
            dal.Commit();

            Operator op2 = new Operator("Mortadelo", "o2", "o2", Shift.Afternoon);
            dal.Insert<Operator>(op2);
            dal.Commit();

            Employee empleado1 = new Employee("Sacarino", "e2", "e2"); 
            dal.Insert<Employee>(empleado1);
            dal.Commit();

            Console.WriteLine("\n// CREACIÓN DE ÁREAS");
            Area areaElec = new Area("Electricidad", master1);      
            dal.Insert<Area>(areaElec);
            dal.Commit();

            Area areaHVAC = new Area("Climatización", master2);
            dal.Insert<Area>(areaHVAC);
            dal.Commit();

            Console.WriteLine("\n// CREACIÓN DE PIEZAS");
            Part pLamp = new Part("P-LAMP", 50, "Lámpara LED 15W E27", 10, "ud", 3.25f);
            Part pFuse = new Part("P-FUSE", 20, "Fusible 10A", 5, "ud", 0.80f);
            Part pFilter = new Part("P-FILTER", 5, "Filtro A/A", 5, "ud", 12.90f);

            dal.Insert<Part>(pLamp);
            dal.Insert<Part>(pFuse);
            dal.Insert<Part>(pFilter);
            dal.Commit();

            Console.WriteLine("\n// CREACIÓN DE INCIDENCIAS");
            Incident inc1 = new Incident(
                Department: "Mantenimiento",
                Description: "Lámpara fundida en pasillo 2",
                ReportDate: DateTime.Today,
                Reporter: empleado1
            );
            inc1.Area = areaElec;      
            dal.Insert<Incident>(inc1);
            dal.Commit();

            Incident inc2 = new Incident(
                Department: "Clima",
                Description: "A/A no enfría en aula 3",
                ReportDate: DateTime.Today.AddDays(-1),
                Reporter: empleado1
            );
            inc2.Area = areaHVAC;
            dal.Insert<Incident>(inc2);
            dal.Commit();

            Console.WriteLine("\n// CREACIÓN DE ÓRDENES DE TRABAJO");

            WorkOrder wo1 = new WorkOrder(DateTime.Now, inc1);
            wo1.Operators.Add(op1);
            op1.WorkOrders.Add(wo1);

            var up1 = new UsedPart(2, pLamp);   
            wo1.UsedParts.Add(up1);

            var up2 = new UsedPart(1, pFuse);
            wo1.UsedParts.Add(up2);

            dal.Insert<WorkOrder>(wo1); 
            dal.Commit();

            wo1.EndDate = DateTime.Now.AddHours(2);      
            wo1.RepairReport = "Sustituidas 2 lámparas y 1 fusible. Iluminación OK.";
            dal.Commit(); 

            WorkOrder wo2 = new WorkOrder(DateTime.Now.AddHours(-3), inc2);
            wo2.Operators.Add(op2);
            op2.WorkOrders.Add(wo2);

            var up3 = new UsedPart(3, pFilter); 
            wo2.UsedParts.Add(up3);

            dal.Insert<WorkOrder>(wo2);
            dal.Commit();

            Console.WriteLine("\n// FIN DE CREACIÓN DE DATOS");
        }


        // Copiar a partir de aquí
        private void PrintSampleDB(IDAL dal)
        {
            Console.WriteLine("\n\nMOSTRANDO LOS DATOS DE LA BD");
            Console.WriteLine("============================\n");

            Console.WriteLine("\nPersonas creadas:");
            foreach (Employee p in dal.GetAll<Employee>())
                Console.WriteLine("   FullName: " + p.FullName + " Id: " + p.Id + " Password: " + p.Password);

            // Show the rest of the database
            Console.WriteLine("\nPiezas creadas:");
            foreach (Part p in dal.GetAll<Part>())
                Console.WriteLine("   Code: " + p.Code + " Description: " + p.Description + " CurrentQuantity: " + p.CurrentQuantity);

            Console.WriteLine("\nÁreas, Indicencias, Órdenes de trabajo y piezas pedidas creadas:");
            foreach (Area a in dal.GetAll<Area>())
            {
                Console.WriteLine("   Name: " + a.Name);
                foreach (Incident i in a.Incidents)
                {
                    Console.WriteLine("      Incident Id: " + i.Id + " ReportDate: " + i.ReportDate + " Description: " + i.Description);
                    WorkOrder o = i.WorkOrder;
                    if (o != null)
                    {
                        Console.WriteLine("          WorkOrder Id: " + o.Id + " StartDate: " + o.StartDate);
                        foreach (UsedPart up in o.UsedParts)
                        {
                            Console.WriteLine("             Part Description: " + up.Part.Description + " Quantity: " + up.Quantity);
                        }
                    }

                }
            }


        }

    }

}