using UnityEngine;
using UnityEngine.UI;

public class UIOverlayCanvas : MonoBehaviour
{
    [SerializeField]
    private UILocationMenu m_LocationMenu;
    [SerializeField]
    Button m_ScanButton;

    void Start()
    {
        GlobalEventSystem.Instance.OnStartNavigatting += _OnStartNavigatting;
        GlobalEventSystem.Instance.OnEndNavigatting += _OnEndNavigatting;
        ImageTargetManager.Instance.OnImageScanStatusChanged += _OnImageScanStatusChanged;
        _OnImageScanStatusChanged(ImageTargetManager.Instance.IsScanning);
        if (m_LocationMenu == null) return;
        m_LocationMenu.OnMenuButtonClick += _OnMenuButtonClick;
        m_LocationMenu.OnNavigateButtonClick += _OnNavigateButtonClick;
        m_LocationMenu.HideDropdownMenu();
    }
    private void OnDestroy()
    {
        GlobalEventSystem.Instance.OnStartNavigatting -= _OnStartNavigatting;
        GlobalEventSystem.Instance.OnEndNavigatting -= _OnEndNavigatting;
        ImageTargetManager.Instance.OnImageScanStatusChanged -= _OnImageScanStatusChanged;
        if (m_LocationMenu == null) return;
        m_LocationMenu.OnMenuButtonClick -= _OnMenuButtonClick;
        m_LocationMenu.OnNavigateButtonClick -= _OnNavigateButtonClick;
    }
    private void _OnStartNavigatting()
    {
        m_LocationMenu?.ShowCurrentGoalText(NavigateManager.Instance.CurrentGoalName);
    }
    private void _OnEndNavigatting(EntranceStatus status)
    {
        m_LocationMenu?.HideCurrentGoalText();
    }
    private void _OnImageScanStatusChanged(bool isScanning)
    {
        if (m_LocationMenu == null) return;
        if (isScanning) m_LocationMenu.Hide();
        else m_LocationMenu.Show();
    }
    private void _OnMenuButtonClick()
    {
        m_LocationMenu?.ShowDropdownMenu();
        NavigateManager.Instance.StopNavigate();
    }
    private void _OnNavigateButtonClick(int index)
    {
        NavigateManager.Instance.TrySetGoal(index);
        m_LocationMenu?.HideDropdownMenu();
    }
}
