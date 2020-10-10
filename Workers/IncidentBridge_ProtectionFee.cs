using RimWorld;
using System.Collections.Generic;
using Verse;
using VFE_Settlers.Workers;
using TwitchToolkit.Store;

namespace ToolkitBridge_VFE_Settlers
{
    public class IncidentBridge_ProtectionFee : IncidentHelper
    {
        private IncidentParms parms;
        private IncidentWorker worker;
        

        public override bool IsPossible()
        {
            this.worker = (IncidentWorker) new IncidentWorker_ProtectionFee();
            this.worker.def = IncidentDef.Named("ProtectionFee");
            this.parms = new IncidentParms();
            List<Map> maps = Current.Game.Maps;
            ((IList<Map>) maps).Shuffle<Map>();
            using (List<Map>.Enumerator enumerator = maps.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    this.parms.target = enumerator.Current;
                    if (this.worker.CanFireNow(this.parms, false))
                    {
                        this.parms.points = StorytellerUtility.DefaultThreatPointsNow(this.parms.target);
                        return true;
                    }
                }
            }
            return false;
        }

        public override void TryExecute() => this.worker.TryExecute(this.parms);
    }
}