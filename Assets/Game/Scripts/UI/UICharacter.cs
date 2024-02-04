using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryBattle.UI
{
    public class UICharacter : MonoBehaviour
    {
        [SerializeField]
        UIHealthBar _healthBar;

        [SerializeField]
        Image _head;
        [SerializeField]
        Image _body;

        public void SetHealth(int count) => _healthBar.SetCount(count);
        public void SetHead(Sprite sprite) => _head.sprite = sprite;
        public void SetBody(Sprite sprite) => _body.sprite = sprite;
    }
}
