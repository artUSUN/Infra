using TMPro;
using UnityEngine;

namespace Task2.Source.Code.Visualization
{
    public class UIInputHandler : MonoBehaviour
    {
        [SerializeField] private CellsVisualizator visualizator;

        [SerializeField] private TMP_InputField inputFieldX;
        [SerializeField] private TMP_InputField inputFieldY;

        private int sizeX, sizeY;
        private bool generateJaggedArray = false;

        private const int maxSize = 50;

        public void OnToggleValueChanged(bool value)
        {
            generateJaggedArray = value;
        }

        public void Generate()
        {
            visualizator.Clear();

            SetSize();

            visualizator.Create(new Vector2Int(sizeX, sizeY), generateJaggedArray);
        }

        private void SetSize()
        {
            SetSize(inputFieldX, ref sizeX);
            SetSize(inputFieldY, ref sizeY);
        }

        private void SetSize(TMP_InputField inputField, ref int size)
        {
            if (int.TryParse(inputField.text, out int result)) size = Mathf.Clamp(result, 1, maxSize);
            else size = Random.Range(1, maxSize);
            inputField.text = size.ToString();
        }
    }
}
