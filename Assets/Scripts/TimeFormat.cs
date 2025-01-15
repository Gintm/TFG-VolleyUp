using System;

static class TimeFormat
{
    public static string AsStopwatch(float seconds)
    {
        return TimeSpan.FromSeconds(seconds).Seconds > 10
            ? TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss")
            : TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss\.ff");
    }
}