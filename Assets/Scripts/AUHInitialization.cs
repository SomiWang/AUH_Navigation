using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUHInitialization : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventSystem.Instance.OnInit.Invoke();
        GlobalEventSystem.Instance.Init();
    }
}
