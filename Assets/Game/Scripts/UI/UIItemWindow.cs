using InventoryBattle.Configs;
using InventoryBattle.Controllers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace InventoryBattle.UI
{
    public class UIItemWindow : MonoBehaviour
    {
        [Inject]
        InventoryConfig _config;

        [Inject]
        InventoryController _controller;

        [SerializeField]
        GameObject _view;

        [SerializeField]
        Image _icon;

        [SerializeField]
        TMP_Text _armor;

        [SerializeField]
        TMP_Text _weight;

        [SerializeField]
        TMP_Text _title;

        [SerializeField]
        Button _deleteBtn;
        
        [SerializeField]
        Button _useBtn;

        [SerializeField]
        Button _closeBtn;

        [SerializeField]
        GameObject _equipText;
        [SerializeField]
        GameObject _healText;
        [SerializeField]
        GameObject _buyText;

        public Action<int> OnEquip = delegate { };
        public Action<int> OnHeal = delegate { };
        public Action<int> OnBuy = delegate { };

        public Action<int> OnDelete = delegate { };

        int _index = 0;

        private void Awake()
        {
            _deleteBtn.onClick.AddListener(Delete);            
            _useBtn.onClick.AddListener(Use);            
            _closeBtn.onClick.AddListener(Hide);
            _controller.OnChooseItem = Show;
        }

        public void SetArmor(int armor) => _armor.text = armor.ToString();
        public void SetWeight(int weight) => _weight.text = weight.ToString();
        public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
        public void SetTitle(string title) => _title.text = title;

        void Show(string itemId, int index, int count)
        {
            var itemConfig = _config.GetItemByID(itemId);

            _index = index;
            _icon.sprite = itemConfig.Icon;            
            _weight.text = itemConfig.Weight.ToString("0.00");
            _title.text = itemConfig.Title;            
            _equipText.SetActive(itemConfig.ItemType == EItemType.Armor);
            _healText.SetActive(itemConfig.ItemType == EItemType.Aid);
            _buyText.SetActive(itemConfig.ItemType == EItemType.Bullet);
            _armor.transform.parent.gameObject.SetActive(itemConfig.ItemType == EItemType.Armor);

            if (itemConfig is ArmorItem armor) _armor.text = armor.Defense.ToString();

            _view.SetActive(true);
        }

        void Hide() => _view.SetActive(false);

        void Use()
        {
            _controller.Use(_index);
            Hide();
        }

        void Delete()
        {
            _controller.Delete(_index);
            Hide();            
        }
    }
}


