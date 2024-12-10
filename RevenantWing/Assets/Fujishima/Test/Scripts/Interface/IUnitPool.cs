using UnityEngine;

public interface IUnitPool 
{
    public UnitBase TakeUnit() 
    { 
        Debug.Log("IUnitPool : TakeUnit デフォルト実装が起動しました");
        return default;
    }

    public void ReturnUnit(UnitBase returnDrone)
    {
        Debug.Log("IUnitPool : ReturnUnit デフォルト実装が起動しました");
    }
}