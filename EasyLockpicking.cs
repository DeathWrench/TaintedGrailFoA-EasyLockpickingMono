using HarmonyLib;
using Awaken.TG.Main.Locations.Actions;

namespace EasyLockpicking
{
    [HarmonyPatch(typeof(LockAction))]
    public static class LockActionPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch("OnStart")]
        public static void LockAction_OnStart_Postfix(LockAction __instance)
        {
            __instance.DecreaseDifficulty(100);
        }
    }
}