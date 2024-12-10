using UnityEngine;

[CreateAssetMenu(menuName ="ObjectPool/Parameter",fileName ="ObjectPoolParameter")]
public class ObjectPoolParameter : ScriptableObject
{
    [Tooltip("オブジェクトプール初期生成量")] public int InitialCreateCount;
}