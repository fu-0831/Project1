using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "List/UnitList", fileName = "UnitList")]
public class UnitList : ScriptableObject
{
    [Tooltip("���j�b�g���X�g")] public UnitBase[] Units;
}
