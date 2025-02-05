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
    public string firstname;
    public string surname;
    public string degree;
    public Team teams;
}

[Serializable]
public class Team
{
    public string name;
    public string category;
    public string league;
}
