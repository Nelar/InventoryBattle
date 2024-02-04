using System.Collections.Generic;
using UnityEngine;

namespace InventoryBattle.Configs
{
    public enum EItemType
    {
        Bullet,
        Aid,
        Armor
    }

    public enum EArmorType
    {
        Head,
        Body
    }

    public enum EBulletType
    {
        Gun,
        Rifle
    }

    interface IItem
    {
        string ID { get; }

        EItemType ItemType { get; }
        string Title { get; }
        float Weight { get; }        
        int MaxInCell { get; }

        Sprite Icon { get; }
    }

    public class Item : ScriptableObject, IItem
    {
        [SerializeField]
        string _id;

        [SerializeField]
        string _title;

        [SerializeField]
        float _weight;

        [SerializeField]
        int _maxInCell;

        [SerializeField]
        Sprite _icon;

        public string ID => _id;

        public EItemType ItemType => EItemType.Bullet;

        public string Title => _title;

        public float Weight => _weight;

        public int MaxInCell => _maxInCell;

        public Sprite Icon => _icon;
    }

    [CreateAssetMenu(fileName = "Armor", menuName = "Configs/Armor")]    
    public class ArmorItem : Item
    {
        [SerializeField]
        EArmorType _armorType;

        [SerializeField]
        int _defense;

        public EArmorType ArmorType => _armorType;
        public int Defense => _defense;

        public EItemType Type => EItemType.Armor;
    }

    [CreateAssetMenu(fileName = "Bullet", menuName = "Configs/Bullet")]
    public class BulletItem : Item
    {
        [SerializeField]
        EBulletType _bulletType;

        [SerializeField]
        float _damage;

        public EBulletType BulletType => _bulletType;
        public float Damage => _damage;
        public EItemType Type => EItemType.Bullet;
    }

    [CreateAssetMenu(fileName = "Aid", menuName = "Configs/Aid")]
    public class AidItem : Item
    {
        [SerializeField]
        int _hp;        
        public int Hp => _hp;
        public EItemType Type => EItemType.Aid;
    }


    [CreateAssetMenu(fileName = "Inventory", menuName = "Configs/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField]
        List<Item> _items;

        public IReadOnlyList<Item> Items => _items;
    }
}