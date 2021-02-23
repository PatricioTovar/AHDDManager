using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{
    public class Result
    {
        private bool iRes;
        private string iMessage;
        private Object iObject;

        public void initialize()
        {
            this.iRes = true;
            this.iMessage = null;
            this.iObject = null;
        }

        public Result()
        {
            initialize();
        }

        public bool Res
        {
            get { return iRes; }
            set { iRes = value; }
        }
        public string Message
        {
            get { return iMessage; }
            set { iMessage = value; }
        }
        public Object Object
        {
            get { return iObject; }
            set { iObject = value; }
        }

    }
}
