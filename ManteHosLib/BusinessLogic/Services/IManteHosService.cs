using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;


namespace ManteHos.Services
{
    public interface IManteHosService
    {
        void RemoveAllData();
        void Commit();


        // Necesario para la inicialización de la BD
        void DBInitialization();

        //
        // A partir de aquí los necesarios para los CU solicitados
        //

        // Case 1: LogIn

        void LogIn(string username, string password);

        // Case 2: LogOut

        void LogOut();

        Employee GetLoggedUser();

        // Case 4: Review incident

        //Returns the incidents that are created and still pending acceptance
        // only called by HEAD
        IList<Incident> GetIncidentsPendingAcceptance();

        /// Accepts an incident assigning it to an Area and giving it a Priority.
        void AcceptIncident(int incidentId, string areaName, Priority priority);

        // Rejects an indicent while recording the rejection reason 
        void RejectIncident(int incidentId, string reason);

        // Case 5

        // Shows the incidents in Master's area that are not closed
        ICollection<Incident> GetPendingIncidentsForLoggedMaster();

        // Gets WorkOrder related to a specific incident, if there's not a Workorder, it returns null
        WorkOrder GetWorkOrderRelatedToIncident(Incident incident);

        // New WorkOrder is created (will be associated to a specific incident)
        WorkOrder CreateWorkOrder(Incident incident);

        //Shows operators that can be asigned to the WorkOrder
        ICollection<Operator> GetAvailableOperatorsForWorkOrder(WorkOrder workOrder);

        // Adds operator to the selected WorkOrder
        void AddOperatortoWorkOrder(WorkOrder workOrder, String operatorId);

        void ReportIncident(DateTime date, string department, string description);

        // Removes operator if the one the master selectedis already assigned to the WorkOrder
        void RemoveOperatorFromWorkOrder(WorkOrder workOrder, String operatorId);

        // Case 7: Close WorkOrder
        // The operator must be logged in to close work orders

        IEnumerable<WorkOrder> GetOpenWorkOrdersForLoggedOperator();

        void CloseWorkOrder(int workOrderId, string repairReport, DateTime? endDate = null);

        Boolean IsLogged();
        string GetUser();

    }
}