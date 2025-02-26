using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int lifes;
    public int coins;
    public int streaks;
    public int currentSession;
    public int lvlCurrentSession;
    public string name;
    public string certification;
    public string victories;
    public string loses;
    public List<Team> teams;
}

[Serializable]
public class Team
{
    public string name;
    public string category;
    public string league;
}
