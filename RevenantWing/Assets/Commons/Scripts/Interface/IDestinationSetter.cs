using UnityEngine;
public interface IDestinationSetter
{
    public void SetDestination(Vector3 destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Vector3) デフォルト実装が起動しています"); }
    public void SetDestination(Transform destinationPoint) { Debug.Log("IDestinationSetter : SetDestination(Transform) デフォルト実装が起動しています"); }
}
