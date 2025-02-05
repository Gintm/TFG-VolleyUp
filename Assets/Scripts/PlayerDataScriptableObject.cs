using DefaultNamespace;
using Persistence;
using UnityEngine;

[CreateAssetMenu]
public class PlayerDataScriptableObject : ScriptableObject, PlayerRepo
{
    [SerializeField] private int lifes;
    [SerializeField] private int coins;
    [SerializeField] private int streaks;
    [SerializeField] private int currentSession;
    [SerializeField] private int lvlCurrentSession;
    [SerializeField] public string firstname;
    [SerializeField] public string surname;
    [SerializeField] public string degree;
    [SerializeField] public Team teams;

    public int GetLifes() => lifes;

    public void Lost()
    {
        lifes -= 1;
        streaks = 0;
    }

    public void Win(Round round)
    {
        coins += round.Coins;
        streaks += 1;
    }

    public int GetCurrentSession() => currentSession;

    public void UpdateWith(PlayerData infoSource)
    {
        lifes = infoSource.lifes;
        coins = infoSource.coins;
        streaks = infoSource.streaks;
        currentSession = infoSource.currentSession;
        lvlCurrentSession = infoSource.lvlCurrentSession;
        firstname = infoSource.firstname;
        surname = infoSource.surname;
        degree = infoSource.degree;
        teams = infoSource.teams;

    }

    public void SaveOneRound(Round round)
    {
        if (round.HasLost)
        {
            Lost();
        }
        else
        {
            Win(round);
        }
    }
}
