using System;

namespace Rest
{
    internal class sqlConnection
    {
        private string v;

        public sqlConnection(string v)
        {
            this.v = v;
        }

        public object state { get; internal set; }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}