using System.Collections.Generic;
using RimWorld;
using TwitchToolkit.Store;
using Verse;
using VFE_Settlers.Workers;

namespace ToolkitBridge_VFE_Settlers
{
    public class IncidentBridge_ProtectionFee : IncidentHelper
    {
        private IncidentParms parms;
        private IncidentWorker worker;
        

        public override bool IsPossible()
        {
            worker = new IncidentWorker_ProtectionFee();
            worker.def = IncidentDef.Named("ProtectionFee");
            parms = new IncidentParms();
            parms.target = Current.Game.RandomPlayerHomeMap;
            parms.points = StorytellerUtility.DefaultThreatPointsNow(parms.target);
            return (worker.CanFireNow(parms));
        }

        public override void TryExecute() => worker.TryExecute(parms);
    }
}