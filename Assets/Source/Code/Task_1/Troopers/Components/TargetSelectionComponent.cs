using Source.Code.Task_1.Systems;
using UnityEngine;

namespace Source.Code.Task_1.Troopers.Components
{
    public abstract class TargetSelectionComponent : ScriptableObject
    {
        public abstract TrooperBehaviour GetNewTarget(TrooperBehaviour trooper, Faction faction);
    }
}
