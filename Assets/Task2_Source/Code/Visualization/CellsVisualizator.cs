using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Task2.Source.Code.Visualization
{
    //Здесь для оптимизации надо бы использовать обжект пул, но путь наименьшего сопротивления он такой, беспощадный. Поэтому смотрим на 10 тысяч инстансов/дестроев
    public class CellsVisualizator : MonoBehaviour
    {
        [SerializeField] private GameObject waterSquarePrefab;
        [SerializeField] private GameObject islandSquarePrefab;

        [SerializeField] private Transform cellsRoot;

        [SerializeField] private ResultUI resultUI;

        private List<GameObject> cellsGOList = new List<GameObject>();
        private int[][] cells;

        public void Create(Vector2Int size, bool needJaggedArray)
        {
            Stopwatch visualizationStopwatch = new Stopwatch();
            visualizationStopwatch.Start();

            cells = new int[size.x][];

            for (int i = 0; i < size.x; i++)
            {
                int curLineLength = size.y;

                if (needJaggedArray) curLineLength = Random.Range(0, size.y);

                cells[i] = new int[curLineLength];

                for (int j = 0; j < curLineLength; j++)
                {
                    cells[i][j] = Random.Range(0, 2);
                    var curPrefab = cells[i][j] == 0 ? waterSquarePrefab : islandSquarePrefab;
                    cellsGOList.Add(Instantiate(curPrefab, new Vector3(i, -j, 0), Quaternion.identity, cellsRoot));
                }
            }

            visualizationStopwatch.Stop();


            Stopwatch algorithmStopwatch = new Stopwatch();
            algorithmStopwatch.Start();

            int islandCount = Main.CountIslands(cells);

            algorithmStopwatch.Stop();

            resultUI.ShowResult(islandCount, visualizationStopwatch.ElapsedMilliseconds, algorithmStopwatch.ElapsedMilliseconds);
        }

        public void Clear()
        {
            if (cellsGOList.Count == 0) return;

            foreach (var cell in cellsGOList)
            {
                Destroy(cell);
            }
            cellsGOList.Clear();
        }
    }
}
