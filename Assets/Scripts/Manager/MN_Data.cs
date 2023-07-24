using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MN_Data : MonoBehaviour
{
    private string basePath = "DataTable";

    public Dictionary<int, TDUnit> tdUnitDict = new Dictionary<int, TDUnit>();

    private void Awake()
    {
        LoadTableData();
    }

    public void LoadTableData()
    {
        LoadUnitTable();
    }


    public void LoadUnitTable()
    {
        tdUnitDict.Clear();

        TextAsset jsonText = Resources.Load<TextAsset>(basePath + "/Unit");

        JObject parsedObj = new JObject();

        try
        {
            parsedObj = JObject.Parse(jsonText.text);

            foreach (KeyValuePair<string, JToken> pair in parsedObj)
            {
                TDUnit tdUnit = new TDUnit();
                tdUnit.SetJsonData(pair.Key, pair.Value.ToObject<JObject>());

                tdUnitDict.Add(tdUnit.unitNo, tdUnit);
            }
        }

        catch
        {

        }
    }
}