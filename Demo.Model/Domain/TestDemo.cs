using System;

namespace Demo.Model.Domain
{
    #region TestDemo

    /// <summary>
    /// TESTDEMO object for NHibernate mapped table 'TESTDEMO'.
    /// </summary>
    public class TestDemo
    {
        #region Member Variables
        protected string _id;
        protected string _name;


        #endregion

        #region Constructors

        public TestDemo() { }

        public TestDemo(string name)
        {
            this._name = name;
        }

        #endregion

        #region Public Properties
        public virtual string Id
        {
            get { return _id; }
            set
            {
                if (value != null && value.Length > 384)
                    throw new ArgumentOutOfRangeException("Invalid value for Id", value, value.ToString());
                _id = value;
            }
        }

        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (value != null && value.Length > 192)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
                _name = value;
            }
        }



        #endregion
    }
    #endregion
}