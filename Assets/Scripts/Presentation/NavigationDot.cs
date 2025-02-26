using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    public class NavigationDot : MonoBehaviour
    {
        public void UpdateColor( bool isCurrent )
        {
            var dotImage = GetComponent<Image>();
            dotImage.color = isCurrent ? Color.white : Color.gray;
            dotImage.fillAmount = 0f;
        }
    }
}