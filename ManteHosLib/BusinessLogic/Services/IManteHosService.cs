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

        /// <summary>
        /// Obtains the work orders assigned to the given operator that are still open.
        /// </summary>
        /// <param name="operatorId">Identifier of the operator whose work orders are requested.</param>
        /// <returns>Enumerable containing the open work orders.</returns>
        IEnumerable<WorkOrder> GetOpenWorkOrdersForOperator(string operatorId);

        /// <summary>
        /// Closes a work order providing the repair report and closing date.
        /// </summary>
        /// <param name="operatorId">Identifier of the operator performing the closure.</param>
        /// <param name="workOrderId">Identifier of the work order to be closed.</param>
        /// <param name="repairReport">Description of the work done.</param>
        /// <param name="endDate">Date of closure. If null the current date will be used.</param>
        void CloseWorkOrder(string operatorId, int workOrderId, string repairReport, DateTime? endDate = null);

    }
}
