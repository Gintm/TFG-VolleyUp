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

    public int GetLifes() => lifes;

    public void Lost()
    {
        lifes -= 1;
        streaks = 0;
    }

    public void Win(int score)
    {
        coins += score * 100;
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
    }

    public void SaveOneRound(Round round)
    {
        if (round.HasLost)
        {
            Lost();
        }
        else
        {
            Win(round.Hits);
        }
    }
}
