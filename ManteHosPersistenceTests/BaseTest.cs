using ManteHos.Entities;
using ManteHos.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace ManteHosPersistenceTests
{
    [TestClass]
    public class BaseTest
    {
        protected private EntityFrameworkDAL dal;

        private static bool HasRequiredAnnotation(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(false);
            Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
            return attrs.Any((attr) =>
            {
                return attr is RequiredAttribute;
            });

        }

        private static bool HasKeyAnnotation(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(false);
            Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
            return attrs.Any((attr) =>
            {
                return attr is KeyAttribute;
            });

        }

        /*private static bool HasDatabaseGeneratedOptionNone(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(false);
            Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
            return attrs.Any((attr) =>
            {
                if (attr is DatabaseGeneratedAttribute)
                {
                    DatabaseGeneratedAttribute dbGenAtt = attr as DatabaseGeneratedAttribute;
                    return dbGenAtt.DatabaseGeneratedOption == DatabaseGeneratedOption.None;
                }
                else return false;
                    
        
            });

        }
        */

        [TestInitialize]
        public void IniTests()
        {
            // Si no hacemos este test aquí da otra excepción que no es trivial
            // para los alumnos saber qué está ocurriendo
            // Con estos assert sabrán que han de añadir los Required
            // Required en Area: Master
            // Required en Incident: Reporter
            // Required en UsedPart: Part
            // Required en WorkOrder: Incident
            Assert.IsTrue(HasRequiredAnnotation(typeof(Area).GetProperty("Master")), "Property named \"Master\" in \"Area\" class should have Data Annotation [Required]");
            Assert.IsTrue(HasRequiredAnnotation(typeof(Incident).GetProperty("Reporter")), "Property named \"Reporter\" in \"Incident\" class should have Data Annotation [Required]");
            Assert.IsTrue(HasRequiredAnnotation(typeof(UsedPart).GetProperty("Part")), "Property named \"Part\" in \"UsedPart\" class should have Data Annotation [Required]");
            Assert.IsTrue(HasRequiredAnnotation(typeof(WorkOrder).GetProperty("Incident")), "Property named \"Incident\" in \"WorkOrder\" class should have Data Annotation [Required]");

            //Key Annotations
            Assert.IsTrue(HasKeyAnnotation(typeof(Part).GetProperty("Code")), "Property named \"Code\" in \"Part\" class should have Data Annotation [Key]");
            
            //DatabaseGeneratedOption
            //None
            //Assert.IsTrue(HasDatabaseGeneratedOptionNone(typeof(TaughtCourse).GetProperty("Id")), "Property named \"Id\" in \"TaughtCourse\" class should have Data Annotation [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]");
           
            dal = new EntityFrameworkDAL(new ManteHosDbContext());
            dal.RemoveAllData();
        }
        [TestCleanup]
        public void CleanTests()
        {
            dal.RemoveAllData();
        }
    }
}
