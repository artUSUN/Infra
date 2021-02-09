using Task1.Source.Code.Systems;
using UnityEngine;

namespace Task1.Source.Code.UI
{
    public class StartButton : MonoBehaviour
    {
        public void OnButtonClicked()
        {
            GameStatesSwitcher.StartGame();
        }
    }
}