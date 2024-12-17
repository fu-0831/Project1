using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSquadManager : IDestinationSetter
{
    List<UnitBase> unitList = new List<UnitBase>();

    public UnitSquadManager(List<UnitBase> unitList)
    {
        this.unitList = unitList;
    }

    public void SetDestination(Vector3 destinationPoint)
    {

    }

    public void SetDestination(Transform destinationPoint)
    {

    }
}
