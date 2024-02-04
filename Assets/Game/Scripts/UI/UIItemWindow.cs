using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryBattle.UI
{
    public class UIItemWindow : MonoBehaviour
    {
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
        Button _equipBtn;

        [SerializeField]
        Button _closeBtn;

        public Action OnEquip = delegate { };
        public Action OnDelete = delegate { };

        private void Awake()
        {
            _deleteBtn.onClick.AddListener(Delete);
            _equipBtn.onClick.AddListener(Equip);
            _closeBtn.onClick.AddListener(Hide);
        }

        public void SetArmor(int armor) => _armor.text = armor.ToString();
        public void SetWeight(int weight) => _weight.text = weight.ToString();
        public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
        public void SetTitle(string title) => _title.text = title;

        void Hide()
        {

        }

        void Equip()
        {
            Hide();
            OnEquip?.Invoke();
        }

        void Delete()
        {
            Hide();
            OnDelete?.Invoke();
        }
    }
}


