using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationMenuController : MonoBehaviour
{
    [SerializeField]
    Button m_MenuButton;
    [SerializeField]
    Button m_ScanButton;
    [SerializeField]
    Button m_NavigateButton;
    [SerializeField]
    GameObject m_DropdownRoot;
    [SerializeField]
    Image m_Background;
    [SerializeField]
    Text m_CurrentGoal;

    private Dropdown dropdownMenu;

    void Start()
    {
        m_MenuButton.onClick.AddListener(_ShowDropDownRoot);
        m_NavigateButton.onClick.AddListener(_StartNavigate);
        dropdownMenu = m_DropdownRoot.GetComponentInChildren<Dropdown>();
        _SwitchUIState(false);
        m_CurrentGoal.gameObject.SetActive(GlobalEventSystem.Instance.IsNavigatting);
        GlobalEventSystem.Instance.OnStartNavigatting += _OnStartNavigatting;
        GlobalEventSystem.Instance.OnEndNavigatting += _OnEndNavigatting;
        ImageTargetManager.Instance.OnImageScanStatusChanged += _OnImageScanStatusChanged;
        m_MenuButton.gameObject.SetActive(!ImageTargetManager.Instance.IsScanning);
    }

    private void _OnImageScanStatusChanged(bool isScanning)
    {
        m_MenuButton.gameObject.SetActive(!isScanning);
    }

    private void OnDestroy()
    {
        GlobalEventSystem.Instance.OnStartNavigatting -= _OnStartNavigatting;
        GlobalEventSystem.Instance.OnEndNavigatting -= _OnEndNavigatting;
    }
    private void _OnEndNavigatting(GlobalEventSystem.EntranceStatus status)
    {
        m_CurrentGoal.gameObject.SetActive(false);
    }
    private void _OnStartNavigatting()
    {
        m_CurrentGoal.gameObject.SetActive(true);
    }

    private void _StartNavigate()
    {
        if (dropdownMenu.value != 2) return;
        _SwitchUIState(false);
        NavigateManager.Instance.TrySetGoal("LocationName");
    }

    private void _ShowDropDownRoot()
    {
        _SwitchUIState(true);

    }
    private void _SwitchUIState(bool isOnDropdownMenu)
    {
        m_Background.gameObject.SetActive(isOnDropdownMenu);
        m_DropdownRoot.gameObject.SetActive(isOnDropdownMenu);
        m_MenuButton.gameObject.SetActive(!isOnDropdownMenu);
        m_ScanButton.gameObject.SetActive(!isOnDropdownMenu);
    }
}
