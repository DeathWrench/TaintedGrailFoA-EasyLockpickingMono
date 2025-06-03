using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP; // this causes huge numbers of warnings because it wants System.Runtime package 6.0.0.0 instead of a verion that exists
using HarmonyLib;
using Awaken.TG.Main.Locations.Actions;
using Awaken.TG.Main.Heroes.Interactions;
using Awaken.TG.Main.Heroes;


namespace EasyLockpicking
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
    {
        private static Harmony _harmony;
        internal static ManualLogSource MyLog; //So DebugLog can be called as a static function, once the Load() method sets up this variable
        public override void Load()
        {
            MyLog = base.Log;
            Plugin.DebugLog($"Applying Harmony Patches");
            _harmony = Harmony.CreateAndPatchAll(typeof(Plugin));
            Log.LogInfo("Patching complete.");
        }

        public static void DebugLog(string msg)
        {
            MyLog.LogInfo($"{PluginInfo.PLUGIN_GUID}: {msg}");
        }
 
        [HarmonyPatch(typeof(LockAction), "OnStart")] //Triggers when the player start to pick a lock
        [HarmonyPostfix]
        public static void LockAction_OnStart_Postfix(LockAction __instance, Hero hero, IInteractableWithHero interactable) 
        {
            //Plugin.DebugLog($"LockAction OnStart Postfix");
            __instance.DecreaseDifficulty(100); //This makes the lock fall open, and I don't feel like spending time to play around blindly with different values.
        }
    }
}