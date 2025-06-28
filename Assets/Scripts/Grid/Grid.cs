using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Grid.Interface;
using UnityEngine;
using UnityEngine.UIElements;

namespace Grid
{
    public static class Grid
    {
        public static IObjectType[,] ObjectList=new IObjectType[8,8];


        
        public static Vector2 StartPosition=new Vector2(-8.5f,3.85f);
        public static float CellSize=0.6f;
        public static float Spacing=0.17f;
        public static void GetGridPosition(Vector2 position,out int row,out int col)
        {
            if (position.x < StartPosition.x || position.y > StartPosition.y ||
                position.x > StartPosition.x + CellSize * 8 + Spacing * 7 ||
                position.y < StartPosition.y - CellSize * 8 - Spacing * 7)
            {
                row=-1;
                col=-1;
                return;
            }
            int x=(int)(Mathf.Abs(position.x-StartPosition.x)/(CellSize+Spacing));
            int y=(int)(Mathf.Abs(position.y-StartPosition.y)/(CellSize+Spacing));
            row = y;
            col = x;
        }

        public static bool ExaminePosition(IObjectType type,int row, int col)
        {
            for (int i = 0; i < type.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < type.Shape.GetLength(1); j++)
                {
                    Debug.Log(i+","+j+","+row+","+col);
                    if (row + i >= 8 || col + j >= 8) return false;
                    if (type.Shape[i, j] && ObjectList[row+i, col+j]!=  null) return false;
                }
            }
            return true;
        }
        public static void AddToGrid(GameObject go,IObjectType type,int row,int col)
        {
            
            for (int i = 0; i < type.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < type.Shape.GetLength(1); j++)
                {
                    if(type.Shape[i, j])ObjectList[row + i, col + j] = type;
                }
            }
            go.transform.position = StartPosition+new Vector2((CellSize+Spacing)*col,-(CellSize+Spacing)*row)+new Vector2(type.Shape.GetLength(1),-type.Shape.GetLength(0))*(CellSize/2);
            Player.Player.Instance.ExecuteObject(type);
            
        }

        public static void RemoveFromGrid(IObjectType type, int row, int col)
        {
            for (int i = 0; i < type.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < type.Shape.GetLength(1); j++)
                {
                    if(type.Shape[i, j])ObjectList[row + i, col + j] = null;
                }
            }
            Player.Player.Instance.RemoveObject(type);
        }
    }
}