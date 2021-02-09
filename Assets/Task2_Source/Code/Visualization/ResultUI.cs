using TMPro;
using UnityEngine;

namespace Task2.Source.Code.Visualization
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI visualizationDurationTMP;
        [SerializeField] private TextMeshProUGUI algorithmDurationTMP;
        [SerializeField] private TextMeshProUGUI islandCountTMP;

        public void ShowResult(int islandCount, float visualizationDuration, float algorithmDuration)
        {
            islandCountTMP.text = islandCount.ToString();
            visualizationDurationTMP.text = $"{visualizationDuration/1000,0:f5} s.";
            algorithmDurationTMP.text = $"{algorithmDuration/1000,0:f5} s.";
        }
    }
}
