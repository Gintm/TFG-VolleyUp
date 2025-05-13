using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Presentation
{
    public class Footer : MonoBehaviour
    {

        const int FIRST_SESSION = 0;
        const int SECOND_SESSION = 1;

        public void RefreshButtons( PlayerData playerData )
        {
            ButtonOf( "exercises" ).SetActive( playerData.currentSession > FIRST_SESSION );
            ButtonOf( "board" ).SetActive( playerData.currentSession > SECOND_SESSION );
        }

        [NotNull]
        SectionButton ButtonOf( string section )
            => GetComponentsInChildren<SectionButton>().Single( x => x.IsOf( section ) );
    }
}