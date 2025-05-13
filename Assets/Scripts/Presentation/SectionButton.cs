using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    public class SectionButton : MonoBehaviour
    {
        [SerializeField] string buttonId;

        public bool IsOf( string section ) => buttonId == section;

        public void SetActive( bool shouldBeActive )
            => GetComponentInChildren<Button>().interactable = shouldBeActive;
    }
}