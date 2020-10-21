using UnityEngine;

public class EntranceCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cam"))
            GlobalEventSystem.Instance.OnEnterEntrance.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cam"))
            GlobalEventSystem.Instance.OnExitEntrance.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cam")
            && !GlobalEventSystem.Instance.InEntranceCollider)
            GlobalEventSystem.Instance.OnEnterEntrance.Invoke();
    }
}
