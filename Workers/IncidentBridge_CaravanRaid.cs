using RimWorld;
using TwitchToolkit.Store;
using Verse;

namespace ToolkitBridge_VFE_Settlers
{
    public class IncidentBridge_CaravanRaid : IncidentHelper
    {
        private IncidentParms parms;
        private IncidentWorker worker;
        

        public override bool IsPossible()
        {
            worker = new IncidentWorker_GiveQuest();
            worker.def = IncidentDef.Named("GiveQuest_CaravanRaid");
            worker.def.questScriptDef = DefDatabase<QuestScriptDef>.GetNamed("VFES_CaravanRaid");
            parms = new IncidentParms();
            parms.questScriptDef = DefDatabase<QuestScriptDef>.GetNamed("VFES_CaravanRaid");
            parms.points = StorytellerUtility.DefaultThreatPointsNow(Current.Game.RandomPlayerHomeMap);
            parms.forced = true;
            return (worker.CanFireNow(parms));
        }

        public override void TryExecute() => worker.TryExecute(parms);
    }
}