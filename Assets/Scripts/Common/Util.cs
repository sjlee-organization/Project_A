using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{

}

public static class EnumUtil<T>
{
    public static bool TryParse(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }

        if (!Enum.IsDefined(typeof(T), s))
            return false;

        return true;
    }

    public static T Parse(string s)
    {
        return (T)Enum.Parse(typeof(T), s);
    }
}