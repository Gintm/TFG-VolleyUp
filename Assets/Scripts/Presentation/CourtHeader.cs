using Persistence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation
{
    public class CourtHeader : MonoBehaviour
    {
        public Color currentColor = Color.black;
        public void GoHome()
        {
            Utils.ChangeScene( 1 );
        }

        public void ToggleColor()
        {
            currentColor = currentColor == Color.black ? Color.yellow : Color.black;
        }
    }
}
