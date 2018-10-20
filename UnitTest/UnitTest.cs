using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hoplon;
using System.Collections.Generic;

namespace UnitTest {

    [TestClass]
    public class UnitTest {

        [TestMethod]
        public void AddSortedItemsTrue() {
            MyCollection myCollectionActual = new MyCollection();
            myCollectionActual.Add("classe", 0, "Rodrigo");
            myCollectionActual.Add("classe", 0, "Anderson");
            myCollectionActual.Add("classe", 0, "Juliana");
            myCollectionActual.Add("assinaturas", 1, "Juliana");

            MyCollection myCollectionExpected = new MyCollection();
            myCollectionExpected.Add("assinaturas", 1, "Juliana");
            myCollectionExpected.Add("classe", 0, "Anderson");
            myCollectionExpected.Add("classe", 0, "Juliana");
            myCollectionExpected.Add("classe", 0, "Rodrigo");

            CollectionAssert.AllItemsAreInstancesOfType(myCollectionActual.ObjectsList, typeof(MyCollection));
            CollectionAssert.AllItemsAreInstancesOfType(myCollectionExpected.ObjectsList, typeof(MyCollection));
            CollectionAssert.AreEqual(myCollectionExpected.ObjectsList, myCollectionActual.ObjectsList);
        }

        [TestMethod]
        public void AddSortedItemsFalse() {
            MyCollection myCollectionActual = new MyCollection();
            myCollectionActual.Add("classe", 0, "Rodrigo");
            myCollectionActual.Add("classe", 0, "Anderson");

            MyCollection myCollectionExpected = new MyCollection();
            myCollectionExpected.Add("classe", 0, "Rodrigo");
            myCollectionExpected.Add("classe", 0, "Anderson");

            CollectionAssert.AllItemsAreInstancesOfType(myCollectionActual.ObjectsList, typeof(MyCollection));
            CollectionAssert.AllItemsAreInstancesOfType(myCollectionExpected.ObjectsList, typeof(MyCollection));
            CollectionAssert.AreEqual(myCollectionExpected.ObjectsList, myCollectionActual.ObjectsList);
        }

        [TestMethod]
        public void RemoveRepeatedItemTrue() {
            MyCollection myCollectionActual = new MyCollection();
            myCollectionActual.Add("classe", 0, "Rodrigo");
            myCollectionActual.Add("classe", 0, "Rodrigo");

            MyCollection myCollectionExpected = new MyCollection();
            myCollectionExpected.Add("classe", 0, "Rodrigo");

            CollectionAssert.AreEqual(myCollectionExpected.ObjectsList, myCollectionActual.ObjectsList);
            CollectionAssert.AllItemsAreUnique(myCollectionActual.ObjectsList);
        }

        [TestMethod]
        public void RemoveRepeatedItemFalse() {
            MyCollection myCollectionActual = new MyCollection();
            myCollectionActual.Add("classe", 0, "Rodrigo");
            myCollectionActual.Add("classe", 0, "Rodrigo");

            MyCollection myCollectionExpected = new MyCollection();
            myCollectionExpected.Add("classe", 0, "Rodrigo");
            MyObject myObject = new MyObject("classe", 0, "Rodrigo");
            myCollectionExpected.ObjectsList.Add(myObject);

            CollectionAssert.AreNotEqual(myCollectionExpected.ObjectsList, myCollectionActual.ObjectsList);
            CollectionAssert.AllItemsAreUnique(myCollectionActual.ObjectsList);
        }

        [TestMethod]
        public void ListAllOfKeyTrue() {
            MyCollection myCollectionActual = new MyCollection();
            myCollectionActual.Add("chave", 1, "c");
            myCollectionActual.Add("chave", 1, "b");
            myCollectionActual.Add("chave", 1, "a");
            myCollectionActual.Add("porta", 1, "a");
            myCollectionActual.Add("porta", 1, "b");

            var listActual = myCollectionActual.Get("chave", 0, -1);
            List<string> listExpected = new List<string>() { "a", "b", "c" };
            //CollectionAssert.AreEqual(listExpected, listActual);
        }

    }
}
