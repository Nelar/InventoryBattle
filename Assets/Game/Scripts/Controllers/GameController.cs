using Zenject;

namespace InventoryBattle.Controllers
{
    public class GameController : IInitializable
    {
        readonly InventoryController _inventory;
        readonly PlayerController _player;
        readonly EnemyController _enemy;
        public GameController(InventoryController inventory, PlayerController player, EnemyController enemy)
        {
            _inventory = inventory;
            _player = player;
            _enemy = enemy;
        }

        public void Initialize()
        {            
            _player.Initialize();
            _enemy.Initialize();
            _inventory.Initialize();
        }
    }
}
