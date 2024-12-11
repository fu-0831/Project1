using UnityEngine;

public class UnitBaseParameter : ScriptableObject
{
    [Tooltip("�ő�HP")] public float HP;
    [Tooltip("�����U����")] public float PhisicalAttackPower;
    [Tooltip("�����h���")] public float PhisicalDeffensePower;
    [Tooltip("����U����")] public float SpecialAttackPower;
    [Tooltip("����h���")]public float SpecialDeffensePower;
    [Tooltip("�ړ����x")] public float MovePower;
    [Tooltip("�A�N�V�����J�n����")] public float ActionRange;
    [Tooltip("�A�N�V�����N�[���^�C��")] public float ActionCoolTime;
}
