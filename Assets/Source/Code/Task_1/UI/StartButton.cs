using Source.Code.Task_1.Systems;
using UnityEngine;

namespace Source.Code.Task_1.UI
{
    public class StartButton : MonoBehaviour
    {
        public void OnButtonClicked()
        {
            GameStatesSwitcher.StartGame();

            this.gameObject.SetActive(false);
        }
    }
}