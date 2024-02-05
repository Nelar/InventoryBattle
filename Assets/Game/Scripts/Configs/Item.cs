using UnityEngine;

namespace InventoryBattle.Configs
{
    public class Item : ScriptableObject
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

        public virtual EItemType ItemType => EItemType.Bullet;

        public string Title => _title;

        public float Weight => _weight;

        public int MaxInCell => _maxInCell;

        public Sprite Icon => _icon;
    }
}