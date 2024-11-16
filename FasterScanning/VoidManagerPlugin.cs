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
        }

        static void HostVerifiedClient(object source, Events.PlayerEventArgs Player)
        {
            if (NetworkedPeerManager.Instance.NetworkedPeerHasMod(Player.player, MyPluginInfo.PLUGIN_GUID))
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

        public override SessionChangedReturn OnSessionChange(SessionChangedInput input)
        {
            switch(input.CallType)
            {
                case CallType.HostChange:
                    if (input.IsHost)
                    {
                        BepinPlugin.UpdateActiveValue(BepinPlugin.Bindings.ScanTimeMultiplier.Value * BepinPlugin.Bindings.VanillaDefaultValue);
                        UpdateActiveScanTimeMessage.Instance.SendToOthers();
                    }
                    break;
                case CallType.HostStartSession:
                    BepinPlugin.UpdateActiveValue(BepinPlugin.Bindings.ScanTimeMultiplier.Value * BepinPlugin.Bindings.VanillaDefaultValue);
                    UpdateActiveScanTimeMessage.Instance.SendToOthers();
                    break;
            }
            return new SessionChangedReturn() { SetMod_Session = true };
        }
    }
}
