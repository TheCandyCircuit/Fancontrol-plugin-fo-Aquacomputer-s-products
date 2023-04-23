using FanControl.Plugins;
using TCC_AquaComputer.Aquacomputer;

namespace TCC
{
    public class AquacomputerProductsPlugin : IPlugin2
    {
        string IPlugin.Name => "Aquacomputer Plugin by TCC";
        AquaManager myAquaManager;
        public void Initialize()
        {
            myAquaManager = new AquaManager();
            myAquaManager.Start();
        }

        public void Close()
        {
            myAquaManager.Stop();
        }


        public void Load(IPluginSensorsContainer aPluginContainer)
        {
            myAquaManager.Init(aPluginContainer);
        }

        public void Update()
        {
        }
    }
}