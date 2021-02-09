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

        public override void FixedUpdate()
        {
            if (trooper.CurrentTarget == null) 
            {
                trooper.SetState(trooper.TrooperStates.Idle);
                return;
            }

            
            trooper.MoverComponent.Move(trooper.CurrentTarget.Transform.position);

            if (trooper.IsTargetInAttackRadius())
            {
                trooper.SetState(trooper.TrooperStates.AttackTarget);
            }
        }
    }
}
