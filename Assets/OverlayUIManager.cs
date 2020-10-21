using UnityEngine;
using UnityEngine.UI;

public class OverlayUIManager : MonoBehaviour
{
    [SerializeField]
    private UILocationMenu m_LocationMenu;
    [SerializeField]
    private Button m_HomeButton;

    void Start()
    {
        //TODO : UIBehaviour
        m_LocationMenu.gameObject.SetActive(!GlobalEventSystem.Instance.IsNavigatting);
        m_HomeButton.onClick.AddListener(OnHomeButtonClick);
    }

    private void OnDestroy()
    {
        m_HomeButton.onClick.RemoveListener(OnHomeButtonClick);
    }
    private void OnHomeButtonClick()
    {
        m_LocationMenu.gameObject.SetActive(true);
    }
}
