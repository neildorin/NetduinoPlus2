using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Blinky
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            InputPort button = new InputPort(Pins.ONBOARD_BTN, false, Port.ResistorMode.Disabled);

            bool buttonState = false;

            int count = 0;
            int blinkspeed = 250;

            
            while (true)
            {
               /* buttonState = button.Read();

                led.Write(!buttonState);*/

                if ((count % 2) > 0)
                {
                    blinkspeed = 500;
                }
                else
                {
                    blinkspeed = 250;
                }

                led.Write(true);
                Thread.Sleep(blinkspeed);
                led.Write(false);
                Thread.Sleep(blinkspeed);

                count++;

            }

        }

    }
}
