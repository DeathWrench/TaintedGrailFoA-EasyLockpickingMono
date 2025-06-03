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
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loading.");
            // Plugin startup logic
            System.Threading.Thread.Sleep(10000);
            MyLog = base.Log;
            _harmony = Harmony.CreateAndPatchAll(typeof(Plugin));
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded. HELLO WORLD!");
        }

        public static void DebugLog(string msg)
        {
            MyLog.LogInfo(msg);
        }
 
        [HarmonyPatch(typeof(LockAction), "OnStart")] //Triggers when a 
        [HarmonyPostfix]
        public static void LockAction_OnStart_Postfix(LockAction __instance, Hero hero, IInteractableWithHero interactable) 
        {
            Plugin.DebugLog($"LockAction OnStart Postfix");
            __instance.DecreaseDifficulty(100);
            //__instance.Unlock(false)

        }




    }
}