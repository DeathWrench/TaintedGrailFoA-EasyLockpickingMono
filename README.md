
A mod for Tainted Grail: Fall of Avalon

This mod makes lock picking easier.  In fact it's so easy that locks just fall open if you wave a lockpick at them, skipping the minigame entirely because that turned out to be vastly easier than adjusting the difficulty.


[Nexus Mods Page]([https://www.nexusmods.com/taintedgrailthefallofavalon/mods/29?tab=description)

Reference Assemblies: I used IL2CPPDumper to create a dummy TG.Main.dll that the compiler could reference for object names.  The other needed reference is BepInEx.Unity.IL2CPP.dll which is part of the Bepinex install.

Compilation Warnings: Warning MSB3277 is downgraded to a message in the .csprj file to prevent it spamming the build log because BepInEx.Unity.IL2CPP.dll wants a version of the system runtime that does not exist.

Crashing on Startup: MAke sure UnityLogListening is set to false in the Bepinex config, as described [here](https://github.com/BepInEx/BepInEx/issues/474)

Accessing function code: In theory this might be possibel (at least to some extent) through IL2CPPDumper and Ghidra but so far I have not gotten this to work, so I'm just modding blind based off the Class/method names.

