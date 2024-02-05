using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventoryBattle.UI
{
    public class UIItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler
    {
        [SerializeField]
        Image _icon;

        [SerializeField]
        TMP_Text _count;

        Image _raycastTarget;
        Transform _parent;
        Vector3 _startPos;

        public int Index = 0;

        public Action<int, int> OnSwapItems = delegate { };
        public Action<int> OnChooseItem = delegate { };

        void Awake()
        {
            _raycastTarget = GetComponent<Image>();
            _parent = transform.parent;
            _startPos = transform.localPosition;
        }

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
            _icon.gameObject.SetActive(sprite != null);                        
        }
        public void SetCount(int count)
        {            
            _count.text = count.ToString();
            _count.gameObject.SetActive(count > 0);
            _icon.gameObject.SetActive(count > 0);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _raycastTarget.raycastTarget = false;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(_parent);
            transform.localPosition = _startPos;
            _raycastTarget.raycastTarget = true;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) return;

            var anotherCell = eventData.pointerDrag.GetComponent<UIItem>();
            if (anotherCell == null) return;

            OnSwapItems?.Invoke(Index, anotherCell.Index);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnChooseItem?.Invoke(Index);
        }
    }
}
