using System.Collections.Generic;
using UnityEngine;

public class UnitSquadManager : ITargetSetter
{
    SquadParameter parameter;

    List<UnitBase> unitList = new List<UnitBase>();

    UnitLender unitLender = null;

    Vector3 appearancePosition = Vector3.zero;

    public UnitSquadManager(SquadParameter parameter, UnitLender unitLender, Vector3 appearancePosition)
    {
        this.parameter = parameter;
        this.unitLender = unitLender;
        this.appearancePosition = appearancePosition;
    }

    private void SetUp()
    {
        unitList = unitLender.LendUnits(UnitID.ShortRangeDrone, parameter.GenerateCount);
        foreach(UnitBase unit in unitList)
        {
            unit.SetUp(appearancePosition);
        }
    }

    /// <summary>
    /// 各ユニットに移動ポイント(Vector3)を設定します。
    /// </summary>
    /// <param name="targetPoint"></param>
    public void SetSquadTarget(Vector3 targetPoint)
    {
        foreach (var unit in unitList)
        {
            unit.SetTarget(targetPoint);
        }
    }

    /// <summary>
    /// 各ユニットに移動対象(Transform)を設定します。
    /// </summary>
    /// <param name="targetPoint"></param>
    public void SetSquadTarget(Transform targetPoint)
    {
        foreach (var unit in unitList)
        {
            unit.SetTarget(targetPoint);
        }
    }

    public void RemoveSquadTarget()
    {
        foreach (var unit in unitList)
        {
            unit.RemoveTarget();
        }
    }

    /// <summary>
    /// スクアッドを削除します。
    /// </summary>
    public void RemoveSquad()
    {
        foreach(UnitBase unit in unitList)
        {
            unitLender.ReturnUnit(unit);
        }
    }
}