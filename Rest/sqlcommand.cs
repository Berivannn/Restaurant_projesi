using System;
using System.Data.SqlClient;

namespace Rest
{
    internal class sqlcommand
    {
        internal object parameters;
        private string v;
        private sqlConnection con;

        public sqlcommand(string v, sqlConnection con)
        {
            this.v = v;
            this.con = con;
        }

        public object Parameters { get; internal set; }

        internal SqlDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }
    }
}