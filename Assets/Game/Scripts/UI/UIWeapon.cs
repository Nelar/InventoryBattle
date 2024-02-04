using TMPro;
using UnityEngine;

namespace InventoryBattle.UI
{
    public class UIWeapon : MonoBehaviour
    {
        [SerializeField]
        TMP_Text _count;

        [SerializeField]
        GameObject _active;

        public void Set(int count) => _count.text = count.ToString();
        public bool Active
        {
            get => _active.activeSelf;
            set => _active.SetActive(value);
        }
    }
}
