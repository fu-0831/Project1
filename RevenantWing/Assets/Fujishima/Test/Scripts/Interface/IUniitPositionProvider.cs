using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUniitPositionProvider
{
    public List<DroneBase> Drones { get; }

    public void SetOtherUnitInformation();
}
