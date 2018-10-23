
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpectedObjects;
using System;

namespace Hoplon.UnitTest {

    [TestClass]
    public class MyObjectTest {

        [TestMethod]
        [Description("CreateObjectMyObject")]
        public void CreateObjectMyObject() {

            var myObjectExpected = new {
                key = "chave",
                subIndex = 1,
                value = "Rodrigo"
            };

            var myObject = new MyObject(myObjectExpected.key, myObjectExpected.subIndex, myObjectExpected.value);

            myObjectExpected.ToExpectedObject().ShouldMatch(myObject);

        }

        [DataTestMethod]
        [Description("KeyCannotBeInvalid")]
        [DataRow("")]
        [DataRow(null)]
        public void KeyCannotBeInvalid(string param) {
            try {
                MyObject myObject = new MyObject(param, 1, "Rodrigo");
            }
            catch (ArgumentException ex) {
                Assert.IsTrue(true, ex.Message);
            }
            catch (Exception) {
                Assert.Fail();
            }            
        }

        [DataTestMethod]
        [Description("ValueCannotBeInvalid")]
        [DataRow("")]
        [DataRow(null)]
        public void ValueCannotBeInvalid(string param) {
            try {
                MyObject myObject = new MyObject("chave", 1, param);
            }
            catch (ArgumentException ex) {
                Assert.IsTrue(true, ex.Message);
            }
            catch (Exception) {
                Assert.Fail();
            }
        }

    }
}
