using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.Troopers.BehaviourStates
{
    public class MoveToTarget : State
    {
        public MoveToTarget(TrooperBehaviour trooper) : base(trooper) { }

        public override void Enter()
        {
            trooper.TrySetNewTarget();
        }
    }
}
