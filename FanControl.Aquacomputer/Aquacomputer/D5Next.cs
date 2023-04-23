using FanControl.Plugins;
using System;

namespace TCC_AquaComputer.Aquacomputer
{
    public class D5Next : BaseAquaDevice
    {
        PluginSensor myWaterSensor;
        PluginSensor myPumpSpeedPercent;
        PluginSensor myFanSpeedPercent;
        PluginSensor my5VoltRail;
        PluginSensor my12VoltRail;
        

        const int COOLANT_TEMP = 0x57;
        const int D5NEXT_PUMP_OFFSET = 0x6c;
        const int D5NEXT_FAN_OFFSET = 0x5f;
        const int VOLTAGE_5V = 0x39;
        const int VOLTAGE_12V =	0x37;

        const int NUM_VIRTUAL_SENSORS = 8;
        const int D5NEXT_VIRTUAL_SENSORS_START = 0x3f;


        protected override void ParseData(byte[] someData)
        {
            base.ParseData(someData);
            my5VoltRail.Value = Read16(someData, VOLTAGE_5V) / 100.0f;
            my12VoltRail.Value = Read16(someData, VOLTAGE_12V) / 100.0f;
            UInt16 TempWaterTemp = Read16(someData, COOLANT_TEMP);
            if (NA!= TempWaterTemp)
            {
                myWaterSensor.Value = TempWaterTemp / 100.0f;
            }
            myPumpSpeedPercent.Value = ReadPumpRPM(someData, D5NEXT_PUMP_OFFSET);
            myFanSpeedPercent.Value = ReadFanRPM(someData, D5NEXT_FAN_OFFSET);
        }

        protected override void SubInit(IPluginSensorsContainer aPluginContainer)
        {
            base.SubInit(aPluginContainer);

            myWaterSensor = new PluginSensor("Water Temp", "ID");
            aPluginContainer.TempSensors.Add(myWaterSensor);

            myPumpSpeedPercent = new PluginSensor("Pump %", "ID");
            aPluginContainer.TempSensors.Add(myPumpSpeedPercent);

            myFanSpeedPercent = new PluginSensor("Fan %", "ID");
            aPluginContainer.TempSensors.Add(myFanSpeedPercent);

            my5VoltRail = new PluginSensor("5V", "ID");
            aPluginContainer.TempSensors.Add(my5VoltRail);

            my12VoltRail = new PluginSensor("12V", "ID");
            aPluginContainer.TempSensors.Add(my12VoltRail);

        }
    }
}
