using System;

namespace Demo.Model.Domain
{
    #region TESTDEMO

    /// <summary>
    /// TESTDEMO object for NHibernate mapped table 'TESTDEMO'.
    /// </summary>
    public class TESTDEMO
    {
        #region Member Variables
        private string _id;
        private string _sTAFFNAME;


        #endregion

        #region Constructors

        public TESTDEMO() { }

        public TESTDEMO(string sTAFFNAME)
        {
            this._sTAFFNAME = sTAFFNAME;
        }

        #endregion

        #region Public Properties
        public virtual string Id
        {
            get => _id;
            set
            {
                if (value != null && value.Length > 384)
                    throw new ArgumentOutOfRangeException("Invalid value for Id", value, value.ToString());
                _id = value;
            }
        }

        public virtual string STAFFNAME
        {
            get => _sTAFFNAME;
            set
            {
                if (value != null && value.Length > 192)
                    throw new ArgumentOutOfRangeException("Invalid value for STAFFNAME", value, value.ToString());
                _sTAFFNAME = value;
            }
        }



        #endregion
    }
    #endregion
}