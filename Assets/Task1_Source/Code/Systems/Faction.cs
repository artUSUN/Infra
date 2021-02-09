using Task1.Source.Code.Troopers;
using Task1.Source.Code.Troopers.Components;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Task1.Source.Code.Systems
{
    public class Faction : MonoBehaviour
    {
        private GameObject trooperPrefab;
        private FactionSettings settings;
        private readonly List<TrooperBehaviour> trooperList = new List<TrooperBehaviour>();

        public LayerMask EnemyLayers => settings.EnemyLayers;
        public Transform Transform { get; private set; }
        public string Name => settings.Name;

        public void Initialize(FactionSettings settings, GameObject trooperPrefab)
        {
            this.settings = settings;
            this.trooperPrefab = trooperPrefab;
            Transform = transform;
            SpawnTroopers();
        }

        public void ForEachTrooper(Action<TrooperBehaviour> action)
        {
            foreach (var trooper in trooperList) action(trooper);
        }

        private void SpawnTroopers()
        {
            float firstTrooperXPos = (settings.NumOfTroopers - 1) * (settings.SpawnDistance / 2);
            SpawnTrooper(firstTrooperXPos, 1);

            for (int i = 1; i < settings.NumOfTroopers; i++)
            {
                float trooperXPos = firstTrooperXPos - (settings.SpawnDistance * i);
                SpawnTrooper(trooperXPos, i + 1);
            }
        }

        private void SpawnTrooper(float trooperXPos, int index)
        {
            var trooperBehaviour = trooperPrefab.GetComponentInChildren<TrooperBehaviour>();

            if (trooperBehaviour == null)
            {
                Debug.LogError("Can't find TrooperBehaviour in trooper prefab", trooperPrefab);
                return;
            }

            var newTrooper = Instantiate(trooperPrefab, Transform);
            newTrooper.transform.localPosition = Vector3.zero;
            newTrooper.transform.localPosition += Vector3.left * trooperXPos;
            newTrooper.gameObject.name += " " + index;

            trooperBehaviour = newTrooper.GetComponentInChildren<TrooperBehaviour>();
            trooperBehaviour.gameObject.layer = settings.Layer;
            trooperBehaviour.Initialize(this, settings.TargetSelectionComponent);
            trooperBehaviour.HealthComponent.TrooperDied += OnTrooperDied;
            trooperList.Add(trooperBehaviour);


            var newModel = Instantiate(settings.TrooperModel, trooperBehaviour.Transform);
            newModel.transform.localPosition = Vector3.zero;
        }

        private void OnTrooperDied(TrooperBehaviour diedTrooper)
        {
            if (trooperList.Contains(diedTrooper)) trooperList.Remove(diedTrooper);
#if UNITY_EDITOR
            else
            {
                Debug.LogError($"Trooper list does not contains this trooper", diedTrooper.Transform);
                Debug.Break();
            }
#endif
            diedTrooper.HealthComponent.TrooperDied -= OnTrooperDied;

            if (trooperList.Count == 0)
            {
                GameStatesSwitcher.FactionLost(this);
            }
        }
    }


    [Serializable]
    public struct FactionSettings
    {
        [SerializeField] private string name;
        [Range(0, 31)] [SerializeField] private int layer;
        [SerializeField] private LayerMask enemyLayers;
        [SerializeField] private TargetSelectionComponent targetSelectionComponent;
        [Range(1, 5)] [SerializeField] private int numberOfTroopers;
        [Min(1)] [SerializeField] private float spawnDistanceBetweenTroopers;
        [Header("Links")]
        [SerializeField] private GameObject trooperModelPrefab;
        [SerializeField] private Transform spawnPoint;

        public string Name => name;
        public GameObject TrooperModel => trooperModelPrefab;
        public Transform SpawnPoint => spawnPoint;
        public TargetSelectionComponent TargetSelectionComponent => targetSelectionComponent;
        public int NumOfTroopers => numberOfTroopers;
        public float SpawnDistance => spawnDistanceBetweenTroopers;
        public int Layer => layer;
        public LayerMask EnemyLayers => enemyLayers;
    }
}