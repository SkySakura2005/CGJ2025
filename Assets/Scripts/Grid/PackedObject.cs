using System;
using Grid.Interface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class PackedObject:MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        private IObjectType _type;
        
        private SpriteRenderer _sr;
        
        private Vector3 _standardDragPosition;
        private Vector2 _initialPosition;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _standardDragPosition =new Vector3(-0.3f,0.3f);
        }

        public void InitializeObject(IObjectType objectType,Vector3 position)
        {
            _type = objectType;
            _sr.sprite = _type.Sprite;
            
            transform.position = position;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            int row;
            int col;
            Grid.GetGridPosition(transform.position-new Vector3(_type.Shape.GetLength(0),-_type.Shape.Length,0)*0.3f+_standardDragPosition,out row,out col);
            if (row!=-1&&col!=-1)
            {
                Debug.Log("Removed!");
                Grid.RemoveFromGrid(_type,row,col);
            }
            _initialPosition=transform.position;
            transform.position = GetWorldPosition(eventData.position)+_standardDragPosition +new Vector3(_type.Shape.GetLength(0),-_type.Shape.Length,0)*0.3f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            //transform.position = GetWorldPosition(eventData.position)+_standardDragPosition +new Vector3(_sr.size.x/2,-_sr.size.y/2,0)*0.6f;
            transform.position = GetWorldPosition(eventData.position)+_standardDragPosition +new Vector3(_type.Shape.GetLength(1),-_type.Shape.GetLength(0),0)*0.3f;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            int row;
            int col;
            Grid.GetGridPosition(GetWorldPosition(eventData.position),out row,out col);
            if (row==-1&&col==-1)
            {
                transform.position = _initialPosition;
                return;
            }
            if (!Grid.ExaminePosition(_type, row, col))
            {
                Debug.Log("Examine is not passed!");
                transform.position = _initialPosition;
                return;
            }
            Grid.AddToGrid(gameObject,_type,row,col);
        }
        
        private Vector3 GetWorldPosition(Vector2 screenPosition)
        {
            Plane dragPlane = new Plane(Vector3.forward, Vector3.zero);
            // 创建从相机到屏幕点的射线
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        
            // 获取射线与拖拽平面的交点
            if (dragPlane.Raycast(ray, out float distance))
            {
                return ray.GetPoint(distance);
            }
        
            // 如果无法相交，使用默认方法
            return Camera.main.ScreenToWorldPoint(
                new Vector3(screenPosition.x, screenPosition.y, 
                    Camera.main.WorldToScreenPoint(transform.position).z));
        }
    }
}