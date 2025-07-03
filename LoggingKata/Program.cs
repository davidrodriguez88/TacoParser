using System;
using System.Linq;
using System.IO;
using System.Runtime.ExceptionServices;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("File has no input");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("File only has one line of input");
            }
           
            logger.LogInfo($"First line: {lines[0]}");
            
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double maxDistance = 0;

            // NESTED LOOPS SECTION----------------------------

            // FIRST FOR LOOP -
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    var distance = corA.GetDistanceTo(corB);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }
            logger.LogInfo($"{tacoBell1?.Name} and {tacoBell2?.Name} are the farthest apart.");
        }
    }
}
