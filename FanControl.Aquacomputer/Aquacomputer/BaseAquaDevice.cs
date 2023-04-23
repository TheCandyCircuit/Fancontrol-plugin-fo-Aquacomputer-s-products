using FanControl.Plugins;
using HidLibrary;
using System;
using System.Buffers.Binary;

namespace TCC_AquaComputer.Aquacomputer
{
    public class BaseAquaDevice
    {
        protected class PluginSensor : IPluginSensor
        {
            public PluginSensor(string aName, string anId) 
            { 
                Name = aName;
                Id= anId;
                Value= 0.0f;
            }

            public string Name { get; }

            public float? Value { get; internal set; }

            public string Id { get; }

            public void Update()
            {
            }
        }

        protected const int NA = 0x7FFF;
        HidDevice myDDevice;
        bool myIsPlugged;
        public void Init(HidDevice aDevice,IPluginSensorsContainer aPluginContainer)
        {
            SubInit(aPluginContainer);
            myDDevice = aDevice;
            myIsPlugged = true;

            myDDevice.OpenDevice();
            myDDevice.Inserted += OnInsert;
            myDDevice.Removed += OnRemove;
            myDDevice.MonitorDeviceEvents = true;
            myDDevice.ReadReport(OnReport);
        }

        protected virtual void SubInit(IPluginSensorsContainer aPluginContainer)
        {

        }
        
        protected UInt32 Read32(byte[] someData,int anOffset)
        {
            return BinaryPrimitives.ReverseEndianness(BitConverter.ToUInt32(someData, anOffset));
        }

        protected UInt16 Read16(byte[] someData, int anOffset)
        {
            return BinaryPrimitives.ReverseEndianness(BitConverter.ToUInt16(someData, anOffset));
        }

        protected UInt16 ReadPumpRPM(byte[] someData, int anOffset)
        {
            UInt16 value = Read16(someData, anOffset);
            value = (UInt16)(value / 100);
            return value;
        }

        protected UInt16 ReadFanRPM(byte[] someData, int anOffset)
        {
            UInt16 value = Read16(someData, anOffset);
            value = (UInt16)(value / 100);
            return value;
        }

        private void OnReport(HidReport aReport)
        {
            if (myIsPlugged)
            {
                ParseData(aReport.GetBytes());
                myDDevice.ReadReport(OnReport);
            }
        }

        protected virtual void ParseData(byte[] bytes)
        {
        }

        private void OnRemove()
        {
            myIsPlugged = false;
        }

        private void OnInsert()
        {
            myIsPlugged = true;
            myDDevice.ReadReport(OnReport);
        }

        public void Shutdown()
        {
            myDDevice.MonitorDeviceEvents = false;
            myIsPlugged = false;
            myDDevice.Inserted -= OnInsert;
            myDDevice.Removed -= OnRemove;
            myDDevice.CloseDevice();
            myDDevice.Dispose();
        }
    }
}
