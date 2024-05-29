using Gameplay.TacticalTargeting;
using HarmonyLib;
using System;
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

    [HarmonyPatch(typeof(KeyBindVE), "Init", new Type[] { typeof(InputAction), typeof(bool) })]
    class UIPatch
    {
        internal static FieldInfo DurationFI = AccessTools.Field(typeof(KeyBindVE), "duration");
        
        static void Postfix(KeyBindVE __instance)
        {
            //Adjusts displayed hold time for completion and caches for later runtime changes.
            if((float)DurationFI.GetValue(__instance) == BepinPlugin.Bindings.VanillaDefaultValue)
            {
                KeybindDurationPatch.KeyBindVEInstance = __instance;
                DurationFI.SetValue(__instance, BepinPlugin.Bindings.ActiveValue);
            }
        }
    }
}
