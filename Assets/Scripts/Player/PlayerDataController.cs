using Persistence;
using Presentation;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    [SerializeField] PlayerDataScriptableObject gameData;

    void Awake() => Load();

    void Load()
    {
        var playerData = LoadFromJson.PlayerData();

        gameData.UpdateWith(playerData);
        GetComponent<Header>()?.RefreshLabels( playerData );
        FindObjectOfType<Footer>()?.RefreshButtons( playerData );
        FindObjectOfType<TeamClassification>()?.LoadTable( playerData );
        FindObjectOfType<PlayerProfile>()?.LoadProfileInformation( playerData );
    }

    public void Save()
    {
        SaveToJson.PlayerData( gameData );
    }

    public bool HasNoLifes() => gameData.GetLifes() == 0;
}
