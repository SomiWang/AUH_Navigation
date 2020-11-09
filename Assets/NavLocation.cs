using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavLocation : MonoBehaviour
{
    [SerializeField]
    UIEscalator m_UIEscalator;
    [SerializeField]
    GameObject m_Arrow;

    bool isArrived;
    Coroutine delay;

    private void Awake()
    {
        m_Arrow.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != Camera.main.gameObject || !GlobalEventSystem.Instance.IsNavigatting/* || target.navlocation != this*/) return;
        {
            GlobalEventSystem.Instance.OnEndNavigatting(GlobalEventSystem.EntranceStatus.Arrived);
            m_UIEscalator.Show(gameObject.transform.position + Camera.main.transform.forward, GlobalEventSystem.EscalatorStatus.None, true);
            m_Arrow.SetActive(true);
            isArrived = true;
        }
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
        m_Arrow.SetActive(false);
        delay = null;
        
    }
}




