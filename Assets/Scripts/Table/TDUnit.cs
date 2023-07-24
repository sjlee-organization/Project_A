using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class TDUnit : TDBase
{
    public int unitNo;

    public string unitModel;

    public string unitKind;
    public UnitType unitType;

    public int hp;
    public int mp;

    public int speed;

    public AttackType attackType;

    public int adAttack;
    public int apAttack;

    public int adPen;
    public int apPen;

    public int adDef;
    public int apDef;

    public int mpRecoveryTime;

    public string unitNameKey;


    public override void SetJsonData(string key, JObject info)
    {
        base.SetJsonData(key, info);

        unitNo = int.Parse(key);

        unitModel = ParsingStringData("UnitModel", info);

        unitKind = ParsingStringData("UnitKind", info);

        unitType = ParsingEnumData<UnitType>("UnitType", info);

        hp = ParsingIntData("HP", info);
        mp = ParsingIntData("MP", info);

        speed = ParsingIntData("Speed", info);

        adAttack = ParsingIntData("AD_Attack", info);
        apAttack = ParsingIntData("AP_Attack", info);

        adPen = ParsingIntData("AD_PEN", info);
        apPen = ParsingIntData("AP_PEN", info);

        adDef = ParsingIntData("AD_DEF", info);
        apDef = ParsingIntData("AP_DEF", info);

        mpRecoveryTime = ParsingIntData("MP_Recovery_Time", info);

        unitNameKey = ParsingStringData("UnitNameKey", info);
    } 
}