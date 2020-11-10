using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIConditionHint : MonoBehaviour
{
    private Coroutine lookAtCoroutine;
    [SerializeField]
    private Text m_Content;

    private void Awake()
    {
        Hide();
    }
    public void Show(EscalatorStatus status, bool isArrived = false)
    {
        gameObject.SetActive(true);

        if (isArrived) m_Content.text = "已抵達目的地";
        switch (status)
        {
            case EscalatorStatus.Up:
                m_Content.text = "請到左側電扶梯前往三樓";
                break;
            case EscalatorStatus.Down:
                m_Content.text = "請下樓";
                break;
        }
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator LookAtCamera()
    {
        var dirToCam = Camera.main.transform.position - transform.position;
        dirToCam.y = 0.0f;
        var rotation = Quaternion.FromToRotation(-transform.forward, dirToCam);
        transform.rotation = rotation * transform.rotation;

        while (true)
        {
            dirToCam = Camera.main.transform.position - transform.position;
            dirToCam.y = 0.0f;
            rotation = Quaternion.FromToRotation(-transform.forward, dirToCam);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation * transform.rotation, Time.deltaTime * 0.5f);
            yield return null;
        }
    }
}
