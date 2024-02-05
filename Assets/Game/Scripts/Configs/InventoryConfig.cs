using System.Collections.Generic;
using System.Linq;
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

    [CreateAssetMenu(fileName = "Inventory", menuName = "Configs/Inventory")]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField]
        List<Item> _items = new List<Item>();
        
        public List<Item> Items => _items;

        public Item GetItemByID(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return _items.FirstOrDefault(x => x.ID == id);
        }
    }
}