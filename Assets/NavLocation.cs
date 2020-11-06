using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavLocation : MonoBehaviour
{
    [SerializeField]
    UIEscalator m_UIEscalator;
    [SerializeField]
    Vector3 m_Offset;
    bool isArrived;
    Coroutine delay;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != Camera.main.gameObject || !GlobalEventSystem.Instance.IsNavigatting/* || target.navlocation != this*/) return;

        isArrived = true;
        GlobalEventSystem.Instance.OnEndNavigatting(GlobalEventSystem.EntranceStatus.Arrived);
        m_UIEscalator.Show(gameObject.transform.position + m_Offset, GlobalEventSystem.EscalatorStatus.None, true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject != Camera.main.gameObject || !isArrived) return;
        if (delay == null) delay = StartCoroutine(DelayToHideUI());
        isArrived = false;
    }

    private IEnumerator DelayToHideUI()
    {
        yield return new WaitForSeconds(3.0f);
        m_UIEscalator.Hide();
        delay = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            m_UIEscalator.Show(gameObject.transform.position + m_Offset, GlobalEventSystem.EscalatorStatus.None, true);
    }
}
