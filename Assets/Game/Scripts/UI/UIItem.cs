using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryBattle.UI
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField]
        Image _icon;

        [SerializeField]
        TMP_Text _count;

        public void SetCount(int count) => _count.text = count.ToString();
        public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
    }
}
