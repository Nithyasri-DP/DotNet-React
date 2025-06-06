using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviouralPattern.ChainOfResponsibility
{
    public class ChainOfResponsibilityDemo
    {
        public static void Run()
        {
            ISupportHandler level1 = new Level1Support();
            ISupportHandler level2 = new Level2Support();
            ISupportHandler manager = new ManagerSupport();

            level1.SetNext(level2);
            level2.SetNext(manager);

            level1.HandleRequest("password reset");
            level1.HandleRequest("software issue");
            level1.HandleRequest("Admin Request");
        }
    }
}
