using Source.Code.Task_1.Systems;
using TMPro;
using UnityEngine;

namespace Source.Code.Task_1.UI
{
    public class ResultPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI winnerTMP;
        [SerializeField] private TextMeshProUGUI gameDurationTMP;
        [SerializeField] private Timer timer;

        private void OnEnable()
        {
            gameDurationTMP.text = timer.CurrentTimeFormated;
            winnerTMP.text = GameStatesSwitcher.WinningFaction.Name + " won!";
            if (GameStatesSwitcher.WinningFaction == GameStatesSwitcher.BlueFaction) winnerTMP.color = Color.blue;
            else winnerTMP.color = Color.red;
        }
    }
}