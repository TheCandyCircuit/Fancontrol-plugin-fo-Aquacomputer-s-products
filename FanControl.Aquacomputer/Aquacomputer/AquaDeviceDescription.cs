using System;

namespace TCC_AquaComputer.Aquacomputer
{
    public class AquaDeviceDescription
    {
        public string myName;
        public int myDeviceHIDId;
        public Type myClass;
        static public AquaDeviceDescription[] ourSupportedDevices =
        {
            new AquaDeviceDescription{ myDeviceHIDId = 0x0c70 ,myClass = typeof(BaseAquaDevice), myName = "AQUACOMPUTER" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf001 ,myClass = typeof(BaseAquaDevice), myName = "AQUAERO" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf00a ,myClass = typeof(BaseAquaDevice), myName = "FARBWERK" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf00d ,myClass = typeof(BaseAquaDevice), myName = "QUADRO" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf00e ,myClass = typeof(D5Next), myName = "D5NEXT" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf011 ,myClass = typeof(BaseAquaDevice), myName = "OCTO" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf012 ,myClass = typeof(BaseAquaDevice), myName = "HIGHFLOWNEXT" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf014 ,myClass = typeof(LeakShield), myName = "LEAKSHIELD" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf0b6 ,myClass = typeof(BaseAquaDevice), myName = "AQUASTREAMXT" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf00b ,myClass = typeof(BaseAquaDevice), myName = "AQUASTREAMULT" },
            new AquaDeviceDescription{ myDeviceHIDId = 0xf0bd ,myClass = typeof(BaseAquaDevice), myName = "POWERADJUST3" }
        };       
    }
}
