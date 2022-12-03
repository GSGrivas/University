namespace Application
{
    using EdabitExercise;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using static EdabitExercise.Incident;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(PlayAnalyzer.AnalyzeOffField(new Injury(8)));
        }

    }
}