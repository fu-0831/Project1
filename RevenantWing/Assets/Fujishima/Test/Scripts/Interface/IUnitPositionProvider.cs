using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitPositionProvider
{
    public List<UnitBase> UnitList { get; }
}
