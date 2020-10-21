using UnityEngine;

public class RoadContianer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Roads;
    public GameObject[] Roads { get => m_Roads; }

    private void Awake()
    {
        HideRoads();
    }

    public void HideRoads()
    {
        foreach (var i in m_Roads)
        {
            i.SetActive(false);
        }
    }
}
