using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.Troopers.Components
{
    public class AttackComponent
    {
        private TrooperBehaviour trooper;

        public AttackComponent(TrooperBehaviour trooper)
        {
            this.trooper = trooper;
        }

        public void AttackTarget(TrooperBehaviour target)
        {
            target.HealthComponent.ApplyDamage(trooper.Settings.DamagePerSecond, trooper);
        }
    }
}