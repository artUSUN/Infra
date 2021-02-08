using Source.Code.Task_1.Troopers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.Systems
{
    public class FactionTarget : MonoBehaviour
    {
        private Faction faction;
        private TrooperBehaviour target;

        private const float raycastLength = 100;

        public TrooperBehaviour Target 
        { 
            get 
            {
                if (target == null)
                {
                    target = GetNewTarget();
                }
                return target;
            } 
        }

        private void Awake()
        {
            faction = GetComponent<Faction>();
        }

        private TrooperBehaviour GetNewTarget()
        {
            var enemies = Physics.OverlapSphere(faction.Transform.position, raycastLength, faction.EnemyLayers);
            if (enemies.Length == 0) return null;

            int randomValue = Random.Range(0, enemies.Length);
            var enemyTrooper = enemies[randomValue].GetComponent<TrooperBehaviour>();

            if (enemyTrooper == null)
            {
                Debug.LogError("Object on enemy layer has no component \"TrooperBehaviour\"");
                return null;
            }

            return enemyTrooper;
        }
    }
}
