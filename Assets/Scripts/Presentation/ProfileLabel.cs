using TMPro;
using UnityEngine;

namespace Presentation
{
    public class ProfileLabel : MonoBehaviour
    {
        [SerializeField] public string labelId;

        public bool IsOf( string data ) => labelId == data;

        public void Refresh( string value )
            => GetComponentInChildren<TMP_Text>().text = value;
    }
}