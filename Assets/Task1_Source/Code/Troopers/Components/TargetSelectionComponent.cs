using Task1.Source.Code.Systems;
using UnityEngine;

namespace Task1.Source.Code.Troopers.Components
{
    public abstract class TargetSelectionComponent : ScriptableObject
    {
        public abstract TrooperBehaviour GetNewTarget(TrooperBehaviour trooper, Faction faction);
    }
}
