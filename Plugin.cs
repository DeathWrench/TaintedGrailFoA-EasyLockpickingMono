using System;
//using System.Reflection;
using BepInEx;
using BepInEx.Logging;
//using BepInEx.IL2CPP;
using BepInEx.Unity.IL2CPP; // this causes huge numbers of erros because it wants 
using HarmonyLib;
using Awaken.TG.Main.Locations.Actions.Lockpicking;
using Awaken.TG.Main.Locations.Actions;

namespace EasyLockpicking
{
    [BepInPlugin("Nep.EasyLockpicking", "EasyLockpicking", "1.0.0")]
    public class Plugin : BasePlugin
    {
        private static Harmony _harmony;
        internal static ManualLogSource MyLog; //So DebugLog can be called as a static function, once the Load() method sets up this variable
        public override void Load()
        {
            // Plugin startup logic
            MyLog = base.Log;
            _harmony = Harmony.CreateAndPatchAll(typeof(Plugin));
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded! HELLO WORLD!");
        }

        public static void DebugLog(string msg)
        {
            MyLog.LogInfo(msg);
        }

        [HarmonyPatch(typeof(LockAction), "OnFullyInitialized")]
        [HarmonyPostfix]
        public static float OnFullyInitializedPostfix(LockTolerance __instance, ref float __result)
        {
            Plugin.DebugLog($"LockTolerance OnFullyInitialized Postfix");
            return __result;
        }

        [HarmonyPatch(typeof(LockTolerance), "angle")]
        [HarmonyPostfix]
        public static float LockTolerancePostfix(LockTolerance __instance, ref float __result)
        {
            Plugin.DebugLog($"LockTolerance.angle returns: {__result}");
            return __result;
        }




    }
}