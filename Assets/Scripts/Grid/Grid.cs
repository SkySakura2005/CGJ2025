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

        /*public static Dictionary<ObjectType, bool[,]> ShapeMap = new Dictionary<ObjectType, bool[,]>
        {
            [ObjectType.ObjectA] = new bool[1, 1]
            {
                { true }
            },
            [ObjectType.ObjectB] = new bool[2, 1]
            {
                { true },
                { true }
            },
            [ObjectType.ObjectC] = new bool[2, 2]
            {
                { false,true },
                { true,true }
            }
        };*/
        
        public static Vector2 StartPosition=new Vector2(0,0);
        public static int CellSize=1;
        public static int Spacing=2;
        public static void GetGridPosition(Vector2 position,out int row,out int col)
        {
            if (position.x < StartPosition.x || position.y < StartPosition.y ||
                position.x > StartPosition.x + CellSize * 8 + Spacing * 7 ||
                position.y > StartPosition.y + CellSize * 8 + Spacing * 7)
            {
                row=-1;
                col=-1;
                return;
            }
            int x=(int)(position.x-StartPosition.x)/(CellSize+Spacing);
            int y=(int)(position.y-StartPosition.y)/(CellSize+Spacing);
            row = x;
            col = y;
        }

        public static bool ExaminePosition(IObjectType type,int row, int col)
        {
            for (int i = 0; i < type.Shape.Length; i++)
            {
                for (int j = 0; j < type.Shape.GetLength(0); j++)
                {
                    if (row + i >= type.Shape.Length || col + j >= type.Shape.GetLength(0)) return false;
                    if (type.Shape[i, j] && ObjectList[row+i, col+j]!=  null) return false;
                }
            }
            return true;
        }
        public static void AddToGrid(GameObject go,IObjectType type,int row,int col)
        {
            
            for (int i = 0; i < type.Shape.Length; i++)
            {
                for (int j = 0; j < type.Shape.GetLength(0); j++)
                {
                    if(type.Shape[i, j])ObjectList[row + i, col + j] = type;
                }
            }
            go.transform.position = StartPosition+new Vector2((CellSize+Spacing)*col,(CellSize+Spacing)*row)+new Vector2(CellSize/2,CellSize/2);
            Player.Player.Instance.ExecuteObject(type);
            
        }

        public static void RemoveFromGrid(IObjectType type, int row, int col)
        {
            for (int i = 0; i < type.Shape.Length; i++)
            {
                for (int j = 0; j < type.Shape.GetLength(0); j++)
                {
                    if(type.Shape[i, j])ObjectList[row + i, col + j] = null;
                }
            }
        }
    }
}