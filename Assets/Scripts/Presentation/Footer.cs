using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Presentation
{
    public class Footer : MonoBehaviour
    {

        const int FIRST_SESSION = 0;
        const int SECOND_SESSION = 1;
        const int LAST_LEVEL = 2;

        public void RefreshButtons( PlayerData playerData )
        {
            bool isBoardEnabled = playerData.currentSession > SECOND_SESSION || ( playerData.currentSession == SECOND_SESSION && playerData.lvlCurrentSession == LAST_LEVEL );
            ButtonOf( "exercises" ).SetActive( playerData.currentSession > FIRST_SESSION );
            ButtonOf( "board" ).SetActive( isBoardEnabled );
        }

        [NotNull]
        SectionButton ButtonOf( string section )
            => GetComponentsInChildren<SectionButton>().Single( x => x.IsOf( section ) );
    }
}