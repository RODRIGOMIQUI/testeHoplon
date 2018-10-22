using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hoplon;
using System.Collections.Generic;

namespace UnitTest {

    [TestClass]
    public class MyCollectionTest {

        [TestMethod]
        public void AddSortedItems() {

            MyCollection myCollectionExpected = new MyCollection();
            MyCollection myCollectionActual = new MyCollection();

            myCollectionExpected.Add("assinaturas", 1, "Juliana");
            myCollectionExpected.Add("classe", 0, "Anderson");
            myCollectionExpected.Add("classe", 0, "Juliana");
            myCollectionExpected.Add("classe", 0, "Rodrigo");

            myCollectionActual.Add("classe", 0, "Rodrigo");
            myCollectionActual.Add("classe", 0, "Anderson");
            myCollectionActual.Add("classe", 0, "Juliana");
            myCollectionActual.Add("assinaturas", 1, "Juliana");

            CollectionAssert.AreEqual(myCollectionExpected.ObjectsList, myCollectionActual.ObjectsList);
        }

        [TestMethod]
        public void RemoveRepeatedItem() {
            MyCollection myCollectionActual = new MyCollection();
            myCollectionActual.Add("classe", 0, "Rodrigo");
            myCollectionActual.Add("classe", 0, "Rodrigo");

            MyCollection myCollectionExpected = new MyCollection();
            myCollectionExpected.Add("classe", 0, "Rodrigo");

            CollectionAssert.AreEqual(myCollectionExpected.ObjectsList, myCollectionActual.ObjectsList);
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
