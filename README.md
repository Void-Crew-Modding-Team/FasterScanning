[![](https://img.shields.io/badge/-Void_Crew_Modding_Team-111111?style=just-the-label&logo=github&labelColor=24292f)](https://github.com/Void-Crew-Modding-Team)
![](https://img.shields.io/badge/Game%20Version-0.27.1-111111?style=flat&labelColor=24292f&color=111111)
[![](https://img.shields.io/discord/1180651062550593536.svg?&logo=discord&logoColor=ffffff&style=flat&label=Discord&labelColor=24292f&color=111111)](https://discord.gg/g2u5wpbMGu "Void Crew Modding Discord")

# Faster Scanning

Version 1.0.3  
For Game Version 0.27.1  
Developed by Dragon  
Requires:  BepInEx-BepInExPack-5.4.2100, VoidCrewModdingTeam-VoidManager-1.2.2


---------------------

### 💡 Functions - **Reduces enemy scan time to 15% of vanilla scan time**

- Provides GUI and BepinConfig for configuring mod settings
- Multiplies scan time by configured value
- Modifies UI to use configured scan time because it's a seperate system
- Syncs active scan time for multiplayer
- Disables when joining vanilla client

### 🎮 Client Usage

- Simply install and play while the host has the mod. 
- Configure/view setting at F5 > Mod Settings > Faster Scanning

### 👥 Multiplayer Functionality

- ✅ Client
  - The piloting client must have the mod installed for scan time to take effect. 
  - Clients will be allowed to join vanilla sessions, however the mod will be disabled.
- ✅ Host
  - The host must have the mod installed for it to function.  
- ✅ Session
  - Marks the room as Mod_Session when hosting.

---------------------

## 🔧 Install Instructions - **Install following the normal BepInEx procedure.**

Ensure that you have [BepInEx 5](https://thunderstore.io/c/void-crew/p/BepInEx/BepInExPack/) (stable version 5 **MONO**) and [VoidManager](https://thunderstore.io/c/void-crew/p/VoidCrewModdingTeam/VoidManager/) installed.

#### ✔️ Mod installation - **Unzip the contents into the BepInEx plugin directory**

Drag and drop `FasterScanning.dll` into `Void Crew\BepInEx\plugins`
