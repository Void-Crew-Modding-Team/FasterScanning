using VoidManager;
using VoidManager.MPModChecks;

namespace FasterScanning
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public VoidManagerPlugin()
        {
            Events.Instance.HostVerifiedClient += HostVerifiedClient;
        }

        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "Dragon";

        public override string Description => "Reduces enemy scan time to 1/4th of vanilla. Customizable, Host and piloting client must have.";

        static void HostVerifiedClient(object source, Events.PlayerEventArgs Player)
        {
            if (MPModCheckManager.Instance.NetworkedPeerHasMod(Player.player, MyPluginInfo.PLUGIN_GUID))
            {
                UpdateActiveScanTimeMessage.Instance.SendToPlayer(Player.player);
            }
        }
    }
}
