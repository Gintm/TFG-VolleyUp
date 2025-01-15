using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu]
public class PlayerDataScriptableObject : ScriptableObject, PlayerRepo
{
    private int lifes;
    private int coins;
    private int strikes;
    private int currentSession;
    private int lvlCurrentSession;

    public int GetLifes() => lifes;

    public void Lost()
    {
        lifes -= 1;
        strikes = 0;
    }

    public void Win(int score)
    {
        coins += score * 100;
        strikes += 1;
    }

    public int GetCurrentSession() => currentSession;

    public void UpdateWith(PlayerData infoSource)
    {
        lifes = infoSource.lifes;
        coins = infoSource.coins;
        strikes = infoSource.strikes;
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
