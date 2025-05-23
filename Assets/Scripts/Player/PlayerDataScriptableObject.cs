using DefaultNamespace;
using Persistence;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerDataScriptableObject : ScriptableObject, PlayerRepo
{
    [SerializeField] private int lifes;
    [SerializeField] private int coins;
    [SerializeField] private int streaks;
    [SerializeField] private int currentSession;
    [SerializeField] private int lvlCurrentSession;
    [SerializeField] private string name;

    public PlayerDataScriptableObject( string name )
    {
        this.name = name;
    }

    [SerializeField] private string certification;
    [SerializeField] private string victories;
    [SerializeField] private string loses;
    [SerializeField] private List<Team> teams;

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

    public int GetCurrentLevel() => lvlCurrentSession;

    public void UpdateWith(PlayerData infoSource)
    {
        lifes = infoSource.lifes;
        coins = infoSource.coins;
        streaks = infoSource.streaks;
        currentSession = infoSource.currentSession;
        lvlCurrentSession = infoSource.lvlCurrentSession;
        name = infoSource.name;
        certification = infoSource.certification;
        victories = infoSource.victories;
        loses = infoSource.loses;
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
