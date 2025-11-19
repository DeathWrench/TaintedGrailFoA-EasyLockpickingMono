using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace EasyLockpicking
{
	[BepInPlugin("drstalker.EasyLockpicking", "EasyLockpicking", "0.1.0")]
	public class Plugin : BaseUnityPlugin
	{
		public Harmony HarmonyInstance { get; set; }
		public void Awake()
		{
			Plugin.Log = base.Logger;
			Plugin.Log.LogInfo("Plugin drstalker.EasyLockpicking is loading...");
			this.HarmonyInstance = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
			Plugin.Log.LogInfo("Plugin drstalker.EasyLockpicking is loaded!");
		}
		public void OnDestroy()
		{
			Plugin.Log.LogInfo("Plugin drstalker.EasyLockpicking is unloading...");
			Harmony harmonyInstance = this.HarmonyInstance;
			if (harmonyInstance != null)
			{
				harmonyInstance.UnpatchSelf();
			}
			Plugin.Log.LogInfo("Plugin drstalker.EasyLockpicking is unloaded!");
		}
		internal static ManualLogSource Log;
	}
}

