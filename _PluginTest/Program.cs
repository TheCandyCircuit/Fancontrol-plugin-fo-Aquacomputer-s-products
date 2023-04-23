// See https://aka.ms/new-console-template for more information
using FanControl.Plugins;
using TCC;

Console.WriteLine("Hello, World!");
AquacomputerProductsPlugin Plugin = new AquacomputerProductsPlugin();
TestPlugin data = new TestPlugin();
Plugin.Initialize();
Plugin.Load(data);

while(true)
{
    Thread.Sleep(1000);
    for(int i=0;i<data.TempSensors.Count;i++)
    {
        Console.WriteLine(data.TempSensors[i].Name + ": "+ data.TempSensors[i].Value);
    }
}


class TestPlugin : IPluginSensorsContainer
{
    public List<IPluginControlSensor> ControlSensors => new List<IPluginControlSensor>();

    public List<IPluginSensor> FanSensors => new List<IPluginSensor>();

    public List<IPluginSensor> TempSensors => new List<IPluginSensor>();
}

