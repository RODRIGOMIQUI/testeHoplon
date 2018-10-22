using System;
using System.Collections.Generic;
using System.Text;

namespace Hoplon {

    public abstract class BaseObject : IEquatable<BaseObject> {
        public BaseObject() { }

        #region IEquatable<EntityBase> Members

        public bool Equals(BaseObject other) {
            //Generic implementation of equality using reflection on derived class instance.
            return true;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as BaseObject);
        }

        public override int GetHashCode() {
            return 0;
        }

        #endregion

    }

    public class MyObject : BaseObject {

        #region Atributes

        private string _key;
        private int _subIndex;
        private string _value;

        #endregion

        #region Properties

        public string key {
            get {
                return _key;
            }
            set {
                _key = value;
            }
        }

        public int subIndex {
            get {
                return _subIndex;
            }
            set {
                _subIndex = value;
            }
        }

        public string value {
            get {
                return _value;
            }
            set {
                _value = value;
            }
        }

        #endregion

        #region Constructors

        public MyObject(string key, int subIndex, string value) {
            this.key = key;
            this.subIndex = subIndex;
            this.value = value;
        }

        #endregion

    }
}
