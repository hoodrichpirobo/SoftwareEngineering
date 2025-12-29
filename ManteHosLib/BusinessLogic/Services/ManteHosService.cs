using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ManteHos.Entities;
using ManteHos.Persistence;


namespace ManteHos.Services
{
    public class ManteHosService : IManteHosService
    {
        private readonly IDAL dal;
        private Employee Logged;

        public Employee GetLoggedUser()
        {
            return this.Logged;
        }

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


        //
        // Resto de metodos necesarios para el servicio
        //

        // Case 1. LogIn
        public void LogIn(string username, string password)
        {
            Employee person = dal.GetById<Employee>(username);
            if (person == null)
            {
                throw new ServiceException("User " + username + " does not exist.");
            }
            else if (!person.Password.Equals(password))
            {
                throw new ServiceException("Password is incorrect.");
            }
            this.Logged = person;
        }

        // Case 2. LogOut

        public void LogOut()
        {
            this.Logged = null;
        }

        // Case 3. ReportIncident
        public void ReportIncident(DateTime date, string department, string description)
        {
            if (this.Logged != null)
            {
                dal.Insert<Incident>(new Incident(department, description, date, this.Logged));
                dal.Commit();
            }
            else
            {
                throw new ServiceException("Employee not logged in.");
            }
        }


        //case 4: Review Incident (actor: Head)
        public IList<Incident> GetIncidentsPendingAcceptance()
        {
            if (!(this.Logged is Head))
            {
                throw new ServiceException("Only a Head can review incidents.");
            }
            //created incidents not yet reviewed
            return dal.GetWhere<Incident>(i => i.Status == Status.Created).ToList();

        }

        public void AcceptIncident(int incidentId, string areaName, Priority priority)
        {
            if (!(this.Logged is Head))
            {
                throw new ServiceException("Only a Head can accept incidents");
            }

            //get incident 
            Incident incident = dal.GetById<Incident>(incidentId);
            if (incident == null)
            {
                throw new ServiceException("Incident with id " + incidentId + " does not exist");
            }
            //get area 
            Area area = dal.GetWhere<Area>(a => a.Name == areaName).FirstOrDefault();
            if (area == null)
            {
                throw new ServiceException("Area " + areaName + " does not exist");
            }
            //updat info 
            incident.Area = area;
            incident.Priority = priority;
            incident.Status = Status.Accepted;

            dal.Commit();

        }
        public void RejectIncident(int incidentId, string reason)
        {
            if (!(this.Logged is Head))
            {
                throw new ServiceException("Only a Head can reject incidents");
            }

            //get incident 
            Incident incident = dal.GetById<Incident>(incidentId);
            if (incident == null)
            {
                throw new ServiceException("Incident with id " + incidentId + " does not exist");
            }

            //record rejection 
            incident.Status = Status.Rejected;

            incident.RejectionReason = reason;

            dal.Commit();
        }


        // Case 5. Assign WorkOrder

        public ICollection<Incident> GetPendingIncidentsForLoggedMaster()
        {
            // Precondition: The master must be logged in
            if (!(this.Logged is Master))
            {
                throw new ServiceException("Only a logged-in Master can assign work orders.");
            }

            Master master = (Master)this.Logged;

            if (master.Area == null)
            {
                throw new ServiceException("The logged Master is not assigned to an area.");
            }

            return dal.GetWhere<Incident>(i => i.Area.Name == master.Area.Name && i.Status != Status.Rejected && i.Status != Status.Completed).ToList();

        }




        // Gets the WorkOrder that is related to a specific incident, if there's not a Workorder, it returns null
        public WorkOrder GetWorkOrderRelatedToIncident(Incident incident)
        {
            //I mean, it seems that this First() is working, have to take another look into this    
            // Correction -> Using FirstOrDefault is better because if noting is found it returns null, First() crashes
            // Assuming Incident has an 'Id' property
            return dal.GetAll<WorkOrder>().Where(wko => wko.Incident.Id == incident.Id).FirstOrDefault();
        }


        // New WorkOrder is created (will be associated to a specific incident)
        public WorkOrder CreateWorkOrder(Incident incident)
        {
            if (GetWorkOrderRelatedToIncident(incident) != null)
            {
                throw new ServiceException("There is an already existing Work Order for this incident");
            }

            //Creating new WorkOrder if all goes correctly, we dont use the default constructor because
            WorkOrder newWkOrder = new WorkOrder()
            {
                Incident = incident,
                StartDate = DateTime.Now
            };
            dal.Insert(newWkOrder);
            dal.Commit();
            return newWkOrder;
        }

        //Shows operators that can be asigned to the WorkOrder
        public ICollection<Operator> GetAvailableOperatorsForWorkOrder(WorkOrder workOrder)
        {
            // Getting all operators and of them, choose the ones which 
            return dal.GetAll<Operator>().Where(op => !workOrder.Operators.Contains(op)).ToList();
        }

        // Adds operator to the selected WorkOrder, not sure if i got it right (i have to think more about this)
        public void AddOperatortoWorkOrder(WorkOrder workOrder, String operatorId)
        {
            Operator newOperator = dal.GetById<Operator>(operatorId);

            if (workOrder.Operators.Contains(newOperator))
            {
                throw new ServiceException("Operator already assigned to this WorkOrder");
            }

            workOrder.Operators.Add(newOperator);
            dal.Commit();
        }

        // Removes operator if the one the master selected is already assigned to the WorkOrder (done)
        public void RemoveOperatorFromWorkOrder(WorkOrder workOrder, String operatorId)
        {
            Operator newOperator = dal.GetById<Operator>(operatorId);

            if (workOrder.Operators.Contains(newOperator))
            {
                workOrder.Operators.Remove(newOperator);
                dal.Commit();
            }
            else
            {
                throw new ServiceException("Operator is not assigned to this Work Order.");
            }
        }

        // Case 7: Close WorkOrder
        // The operator must be logged in to close work orders

        public IEnumerable<WorkOrder> GetOpenWorkOrdersForLoggedOperator()
        {
            // Check that someone is logged in and is an Operator
            if (!(this.Logged is Operator))
            {
                throw new ServiceException("Only a logged-in Operator can view their work orders.");
            }

            string operatorId = this.Logged.Id;
            return dal.GetWhere<WorkOrder>(wo => wo.EndDate == null && wo.Operators.Any(op => op.Id == operatorId));
        }

        public void CloseWorkOrder(int workOrderId, string repairReport, DateTime? endDate = null)
        {
            // Check that someone is logged in and is an Operator
            if (!(this.Logged is Operator))
            {
                throw new ServiceException("Only a logged-in Operator can close work orders.");
            }

            string operatorId = this.Logged.Id;

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
                throw new ServiceException("You are not assigned to work order " + workOrderId + ".");
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

        public Boolean IsLogged()
        {
            return (Logged != null);
        }

        public string GetUser()
        {
            return Logged.FullName;
        }

    }
}