using UnityEngine;

public interface IUnitSpawner
{
    public void SpawnUnit(UnitID unitID, int createCount) { Debug.Log("IUnitSpawner : SpawnUnit デフォルト実装が起動しています"); }
}
