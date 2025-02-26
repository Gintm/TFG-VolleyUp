using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    public class TeamClassification : MonoBehaviour
    {
        public GameObject rowPrefab;
        public Transform tableParent;

        public void LoadTable( PlayerData playerData )
        {

            foreach( var team in playerData.teams )
            {
                GameObject newRow = Instantiate( rowPrefab, tableParent );

                TextMeshProUGUI[] textFields = newRow.GetComponentsInChildren<TextMeshProUGUI>();

                textFields[0].text = team.name;
                textFields[1].text = team.category;
                textFields[2].text = team.league;
            }
        }
    }
}
