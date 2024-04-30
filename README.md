[![](https://img.shields.io/badge/-Void_Crew_Modding_Team-111111?style=just-the-label&logo=github&labelColor=24292f)](https://github.com/Void-Crew-Modding-Team)
![](https://img.shields.io/badge/Game%20Version-0.25.2-111111?style=flat&labelColor=24292f&color=111111)
[![](https://img.shields.io/discord/1180651062550593536.svg?&logo=discord&logoColor=ffffff&style=flat&label=Discord&labelColor=24292f&color=111111)](https://discord.gg/g2u5wpbMGu "Void Crew Modding Discord")

# FasterScanning

Version 1.0.0  
For Game Version 0.25.2  
Developed by Dragon  
Requires VoidManager 1.0.5


---------------------

### 💡 Function - **Reduces enemy scan time to 15% of vanilla scan time**
- Provides GUI and BepinConfig for configuring mod settings
- Multiplies scan time by configured value
- Modifies UI to use configured scan time because it's a seperate system
- Syncs active scan time for multiplayer
- Disables when joining vanilla client


### 🎮 Client Usage

- Simply install and play while the host has the mod. Configure/view setting at F5 > Mod Settings > Faster Scanning

### 👥  Multiplayer Functionality

- ✅ Host  
  - The host must have the mod installed for it to function.  
- ✅ Client  
  - The piloting client must have the mod installed for scan time to take effect. Clients will be allowed to join vanilla sessions, however the mod will be disabled.

---------------------

## 🔧 Install Instructions - **Install following the normal BepInEx procedure.**

Ensure that you have [BepInEx 5](https://thunderstore.io/c/void-crew/p/BepInEx/BepInExPack/) (stable version 5 **MONO**) and [VoidManager](https://thunderstore.io/c/void-crew/p/VoidCrewModdingTeam/VoidManager/) installed.

#### ✔️ Mod installation - **Unzip the contents into the BepInEx plugin directory**

Drag and drop `FasterScanning.dll` into `Void Crew\BepInEx\plugins`