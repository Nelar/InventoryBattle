using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static InventoryBattle.Installers.ConfigsInstaller;

namespace InventoryBattle.Installers
{
    public class PlayerProfile
    {        
        [System.Serializable]
        public class Cell
        {
            public string ItemId;
            public int Count;
        }

        public List<Cell> Inventory = new List<Cell>();

        public string HeadArmor;
        public string BodyArmor;
        public float Health;
        public float MaxHealth;

        string FilePath => $"{Application.persistentDataPath}/player.json";

        public void Load(PlayerInitialState initialState)
        {
            if (File.Exists(FilePath))
            {                
                string json = File.ReadAllText(FilePath);
                JsonUtility.FromJsonOverwrite(json, this);
                return;
            }

            //Fill initial state
            Health = initialState.Health;
            MaxHealth = initialState.Health;
            BodyArmor = initialState.BodyArmor;
            HeadArmor = initialState.HeadArmor;

            Inventory.Clear();
            for (var i = 0; i < initialState.InventorySize; i++)
            {
                var cell = new Cell()
                {
                    ItemId = string.Empty,
                    Count = 0
                };

                Inventory.Add(cell);

                if (initialState.Inventory.Count <= i) continue;

                cell.ItemId = initialState.Inventory[i].ID;
                cell.Count = initialState.Inventory[i].Count;
            }
        }

        public void Save()
        {
            var json = JsonUtility.ToJson(this);
            File.WriteAllText(FilePath, json);
        }
    }
}

