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

        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "Dragon";

        public override string Description => "Reduces enemy scan time to 15% of vanilla scan time. Customizable, host and piloting client must have.";

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

        static void HostStartSession(object source, EventArgs ea)
        {
            BepinPlugin.UpdateActiveValue(BepinPlugin.Bindings.ScanTimeMultiplier.Value * BepinPlugin.Bindings.VanillaDefaultValue);
        }
    }
}
