using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace RGBStrip
{
    public class Program
    {
        public static void Main()
        {

            AnalogInput potentiometer = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);

          //  AnalogInput potentiometer = new AnalogInput(Pins.GPIO_PIN_A0);

            InputPort button1 = new InputPort(Pins.GPIO_PIN_D0, false, Port.ResistorMode.Disabled);
            

            PWM redLED = new PWM(PWMChannels.PWM_PIN_D6, 100, .5, false);
            PWM greenLED = new PWM(PWMChannels.PWM_PIN_D5, 100, .5, false);
            PWM blueLED = new PWM(PWMChannels.PWM_PIN_D9, 100, .5, false);
            /*
            uint R = 0;
            uint G = 0;
            uint B = 0;
            */
            double Rdty = .5;
            double Gdty = .5;
            double Bdty = .5;

            uint Frequency_hz = 400;

            redLED.Frequency = Frequency_hz;
            redLED.DutyCycle = .5;
            redLED.Start();

            greenLED.Frequency = Frequency_hz;
            greenLED.DutyCycle = .5;
            greenLED.Start();

            blueLED.Frequency = Frequency_hz;
            blueLED.DutyCycle = .5;
            blueLED.Start();


            bool LEDState = false;

            while (true)
            {
                if (button1.Read())
                {
                    if (LEDState == true)
                    {
                        LEDState = false;
                    }
                    else
                    {
                        LEDState = true;
                    }
                }

                double sensorValue = 0;

                sensorValue = potentiometer.Read();

                double brightness = sensorValue;

              //  string sSensorValue = sensorValue.ToString;
                
              //  Debug.Print(sensorValue.ToString("F1"));
                if (LEDState == true)
                {
                    redLED.DutyCycle = sensorValue;
                    greenLED.DutyCycle = sensorValue;
                    blueLED.DutyCycle = sensorValue;
                    redLED.Frequency = Frequency_hz;
                    greenLED.Frequency = Frequency_hz;
                    blueLED.Frequency = Frequency_hz;

                }
                else
                {
                    redLED.DutyCycle = 0;
                    greenLED.DutyCycle = 0;
                    blueLED.DutyCycle = 0;
                    redLED.Frequency = 0;
                    greenLED.Frequency = 0;
                    blueLED.Frequency = 0;
                }

                Thread.Sleep(10);
            }         
      
        }

    }
}
