using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.Troopers.Components
{
    public class HealthComponent
    {
        private TrooperBehaviour trooper;
        private float currentHP;

        public event Action<TrooperBehaviour> TrooperDied;

        public HealthComponent(TrooperBehaviour trooper)
        {
            this.trooper = trooper;
            currentHP = trooper.Settings.MaxHP;
        }

        public void ApplyDamage(float value, TrooperBehaviour damageDealer)
        {
            if (value < 0)
            {
                Debug.LogError("Damage value cannot be negative", trooper.Transform);
                return;
            }

            currentHP -= value;

            if (currentHP <= 0)
            {
                currentHP = 0;
                Death();
            }


        }

        private void Death()
        {
            TrooperDied?.Invoke(trooper);
        }
    }
}
