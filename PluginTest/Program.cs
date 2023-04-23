using FanControl.Plugins;
using System;
using System.Collections.Generic;
using System.Threading;
using TCC;

namespace PluginTest
{
    class Program
    {
        class TestPlugin : IPluginSensorsContainer
        {
            public TestPlugin()
            {
                ControlSensors = new List<IPluginControlSensor>();
                FanSensors = new List<IPluginSensor>();
                TempSensors = new List<IPluginSensor>();
            }

            public List<IPluginControlSensor> ControlSensors { get; }
            public List<IPluginSensor> FanSensors { get; }
            public List<IPluginSensor> TempSensors { get; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AquacomputerProductsPlugin Plugin = new AquacomputerProductsPlugin();
            TestPlugin data = new TestPlugin();
            Plugin.Initialize();
            Plugin.Load(data);

            while (true)
            {
                Thread.Sleep(1000);
                for (int i = 0; i < data.TempSensors.Count; i++)
                {
                    Console.WriteLine(data.TempSensors[i].Name + ": " + data.TempSensors[i].Value);
                }
            }
        }
    }
}
