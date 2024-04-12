
try
{
    Date date1 = new Date(2024, 03, 28);
    //Вычислить количество дней между датами
    Console.WriteLine($"Days between dates: {date1.DaysBetween(2022, 10, 20)}");
    //Вычислить високосный ли год или нет
    Console.WriteLine($"Define a leap year: {date1.IsLeapYear(2024)}");
    //Вычислить дату через некоторое количество дней
    Console.WriteLine($"Calculation the date after a given number of days: {date1.AddDays(12)} ");
    //Вычислить дату некоторое количество дней назад
    Console.WriteLine($"Calculation the specified number of days from the date:{date1.SubtractDays(10)}");
    //Сравнить даты
    Console.WriteLine($"Compare dates: {date1.Comparison(2021, 11, 21)}");
}
catch (Exception ex)
{
    Console.WriteLine("You got an error" + ex.Message);
}

public interface IDate
{
    uint Year { get; set; }
    uint Month { get; set; }
    uint Day { get; set; }
    bool IsLeapYear(uint _year);
}

abstract class AbstrDate : IDate
{
    protected uint _year;
    protected uint _month;
    protected uint _day;
    public uint Year
    {
        get { return _year; }
        set { _year = value; }
    }
    public uint Month
    {
        get { return _month; }
        set { _month = value; }
    }
    public uint Day
    {
        get { return _day; }
        set { _day = value; }
    }
    public bool IsLeapYear(uint _year)
    {
        return IsLeapYear(_year);
    }
}

class Date : AbstrDate
{
    public DateTime ToDateTime()
    {
        return new DateTime((int)_year, (int)_month, (int)_day);
    }
    public Date(uint year, uint month, uint day)
    {
        _year = year;
        _month = month;
        _day = day;
    }
    public bool IsLeapYear(uint year)
    {
        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public uint AddDays(uint days)
    {
        var date = ToDateTime();
        date = date.AddDays(days);
        return (uint)date.Day;
    }
    public uint SubtractDays(uint days)
    {
        var date = ToDateTime();
        date = date.AddDays(-days);
        return (uint)date.Day;
    }

    public uint DaysBetween(uint otherYear, uint otherMonth, uint otherDay)
    {
        var thisDate = ToDateTime();
        var otherDate = new DateTime((int)otherYear, (int)otherMonth, (int)otherDay);
        return (uint)(thisDate - otherDate).TotalDays;
    }
    public string Comparison(uint otherYear, uint otherMonth, uint otherDay)
    {
        var thisDate = ToDateTime();
        var otherDate = new DateTime((int)otherYear, (int)otherMonth, (int)otherDay);
        if (thisDate == otherDate)
        {
            return "Dates are equally";
        }
        if (thisDate > otherDate)
        {
            return "The date is earlier";
        }
        if (thisDate < otherDate)
        {
            return "The date is later";
        }
        return "Dates are not comparable";
    }
    public override string ToString()
    {
        return $"{Year}.{Month}.{Day}";
    }
}