using System;
using UnityEngine;

namespace Grid
{
    public class GridView:MonoBehaviour
    {
        private GameObject[,] grid=new GameObject[8,8];
        public static GridView Instance;
        private void Start()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j] =Instantiate( Resources.Load<GameObject>("Prefab/Square"),transform,true);
                    grid[i,j].name = "grid "+i+"_"+j;
                    grid[i, j].transform.localScale = new Vector3(Grid.CellSize, Grid.CellSize);
                    grid[i, j].transform.position = (Vector3)Grid.StartPosition +
                                                    new Vector3(j, -i, 0) * (Grid.CellSize + Grid.Spacing) +
                                                    new Vector3(Grid.CellSize, -Grid.CellSize, 0) / 2;
                    grid[i, j].SetActive(false);
                }
            }
        }

        public void UpdateGrid(int startRow,int startCol,bool[,] shape)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j].SetActive(false);
                }
            }

            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    if(shape[i,j]&&startRow+i<8&&startCol+j<8&&Grid.ObjectList[startRow+i, startCol+j]==null)
                        grid[startRow+i, startCol+j].SetActive(true);
                }
            }
        }

        public void ClearGrid()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j].SetActive(false);
                }
            }
        }
    }
}