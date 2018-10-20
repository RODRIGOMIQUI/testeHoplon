using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Hoplon {

    public class MyCollection : IHoplonCollection {

        #region Attributes
                
        private List<MyObject> _objectsList;

        #endregion

        #region Properties

        public List<MyObject> ObjectsList {
            get {
                return _objectsList;
            }
            set {
                _objectsList = value;
            }
        }

        public int totalItens {
            get {
                return ObjectsList.Count;
            }
        }

        #endregion

        #region Constructors

        public MyCollection() {
            ObjectsList = new List<MyObject>();
        }

        #endregion

        #region Methods

        public bool Add(string key, int subIndex, string value) {
            //var s1 = Stopwatch.StartNew();
            MyObject newObj = new MyObject(key, subIndex, value);
            if (ObjectsList.Count == 0) {

                ObjectsList.Add(newObj);

            } else {

                //Caso seja chamado esta API com um valor que já foi mapeado para a chave e para algum subIndice, o valor antigo deve ser removido e o novo valor deve ser adicionado na posição correta considerando ordem crescente.
                if (ObjectsList.Exists(e => e.key == newObj.key && e.subIndex == newObj.subIndex && e.value == newObj.value)) {
                    var indexToRemove = ObjectsList.FindIndex(e => e.key == newObj.key && e.subIndex == newObj.subIndex && e.value == newObj.value);
                    ObjectsList.RemoveAt(indexToRemove);
                }
                IComparer<MyObject> compare = new CompareObject();
                int binarySearchIndex = ObjectsList.BinarySearch(newObj, (IComparer<MyObject>)compare);
                if (binarySearchIndex < 0) {
                    ObjectsList.Insert(~binarySearchIndex, newObj);
                }

                //ObjectsList.Add(myObj);
                //List<MyObject> sortedList = ObjectsList.OrderBy(order => order.key)
                //    .ThenBy(order => order.subIndex)
                //    .ThenBy(order => order.value)
                //    .ToList();
                //ObjectsList.Clear();
                //foreach (MyObject item in sortedList) {
                //    ObjectsList.Add(item);
                //}

            }
            //s1.Stop();
            //Console.WriteLine(s1.Elapsed.TotalMilliseconds);
            return true;
        }

        public IList<string> Get(string key, int start, int end) {

            //Resultado
            IList<string> resultList = new List<string>();

            //Filtro por key
            List <MyObject> sortedList = ObjectsList.FindAll(x => x.key == key).ToList();

            if (sortedList.Count > 0) { 
            
                //Caso o parâmetro start seja menor que zero, deve ser considerado como se fosse o primeiro elemento.
                if (start < 0) {
                    start = 0;
                }

                int offset = 0;
                if (end > sortedList.Count) {
                    //Caso o parâmetro end seja maior que o numero de elementos, deve ser considerado como se fosse o último elemento.
                    offset = sortedList.Count - 1;
                } else if (end < 0) {
                    //O parâmetro end pode ter valores negativos, neste caso ele funciona como um offset considerando o útimo elemento.Exemplo: -1 vai retornar o último elemento, -2 vai retornar o penúltimo elemento e assim por diante.
                    offset = sortedList.Count + end;
                } else {
                    offset = end;
                }

                sortedList = sortedList.OrderBy(order => order.key)
                    .ThenBy(order => order.subIndex)
                    .ThenBy(order => order.value)
                    .ToList();

                var values = sortedList.GetRange(start, offset + 1)
                    .Select((obj, v) => new { obj, v })
                    .Select(x => x.obj.value);
                
                foreach (var item in values) {
                    resultList.Add(item);
                }
            }
            
            return resultList;
        }

        public bool RemoveElement(string key) {
            ObjectsList.RemoveAll(e => e.key == key);
            return true;
        }

        public bool RemoveValuesFromSubIndex(string key, int subIndex) {
            ObjectsList.RemoveAll(e => e.key == key && e.subIndex == subIndex);
            return true;
        }

        #endregion

        #region Auxiliar Methods

        public IList<string> List() {
            IList<string> resultList = new List<string>();
            var values = ObjectsList.Select((obj, v) => new { obj, v })
                .Select(x => x.obj.value);
            foreach (var item in values) {
                resultList.Add(item);
            }
            return resultList;
        }

        #endregion

    }
}
