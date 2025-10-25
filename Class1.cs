using Bannerlord.ButterLib.MBSubModuleBaseExtended;
using HarmonyLib;
using Microsoft.SqlServer.Server;
using SandBox.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.LinQuick;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.PlayerServices;



namespace instafail_stealth_change
{
    // Harmony patch: prevent the OnMissionTick logic from running
    [HarmonyPatch(typeof(StealthFailCounterMissionLogic), "OnMissionTick")]
    public static class PreventOnMissionTickPatch
    {
        // Prefix matching the signature; returning false skips original OnMissionTick
        public static bool Prefix(StealthFailCounterMissionLogic __instance, float dt)
        {
            // Optionally implement alternative behavior here.
            return false; // skip original OnMissionTick
        }
    }

    public class MainModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            // Apply Harmony patches so every StealthFailCounterMissionLogic instance uses the desired value
            try
            {
                var harmony = new Harmony("instafail_stealth_change.stealth");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                InformationManager.DisplayMessage(new InformationMessage($"Harmony patch worked!!!!"));

            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage($"Harmony patch failed: {ex.Message}"));
            }
        }

    }
}
