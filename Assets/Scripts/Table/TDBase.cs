using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System;

public class TDBase
{
    public virtual void SetJsonData(string key, JObject info)
    {

    }

    protected virtual int ParsingIntData(string key, JObject info)
    {
        int data = 0;

        if (info[key] != null)
        {
            data = info[key].Value<int>();
        }

        return data;
    }

    protected virtual float ParsingFloatData(string key, JObject info)
    {
        float data = 0;

        if (info[key] != null)
        {
            data = info[key].Value<float>();
        }

        return data;
    }

    protected virtual string ParsingStringData(string key, JObject info)
    {
        string data = "";

        if (info[key] != null)
        {
            data = info[key].Value<string>();
        }

        return data;
    }

    protected virtual T ParsingEnumData<T>(string key, JObject info)
    {
        T data = default(T);

        if (info[key] != null)
        {
            if (EnumUtil<T>.TryParse(info[key].Value<string>()))
            {
                data = EnumUtil<T>.Parse(info[key].Value<string>());
            }
        }

        return data;
    }
}