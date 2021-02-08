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

        public void Initialize(FactionSettings settings, GameObject trooperPrefab)
        {
            this.settings = settings;
            this.trooperPrefab = trooperPrefab;
        }
    }


    [Serializable]
    public struct FactionSettings
    {
        [SerializeField] private GameObject trooperModelPrefab;
        [SerializeField] private Transform spawnPoint;
        //[SerializeField] private TargetSelectionComponent targetSelectionComponent;
        [Range(1, 5)] [SerializeField] private int numberOfTroopers;

        public GameObject TrooperModel => trooperModelPrefab;
        public Transform SpawnPoint => spawnPoint;

        public int NumOfTroopers => numberOfTroopers;
    }
}