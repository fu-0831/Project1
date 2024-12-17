using UnityEngine;

[CreateAssetMenu(menuName ="System/Parameter/UnitSpawn")]
public class UnitSpawnParameter : ScriptableObject
{
    [Tooltip("近距離ユニット生成数")] public int ShortRangeDroneSpawnCount;
    [Tooltip("遠距離ユニット生成数")] public int LongRangeDroneSpawnCount;
    [Tooltip("回復ユニット生成数")] public int HealDroneSpawnCount;
    [Tooltip("タンクユニット生成数")] public int ShieldDroneSpawnCount;

}
