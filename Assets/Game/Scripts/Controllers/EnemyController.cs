using InventoryBattle.Configs;
using InventoryBattle.Installers;
using System;
using static InventoryBattle.Installers.ConfigsInstaller;

namespace InventoryBattle.Controllers
{
    public class EnemyController
    {
        readonly EnemyProfile _profile;
        readonly PlayerController _player;
        readonly EnemyInitialState _enemyInitialState;
        
        public Action<float> OnHpChange = delegate { };
        public Action OnDeath = delegate { };

        EArmorType _currentAttackZone = EArmorType.Body;

        public EnemyController(EnemyProfile profile, EnemyInitialState enemyInitialState, PlayerController player)
        {
            _player = player;
            _profile = profile;
            _enemyInitialState = enemyInitialState;
        }

        public void Initialize()
        {
            _profile.Load(_enemyInitialState);
            OnHpChange?.Invoke(_profile.Health);
        }

        public void Damage(float damage)
        {
            _profile.Health -= damage;                        
            OnHpChange?.Invoke(_profile.Health);
            _profile.Save();

            if (CheckOnDeath())
            {
                Ressurect();
            }                
            else
            {
                Attack();
            }                
        }

        bool CheckOnDeath()
        {
            if (_profile.Health > 0) return false;

            OnDeath?.Invoke();
            return true;
        }

        public void Ressurect()
        {
            _profile.Health = _profile.MaxHealth;
            OnHpChange?.Invoke(_profile.Health);
            _profile.Save();
        }

        void Attack()
        {
            _player.Damage(_profile.Damage, _currentAttackZone);

            if (_currentAttackZone == EArmorType.Body)
            {
                _currentAttackZone = EArmorType.Head;
            }
            else
            {
                _currentAttackZone = EArmorType.Body;
            }                
        }
    }
}
