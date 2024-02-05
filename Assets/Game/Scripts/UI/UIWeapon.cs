using InventoryBattle.Configs;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryBattle.UI
{
    public class UIWeapon : MonoBehaviour
    {
        [SerializeField]
        TMP_Text _count;

        [SerializeField]
        GameObject _active;
        
        Toggle _toggle;

        public Action<string> OnChooseWeapon = delegate { };

        string _bulletId;

        void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(isOn =>
            {
                if (isOn) OnChooseWeapon?.Invoke(_bulletId);
            });
        }

        public void Init(BulletItem bullet)
        {
            _bulletId = bullet.ID;
            _count.text = bullet.Damage.ToString("0");
        }
    }
}
