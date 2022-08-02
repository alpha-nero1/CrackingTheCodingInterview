using System;

namespace Core.Experiments;

public static class DateTimeExperiment
{
    public static void Experiment()
    {
        var dNow = DateTime.Now;
        var dNowUtcLocalTime = DateTime.UtcNow.ToLocalTime();
        var dNowUtc = DateTime.UtcNow;

        Console.WriteLine(dNow); // 2/08/2022 3:39:25 PM
        Console.WriteLine(dNowUtcLocalTime); // 2/08/2022 3:39:25 PM
        Console.WriteLine(dNowUtc); // 2/08/2022 5:40:08 AM
    }
}