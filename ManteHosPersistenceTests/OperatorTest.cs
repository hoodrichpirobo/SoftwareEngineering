using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;
using ManteHos.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManteHosPersistenceTests
{
    [TestClass]
    public class OperatorTest : BaseTest
    {
        [TestMethod]
        public void StoresInitialData()
        {
            var op = new Operator(
                TestData.EXPECTED_EMPLOYEE_FULLNAME,
                TestData.EXPECTED_EMPLOYEE_ID,
                TestData.EXPECTED_EMPLOYEE_PASSWORD,
                TestData.EXPECTED_OPERATOR_SHIFT
            );

            dal.Insert(op);
            dal.Commit();

            var opFromDAL = dal.GetById<Operator>(op.Id);

            // Test non-virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, opFromDAL.FullName, "FullName not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, opFromDAL.Password, "Password not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_OPERATOR_SHIFT, opFromDAL.Shift, "Shift not properly stored.");

            // Test virtual properties properly stored
            Assert.IsNotNull(opFromDAL.WorkOrders, "WorkOrders collection not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, opFromDAL.WorkOrders.Count, "WorkOrders should be initially empty.");
        }

        [TestMethod]
        public void StoresDataWithRelations()
        {
            var op = new Operator(
                TestData.EXPECTED_EMPLOYEE_FULLNAME,
                TestData.EXPECTED_EMPLOYEE_ID,
                TestData.EXPECTED_EMPLOYEE_PASSWORD,
                TestData.EXPECTED_OPERATOR_SHIFT
            );
            dal.Insert(op);
            dal.Commit();

            var incident = new Incident(
                TestData.EXPECTED_INCIDENT_DEPARTMENT,
                TestData.EXPECTED_INCIDENT_DESCRIPTION,
                TestData.EXPECTED_INCIDENT_REPORTDATE,
                op
            );
            dal.Insert(incident);
            dal.Commit();

            var workOrder = new WorkOrder(TestData.EXPECTED_WORKORDER_START_DATE, incident);
            workOrder.AddOperator(op);
            dal.Insert(workOrder);
            dal.Commit();

            var opFromDAL = dal.GetById<Operator>(op.Id);

            // Test non-virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_OPERATOR_SHIFT, opFromDAL.Shift, "Shift not properly stored.");

            // Test bidirectional relationships
            Assert.AreEqual(workOrder, opFromDAL.WorkOrders.FirstOrDefault(x => x.Id == workOrder.Id), "WorkOrder not properly linked from Operator.");
            Assert.AreEqual(op, workOrder.Operators.FirstOrDefault(x => x.Id == op.Id), "Operator not properly linked from WorkOrder.");
        }
    }
}
