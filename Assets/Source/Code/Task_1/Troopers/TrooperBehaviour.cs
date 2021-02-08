using Source.Code.Task_1.Systems;
using Source.Code.Task_1.Troopers.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.Troopers
{
    public class TrooperBehaviour : MonoBehaviour
    {
        private Faction faction;

        public TargetSelectionComponent TargetSelection { get; private set; }

        public void Initialize(Faction faction, TargetSelectionComponent targetSelectionComponent)
        {
            this.faction = faction;
            TargetSelection = targetSelectionComponent;
        }

        
    }
}
