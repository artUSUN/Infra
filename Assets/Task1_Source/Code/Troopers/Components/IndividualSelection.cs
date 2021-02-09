using Task1.Source.Code.Systems;
using System;
using System.Linq;
using UnityEngine;

namespace Task1.Source.Code.Troopers.Components
{
    [CreateAssetMenu(fileName = "Individual Target Selection", menuName = "Target Selection Components/Individual Target Selection")]
    public class IndividualSelection : TargetSelectionComponent
    {
        private const float raycastLength = 100;

        public override TrooperBehaviour GetNewTarget(TrooperBehaviour trooper, Faction faction)
        {
            var enemies = Physics.OverlapSphere(faction.Transform.position, raycastLength, faction.EnemyLayers);
            if (enemies.Length == 0) return null;

            //int randomValue = Random.Range(0, enemies.Length);
            //var enemyTrooper = enemies[randomValue].GetComponent<TrooperBehaviour>();
            var enemyTrooper = GetClosestCollider(trooper.Transform.position, enemies).GetComponent<TrooperBehaviour>();

            if (enemyTrooper == null)
            {
                Debug.LogError("Object on enemy layer has no component \"TrooperBehaviour\"");
                return null;
            }

            return enemyTrooper;
        }

        private Collider GetClosestCollider(Vector3 point, Collider[] colliders)
        {
            float[] distances = new float[colliders.Length];
            for (int i = 0; i < colliders.Length; i++)
            {
                distances[i] = (colliders[i].transform.position - point).sqrMagnitude;
            }
            return colliders[Array.IndexOf(distances, distances.Min())];
        }
    }
}
