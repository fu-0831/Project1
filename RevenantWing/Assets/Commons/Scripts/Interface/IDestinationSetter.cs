using UnityEngine;
public interface IDestinationSetter
{
    public void SetDestination(Vector3 destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Vector3) �f�t�H���g�������N�����Ă��܂�"); }
    public void SetDestination(Transform destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Transform) �f�t�H���g�������N�����Ă��܂�"); }
}
