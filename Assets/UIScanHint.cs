using UnityEngine;
using UnityEngine.UI;

public class UIScanHint : MonoBehaviour
{
    [SerializeField]
    private Text m_HintText;
    [SerializeField]
    private Image m_HintFrame;
    [SerializeField]
    private Text m_CenterText;
    [SerializeField]
    private float t;
    private float targetAlpha;

    private void Awake()
    {
        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Show("測試123456789", "請掃描患者照片", true);
        }
    }

    public void Show(string str = null, string center = null, bool isShowFrame = false)
    {
        if (str != null) SetHintContent(str);
        if (center != null) m_CenterText.text = center;
        gameObject.SetActive(true);
        SwitchHintFrame(isShowFrame);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SwitchHintFrame(bool isOn)
    {
        m_HintFrame.gameObject.SetActive(isOn);
        m_CenterText.gameObject.SetActive(isOn);
    }
    public void SetHintContent(string str)
    {
        m_HintText.text = str;
    }
}
