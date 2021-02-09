using UnityEngine;

namespace Task1.Source.Code.Troopers.Components
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
            target.HealthComponent.ApplyDamage(trooper.Settings.DamagePerSecond * Time.deltaTime, trooper);
        }
    }
}