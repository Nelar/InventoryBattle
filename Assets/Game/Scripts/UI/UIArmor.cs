using InventoryBattle.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryBattle.UI
{
    public class UIArmor : MonoBehaviour
    {
        [SerializeField]
        Image _icon;

        [SerializeField]
        TMP_Text _count;
        public void Init(ArmorItem item)
        {
            _icon.sprite = null;
            _count.text = "0";
            _icon.gameObject.SetActive(false);

            if (item == null) return;

            _icon.sprite = item.Icon;
            _icon.gameObject.SetActive(true);
            _count.text = item.Defense.ToString();
        }
    }
}
