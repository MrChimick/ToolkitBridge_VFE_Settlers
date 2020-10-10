using RimWorld;
using Verse;
using TwitchToolkit.Store;

namespace ToolkitBridge_VFE_Settlers
{
    public class IncidentBridge_Wanted : IncidentHelper
    {
        private IncidentParms parms;
        private IncidentWorker worker;
        

        public override bool IsPossible()
        {
            this.worker = (IncidentWorker) new IncidentWorker_GiveQuest();
            this.worker.def = IncidentDef.Named("GiveQuest_Settlers_Wanted");
            this.worker.def.questScriptDef = DefDatabase<QuestScriptDef>.GetNamed("Settlers_Wanted");
            this.parms = new IncidentParms();
            this.parms.questScriptDef = DefDatabase<QuestScriptDef>.GetNamed("Settlers_Wanted");
            this.parms.points = StorytellerUtility.DefaultThreatPointsNow(Current.Game.RandomPlayerHomeMap);
            this.parms.forced = true;
            return (this.worker.CanFireNow(this.parms, false));
        }

        public override void TryExecute() => this.worker.TryExecute(this.parms);
    }
}