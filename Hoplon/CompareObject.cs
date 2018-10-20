using System;
using System.Collections.Generic;
using System.Text;

namespace Hoplon {
    class CompareObject : IComparer<MyObject> {

        public int Compare(MyObject obj1, MyObject obj2) {
            int result;
            if (MyObject.ReferenceEquals(obj1, obj2)) {
                result = 0;
            } else {
                if (obj1 == null) {
                    result = 1;
                } else if (obj2 == null) {
                    result = -1;
                } else {
                    result = CompareString(obj1.key, obj2.key);
                    if (result == 0) {
                        result = CompareNumber(obj1.subIndex, obj2.subIndex);                        
                    }
                    if (result == 0) {
                        result = CompareString(obj1.value, obj2.value);
                    }
                }
            }
            return result;
        }

        int CompareString(string string1, string string2) {
            int result;
            if (string1 == null) {
                if (string2 == null) {
                    result = 0;
                } else {
                    result = 1;
                }
            } else {
                result = string1.CompareTo(string2);
            }
            return result;
        }

        int CompareNumber(int number1, int number2) {
            int result;
            if (number1 > number2) {
                result = 1;
            } else if (number1 < number2) {
                result = -1;
            } else {
                result = 0;
            }
            return result;
        }

    }
}
