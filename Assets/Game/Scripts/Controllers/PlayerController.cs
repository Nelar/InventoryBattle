using InventoryBattle.Configs;
using InventoryBattle.Installers;
using System;
using UnityEngine;
using static InventoryBattle.Installers.ConfigsInstaller;

namespace InventoryBattle.Controllers
{
    public class PlayerController
    {
        readonly InventoryConfig _config;
        readonly PlayerProfile _profile;
        readonly PlayerInitialState _playerInitialState;

        public Action<string> OnHeadArmorChange = delegate { };
        public Action<string> OnBodyArmorChange = delegate { };
        public Action<float> OnHpChange = delegate { };
        public Action OnDeath = delegate { };
        public Action OnLoaded = delegate { };

        float headDefense = 0.0f;
        float bodyDefense = 0.0f;

        public PlayerController(InventoryConfig config, PlayerProfile profile, PlayerInitialState playerInitialState)
        {
            _config = config;
            _profile = profile;
            _playerInitialState = playerInitialState;
        }

        public void Initialize()
        {
            _profile.Load(_playerInitialState);
            EquipHead(_profile.HeadArmor);
            EquipBody(_profile.BodyArmor);

            OnHpChange?.Invoke(_profile.Health);
            OnLoaded?.Invoke();
        }

        public void EquipHead(string id)
        {
            _profile.HeadArmor = id;
            OnHeadArmorChange?.Invoke(id);

            headDefense = 0.0f;
            var item  = _config.GetItemByID(id);
            if (item == null) return;

            var armor = item as ArmorItem;
            if (armor == null) return;

            headDefense = armor.Defense;
            _profile.Save();
        }

        public void EquipBody(string id)
        {
            _profile.BodyArmor = id;
            OnBodyArmorChange?.Invoke(id);

            bodyDefense = 0.0f;
            var item = _config.GetItemByID(id);
            if (item == null) return;

            var armor = item as ArmorItem;
            if (armor == null) return;

            bodyDefense = armor.Defense;
            _profile.Save();
        }

        public void Heal(float hp) => ChangeHp(hp);

        public void Damage(float hp, EArmorType attackZone)
        {
            var defense = headDefense;
            if (attackZone == EArmorType.Body) defense = bodyDefense;
            
            hp = Mathf.Clamp(hp - defense, 0.0f, hp);
            ChangeHp(-hp);

            CheckOnDeath();
        }

        bool CheckOnDeath()
        {
            if (_profile.Health > 0) return false;

            OnDeath?.Invoke();
            return true;
        }

        void ChangeHp(float hp)
        {
            _profile.Health = Mathf.Clamp(_profile.Health + hp, 0.0f, _profile.MaxHealth);
            OnHpChange?.Invoke(_profile.Health);
            _profile.Save();
        }

        public void Ressurect()
        {
            _profile.Health = _profile.MaxHealth;
            OnHpChange?.Invoke(_profile.Health);
            _profile.Save();
        }
    }
}
