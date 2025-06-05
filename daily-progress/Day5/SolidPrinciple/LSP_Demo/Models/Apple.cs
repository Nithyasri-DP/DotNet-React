using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP_Demo.Models
{
    public class Apple : IFruit
    {
        public string GetColor()
        {
            return "Red";
        }
    }
}
