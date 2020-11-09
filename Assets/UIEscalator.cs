using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIEscalator : MonoBehaviour
{
    private Coroutine lookAtCoroutine;
    [SerializeField]
    private Text m_Content;

    private void Awake()
    {
        Hide();
    }
    public void Show(Vector3 pos, GlobalEventSystem.EscalatorStatus status, bool isArrived = false)
    {
        gameObject.SetActive(true);
        //transform.position = pos;
        ////Align to Vector.up
        //var rotation = Quaternion.FromToRotation(transform.up, Vector3.up);
        //transform.rotation = rotation * transform.rotation;
        //if (lookAtCoroutine != null) StopCoroutine(lookAtCoroutine);
        //lookAtCoroutine = StartCoroutine(LookAtCamera());

        if (isArrived) m_Content.text = "已抵達目的地";

        switch (status)
        {
            case GlobalEventSystem.EscalatorStatus.Up:
                m_Content.text = "請到左側電扶梯前往三樓";
                break;
            case GlobalEventSystem.EscalatorStatus.Down:
                m_Content.text = "請下樓";
                break;
        }
    }
    public void Hide()
    {
        //if (lookAtCoroutine != null) StopCoroutine(lookAtCoroutine);
        gameObject.SetActive(false);
    }

    private IEnumerator LookAtCamera()
    {
        var dirToCam = Camera.main.transform.position - transform.position;
        dirToCam.y = 0.0f;
        //float angle = Vector3.Angle(transform.forward, dirToCam);
        var rotation = Quaternion.FromToRotation(-transform.forward, dirToCam);
        transform.rotation = rotation * transform.rotation;

        while (true)
        {
            dirToCam = Camera.main.transform.position - transform.position;
            dirToCam.y = 0.0f;
            //angle = Vector3.Angle(transform.forward, dirToCam);
            //if ((int)angle == 0) yield return null;
            //Debug.LogError($"Angle{angle}");
            rotation = Quaternion.FromToRotation(-transform.forward, dirToCam);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation * transform.rotation, Time.deltaTime * 0.5f);
            yield return null;
        }
        //lookAtCoroutine = null;
    }
}
