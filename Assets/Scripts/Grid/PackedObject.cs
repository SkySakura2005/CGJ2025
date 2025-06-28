using System;
using Grid.Interface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class PackedObject:MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        public IObjectType type;

        private SpriteRenderer _sr;
        private Vector2 _standardDragPosition;
        
        private Vector2 _initialPosition;

        private void Start()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        public void InitializeObject(IObjectType objectType)
        {
            type = objectType;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _initialPosition=transform.position;
            transform.position = (Vector3)eventData.pressPosition - (Vector3)_standardDragPosition + _sr.bounds.size / 2;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            int row;
            int col;
            Grid.GetGridPosition(eventData.position,out row,out col);
            if (row==-1&&col==-1)
            {
                transform.position = _initialPosition;
                return;
            }
            if (!Grid.ExaminePosition(type, row, col))
            {
                transform.position = _initialPosition;
                return;
            }
            Grid.AddToGrid(gameObject,type,row,col);
        }
    }
}