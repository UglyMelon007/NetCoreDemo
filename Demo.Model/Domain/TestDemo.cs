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
        private string _id;
        private string _name;


        #endregion

        #region Constructors

        public TestDemo() { }

        public TestDemo(string name)
        {
            _name = name;
        }

        #endregion

        #region Public Properties
        public virtual string Id
        {
            get => _id;
            set
            {
                if (value != null && value.Length > 384)
                    throw new ArgumentOutOfRangeException("Invalid value for Id", value, value);
                _id = value;
            }
        }

        public virtual string Name
        {
            get => _name;
            set
            {
                if (value != null && value.Length > 192)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value);
                _name = value;
            }
        }



        #endregion
    }
    #endregion
}