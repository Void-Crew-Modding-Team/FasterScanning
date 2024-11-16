using System;
using VoidManager;
using VoidManager.MPModChecks;

namespace FasterScanning
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public VoidManagerPlugin()
        {
            Events.Instance.HostVerifiedClient += HostVerifiedClient;
            Events.Instance.JoinedRoom += ClientJoinSession;
            Events.Instance.HostStartSession += HostStartSession;
        }

        static void HostVerifiedClient(object source, Events.PlayerEventArgs Player)
        {
            if (MPModCheckManager.Instance.NetworkedPeerHasMod(Player.player, MyPluginInfo.PLUGIN_GUID))
            {
                UpdateActiveScanTimeMessage.Instance.SendToPlayer(Player.player);
            }
        }

        static void ClientJoinSession(object source, EventArgs ea)
        {
            BepinPlugin.UpdateActiveValue(BepinPlugin.Bindings.VanillaDefaultValue);
        }

        public override MultiplayerType MPType => MultiplayerType.Host;

        public override string Author => MyPluginInfo.PLUGIN_AUTHORS;

        public override string Description => MyPluginInfo.PLUGIN_DESCRIPTION;

        public override string ThunderstoreID => MyPluginInfo.PLUGIN_THUNDERSTORE_ID;

        {
            BepinPlugin.UpdateActiveValue(BepinPlugin.Bindings.ScanTimeMultiplier.Value * BepinPlugin.Bindings.VanillaDefaultValue);
        }
    }
}
