using FanControl.Plugins;
using HidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TCC_AquaComputer.Aquacomputer
{
    public class AquaManager
    {
        static readonly int ourVendorID = 0x0c70;
        List<BaseAquaDevice> myDevices;

        public void Start()
        {
            myDevices = new List<BaseAquaDevice>();
        }

        public void Stop() 
        { 
            if (myDevices != null)
            {
                for (int i = 0; i < myDevices.Count; i++) 
                {
                    myDevices[i].Shutdown();
                }
                myDevices.Clear();
            }
        }

        internal void Init(IPluginSensorsContainer aPluginContainer)
        {
            for (int i = 0; i < AquaDeviceDescription.ourSupportedDevices.Length; i++)
            {
                AquaDeviceDescription desc = AquaDeviceDescription.ourSupportedDevices[i];
                IEnumerable<HidDevice> devices = HidDevices.Enumerate(ourVendorID, desc.myDeviceHIDId);
                if (devices != null)
                {
                    for (int j = 0; j < devices.Count(); j++)
                    {
                        BaseAquaDevice newdevice = (BaseAquaDevice)Activator.CreateInstance(desc.myClass);
                        if (newdevice != null)
                        {
                            newdevice.Init(devices.ElementAt(j), aPluginContainer);
                            myDevices.Add(newdevice);
                        }
                    }
                }
            }

        }

        private void Spawn(AquaDeviceDescription aDescription, List<BaseAquaDevice> oDevices)
        {
           
        }

    }
}
