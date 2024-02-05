using InventoryBattle.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace InventoryBattle.UI
{
    public class UILoseWindow : MonoBehaviour
    {
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
            _playerController.OnDeath = Show;
        }

        void Show()
        {
            _view.SetActive(true);
        }
        void Continue()
        {
            _enemyController.Ressurect();
            _playerController.Ressurect();
            _view.SetActive(false);
        }
    }
}
