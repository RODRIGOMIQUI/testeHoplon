using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ExpectedObjects;

namespace Hoplon.UnitTest {

    [TestClass]
    public class MyCollectionTest {

        [TestMethod]
        [Description("CreateObjectMyCollection")]
        public void CreateObjectMyCollection() {
            MyCollection myCollection = new MyCollection();

            MyObject myObject = new MyObject("chave", 1, "Rodrigo");            
            myCollection.Add(myObject.key, myObject.subIndex, myObject.value);

            myObject = new MyObject("chave", 1, "João");
            myCollection.Add(myObject.key, myObject.subIndex, myObject.value);

            CollectionAssert.AllItemsAreNotNull(myCollection.ObjectsList);
            CollectionAssert.AllItemsAreInstancesOfType(myCollection.ObjectsList, typeof(MyObject));
        }

        [TestMethod]
        [Description("AddSortedItems")]
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
        [Description("RemoveRepeatedItem")]
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
        [Description("ListAllOfKey")]
        public void ListAllOfKey() {
            var myCollectionExpected = new List<string> { "a", "b", "c" };

            MyCollection myCollectionActual = new MyCollection();
            myCollectionActual.Add("chave", 1, "c");
            myCollectionActual.Add("chave", 1, "b");
            myCollectionActual.Add("chave", 1, "a");
            myCollectionActual.Add("porta", 1, "a");
            myCollectionActual.Add("porta", 1, "b");

            var listActual = myCollectionActual.Get("chave", 0, -1);

            myCollectionExpected.ToExpectedObject().ShouldMatch(listActual);
        }

    }
}
