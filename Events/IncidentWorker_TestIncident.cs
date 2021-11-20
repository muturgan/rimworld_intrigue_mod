using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Intrigue.Events
{
    public class IncidentWorker_TestIncident : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map map = (Map)parms.target;

            if (map.mapPawns.ColonistsSpawnedCount < 2) {
                Log.Message($"no no {map.mapPawns.ColonistsSpawnedCount}");
                return false;
            }
            Log.Message($"yes yes {map.mapPawns.ColonistsSpawnedCount}");

            return true;
            // return base.CanFireNowSub(parms);
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;

            if (map.mapPawns.ColonistsSpawnedCount < 2)
            {
                Log.Message($"no no no {map.mapPawns.ColonistsSpawnedCount}");
                return false;
            }
            Log.Message($"yes yes yes {map.mapPawns.ColonistsSpawnedCount}");

            // return base.TryExecuteWorker(parms);
            return true;
        }
    }
}
