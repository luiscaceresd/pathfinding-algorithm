using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class RoverApplication
    {
        private ApplicationController appController;

        public RoverApplication()
        {
            appController = new ApplicationController();
        }

        public void Run()
        {
            appController.Run();
        }
    }
}
