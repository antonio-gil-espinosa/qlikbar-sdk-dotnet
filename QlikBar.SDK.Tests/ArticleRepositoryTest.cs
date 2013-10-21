using QlikBar.SDK.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QlikBar.SDK.DTOs;
using System.Collections.Generic;
using System.Collections;

namespace QlikBar.SDK.Tests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para ArticleRepositoryTest y se pretende que
    ///contenga todas las pruebas unitarias ArticleRepositoryTest.
    ///</summary>
    [TestClass()]
    public class ArticleRepositoryTest
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

        private ArticleRepository target;
        /// <summary>
        ///Una prueba de Constructor ArticleRepository
        ///</summary>
        [TestMethod()]
        public void ArticleRepositoryConstructorTest()
        {
            target = new ArticleRepository(localId, apiKey);

        }

        /// <summary>
        ///Una prueba de Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            Article item = null; // TODO: Inicializar en un valor adecuado
            target.Add(item);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            target.Clear();
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            Article item = null; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.Contains(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de CopyTo
        ///</summary>
        [TestMethod()]
        public void CopyToTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            Article[] array = null; // TODO: Inicializar en un valor adecuado
            int arrayIndex = 0; // TODO: Inicializar en un valor adecuado
            target.CopyTo(array, arrayIndex);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            IEnumerator<Article> expected = null; // TODO: Inicializar en un valor adecuado
            IEnumerator<Article> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            Article item = null; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.Remove(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest1()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            int value = 0; // TODO: Inicializar en un valor adecuado
            target.Remove(value);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("QlikBar.SDK.dll")]
        public void GetEnumeratorTest1()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            IEnumerable target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            IEnumerator expected = null; // TODO: Inicializar en un valor adecuado
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            Article value = null; // TODO: Inicializar en un valor adecuado
            target.Update(value);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de IsReadOnly
        ///</summary>
        [TestMethod()]
        public void IsReadOnlyTest()
        {
            int localId = 0; // TODO: Inicializar en un valor adecuado
            string apiKey = string.Empty; // TODO: Inicializar en un valor adecuado
            ArticleRepository target = new ArticleRepository(localId, apiKey); // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.IsReadOnly;
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }
    }
}
