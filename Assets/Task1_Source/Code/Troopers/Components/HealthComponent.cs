using System;
using Task1.Source.Code.Environment;
using UnityEngine;
using UnityEngine.UI;

namespace Task1.Source.Code.Troopers.Components
{
    public class HealthComponent
    {
        private TrooperBehaviour trooper;
        private float currentHP;
        private Slider hpBar;

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

            if (hpBar == null) CreateHpBar();
            hpBar.value = currentHP / trooper.Settings.MaxHP;
        }

        private void Death()
        {
            TrooperDied?.Invoke(trooper);
            MonoBehaviour.Destroy(trooper.Transform.parent.gameObject);
        }

        private void CreateHpBar()
        {
            var hpBarGO = MonoBehaviour.Instantiate(trooper.HpBarPrefab, trooper.FollowToRoot);
            //hpBarGO.transform.localPosition = Vector3.zero;
            hpBarGO.AddComponent<LookAtCamera>();
            hpBar = hpBarGO.GetComponentInChildren<Slider>();
        }
    }
}
