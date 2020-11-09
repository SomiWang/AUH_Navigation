using System;
using UnityEngine;
using UnityEngine.UI;

public class MonitorDataHandler : MonoBehaviour
{
    [SerializeField]
    private string m_HRLable = "心率 : ";
    [SerializeField]
    private string m_OSLable = "血氧濃度 : ";
    [SerializeField]
    private string m_TPLable = "透析液溫度 : ";

    [SerializeField]
    private Image m_MonitorImage;
    [SerializeField]
    private Text m_HeartRate;
    [SerializeField]
    private Text m_OxygenSaturationText;
    [SerializeField]
    private Text m_TemperatureText;

    private void Start()
    {
        if (!IsInvoking("_UpdateMonitor"))
        {
            InvokeRepeating("_UpdateMonitor", 0, 2);
        }
    }
    public void Show()
    {
        m_MonitorImage.gameObject.SetActive(true);
        if (ImageTargetManager.Instance.CurrentPhoto != null)
            m_MonitorImage.sprite = ImageTargetManager.Instance.CurrentPhoto;
    }

    public void Hide()
    {
        m_MonitorImage.gameObject.SetActive(false);
    }

    private void _UpdateMonitor()
    {
        if (m_HeartRate != null)
        {
            int hr = UnityEngine.Random.Range(58, 80);
            m_HeartRate.text = m_HRLable + hr.ToString();
        }

        if (m_OxygenSaturationText != null)
        {
            float os = UnityEngine.Random.Range(70.0f, 100.0f);
            os = (float)Math.Round(os, 1, MidpointRounding.AwayFromZero);
            m_OxygenSaturationText.text = m_OSLable + os + "%";
        }

        if (m_TemperatureText != null)
        {
            float tp = UnityEngine.Random.Range(35.0f, 38.0f);
            tp = (float)Math.Round(tp, 1, MidpointRounding.AwayFromZero);
            m_TemperatureText.text = m_TPLable + tp + "°C";
        }
    }
}
