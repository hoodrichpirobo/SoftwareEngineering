using System;
using ManteHos.Entities;

namespace ManteHosObjectDesignTests
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

        //INCIDENT
        // string aDepartment, string aDescription, DateTime aReportDate, Employee aReporter
        public static string EXPECTED_INCIDENT_DEPARTMENT = "Radiology";
        public static string EXPECTED_INCIDENT_DESCRIPTION = "Broken A/C";
        public static DateTime EXPECTED_INCIDENT_REPORTDATE = DateTime.Today;
        public static ManteHos.Entities.Employee EXPECTED_INCIDENT_EMPLOYEE = new ManteHos.Entities.Employee(EXPECTED_EMPLOYEE_FULLNAME, EXPECTED_EMPLOYEE_ID, EXPECTED_EMPLOYEE_PASSWORD);


        //AREA
        // string aName, Master aMaster
        public static string EXPECTED_AREA_NAME = "A/C";
        public static ManteHos.Entities.Master EXPECTED_AREA_MASTER = new ManteHos.Entities.Master(EXPECTED_EMPLOYEE_FULLNAME, EXPECTED_EMPLOYEE_ID, EXPECTED_EMPLOYEE_PASSWORD);


        //PART
        public static string EXPECTED_PART_CODE = "P100";
        public static string EXPECTED_PART_DESCRIPTION = "Cooling Fan";
        public static float EXPECTED_PART_UNITPRICE = 99.99f;
        public static int EXPECTED_PART_CURRENTQUANTITY = 20;
        public static int EXPECTED_PART_MINIMUMQUANTITY = 5;
        public static string EXPECTED_PART_UNITOFMEASURE = "pcs";

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

        //USEDPART
        public static bool EXPECTED_USEDPART_NEEDED_FALSE = false;
        public static bool EXPECTED_USEDPART_NEEDED_TRUE = true;
        public static int EXPECTED_USEDPART_QUANTITY_NOT_ENOUGH = EXPECTED_PART_CURRENTQUANTITY - EXPECTED_PART_MINIMUMQUANTITY + 1; // provoca Needed = true
        public static int EXPECTED_USEDPART_QUANTITY_ENOUGH = EXPECTED_PART_CURRENTQUANTITY - EXPECTED_PART_MINIMUMQUANTITY - 1;    // provoca Needed = false

        // OPERATOR
        public static Shift EXPECTED_SHIFT = Shift.Morning;
    }

}