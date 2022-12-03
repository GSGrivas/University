using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EdabitExercise
{
    public class Incident
    {
        
        public class Foul
        {
            public string sIncident;

            public Foul()
            {
                sIncident = "The referee deemed a foul.";
            }    

            public string Foul()
            {
                return sIncident;
            }

        }
        public class Injury
        {
            public string sIncident = "Oh no! Player " + 8 + " is injured. Medics are on the field.";
            private int iInjury;

            public Injury(int iInjury)
            {
                this.iInjury = iInjury;
            }
        }
    }

    public static class PlayAnalyzer
    {
        public static string AnalyzeOnField(int shirtNum)
        {
            switch (shirtNum)
            {
                case 1: return "goalie"; break;
                case 2: return "left back";   break;
                case 3:
                case 4: return "center back"; break;
                case 5: return "right back"; break;
                case 6: 
                case 7:
                case 8: return "midfielder"; break;
                case 9: return "left wing"; break;
                case 10: return "striker"; break;
                case 11: return "right wing"; break;
                default: throw new ArgumentOutOfRangeException(""); break;
            }
        }

        public static string AnalyzeOffField(object report)
        {
            switch (report)
            {
                case int: return "There are " + (int)report + " supporters at the match."; break;
                case string: return report.ToString() ; break;
                case Incident.Foul: return report.ToString(); break;
                case Incident.Injury: return report.ToString(); break;
                default: throw new ArgumentException(""); break;
            }
        }
    }

}
