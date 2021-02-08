using Source.Code.Task_1.Troopers;
using Source.Code.Task_1.Troopers.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.Systems
{
    public class Faction : MonoBehaviour
    {
        private GameObject trooperPrefab;
        private FactionSettings settings;
        private readonly List<TrooperBehaviour> trooperList = new List<TrooperBehaviour>();

        public LayerMask EnemyLayers => settings.EnemyLayers;
        public Transform Transform { get; private set; }

        public void Initialize(FactionSettings settings, GameObject trooperPrefab)
        {
            this.settings = settings;
            this.trooperPrefab = trooperPrefab;
            Transform = transform;
            SpawnTroopers();
        }

        private void SpawnTroopers()
        {
            float firstTrooperXPos = (settings.NumOfTroopers - 1) * (settings.SpawnDistance / 2);
            SpawnTrooper(firstTrooperXPos);

            for (int i = 1; i < settings.NumOfTroopers; i++)
            {
                float trooperXPos = firstTrooperXPos - (settings.SpawnDistance * i);
                SpawnTrooper(trooperXPos);
            }
        }

        private void SpawnTrooper(float trooperXPos)
        {
            var newTrooper = Instantiate(trooperPrefab, Transform);
            newTrooper.transform.localPosition = Vector3.zero;
            newTrooper.transform.localPosition += Vector3.left * trooperXPos;
            
            var trooperBehaviour = newTrooper.GetComponent<TrooperBehaviour>();

            if (trooperBehaviour == null)
            {
                Debug.LogError("Can't find TrooperBehaviour in trooper prefab", trooperPrefab);
                return;
            }

            trooperBehaviour.Initialize(this, settings.TargetSelectionComponent);
            trooperList.Add(trooperBehaviour);

            var newModel = Instantiate(settings.TrooperModel, newTrooper.transform);
            newModel.transform.localPosition = Vector3.zero;

            newTrooper.layer = settings.Layer;
        }
    }


    [Serializable]
    public struct FactionSettings
    {
        [Range(0, 31)] [SerializeField] private int layer;
        [SerializeField] private LayerMask enemyLayers;
        [SerializeField] private TargetSelectionComponent targetSelectionComponent;
        [Range(1, 5)] [SerializeField] private int numberOfTroopers;
        [Min(1)] [SerializeField] private float spawnDistanceBetweenTroopers;
        [Header("Links")]
        [SerializeField] private GameObject trooperModelPrefab;
        [SerializeField] private Transform spawnPoint;

        public GameObject TrooperModel => trooperModelPrefab;
        public Transform SpawnPoint => spawnPoint;
        public TargetSelectionComponent TargetSelectionComponent => targetSelectionComponent;
        public int NumOfTroopers => numberOfTroopers;
        public float SpawnDistance => spawnDistanceBetweenTroopers;
        public int Layer => layer;
        public LayerMask EnemyLayers => enemyLayers;
    }
}