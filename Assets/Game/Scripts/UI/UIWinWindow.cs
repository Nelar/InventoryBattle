using InventoryBattle.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace InventoryBattle.UI
{
    public class UIWinWindow : MonoBehaviour
    {
        [Inject]
        InventoryController _inventory;

        [Inject]
        PlayerController _playerController;

        [Inject]
        EnemyController _enemyController;

        [SerializeField]
        GameObject _view;

        [SerializeField]
        Button _continueBtn;

        void Awake()
        {
            _continueBtn.onClick.AddListener(Continue);
            _enemyController.OnDeath = Show;
        }

        void Show()
        {
            _view.SetActive(true);
            _inventory.AddRandomItem();
            _enemyController.Ressurect();
            _playerController.Ressurect();
        }
        void Continue()
        {            
            _view.SetActive(false);
        }
    }
}
