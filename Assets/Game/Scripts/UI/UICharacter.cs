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

        public void SetHealth(float count) => _healthBar.SetCount(count);
        public void SetHead(Sprite sprite)
        {
            _head.sprite = sprite;
            _head.gameObject.SetActive(_head.sprite != null);
        }
        public void SetBody(Sprite sprite)
        {
            _body.sprite = sprite;
            _body.gameObject.SetActive(_body.sprite != null);
        }
    }
}
