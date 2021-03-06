﻿using Task1.Source.Code.Systems;
using UnityEngine;

namespace Task1.Source.Code.Troopers.Components
{
    [CreateAssetMenu(fileName = "Faction Target Selection", menuName = "Target Selection Components/Faction Target Selection")]
    public class FactionTargetSelection : TargetSelectionComponent
    {
        private FactionTarget factionTargetScript;

        public override TrooperBehaviour GetNewTarget(TrooperBehaviour trooper, Faction faction)
        {
            if (factionTargetScript == null)
            {
                var factionTargetScript = faction.GetComponent<FactionTarget>();
                if (factionTargetScript == null)
                {
                    factionTargetScript = faction.gameObject.AddComponent<FactionTarget>();
                }
                this.factionTargetScript = factionTargetScript;
            }

            return factionTargetScript.Target;
        }

    }
}
