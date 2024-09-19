public class DayOfWeek_CodeGrade {
    public static int int_Day;

    public DayOfWeek_CodeGrade(int int_day) {
        int_Day = int_day;
    }
    
    public static string IndexToDay(int int_indexday) {
        int_indexday = makeValid(int_indexday);

        string str_returnValue = int_indexday switch
        {
            0 => "Monday",
            1 => "Tuesday",
            2 => "Wednesday",
            3 => "Thursday",
            4 => "Friday",
            5 => "Saturday",
            6 => "Sunday",
            _ => "out of range",
        };
        return str_returnValue;
    }

    private static int makeValid(int int_indexday) {
        int returnValue = int_indexday;
        List<int> Allowed_Integers = new List<int>();
        Allowed_Integers.Add(0);
        Allowed_Integers.Add(1);
        Allowed_Integers.Add(2);
        Allowed_Integers.Add(3);
        Allowed_Integers.Add(4);
        Allowed_Integers.Add(5);
        Allowed_Integers.Add(6);
        while (!Allowed_Integers.Contains(returnValue)) {
            if (returnValue > 6) {
                returnValue -= 7;
            } else {
                returnValue += 7;
            }
        }
        return returnValue;
    }

    public bool IsWeekend() {
        int int_day = makeValid(int_Day);

        if (int_day == 5 || int_day == 6) {
            return true;
        }
        return false;
    }

    public string CurrentDay() {
        return IndexToDay(int_Day);
    }

    public void NextDay() {
        int_Day++;
    }
}