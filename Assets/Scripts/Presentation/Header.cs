using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Presentation
{
    public class Header : MonoBehaviour
    {
        public void RefreshLabels(PlayerData playerData)
        {
            LabelOf("lifes").Refresh(playerData.lifes);
            LabelOf("coins").Refresh(playerData.coins);
            LabelOf("streaks").Refresh(playerData.streaks);
        }

        [NotNull] CurrencyLabel LabelOf(string currency)
            => GetComponentsInChildren<CurrencyLabel>().Single(x => x.IsOf(currency));
    }
}