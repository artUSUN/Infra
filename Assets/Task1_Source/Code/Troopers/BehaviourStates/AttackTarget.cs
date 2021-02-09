using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task1.Source.Code.Troopers.BehaviourStates
{
    public class AttackTarget : State
    {
        public AttackTarget(TrooperBehaviour trooper) : base(trooper) { }

        public override void Update()
        {
            if (trooper.CurrentTarget == null)
            {
                trooper.SetState(trooper.TrooperStates.MoveToTarget);
                return;
            }

            trooper.AttackComponent.AttackTarget(trooper.CurrentTarget);

            if (trooper.IsTargetInAttackRadius() == false)
            {
                trooper.SetState(trooper.TrooperStates.MoveToTarget);
            }
        }
    }
}