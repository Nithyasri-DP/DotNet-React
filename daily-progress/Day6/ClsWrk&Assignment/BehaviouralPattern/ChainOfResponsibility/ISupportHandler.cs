using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviouralPattern.ChainOfResponsibility
{
    public abstract class ISupportHandler
    {
        protected ISupportHandler nextHandler;

        public void SetNext(ISupportHandler next)
        {
            nextHandler = next;
        }

        public abstract void HandleRequest(string issueType);
    }

    public class Level1Support : ISupportHandler
    {
        public override void HandleRequest(string issueType)
        {
            if (issueType == "password reset")
            {
                Console.WriteLine("\nLevel 1 Support handled: Resetting password.");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(issueType);
            }
        }
    }

    public class Level2Support : ISupportHandler
    {
        public override void HandleRequest(string issueType)
        {
            if (issueType == "software issue")
            {
                Console.WriteLine("Level 2 Support handled: Working on software issue.");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(issueType);
            }
        }
    }

    public class ManagerSupport : ISupportHandler
    {
        public override void HandleRequest(string issueType)
        {
            Console.WriteLine($"Manager handled: {issueType}.");
        }
    }
}
