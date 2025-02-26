using TMPro;
using UnityEngine;

namespace Presentation
{
    public class CurrencyLabel : MonoBehaviour
    {
        [SerializeField] string labelId;

        public bool IsOf( string currency ) => labelId == currency;

        public void Refresh( int value )
            => GetComponentInChildren<TMP_Text>().text = value.ToString();
    }
}