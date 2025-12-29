using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;
using System.Data.Entity.Infrastructure.Interception;

namespace ManteHosPersistenceTests
{
    [TestClass]
    public class WorkOrderTest : BaseTest
    {
        [TestMethod]
        public void StoresInitialData()
        {
            // public WorkOrder(DateTime aStartDate, Incident aIncident) 
            var workOrder = new WorkOrder(TestData.EXPECTED_WORKORDER_START_DATE, TestData.EXPECTED_WORKORDER_INCIDENT);
            dal.Insert(workOrder);
            dal.Commit();

            var workOrderFromDAL = dal.GetAll<WorkOrder>().FirstOrDefault(x => x.Id == workOrder.Id);

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_WORKORDER_START_DATE, workOrderFromDAL.StartDate, "StartDate attribute not properly stored.");

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1
            Assert.AreEqual(TestData.EXPECTED_WORKORDER_INCIDENT, workOrderFromDAL.Incident, "Incident attribute not properly stored.");
        }

        [TestMethod]
        public void StoresDataWithRelations()
        {
            var oper = new Operator(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD, TestData.EXPECTED_OPERATOR_SHIFT);
            dal.Insert(oper);
            dal.Commit();

            //   public Incident(string aDepartment, string aDescription, DateTime aReportDate, Employee aReporter)
            var incident = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, oper);
            dal.Insert(incident);
            dal.Commit();

            var wOrder = new WorkOrder(TestData.EXPECTED_WORKORDER_START_DATE, incident);
            wOrder.AddOperator(oper);
            wOrder.AddUsedPart(TestData.EXPECTED_USEDPART_QUANTITY_ENOUGH, TestData.CreateExpectedPart());
            dal.Insert(wOrder);
            dal.Commit();

            var wOrderFromDAL = dal.GetAll<WorkOrder>().FirstOrDefault(x => x.Id == wOrder.Id);

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_WORKORDER_START_DATE, wOrderFromDAL.StartDate, "StartDate attribute not properly stored.");

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1
            Assert.AreEqual(incident, wOrderFromDAL.Incident, "Incident not properly initialized.");

            // Verify bidirectional relationships: all collections are not null after inserting one element      
            Assert.AreEqual(oper.WorkOrders.FirstOrDefault(x => x.Id == wOrder.Id), wOrderFromDAL, "Bidirectional WorkOrder-Operator relationship not properly set");
        }
    }
}