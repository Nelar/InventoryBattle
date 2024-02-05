using UnityEngine;

namespace InventoryBattle.Configs
{
    [CreateAssetMenu(fileName = "Aid", menuName = "Configs/Aid")]
    public class AidItem : Item
    {
        [SerializeField]
        int _hp;
        public int Hp => _hp;
        public override EItemType ItemType => EItemType.Aid;
    }
}