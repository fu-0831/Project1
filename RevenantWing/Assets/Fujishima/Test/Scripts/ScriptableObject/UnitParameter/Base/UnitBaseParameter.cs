using UnityEngine;

public class UnitBaseParameter : ScriptableObject
{
    [Tooltip("最大HP")] public float HP;
    [Tooltip("物理攻撃力")] public float PhisicalAttackPower;
    [Tooltip("物理防御力")] public float PhisicalDeffensePower;
    [Tooltip("特殊攻撃力")] public float SpecialAttackPower;
    [Tooltip("特殊防御力")]public float SpecialDeffensePower;
    [Tooltip("移動速度")] public float MovePower;
    [Tooltip("アクション開始距離")] public float ActionRange;
    [Tooltip("アクションクールタイム")] public float ActionCoolTime;
}
