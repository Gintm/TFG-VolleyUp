using UnityEngine;

public class PlayerInGameStats : MonoBehaviour
{
    public static void SaveSession( int session )
    {
        PlayerPrefs.SetInt( "Session", session );
        PlayerPrefs.Save();
    }

    public static void SaveLevel( int level )
    {
        PlayerPrefs.SetInt( "Level", level );
        PlayerPrefs.Save();
    }

    public (int, int) Stats()
    {
        int session = PlayerPrefs.GetInt( "Session", 0 );
        int level = PlayerPrefs.GetInt( "Level", 0 );
        return (session, level);
    }
}
