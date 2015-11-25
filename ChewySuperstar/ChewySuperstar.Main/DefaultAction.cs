using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerSpaceAPI;

namespace ChewySuperstar.Main
{
    public class DefaultAction : IEVEAction
    {
        private int executeCount;

        public void Execute()
        {
            InnerSpace.Echo(string.Format("{0:HH:mm:ss} Execute Count: {1}", DateTime.Now, executeCount++));
        }
    }
}
