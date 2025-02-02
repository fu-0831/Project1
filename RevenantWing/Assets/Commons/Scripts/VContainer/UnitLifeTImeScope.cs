using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class UnitLifeTImeScope : LifetimeScope
{
    [SerializeField] ObjectPoolParameter objectPoolParameter;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(objectPoolParameter);
    }
}
