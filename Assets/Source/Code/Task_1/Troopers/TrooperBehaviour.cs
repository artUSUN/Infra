﻿using Source.Code.Task_1.Systems;
using Source.Code.Task_1.Troopers.BehaviourStates;
using Source.Code.Task_1.Troopers.Components;
using System;
using UnityEngine;

namespace Source.Code.Task_1.Troopers
{
    [RequireComponent(typeof(Rigidbody))]
    public class TrooperBehaviour : MonoBehaviour
    {
        [SerializeField] private TrooperSettings settings;

        private TargetSelectionComponent targetSelectionComponent;

        public Faction Faction { get; private set; }
        public HealthComponent HealthComponent { get; private set; }
        public AttackComponent AttackComponent { get; private set; }
        public MoverComponent MoverComponent { get; private set; }
        public TrooperBehaviour CurrentTarget { get; private set; }
        public Transform Transform { get; private set; }
        public TrooperSettings Settings => settings;
        public State CurrentState { get; private set; }
        public TrooperStates TrooperStates { get; private set; }


        public void Initialize(Faction faction, TargetSelectionComponent targetSelectionComponent)
        {
            this.Faction = faction;
            this.targetSelectionComponent = targetSelectionComponent;

            Transform = transform;

            MoverComponent = new MoverComponent(this);
            HealthComponent = new HealthComponent(this);
            AttackComponent = new AttackComponent(this);
            TrooperStates = new TrooperStates(this);

            SetState(TrooperStates.Idle);
        }

        #region MonoBehaviour
        private void Update()
        {
            CurrentState.Update();
        }

        private void FixedUpdate()
        {
            CurrentState.FixedUpdate();
        }
        #endregion

        #region Public
        public void SetState(State newState)
        {
            if (CurrentState != null) CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void TrySetNewTarget()
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = targetSelectionComponent.GetNewTarget(this, Faction);
            }
        }

        public bool IsTargetInAttackRadius()
        {
            return Mathf.Pow(settings.AttackRange, 2) > (CurrentTarget.Transform.position - Transform.position).sqrMagnitude;
        }
        #endregion
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

    public class TrooperStates
    {
        public readonly State Idle;
        public readonly State MoveToTarget;
        public readonly State AttackTarget;

        public TrooperStates(TrooperBehaviour trooperBehaviour)
        {
            Idle = new Idle(trooperBehaviour);
            MoveToTarget = new MoveToTarget(trooperBehaviour);
            AttackTarget = new AttackTarget(trooperBehaviour);
        }
    }
}