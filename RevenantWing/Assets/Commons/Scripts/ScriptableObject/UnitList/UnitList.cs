using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "List/UnitList", fileName = "UnitList")]
public class UnitList : ScriptableObject
{
    [Tooltip("ユニットリスト")] public UnitBase[] Units;
}
