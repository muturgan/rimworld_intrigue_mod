using RimWorld;
using System.Linq;
using Verse;

namespace Intrigue.Events
{
    public class Item
    {
        public Item(string settlementGuid, string pawnGuid) {
            this.settlementGuid = settlementGuid;
            this.pawnGuid = pawnGuid;
        }

        public readonly string settlementGuid;
        public readonly string pawnGuid;
    }

    public interface IRoyaltyLeader {
        int GetMaxPsylinkLevel();
    }

    public class IncidentWorker_TestIncident : IncidentWorker
    {
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Log.Message("Start!");

            var settlements = Find.WorldObjects.Settlements;
            Log.Message($"Settlement count is: {settlements.Count()}");

            settlements.ForEach((s) => {
                Log.Message($"Settlement guid: {s.GetUniqueLoadID()}");

                var f = s.Faction;
                Log.Message($"Settlement Faction name: {f.Name}");
                Log.Message($"Settlement Faction def fixedName: {f.def.fixedName}");
                Log.Message($"Settlement Faction def categoryTag: {f.def.categoryTag}");
                Log.Message($"Settlement Faction guid: {f.GetUniqueLoadID()}");

                var l = f.leader;
                if (l != null) {
                    Log.Message($"leader is here");
                    Log.Message($"{l.Name}");

                    if (ModLister.RoyaltyInstalled)
                    {
                        Log.Message($"MaxPsylinkLevel {l.GetMaxPsylinkLevel()}");
                    }

                    Log.Message($"TraderCaravanRole {l.GetTraderCaravanRole()}");
                    Log.Message($"guid {l.GetUniqueLoadID()}");
                }


                var map = s.Map;
                if (map != null) {
                    Log.Message($"map is here");
                    var isPlayerHome = map.IsPlayerHome;
                    Log.Message($"isPlayerHome: {isPlayerHome}");

                    var colonists = map.mapPawns.FreeColonists;
                    Log.Message($"colonists count is: {colonists.Count()}");
                    if (colonists.Count() > 0)
                    {
                        Log.Message($"Pawn guid: {colonists.First().GetUniqueLoadID()}");
                        Log.Message($"TRY");
                        var fc = colonists.First();

                        Log.Message($"first colonist is here");
                        Log.Message($"{fc.Name}");

                        Log.Message($"RoyaltyInstalled {ModLister.RoyaltyInstalled}");
                        if (ModLister.RoyaltyInstalled)
                        {
                            Log.Message($"MaxPsylinkLevel {fc.GetMaxPsylinkLevel()}");
                        }

                        Log.Message($"TraderCaravanRole {fc.GetTraderCaravanRole()}");
                        Log.Message($"guid {fc.GetUniqueLoadID()}");

                        var mySkill = fc.skills.skills[fc.skills.skills.Count() - 2];
                        Log.Message($"skillLabel {mySkill.def.skillLabel}");
                        Log.Message($"level {mySkill.Level}");
                        Log.Message($"type def label {mySkill.def.label}");

                        var lead = fc.Faction.TryGenerateNewLeader();
                        Log.Message($"lead {lead}");
                    }
                }

                Log.Message("=====================");
                //if (!map.IsPlayerHome) {
                /*
                    var item = new Item(
                        s.GetUniqueLoadID(),
                        map.mapPawns.FreeColonists.First()?.GetUniqueLoadID()
                    );
                    items.Add(item);
                */
                //}
            });

            //Log.Message($"{items}");

            return true;
        }
    }
}