using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetManager : MonoBehaviour
{
    [SerializeField]
    private List<string> m_PatientNames;
    [SerializeField]
    private List<Sprite> m_PatientTexs;
    public static ImageTargetManager Instance { get; private set; }
    public Action OnImageFound;
    public Action<bool> OnImageScanStatusChanged;
    public string CurrentName { get; private set; }
    public Sprite CurrentPhoto { get; private set; }

    private bool isScanning;
    public bool IsScanning
    {
        get => isScanning;
        private set
        {
            if (isScanning != value)
            {
                isScanning = value;
                OnImageScanStatusChanged?.Invoke(isScanning);
            }
        }
    }


    private void Awake()
    {
        Instance = this;
        Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            OnTargetFound(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnTargetFound(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnTargetFound(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnTargetFound(3);
        }
    }

    public void Reset()
    {
        CurrentName = null;
        CurrentPhoto = null;
    }

    public void StartScan()
    {
        IsScanning = true;
    }
    public void StopScan()
    {
        IsScanning = false;
        Reset();
    }

    public void OnTargetFound(int index)
    {
        if (!IsScanning || m_PatientNames.Count < index || m_PatientTexs.Count < index) return;
        CurrentName = m_PatientNames[index];
        CurrentPhoto = m_PatientTexs[index];
        OnImageFound?.Invoke();
        Debug.Log("[ImageTarget] Get target." + index);
    }
}
