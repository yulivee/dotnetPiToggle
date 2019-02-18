using System;
using System.Diagnostics;
using System.Threading;

namespace RPiButtons
{
    class Program
    {
        static void Main(string[] args)
        {
            var cli = new Cli();
            var togglePin = new IoPin(8);
            var buttonSleep = 500;

            Console.WriteLine("Monitoring Gpio for MPC Status");

            while (true){
                if ( togglePin.ReadPin() ){
                    cli.MPCToggle();
                    Thread.Sleep(buttonSleep);
                }


            }

        }
    }
}
