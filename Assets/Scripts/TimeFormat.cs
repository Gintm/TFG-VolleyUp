using System;

static class TimeFormat
{
    public static string AsStopwatch(float seconds)
    {
        return TimeSpan.FromSeconds( seconds ).ToString( @"mm\:ss" );
    }
}