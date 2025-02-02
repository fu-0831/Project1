using UnityEngine;
public interface ITargetSetter
{
    public void SetSquadTarget(Vector3 destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Vector3) デフォルト実装が起動しています"); }
    public void SetSquadTarget(Transform destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Transform) デフォルト実装が起動しています"); }
}
