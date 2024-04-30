using Photon.Realtime;
using VoidManager.ModMessages;
using VoidManager.MPModChecks;

namespace FasterScanning
{
    internal class UpdateActiveScanTimeMessage : ModMessage
    {
        internal static UpdateActiveScanTimeMessage Instance;

        public UpdateActiveScanTimeMessage()
        {
            Instance = this;
        }

        internal void SendToPlayer(Player player)
        {
            Send(MyPluginInfo.PLUGIN_GUID, Instance.GetIdentifier(), player, new object[] { BepinPlugin.Bindings.ActiveValue }, true);
        }

        internal void SendToOthers()
        {
            Send(MyPluginInfo.PLUGIN_GUID, Instance.GetIdentifier(), MPModCheckManager.Instance.NetworkedPeersWithMod(MyPluginInfo.PLUGIN_GUID).ToArray(), new object[] { BepinPlugin.Bindings.ActiveValue }, true);
        }

        public override void Handle(object[] arguments, Photon.Realtime.Player sender)
        {
            if (sender.IsMasterClient)
            {
                float CAV = (float)arguments[0];
                BepinPlugin.UpdateActiveValue(CAV);
            }
        }
    }
}
