using ManteHos.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity.Migrations.Model;

namespace ManteHosPersistenceTests
{
    public class TestData
    {
        //GENERIC
        public static int EXPECTED_EMPTY_LIST_COUNT = 0;
        public static int EXPECTED_ONE_ELEMENT_LIST_COUNT = 1;

        //EMPLOYEE
        //string FullName, string Id, string PassWord
        public static string EXPECTED_EMPLOYEE_ID = "11111111A";
        public static string EXPECTED_EMPLOYEE_FULLNAME = "Mortadelo Martinez";
        public static string EXPECTED_EMPLOYEE_PASSWORD = "477A!6022";

        public static string EXPECTED_MASTER_ID = "22222222B";
        public static string EXPECTED_MASTER_FULLNAME = "Zipi Rodriguez";
        public static string EXPECTED_MASTER_PASSWORD = "477A!6011";


        //INCIDENT
        // string aDepartment, string aDescription, DateTime aReportDate, Employee aReporter
        public static string EXPECTED_INCIDENT_DEPARTMENT = "Radiology";
        public static string EXPECTED_INCIDENT_DESCRIPTION = "Broken A/C";
        public static DateTime EXPECTED_INCIDENT_REPORTDATE = DateTime.Today;
        public static ManteHos.Entities.Employee EXPECTED_INCIDENT_EMPLOYEE = new ManteHos.Entities.Employee(EXPECTED_EMPLOYEE_FULLNAME, EXPECTED_EMPLOYEE_ID, EXPECTED_EMPLOYEE_PASSWORD);


        //AREA
        // string aName, Master aMaster
        public static string EXPECTED_AREA_NAME = "A/C";
        public static ManteHos.Entities.Master EXPECTED_AREA_MASTER = new ManteHos.Entities.Master(EXPECTED_MASTER_FULLNAME, EXPECTED_MASTER_ID, EXPECTED_MASTER_PASSWORD);


        //OPERATOR
        // Shift aShift 
        public static Shift EXPECTED_OPERATOR_SHIFT = Shift.Morning;

        //PART
        public static string EXPECTED_PART_CODE = "P100";
        public static string EXPECTED_PART_DESCRIPTION = "Cooling Fan";
        public static float EXPECTED_PART_UNITPRICE = 99.99f;
        public static int EXPECTED_PART_CURRENTQUANTITY = 20;
        public static int EXPECTED_PART_MINIMUMQUANTITY = 5;
        public static string EXPECTED_PART_UNITOFMEASURE = "pcs";

        //USEDPART
        public static bool EXPECTED_USEDPART_NEEDED_FALSE = false;
        public static bool EXPECTED_USEDPART_NEEDED_TRUE = true;
        public static int EXPECTED_USEDPART_QUANTITY_NOT_ENOUGH = EXPECTED_PART_CURRENTQUANTITY - EXPECTED_PART_MINIMUMQUANTITY + 1; // provoca Needed = true
        public static int EXPECTED_USEDPART_QUANTITY_ENOUGH = EXPECTED_PART_CURRENTQUANTITY - EXPECTED_PART_MINIMUMQUANTITY - 1;    // provoca Needed = false

        public static UsedPart CreateUsedPart(bool overrideNeeded, int quantity, Part part, out string error)
        {
            var ctorBool = typeof(UsedPart).GetConstructor(new[] { typeof(bool), typeof(int), typeof(Part) });
            var ctorInt = typeof(UsedPart).GetConstructor(new[] { typeof(int), typeof(Part) });
            if (ctorBool == null && ctorInt == null)
            {
                error = "Error creating UsedPart: No valid constructor found. At least one ((bool, int, Part) or (int, Part)) must be implemented.";
                return null;
            }

            UsedPart CreateWithOverride()
            {
                var result = (UsedPart)ctorInt.Invoke(new object[] { quantity, part });
                result.Needed = overrideNeeded;
                return result;
            }

            var usedPart =
                ctorBool != null
                ? (UsedPart)ctorBool.Invoke(new object[] { overrideNeeded, quantity, part })
                : CreateWithOverride();

            error = string.Empty;
            return usedPart;
        }

        // WORKORDER
        public static DateTime EXPECTED_WORKORDER_START_DATE = DateTime.Today;
        public static Incident EXPECTED_WORKORDER_INCIDENT = new Incident(EXPECTED_INCIDENT_DEPARTMENT, EXPECTED_INCIDENT_DESCRIPTION, EXPECTED_INCIDENT_REPORTDATE, EXPECTED_INCIDENT_EMPLOYEE);

        /*
         * Método de factoría para la creación de instancias de la clase Part. En lugar de utilizar el patrón habitual de propiedad estática que llama al constructor de la clase utilizo el patrón factoría.
         * 
         * El motivo es porque si añadimos más adelante algún casos de prueba con varias instancias de Part y operaciones que modifican el stock se producirían inconsistencias dado que al ser una propiedad estática en realidad todos los objetos Part serían el mismo.
         */
        public static Part CreateExpectedPart()
        {
            return new Part
            {
                Code = EXPECTED_PART_CODE,
                Description = EXPECTED_PART_DESCRIPTION,
                UnitPrice = EXPECTED_PART_UNITPRICE,
                CurrentQuantity = EXPECTED_PART_CURRENTQUANTITY,
                MinimunQuantity = EXPECTED_PART_MINIMUMQUANTITY,
                UnitOfMeasure = EXPECTED_PART_UNITOFMEASURE
            };
        }

        // OPERATOR
        public static Shift EXPECTED_SHIFT = Shift.Morning;
    }

}