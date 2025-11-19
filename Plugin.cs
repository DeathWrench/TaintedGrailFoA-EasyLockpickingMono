using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace EasyLockpicking
{
	[BepInPlugin("DeathWrench.EasyLockpicking", "EasyLockpicking", "0.1.0")]
	public class Plugin : BaseUnityPlugin
	{
		public Harmony HarmonyInstance { get; set; }
		public void Awake()
		{
			Plugin.Log = base.Logger;
			Plugin.Log.LogInfo("Plugin DeathWrench.EasyLockpicking is loading...");
			this.HarmonyInstance = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
			Plugin.Log.LogInfo("Plugin DeathWrench.EasyLockpicking is loaded!");
		}
		public void OnDestroy()
		{
			Plugin.Log.LogInfo("Plugin DeathWrench.EasyLockpicking is unloading...");
			Harmony harmonyInstance = this.HarmonyInstance;
			if (harmonyInstance != null)
			{
				harmonyInstance.UnpatchSelf();
			}
			Plugin.Log.LogInfo("Plugin DeathWrench.EasyLockpicking is unloaded!");
		}
		internal static ManualLogSource Log;
	}
}
