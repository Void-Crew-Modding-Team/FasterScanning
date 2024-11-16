using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoidManager.CustomGUI;
using VoidManager.Utilities;
using static UnityEngine.GUILayout;

namespace FasterScanning
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name()
        {
            return $"{MyPluginInfo.USERS_PLUGIN_NAME} - {BepinPlugin.GetActiveValueForDisplay()}";
        }

        string ScanMultiplierString = string.Empty;

        public override void Draw()
        {
            if (Game.InGame && !PhotonNetwork.IsMasterClient)
            {
                Label("Must be host to configure. Current setting: " + BepinPlugin.GetActiveValueForDisplay());
                return;
            }

            Label("Scan Time Multiplier");
            ScanMultiplierString = TextField(ScanMultiplierString);

            if (float.TryParse(ScanMultiplierString, out float value) && value >= 0f && value <= 10f)
            {
                if (Button("Apply Setting - Current value: " + BepinPlugin.GetActiveValueForDisplay()))
                {
                    BepinPlugin.Bindings.ScanTimeMultiplier.Value = value;
                    BepinPlugin.UpdateActiveValue(value * BepinPlugin.Bindings.VanillaDefaultValue);
                    UpdateActiveScanTimeMessage.Instance.SendToOthers();
                }
            }
            else
            {
                Label("Cannot Change Setting - Must be a number between 0 and 10.");
            }
        }

        public override void OnOpen()
        {
            ScanMultiplierString = BepinPlugin.Bindings.ScanTimeMultiplier.Value.ToString();
        }
    }
}
