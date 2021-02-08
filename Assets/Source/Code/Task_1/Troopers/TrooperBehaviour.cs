using Source.Code.Task_1.Systems;
using Source.Code.Task_1.Troopers.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.Troopers
{
    public class TrooperBehaviour : MonoBehaviour
    {
        [SerializeField] private TrooperSettings settings;

        private Faction faction;
        private TargetSelectionComponent targetSelectionComponent;

        public TrooperBehaviour Target { get; private set; }
        public Transform Transform { get; private set; }
        public TrooperSettings Settings => settings;
        

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

    [Serializable]
    public struct TrooperSettings
    {
        [Min(1)] [SerializeField] private float maxHP;
        [Min(0)] [SerializeField] private float damagePerSecond;
        [Min(0)] [SerializeField] private float attackRange;
        [Min(0)] [SerializeField] private float speed;

        public float MaxHP => maxHP;
        public float DamagePerSecond => damagePerSecond;
        public float AttackRange => attackRange;
        public float MoveSpeed => speed;
    }

}
