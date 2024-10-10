public class TimeAnalyzerService
{
    public string AnalyzeTime()
    {
        var currentTime = DateTime.Now.TimeOfDay;
        
        if (currentTime.Hours >= 12 && currentTime.Hours < 18)
        {
            return "зараз день";
        }
        else if (currentTime.Hours >= 18 && currentTime.Hours < 24)
        {
            return "зараз вечір";
        }
        else if (currentTime.Hours >= 0 && currentTime.Hours < 6)
        {
            return "зараз ніч";
        }
        else
        {
            return "зараз ранок";
        }
    }
}