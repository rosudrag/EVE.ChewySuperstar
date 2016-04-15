using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewySuperstar.Main
{
    public class DefaultAction : EVEAction
    {
        protected override void ExecuteAction()
        {
        }

        public bool? HasExecutedSuccesfully()
        {
            return ExecuteStatus;
        }
    }
}
