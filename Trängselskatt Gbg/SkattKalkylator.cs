using System.Globalization;

namespace Trängselskatt_Gbg
{
    public class SkattKalkylator
    {
        public static string RäknaTotalBelopp(IEnumerable<string> tullStationPasseringarList)
        {
            int summa = 0;

            foreach (var tullStationPasseringar in tullStationPasseringarList)
            {
                var cultureInfo = new CultureInfo("de-DE");
                var passering = DateTime.Parse(tullStationPasseringar, cultureInfo);
                var timeOnly = TimeOnly.FromDateTime(passering);

                if (passering.Month == 07)
                    return $"Den totala avgiften är 0kr(juli månad)";

                if (passering.DayOfWeek == DayOfWeek.Saturday)
                    return $"Den totala avgiften är 0kr(lördag)";

                if (passering.DayOfWeek == DayOfWeek.Sunday)
                    return $"Den totala avgiften är 0kr(söndag)";

                switch (timeOnly)
                {
                    //Om tiden är mellan 06:00–06:29 blir skatten(summa) 8
                    case var time when time >= new TimeOnly(06, 00, 00) && time <= new TimeOnly(06, 29, 59):
                        summa += 8;
                        break;

                    //Om tiden är mellan 06:30–06:59 blir skatten(summa) 13
                    case var time when time >= new TimeOnly(06, 30, 00) && time <= new TimeOnly(06, 59, 59):
                        summa += 13;
                        break;

                    //Om tiden är mellan 07:00–07:59 blir skatten(summa) 18
                    case var time when time >= new TimeOnly(07, 00, 00) && time <= new TimeOnly(07, 59, 59):
                        summa += 18;
                        break;

                    //Om tiden är mellan 08:00–08:29 blir skatten(summa) 13
                    case var time when time >= new TimeOnly(08, 00, 00) && time <= new TimeOnly(08, 29, 59):
                        summa += 13;
                        break;

                    //Om tiden är mellan 08:30–14:59 blir skatten(summa) 8
                    case var time when time >= new TimeOnly(08, 30, 00) && time <= new TimeOnly(14, 59, 59):
                        summa += 8;
                        break;

                    //Om tiden är mellan 15:00–15:29 blir skatten(summa) 13
                    case var time when time >= new TimeOnly(15, 00, 00) && time <= new TimeOnly(15, 29, 59):
                        summa += 13;
                        break;

                    //Om tiden är mellan 15:30–16:59 blir skatten(summa) 18
                    case var time when time >= new TimeOnly(15, 30, 00) && time <= new TimeOnly(16, 59, 59):
                        summa += 18;
                        break;

                    //Om tiden är mellan 17:00–17:59 blir skatten(summa) 13
                    case var time when time >= new TimeOnly(17, 00, 00) && time <= new TimeOnly(17, 59, 59):
                        summa += 13;
                        break;

                    //Om tiden är mellan 18:00–18:29 blir skatten(summa) 8
                    case var time when time >= new TimeOnly(18, 00, 00) && time <= new TimeOnly(18, 29, 59):
                        summa += 8;
                        break;

                    //Om tiden är mellan 18:30–05:59 blir skatten(summa) 0
                    case var time when time >= new TimeOnly(18, 30, 00) && time <= new TimeOnly(05, 59, 59):
                        summa += 0;
                        break;

                    default:
                        break;
                }
            }

            if (summa > 60)
                return $"Den totala avgiften är 60kr";
            else
                return $"Den totala avgiften är {summa}kr";
        }
    }
}