using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task2.Source.Code
{
    public static class Main
    {
        public static int CountIslands(int[][] cells)
        {
            List<Vector2Int> exploredIslandCells = new List<Vector2Int>();
            Queue<Vector2Int> islandCellQueueForSearch = new Queue<Vector2Int>();
            int islandCount = 0;

            Vector2Int[] cellsAround = new Vector2Int[4]
            {
                Vector2Int.down,
                Vector2Int.right,
                Vector2Int.up,
                Vector2Int.left
            };                

            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    int curCell = cells[i][j];

                    if (curCell == 0) continue;
                    else if (curCell == 1)
                    {
                        Vector2Int curCellCoordinate = new Vector2Int(i, j);

                        do
                        {
                            if (islandCellQueueForSearch.Count != 0) curCellCoordinate = islandCellQueueForSearch.Dequeue();

                            if (exploredIslandCells.Contains(curCellCoordinate)) continue;
                            else
                            {
                                exploredIslandCells.Add(curCellCoordinate);

                                for (int k = 0; k < cellsAround.Length; k++)
                                {
                                    Vector2Int curAroundCellCoordinate = curCellCoordinate + cellsAround[k];
                                    if (IsItUnexploredIslandCell(curAroundCellCoordinate, ref cells, ref exploredIslandCells))
                                        islandCellQueueForSearch.Enqueue(curAroundCellCoordinate);
                                }
                            }

                        } while (islandCellQueueForSearch.Count != 0);
                    }
                }
            }

            return islandCount;
        }

        private static bool IsItUnexploredIslandCell(Vector2Int coordinate, ref int[][] cells, ref List<Vector2Int> exploredIslandCells)
        {
            bool isXValid = 0 <= coordinate.x && coordinate.x < cells.Length;
            bool isYValid = 0 <= coordinate.y && coordinate.y < cells[coordinate.x].Length;

            if (isXValid && isYValid)
            {
                if (exploredIslandCells.Contains(coordinate)) return false;
                else return true;
            }
            else return false;
        }
    }
}