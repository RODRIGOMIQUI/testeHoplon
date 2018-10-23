
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

        #region Properties

        public string key { get ; private set; }

        public int subIndex { get; private set; }

        public string value { get; private set; }

        #endregion

        #region Constructors

        public MyObject(string key, int subIndex, string value) {

            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be invalid");
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("value cannot be invalid");

            this.key = key;
            this.subIndex = subIndex;
            this.value = value;
        }

        #endregion

    }
}
