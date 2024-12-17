using UnityEngine;

[CreateAssetMenu(menuName ="System/Parameter/UnitSpawn")]
public class UnitSpawnParameter : ScriptableObject
{
    [Tooltip("�ߋ������j�b�g������")] public int ShortRangeDroneSpawnCount;
    [Tooltip("���������j�b�g������")] public int LongRangeDroneSpawnCount;
    [Tooltip("�񕜃��j�b�g������")] public int HealDroneSpawnCount;
    [Tooltip("�^���N���j�b�g������")] public int ShieldDroneSpawnCount;

}
