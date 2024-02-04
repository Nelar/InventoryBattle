using TMPro;
using UnityEngine;

namespace InventoryBattle.UI
{
    public class UIArmor : MonoBehaviour
    {
        [SerializeField]
        TMP_Text _count;

        public void Set(int count) => _count.text = count.ToString();
    }
}
