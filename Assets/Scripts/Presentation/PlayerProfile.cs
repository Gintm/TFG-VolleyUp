using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Presentation
{
    public class PlayerProfile : MonoBehaviour
    {
        public void LoadProfileInformation( PlayerData playerData )
        {
            LabelOf( "name" ).Refresh( playerData.name );
            LabelOf( "certification" ).Refresh( playerData.certification );
            LabelOf( "victories" ).Refresh( playerData.victories );
            LabelOf( "loses" ).Refresh( playerData.loses);
        }

        [NotNull] ProfileLabel LabelOf( string currency )
            => GetComponentsInChildren<ProfileLabel>().Single( x => x.IsOf( currency ) );
    }
}
