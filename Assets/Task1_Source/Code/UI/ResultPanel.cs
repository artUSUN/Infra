using Task1.Source.Code.Systems;
using TMPro;
using UnityEngine;

namespace Task1.Source.Code.UI
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