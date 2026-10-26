public static class TimeFormatter
{
    public static string FormatTime (float time)
    {
        byte mins = (byte)(time / 60);
        byte secs = (byte)(time % 60);
        byte decimals = (byte)((time * 100) % 100);        
        return string.Format("{0:00}:{1:00}:{2:00}", mins, secs, decimals);       
    }
}
