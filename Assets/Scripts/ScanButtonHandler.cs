using UnityEngine;
using UnityEngine.UI;

public class ScanButtonHandler : MonoBehaviour
{
    [SerializeField]
    private UIScanHint m_ScanHint;
    private Text m_ButtonText;
    void Start()
    {
        var btn = GetComponent<Button>();
        if (btn != null)
            btn.onClick.AddListener(_OnClick);
        m_ButtonText = GetComponentInChildren<Text>();
        ImageTargetManager.Instance.OnImageFound += _OnImageFound;
        ImageTargetManager.Instance.OnImageScanStatusChanged += OnScanStatusChanged;
    }

    private void _OnClick()
    {
        if (ImageTargetManager.Instance.IsScanning)
            ImageTargetManager.Instance.StopScan();
        else
            ImageTargetManager.Instance.StartScan();
    }
    private void OnScanStatusChanged(bool isScanning)
    {
        if (isScanning)
        {
            m_ScanHint.Show(string.Empty, "請掃描患者照片", false);
            m_ButtonText.text = "結束掃描";
        }
        else
        {
            m_ScanHint.Hide();
            m_ButtonText.text = "掃描";
        }
    }

    private void _OnImageFound()
    {
        if (m_ScanHint == null) return;
        m_ScanHint.Show($"已獲取患者 {ImageTargetManager.Instance.CurrentName} 資訊，請將鏡頭對向血液透析儀", string.Empty, true);
    }
}
