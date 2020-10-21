using System.Collections.Generic;
using UnityEngine;

public class UILocationMenu : MonoBehaviour
{
    [SerializeField]
    private List<string> m_LocationNames = new List<string>();
    [SerializeField]
    IndexButton[] m_Buttons;

    private void Awake()
    {
        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].Index = i;
            m_Buttons[i].OnClick.AddListener(OnLocationButton);
        }
    }

    private void OnLocationButton(int index)
    {
        if (m_LocationNames.Count > index && NavigateManager.Instance.TrySetGoal(m_LocationNames[index]))
            gameObject.SetActive(false);
    }
}
