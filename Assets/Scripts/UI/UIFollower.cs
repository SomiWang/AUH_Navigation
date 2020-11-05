using UnityEngine;

[ExecuteInEditMode]
public class UIFollower : MonoBehaviour
{
    [SerializeField]
    GameObject m_Target;

    // Update is called once per frameㄌ
    void Update()
    {
        transform.position = m_Target.transform.position;
        transform.rotation = m_Target.transform.rotation;
    }
}
