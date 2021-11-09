using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectCodeJarAPA.Tests
{
    /// <summary>
    /// Summary description for CoinJarControllersTests
    /// </summary>
    [TestClass]
    public class CoinJarControllersTests
    {
        [TestMethod]
        publicvoid EmployeeGetById()
        {
            // Set up Prerequisites   
            var controller = new CoinJarController();
            controller.Request = newHttpRequestMessage();
            controller.Configuration = newHttpConfiguration();
            // Act on Test  
            var response = controller.Get(1);
            // Assert the result  
            Employee employee;
            Assert.IsTrue(response.TryGetContentValue<Employee>(out employee));
            Assert.AreEqual("Jignesh", employee.Name);
        }
    }
}
