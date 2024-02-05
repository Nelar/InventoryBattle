using InventoryBattle.Configs;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryBattle.Installers
{
    [CreateAssetMenu(fileName = "Configs", menuName = "Installers/Configs")]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [System.Serializable]
        public struct ItemWithCount
        {
            [SerializeField]
            string _id;
            [SerializeField]
            int _count;

            public string ID => _id;
            public int Count => _count;
        }

        [System.Serializable]
        public struct PlayerInitialState
        {
            [SerializeField]
            string _headArmor;
            [SerializeField]
            string _bodyArmor;
            [SerializeField]
            float _health;

            [SerializeField]
            int _inventorySize;

            [SerializeField]
            List<ItemWithCount> _initialState;

            public string HeadArmor => _headArmor;
            public string BodyArmor => _bodyArmor;
            public float Health => _health;
            public int InventorySize => _inventorySize;
            public IReadOnlyList<ItemWithCount> Inventory => _initialState;
        }

        [System.Serializable]
        public struct EnemyInitialState
        {
            [SerializeField]
            float _health;
            [SerializeField]
            float _damage;

            public float Health => _health;
            public float Damage => _damage;
        }

        [SerializeField]
        private InventoryConfig _inventory;

        [SerializeField]
        private PlayerInitialState _player;

        [SerializeField]
        private EnemyInitialState _enemy;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InventoryConfig>().FromInstance(_inventory).AsSingle();
            Container.Bind<PlayerInitialState>().FromInstance(_player).AsSingle();
            Container.Bind<EnemyInitialState>().FromInstance(_enemy).AsSingle();
        }
    }
}