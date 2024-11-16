using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace FasterScanning
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.USERS_PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency(VoidManager.MyPluginInfo.PLUGIN_GUID)]
    public class BepinPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = Logger;

            Bindings.ScanTimeMultiplier = Config.Bind("General", "ScanTimeMultiplier", 0.15f, new ConfigDescription("The currently active Scan Time multiplier. The host's value is automatically sent to clients and can be changed during runtime.", new AcceptableValueRange<float>(0f, 10f)));
            Bindings.ActiveValue = Bindings.ScanTimeMultiplier.Value * Bindings.VanillaDefaultValue;

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        internal class Bindings
        {
            internal const float VanillaDefaultValue = 2.5f;
            internal static ConfigEntry<float> ScanTimeMultiplier;
            internal static float ActiveValue;
        }

        public static string GetActiveValueForDisplay()
        {
            return (Bindings.ActiveValue / Bindings.VanillaDefaultValue).ToString("0.0#x");
        }

        public static void UpdateActiveValue(float CAV)
        {
            BepinPlugin.Bindings.ActiveValue = CAV;

            BepinPlugin.Log.LogInfo("Updating Active Value to " + CAV);

            if (KeybindDurationPatch.ScanTimeHI != null)
            {
                KeybindDurationPatch.ScanTimeHI.duration = CAV;
            }
            if (KeybindDurationPatch.KeyBindVEInstance != null)
            {
                UIPatch.DurationFI.SetValue(KeybindDurationPatch.KeyBindVEInstance, CAV);
            }
        }
    }
}