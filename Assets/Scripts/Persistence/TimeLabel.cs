using System;
using TMPro;
using UnityEngine;

public class TimeLabel : MonoBehaviour
{
    public void UpdateWith(TimeSpan time)
    {
        GetComponent<TMP_Text>().text = TimeFormat.AsStopwatch((float)time.TotalSeconds);
    }
}