using System;
using UnityEngine;
using UnityEngine.UI;

public class UILocationMenu : MonoBehaviour
{
    [SerializeField]
    Button m_LocationButton;
    [SerializeField]
    Text m_CurrentGoalText;
    [SerializeField]
    UIDropdownMenu m_DropdownMenu;
    [SerializeField]
    Button m_NavigateButton;
    [SerializeField]
    GameObject m_Background;
    public int SelectedLocation => m_DropdownMenu.Menu.value;
    public event Action OnMenuButtonClick;
    public event Action<int> OnNavigateButtonClick;

    private void Start()
    {
        m_LocationButton.onClick.AddListener(_OnLocationButtonClick);
        m_NavigateButton.onClick.AddListener(_OnNavigateButtonClick);
    }

    private void _OnLocationButtonClick()
    {
        OnMenuButtonClick?.Invoke();
    }
    private void _OnNavigateButtonClick()
    {
        OnNavigateButtonClick?.Invoke(m_DropdownMenu.Menu.value);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void ShowCurrentGoalText(string str)
    {
        if (m_CurrentGoalText == null) return;
        m_CurrentGoalText.text = str;
        m_CurrentGoalText.gameObject.SetActive(true);

    }
    public void HideCurrentGoalText()
    {
        if (m_CurrentGoalText == null) return;
        m_CurrentGoalText.text = string.Empty;
        m_CurrentGoalText.gameObject.SetActive(false);
    }

    public void ShowDropdownMenu()
    {
        m_LocationButton.gameObject.SetActive(false);
        m_DropdownMenu.gameObject.SetActive(true);
        m_Background.gameObject.SetActive(true);
    }
    public void HideDropdownMenu()
    {
        m_LocationButton.gameObject.SetActive(true);
        m_DropdownMenu.gameObject.SetActive(false);
        m_Background.gameObject.SetActive(false);
    }
}
