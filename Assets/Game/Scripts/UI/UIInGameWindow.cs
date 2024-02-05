using InventoryBattle.Configs;
using InventoryBattle.Controllers;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace InventoryBattle.UI
{
    public class UIInGameWindow : MonoBehaviour
    {
        [Inject]
        InventoryConfig _inventoryConfig;
        [Inject]
        PlayerController _playerController;
        [Inject]
        EnemyController _enemyController;
        [Inject]
        InventoryController _inventoryController;

        [SerializeField]
        UICharacter _hero;
        [SerializeField]
        UICharacter _enemy;
        
        [SerializeField]
        UIArmor _headArmor;

        [SerializeField]
        UIArmor _bodyArmor;

        [SerializeField]
        UIWeapon _gunWeapon;

        [SerializeField]
        UIWeapon _rifleWeapon;

        [SerializeField]
        Button _shootBtn;

        string _bulletId;

        void Awake()
        {
            _shootBtn.onClick.AddListener(Shoot);
            
            _playerController.OnHpChange = PlayerHpChange;
            _playerController.OnHeadArmorChange = HeadArmorChange;
            _playerController.OnBodyArmorChange = BodyArmorChange;
            _playerController.OnLoaded = InitWeapons;

            _enemyController.OnHpChange = EnemyHpChange;

            _gunWeapon.OnChooseWeapon = ChooseWeapon;
            _rifleWeapon.OnChooseWeapon = ChooseWeapon;
        }

        void InitWeapons()
        {
            var items = _inventoryConfig.Items.FindAll(x=>x.ItemType == EItemType.Bullet);
            var gunBullet = items.FirstOrDefault(x =>

            {
                var b = x as BulletItem;
                return b.BulletType == EBulletType.Gun;
            }) as BulletItem;

            var rifleBullet = items.FirstOrDefault(x =>
            {
                var b = x as BulletItem;
                return b.BulletType == EBulletType.Rifle;
            }) as BulletItem;

            _gunWeapon.Init(gunBullet);
            _rifleWeapon.Init(rifleBullet);

            ChooseWeapon(gunBullet.ID);
        }

        void ChooseWeapon(string bulletId)
        {            
            _bulletId = bulletId;
            _shootBtn.interactable = _inventoryController.GetItemsCount(bulletId) > 0;
        }

        void PlayerHpChange(float hp) => _hero.SetHealth(hp);
        void EnemyHpChange(float hp) => _enemy.SetHealth(hp);

        void HeadArmorChange(string id) 
        {
            if (string.IsNullOrEmpty(id))
            {
                _headArmor.Init(null);
                _hero.SetHead(null);
                return;
            }

            var item = _inventoryConfig.GetItemByID(id);            
            _headArmor.Init(item as ArmorItem);
            _hero.SetHead(item?.Icon);
        }

        void BodyArmorChange(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _bodyArmor.Init(null);
                _hero.SetBody(null);
                return;
            }

            var item = _inventoryConfig.GetItemByID(id);
            _bodyArmor.Init(item as ArmorItem);
            _hero.SetBody(item?.Icon);
        }

        void Shoot()
        {
            var damage = _inventoryController.UseBullets(_bulletId);
            _enemyController.Damage(damage);
        }
    }
}
