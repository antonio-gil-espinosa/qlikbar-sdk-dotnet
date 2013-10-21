using System.Collections.Generic;
using System.Linq;
using Agile;
using QlikBar.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QlikBar.SDK.Results;
using QlikBar.SDK.DTOs;


namespace QlikBar.SDK.Tests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para ClientWebServicesTest y se pretende que
    ///contenga todas las pruebas unitarias ClientWebServicesTest.
    ///</summary>
    [TestClass()]
    public class ClientWebServicesTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private ClientWebServices target;
        private LocalWebServices local;
        /// <summary>
        ///Una prueba de CheckIn
        ///</summary>
        [TestMethod()]
        public void CheckInTest()
        {
            
            target = new ClientWebServices(1235, "Li8ujko97!"); // TODO: Inicializar en un valor adecuado
            local =  new LocalWebServices(2, "39420fdaff211d6a44f6b0cad166323d");

            Table[] enumerable = local.GetTables().ToArray();


            foreach (var i in enumerable.Where(x => x.CheckIns.Any()))
                local.CloseTable(i.Id);

            foreach (var i in enumerable.Where(x => x.Enabled))
                target.TableCheckIn(i.Id);

            foreach (var i in enumerable.Where(x => x.Enabled))
                local.CloseTable(i.Id);    
          
        }
    }
}
