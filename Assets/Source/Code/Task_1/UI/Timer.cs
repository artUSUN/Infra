using TMPro;
using UnityEngine;

namespace Source.Code.Task_1.UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmp;

        public float CurrentTimeInSec { get; private set; }
        public string CurrentTimeFormated 
        { 
            get
            {
                int min = Mathf.RoundToInt(CurrentTimeInSec / 60);
                int sec = Mathf.RoundToInt(CurrentTimeInSec % 60);
                return $"{min,0:d2}:{sec,0:d2}";
            }
        }

        private void Update()
        {
            if (gameObject.activeInHierarchy)
            {
                CurrentTimeInSec += Time.deltaTime;
                tmp.text = CurrentTimeFormated;
            }
        }
    }
}