using Source.Code.Task_1.Systems;
using UnityEngine;

namespace Source.Code.Task_1.UI
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private WorldInitializer worldInitializer;

        public void OnButtonClicked()
        {
            foreach (var faction in worldInitializer.Factions)
            {
                faction.ForEachTrooper(trooper => trooper.SetState(trooper.TrooperStates.MoveToTarget));
            }

            this.gameObject.SetActive(false);
        }
    }
}