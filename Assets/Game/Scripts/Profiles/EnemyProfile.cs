using System.IO;
using UnityEngine;
using static InventoryBattle.Installers.ConfigsInstaller;

namespace InventoryBattle.Installers
{
    public class EnemyProfile
    {
        public float Health;
        public float MaxHealth;
        public float Damage;

        string FilePath => $"{Application.persistentDataPath}/enemy.json";

        public void Load(EnemyInitialState intialState)
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                JsonUtility.FromJsonOverwrite(json, this);
                return;
            }          
            
            Health = intialState.Health;
            MaxHealth = intialState.Health;
            Damage = intialState.Damage;
        }

        public void Save()
        {
            var json = JsonUtility.ToJson(this);
            File.WriteAllText(FilePath, json);
        }

    }
}