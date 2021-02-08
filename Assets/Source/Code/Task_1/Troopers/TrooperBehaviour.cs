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
        private TargetSelectionComponent targetSelectionComponent;

        public TrooperBehaviour Target { get; private set; }
        public Transform Transform { get; private set; }
        

        public void Initialize(Faction faction, TargetSelectionComponent targetSelectionComponent)
        {
            this.faction = faction;
            this.targetSelectionComponent = targetSelectionComponent;
            Transform = transform;
        }

        public void TrySetNewTarget()
        {
            if (Target = null)
            {
                Target = targetSelectionComponent.GetNewTarget(this, faction);
            }
        }
    }
}
