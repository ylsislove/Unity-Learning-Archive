using UnityEditor;

namespace LearningArchive.Framework.ResKit.Editor
{
    public class SimulationModeMenu
    {
        private const string kSimulationModeKey  = "simulation mode";
        private const string kSimulationModePath = "LearningArchive/Framework/ResKit/Simulation Mode";

        [MenuItem(kSimulationModePath)]
        private static void ToggleSimulationMode()
        {
            ResMgr.SimulationMode = !ResMgr.SimulationMode;
        }		
	
        [MenuItem(kSimulationModePath, true)]
        public static bool ToggleSimulationModeValidate ()
        {
            Menu.SetChecked(kSimulationModePath, ResMgr.SimulationMode);
            return true;
        }
    }
}