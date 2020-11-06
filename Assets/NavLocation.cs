using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavLocation : MonoBehaviour
{
    [SerializeField]
    UIEscalator m_UIEscalator;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != Camera.main.gameObject || !GlobalEventSystem.Instance.IsNavigatting/* || target.navlocation != this*/) return;
        {
            GlobalEventSystem.Instance.OnEndNavigatting(GlobalEventSystem.EntranceStatus.Arrived);
            m_UIEscalator.Show(gameObject.transform.position + Camera.main.transform.forward, GlobalEventSystem.EscalatorStatus.None, true);
        }
    }
}
