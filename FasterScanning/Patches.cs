using Gameplay.TacticalTargeting;
using HarmonyLib;
using System.Reflection;
using UI.Core;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace FasterScanning
{
    [HarmonyPatch(typeof(TacticalScan), "AbilityStarted")]
    class KeybindDurationPatch
    {
        static FieldInfo stateFI = AccessTools.Field(typeof(InputActionMap), "m_State");
        //static FieldInfo interactionsFI = AccessTools.Field(typeof(InputAction), "m_Interactions");

        internal static HoldInteraction ScanTimeHI;
        internal static KeyBindVE KeyBindVEInstance;

        static void Postfix(TacticalScan __instance)
        {
            InputAction action = __instance.InputAction.action;

            //Fixes interactions string, which is utilized by UI to determine displayed scan time. Didn't work.
            //interactionsFI.SetValue(action, ((string)interactionsFI.GetValue(action)).Replace(BepinPlugin.Bindings.VanillaDefaultValue.ToString(), BepinPlugin.Bindings.ScanTimeMultiplier.Value.ToString()));

            //Adjusts hold duration in Unity InputAction and caches for later runtime changes.
            foreach (var thing in ((InputActionState)stateFI.GetValue(action.actionMap)).interactions)
            {
                if (thing is HoldInteraction holdInteraction && holdInteraction.duration == BepinPlugin.Bindings.VanillaDefaultValue)
                {
                    ScanTimeHI = holdInteraction;
                    holdInteraction.duration = BepinPlugin.Bindings.ActiveValue;
                    return;
                }
            }
        }
    }

    [HarmonyPatch(typeof(KeyBindVE), "GetHoldDuration")]
    class UIPatch
    {
        internal static FieldInfo DurationFI = AccessTools.Field(typeof(KeyBindVE), "_duration");
        
        static void Postfix(KeyBindVE __instance, ref float __result)
        {
            //Check if value is equivelant to vanilla and change. Nothing else uses a 2.5 second timer.
            if(__result == BepinPlugin.Bindings.VanillaDefaultValue)
            {
                KeybindDurationPatch.KeyBindVEInstance = __instance;
                __result = BepinPlugin.Bindings.ActiveValue;
            }
        }
    }
}
