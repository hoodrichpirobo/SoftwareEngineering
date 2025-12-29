using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;

namespace ManteHosPersistenceTests
{
    [TestClass]
    public class MasterTest : BaseTest
    {
        [TestMethod]
        public void StoresInitialData()
        {
            Master master = new Master(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
            dal.Insert(master);
            dal.Commit();

            Master masterFromDAL = dal.GetAll<Master>().First();

            // Test non virtual properties properly stored
            TestNonVirtualPropertiesProperlyStored(masterFromDAL);

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1

            // They must be initially empty because they are all 0..*
            Assert.IsNotNull(masterFromDAL.ReportedIncidents);
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, masterFromDAL.ReportedIncidents.Count);

        }

        [TestMethod]
        public void StoresDataWithRelations()
        {
            Master master = new Master(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
            dal.Insert(master);
            dal.Commit();

            Area area = new Area(TestData.EXPECTED_AREA_NAME, master);
            dal.Insert(area);
            dal.Commit();

            Incident incident = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, master);
            dal.Insert(incident);
            dal.Commit();

            Master masterFromDAL = dal.GetAll<Master>().First();

            // Test non virtual properties properly stored
            TestNonVirtualPropertiesProperlyStored(masterFromDAL);

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1

            // Verify bidirectional relationships: all collections are not null after inserting one element      
            Assert.AreEqual(masterFromDAL.Area, area, "Bidirectional Area-Master relationship not properly set");
            Assert.AreEqual(masterFromDAL.ReportedIncidents.FirstOrDefault(), incident, "Bidirectional Incident-Master relationship not properly set");

        }

        private static void TestNonVirtualPropertiesProperlyStored(Master masterFromDAL)
        {
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, masterFromDAL.FullName);
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, masterFromDAL.Id);
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, masterFromDAL.Password);
        }

    }
}
