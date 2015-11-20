using Microsoft.VisualStudio.TestTools.UnitTesting;
using nJupiter.DataAccess.Ldap.Extensions;

namespace nJupiter.DataAccess.Ldap.Test
{
    /// <summary>
    /// Summary description for DomainExtensionsTest
    /// </summary>
    [TestClass]
    public class DomainExtensionsTest
    {
        [TestMethod]
        public void Filter_Domain_Empty()
        {
            // Arrange
            var accountName = "";

            // Act
            var result = accountName.FilterDomain();

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Filter_Domain_No_Domain()
        {
            // Arrange
            var accountName = "user";

            // Act
            var result = accountName.FilterDomain();

            // Assert
            Assert.AreEqual("user", result);
        }

        [TestMethod]
        public void Filter_Domain_From_Account()
        {
            // Arrange
            var accountName = "domain\\user";

            // Act
            var result = accountName.FilterDomain();

            // Assert
            Assert.AreEqual("user", result);
        }

        [TestMethod]
        public void Filter_Domain_Multiple_Slash()
        {
            // Arrange
            var accountName = "domain\\com\\user";

            // Act
            var result = accountName.FilterDomain();

            // Assert
            Assert.AreEqual("user", result);
        }
    }
}
