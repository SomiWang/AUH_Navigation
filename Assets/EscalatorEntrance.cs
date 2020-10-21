using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorEntrance : MonoBehaviour
{
    [SerializeField]
    private bool m_IsDown;
    [SerializeField]
    private int m_Floor;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != Camera.main.gameObject) return;
        NavigateManager.Instance.AssignEscalatorEntrance(this);
        GlobalEventSystem.Instance.OnEscalatorStatusChanged.Invoke(GlobalEventSystem.EscalatorStatus.Enter, m_Floor);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject != Camera.main.gameObject) return;
        var _status = GlobalEventSystem.EscalatorStatus.None;

        switch (GetCameraDirection())
        {
            case Direction.Front:
                if (m_IsDown) _status = GlobalEventSystem.EscalatorStatus.Down;
                else _status = GlobalEventSystem.EscalatorStatus.Up;
                break;
            case Direction.Back:
                _status = GlobalEventSystem.EscalatorStatus.Exit;
                break;
        }
        GlobalEventSystem.Instance.OnEscalatorStatusChanged.Invoke(_status, m_Floor);
    }

    private Direction GetCameraDirection()
    {
        var relativePoint = transform.InverseTransformPoint(Camera.main.transform.position);
        if (relativePoint.z < 0.0)
            return Direction.Back;
        else if (relativePoint.z > 0.0)
            return Direction.Front;

        return Direction.None;
    }

    private enum Direction
    {
        None,
        Front,
        Back
    }
}
