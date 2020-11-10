using System;
using UnityEngine;

public class ModelTargetManager : MonoBehaviour
{
    [SerializeField]
    private MonitorDataHandler m_MonitorDataHandler;

    private void Start()
    {
        m_MonitorDataHandler.Hide();
        GetComponentInChildren<Canvas>().enabled = true;
        ImageTargetManager.Instance.OnImageScanStatusChanged += _OnImageScanStatusChanged;
    }

    private void _OnImageScanStatusChanged(bool isScanning)
    {
        if (isScanning)
            m_MonitorDataHandler.Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            OnTargetFound();
        }
    }
    public void OnTargetFound()
    {
        if (ImageTargetManager.Instance.CurrentName == null
            || ImageTargetManager.Instance.CurrentPhoto == null)
            return;

        m_MonitorDataHandler.Show();
        ImageTargetManager.Instance.StopScan();
    }

    public void OnTargetLost()
    {
        if (ImageTargetManager.Instance.CurrentName == null
            || ImageTargetManager.Instance.CurrentPhoto == null)
            return;

        m_MonitorDataHandler.Hide();
    }
}
