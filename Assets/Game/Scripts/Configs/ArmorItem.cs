using UnityEngine;

namespace InventoryBattle.Configs
{
    [CreateAssetMenu(fileName = "Armor", menuName = "Configs/Armor")]
    public class ArmorItem : Item
    {
        [SerializeField]
        EArmorType _armorType;

        [SerializeField]
        int _defense;

        public EArmorType ArmorType => _armorType;
        public int Defense => _defense;

        public override EItemType ItemType => EItemType.Armor;
    }
}