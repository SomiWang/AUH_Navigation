using UnityEngine;
using UnityEngine.UI;

public class UIScanHint : MonoBehaviour
{
    [SerializeField]
    private Text m_TopText;
    [SerializeField]
    private Text m_CenterText;
    [SerializeField]
    private Image m_MachineOutline;
    [SerializeField]
    private Image m_HintFrame;

    private void Awake()
    {
        Hide();
    }
    public void Show(string topStr, string centerStr, bool showOutline, bool showFrame = true)
    {
        m_TopText.text = topStr;
        m_CenterText.text = centerStr;
        gameObject.SetActive(true);
        m_MachineOutline.gameObject.SetActive(showOutline);
        m_HintFrame.gameObject.SetActive(showFrame);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SetTopContent(string str)
    {
        m_TopText.text = str;
    }
}
