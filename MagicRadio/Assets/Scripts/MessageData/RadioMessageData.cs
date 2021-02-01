using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DateTime
{
    public float Year;
    public float Month;
    [SerializeField]
    float _day;
    public float Day
    {
        set
        {
            _day = Mathf.Clamp(value, 1, 31);
        }
        get
        {
            return _day;
        }
    }
    [SerializeField]
    float _hour;
    public float Hour
    {
        set
        {
            _hour = Mathf.Clamp(value, -1, 24);
            if (_hour < 0)
            {
                _hour = 23;
                Day -= 1;
            }
            if (_hour == 24)
            {
                _hour = 0;
                Day += 1;
            }
        }
        get
        {
            return _hour;
        }
    }
    [SerializeField]
    float _min;
    public float Minute
    {
        set
        {
            _min = Mathf.Clamp(value,0,60);
            if(_min==0)
            {
                _min = 59;
                Hour -= 1;
            }
            if (_min == 60)
            {
                _min = 1;
                Hour += 1;
            }
        }
        get
        {
            return _min;
        }
    }
    public bool IsLaterThanOtherDateTime(DateTime targetTime, bool everyDay = false)
    {
        if (!everyDay)
        {
            if ((int)Year > (int)targetTime.Year)
            {
                return true;
            }
            else if ((int)Year < (int)targetTime.Year)
            {
                return false;
            }
            else
            if ((int)Month > (int)targetTime.Month)
            {
                return true;
            }
            else
            if ((int)Month < (int)targetTime.Month)
            {
                return false;
            }
            else
            if ((int)Day > (int)targetTime.Day)
            {
                return true;
            }
            else
            if ((int)Day < (int)targetTime.Day)
            {
                return false;
            }
        }

        if ((int)Hour > (int)targetTime.Hour)
        {
            return true;
        }
        else
        if ((int)Hour < (int)targetTime.Hour)
        {
            return false;
        }
        else
        if ((int)Minute > (int)targetTime.Minute)
        {
            return true;
        }
        else
        if ((int)Minute < (int)targetTime.Minute)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsLaterThanOtherDateTimeSameDay(DateTime targetTime)
    {

        if ((int)Day == (int)targetTime.Day)
        {
            if ((int)Hour > (int)targetTime.Hour)
            {
                return true;
            }
            else
            if ((int)Hour < (int)targetTime.Hour)
            {
                return false;
            }
            else
            if ((int)Minute > (int)targetTime.Minute)
            {
                return true;
            }
            else
            if ((int)Minute < (int)targetTime.Minute)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}


[System.Serializable]
public class RadioMessageData : MessageData
{
   
 
    public DateTime EndTime;
    public float Hz;


}
