using UnityEngine;
public interface ITargetSetter
{
    public void SetSquadTarget(Vector3 destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Vector3) �f�t�H���g�������N�����Ă��܂�"); }
    public void SetSquadTarget(Transform destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Transform) �f�t�H���g�������N�����Ă��܂�"); }
}
