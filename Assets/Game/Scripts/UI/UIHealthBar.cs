using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryBattle.UI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField]
        Image _progress;

        [SerializeField]
        TMP_Text _count;

        public void SetCount(int count)
        {
            var progress = Mathf.Clamp(count, 0, 100);
            _count.text = progress.ToString();
            _progress.fillAmount = progress/100.0f;
        }
    }
}
