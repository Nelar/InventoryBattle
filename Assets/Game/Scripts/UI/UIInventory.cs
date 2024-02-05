using InventoryBattle.Configs;
using InventoryBattle.Controllers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static InventoryBattle.Installers.PlayerProfile;

namespace InventoryBattle.UI
{
    public class UIInventory : MonoBehaviour
    {
        [Inject]
        InventoryConfig _config;
        [Inject]
        InventoryController _controller;

        [SerializeField]
        UICell _cellPrefab;
        [SerializeField]
        Transform _cellsContainer;

        List<UICell> _cells = new List<UICell>();

        void Awake()
        {
            _controller.OnInitialize = Init;
            _controller.OnChangeItem = ChangeItem;
        }

        void Init(List<Cell> cells)
        {
            for (var i = 0; i < cells.Count; i++)
            {
                var instance = Instantiate(_cellPrefab, _cellsContainer);
                instance.Init(_config.GetItemByID(cells[i].ItemId), cells[i].Count, i);
                instance.OnSwapItems = SwapItems;
                instance.OnChooseItem = ChooseItem;
                _cells.Add(instance);
            }
        }

        void ChangeItem(int idx, Cell cell) => _cells[idx].Init(_config.GetItemByID(cell.ItemId), cell.Count, idx);

        void SwapItems(int a, int b) => _controller.SwapItems(a, b);

        void ChooseItem(int idx) => _controller.ChooseItem(idx);
    }
}
