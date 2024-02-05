using UnityEngine;

namespace InventoryBattle.Configs
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Configs/Bullet")]
    public class BulletItem : Item
    {
        [SerializeField]
        EBulletType _bulletType;

        [SerializeField]
        float _damage;

        [SerializeField]
        int _shotsCount;

        public EBulletType BulletType => _bulletType;
        public float Damage => _damage;

        public int ShotsCount => _shotsCount;
        public override EItemType ItemType => EItemType.Bullet;
    }
}