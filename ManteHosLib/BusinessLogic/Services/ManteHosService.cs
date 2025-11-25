using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ManteHos.Entities;
using ManteHos.Persistence;


namespace ManteHos.Services
{
    public class ManteHosService: IManteHosService
    {
        private readonly IDAL dal;

        public ManteHosService(IDAL dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Borra todos los datos de la BD
        /// </summary>
        public void RemoveAllData()
        {
            dal.RemoveAllData();
        }

        /// <summary>
        /// Salva todos los cambios que haya habido en el contexto de la aplicación desde la última vez que se hizo Commit
        /// </summary>
        public void Commit()
        {
            dal.Commit();
        }

        /// <summary>
        /// Inicializa los datos para que haya ciertos datos para poder usarlos luego
        /// </summary>
        public void DBInitialization()
        {
            RemoveAllData();

            // Dar de alta ciertos datos relevantes para el sistema
            Head head = new Head("Ibañez", "h1", "h1");
            AddPerson(head);
            Master tfmotu = new Master("Bárcenas", "m1", "m1");
            AddPerson(tfmotu);
            Master master2 = new Master("He-Man", "m2", "m2");
            AddPerson(master2);
            Master master3 = new Master("Picasso", "m3", "m3");
            AddPerson(master3);
            Operator op1 = new Operator("Pepe Gotera", "o1", "o1", Shift.Morning);
            AddPerson(op1);
            Operator op2 = new Operator("Otilio", "o2", "o2", Shift.Morning);
            AddPerson(op2);
            Operator op3 = new Operator("Rompetechos", "o3", "o3", Shift.Night);
            AddPerson(op3);

            Employee empleado1 = new Employee("Sacarino", "e1", "e1");
            AddPerson(empleado1);
            Employee empleado2 = new Employee("Pepe García", "e2", "e2");
            AddPerson(empleado2);

            Area a1 = new Area("Mecánica", tfmotu);
            AddArea(a1);
            Area a2 = new Area("Electricidad", master2);
            AddArea(a2);
            Area a3 = new Area("Pintura", master3);
            AddArea(a3);

            Part p1 = new Part("Esc50", 5, "Placa de escayola para techo", 1, "Placa de 50x30cms", 5);
            AddPart(p1);
            Part p2 = new Part("TM8", 3000, "Tornillo métrica 8", 100, "Tornillo", 0.01F);
            AddPart(p2);
            Part p3 = new Part("ClimaEst", 4, "Cristal Climalit de ventana estándar", 0, "Cristal 75x100cms", 200);
            AddPart(p3);

        }

        public void AddPerson(Employee person)
        {
            // Restricción: No puede haber dos personas con el mismo Id
            if (dal.GetById<Employee>(person.Id) == null)
            {
                dal.Insert<Employee>(person);
                dal.Commit();
            }
            else throw new ServiceException("Person with Id " + person.Id + " already exists.");
        }

        public void AddArea(Area area)
        {
            // Restricción: No puede haber dos áreas con el mismo Nombre
            if (!dal.GetWhere<Area>(x => x.Name == area.Name).Any())
            {
                dal.Insert<Area>(area);
                dal.Commit();
            }
            else throw new ServiceException("Area with Name " + area.Name + " already exists.");
        }

        public void AddPart(Part part)
        {
            // Restricción: No puede haber dos piezas con la misma descripción
            if (!dal.GetWhere<Part>(x => x.Description == part.Description).Any())
            {
                dal.Insert<Part>(part);
                dal.Commit();
            }
            else throw new ServiceException("Part with Description " + part.Description + " already exists.");
        }

        public IEnumerable<WorkOrder> GetOpenWorkOrdersForOperator(string operatorId)
        {
            if (string.IsNullOrWhiteSpace(operatorId))
            {
                throw new ServiceException("Operator Id is required.");
            }

            if (dal.GetById<Operator>(operatorId) == null)
            {
                throw new ServiceException("Operator with Id " + operatorId + " does not exist.");
            }

            return dal.GetWhere<WorkOrder>(wo => wo.EndDate == null && wo.Operators.Any(op => op.Id == operatorId));
        }

        public void CloseWorkOrder(string operatorId, int workOrderId, string repairReport, DateTime? endDate = null)
        {
            if (string.IsNullOrWhiteSpace(operatorId))
            {
                throw new ServiceException("Operator Id is required.");
            }

            Operator closingOperator = dal.GetById<Operator>(operatorId);
            if (closingOperator == null)
            {
                throw new ServiceException("Operator with Id " + operatorId + " does not exist.");
            }

            WorkOrder workOrder = dal.GetById<WorkOrder>(workOrderId);
            if (workOrder == null)
            {
                throw new ServiceException("Work order with Id " + workOrderId + " does not exist.");
            }

            if (workOrder.EndDate != null)
            {
                throw new ServiceException("Work order with Id " + workOrderId + " is already closed.");
            }

            if (!workOrder.Operators.Any(op => op.Id == operatorId))
            {
                throw new ServiceException("Operator with Id " + operatorId + " is not assigned to work order " + workOrderId + ".");
            }

            if (workOrder.UsedParts.Any(p => p.Needed))
            {
                throw new ServiceException("Work order with Id " + workOrderId + " cannot be closed because there are pending parts.");
            }

            workOrder.RepairReport = repairReport;
            workOrder.EndDate = endDate ?? DateTime.Now;

            if (workOrder.Incident != null)
            {
                workOrder.Incident.Status = Status.Completed;
                workOrder.Incident.CostOfUsedParts = workOrder.UsedParts
                    .Where(p => !p.Needed)
                    .Sum(p => p.Quantity * p.Part.UnitPrice);
            }

            dal.Commit();
        }

        //
        // Resto de metodos necesarios para el servicio
        //

    }
}
