using InventoryBattle.Configs;
using InventoryBattle.Installers;
using System;
using System.Collections.Generic;
using System.Linq;
using static InventoryBattle.Installers.PlayerProfile;

namespace InventoryBattle.Controllers
{
    public class InventoryController
    {
        readonly InventoryConfig _config;
        readonly PlayerProfile _profile;
        readonly PlayerController _player;

        public Action<List<Cell>> OnInitialize = delegate { };
        public Action<int, Cell> OnChangeItem = delegate { };
        public Action<string, int, int> OnChooseItem = delegate { };
        public Action<string> OnDeleteItem = delegate { };

        public InventoryController(PlayerProfile profile, PlayerController player, InventoryConfig config)
        {            
            _profile = profile;
            _player = player;
            _config = config;
        }

        public void Initialize()
        {
            OnInitialize?.Invoke(_profile.Inventory);
        }

        public void SwapItems(int a, int b)
        {
            var cell = _profile.Inventory[a];            
            _profile.Inventory[a] = _profile.Inventory[b];
            _profile.Inventory[b] = cell;

            OnChangeItem?.Invoke(a, _profile.Inventory[a]);
            OnChangeItem?.Invoke(b, _profile.Inventory[b]);

            _profile.Save();
        }

        public void ChooseItem(int idx)
        {
            var item = _profile.Inventory[idx];
            OnChooseItem?.Invoke(item.ItemId, idx, item.Count);
        }

        public void Use(int idx)
        {
            var item = _profile.Inventory[idx];
            var itemConfig = _config.GetItemByID(item.ItemId);

            switch (itemConfig.ItemType)
            {
                case EItemType.Aid:
                    var aid = itemConfig as AidItem;
                    _player.Heal(aid.Hp);
                    item.Count--;
                    break;

                case EItemType.Bullet:
                    var bullets = itemConfig as BulletItem;
                    item.Count = bullets.MaxInCell;
                    break;

                case EItemType.Armor:
                    var armor = itemConfig as ArmorItem;
                    if (armor.ArmorType == EArmorType.Head)
                        _player.EquipHead(itemConfig.ID);
                    else if (armor.ArmorType == EArmorType.Body)
                        _player.EquipBody(itemConfig.ID);
                    break;
            }

            _profile.Save();
            OnChangeItem(idx, _profile.Inventory[idx]);
        }

        public void Delete(int idx)
        {
            var item = _profile.Inventory[idx];
            if (_profile.BodyArmor == item.ItemId) _player.EquipBody(string.Empty);
            if (_profile.HeadArmor == item.ItemId) _player.EquipHead(string.Empty);

            _profile.Inventory[idx].ItemId = string.Empty;
            _profile.Inventory[idx].Count = 0;

            _profile.Save();

            OnChangeItem?.Invoke(idx, _profile.Inventory[idx]);
        }

        public float UseBullets(string _bulletId)
        {
            var item = _config.GetItemByID(_bulletId);            
            var bullet = item as BulletItem;
            if (bullet == null) return 0.0f;

            var damage = bullet.Damage * bullet.ShotsCount;

            if (!TryRemoveItems(_bulletId, bullet.ShotsCount)) return 0.0f;

            return damage;
        }

        public void AddRandomItem()
        {
            var item = _config.Items[UnityEngine.Random.Range(0, _config.Items.Count)];
            var idx = _profile.Inventory.FindIndex(x => x.Count == 0);
            if (idx < 0) return;

            _profile.Inventory[idx].ItemId = item.ID;
            _profile.Inventory[idx].Count = item.MaxInCell;

            OnChangeItem?.Invoke(idx, _profile.Inventory[idx]);
        }

        public int GetItemsCount(string id) => _profile.Inventory.Where(x => x.ItemId == id).Sum(x => x.Count);

        bool TryRemoveItems(string id, int count)
        {
            if (GetItemsCount(id) < count) return false;

            var currentItems = _profile.Inventory.Where(x => x.ItemId == id);
            foreach (var item in currentItems)
            {
                var idx = _profile.Inventory.FindIndex(x => x == item);

                var countInCell = item.Count - count;

                if (countInCell >= 0)
                {
                    item.Count -= count;
                    OnChangeItem(idx, item);
                    break;
                }

                count = count - item.Count;
                item.Count = 0;
                OnChangeItem(idx, item);
            }

            return true;
        }
    }
}
