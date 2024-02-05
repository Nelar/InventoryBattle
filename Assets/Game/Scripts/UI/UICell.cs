using InventoryBattle.Configs;
using System;
using UnityEngine;

namespace InventoryBattle.UI
{
    public class UICell : MonoBehaviour
    {
        [SerializeField]
        UIItem _item;

        public Action<int> OnChooseItem = delegate { };
        public Action<int, int> OnSwapItems = delegate { };

        public void Init(Item item, int count, int index)
        {
            _item.SetIcon(item?.Icon);
            _item.SetCount(count);
            _item.Index = index;
            _item.OnSwapItems = (a, b)=> OnSwapItems?.Invoke(a, b);
            _item.OnChooseItem = a => OnChooseItem?.Invoke(a);
        }        
    }
}
