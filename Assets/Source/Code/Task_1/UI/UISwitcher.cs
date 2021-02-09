using Source.Code.Task_1.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Code.Task_1.UI
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private RectTransform PreGameUI;
        [SerializeField] private RectTransform GameUI;
        [SerializeField] private RectTransform GameEndedUI;

        private void Start()
        {
            GameStatesSwitcher.GameStarted += OnGameStarted;
            GameStatesSwitcher.GameEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            GameStatesSwitcher.GameStarted -= OnGameStarted;
            GameStatesSwitcher.GameEnded -= OnGameEnded;
        }

        private void OnGameStarted()
        {
            PreGameUI.gameObject.SetActive(false);
            GameUI.gameObject.SetActive(true);
        }

        private void OnGameEnded()
        {
            GameUI.gameObject.SetActive(false);
            GameEndedUI.gameObject.SetActive(true);
        }
    }
}