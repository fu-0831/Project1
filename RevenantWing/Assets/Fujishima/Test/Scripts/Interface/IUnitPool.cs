using UnityEngine;

public interface IUnitPool 
{
    public UnitBase TakeUnit() 
    { 
        Debug.Log("IUnitPool : TakeUnit �f�t�H���g�������N�����܂���");
        return default;
    }

    public void ReturnUnit(UnitBase returnDrone)
    {
        Debug.Log("IUnitPool : ReturnUnit �f�t�H���g�������N�����܂���");
    }
}