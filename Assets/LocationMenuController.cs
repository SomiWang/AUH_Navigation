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
    Button m_NavigateButton;
    [SerializeField]
    GameObject m_DropdownRoot;
    [SerializeField]
    Image m_Background;

    private Dropdown dropdownMenu;

    void Start()
    {
        m_MenuButton.onClick.AddListener(_ShowDropDownRoot);
        m_NavigateButton.onClick.AddListener(_StartNavigate);
        dropdownMenu = m_DropdownRoot.GetComponentInChildren<Dropdown>();
        _SwitchUIState(false);
    }

    private void _StartNavigate()
    {
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
    }
}
