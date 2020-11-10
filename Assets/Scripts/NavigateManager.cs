using System.Collections.Generic;
using UnityEngine;

public class NavigateManager : MonoBehaviour
{
    [SerializeField]
    private RoadContianer m_RoadContianer;
    [SerializeField]
    private UIConditionHint m_ConditionHint;
    [SerializeField]
    private GameObject[] m_Arrows;
    [SerializeField]
    private List<NavLocation> m_Locations = new List<NavLocation>();
    public static NavigateManager Instance;
    public int TargetFloor { get; private set; }
    public string CurrentGoalName { get; private set; }
    private EscalatorEntrance currentEscalatorEntrance;
    private EscalatorStatus targetEscalatorStatus;
    private void Start()
    {
        Instance = this;
        GlobalEventSystem.Instance.OnEscalatorStatusChanged += _OnEscalatorStatusChanged;
        GlobalEventSystem.Instance.OnEndNavigatting += _OnEndNavigatting;
        SwitchArrows(false);
    }
    private void OnDestroy()
    {
        GlobalEventSystem.Instance.OnEscalatorStatusChanged -= _OnEscalatorStatusChanged;
        GlobalEventSystem.Instance.OnEndNavigatting -= _OnEndNavigatting;
    }
    public void StopNavigate()
    {
        GlobalEventSystem.Instance.OnEndNavigatting.Invoke(EntranceStatus.ForceStopped);
    }
    private void _OnEndNavigatting(EntranceStatus status)
    {
        m_RoadContianer.HideRoads();
        SwitchArrows(false);
    }

    private void _OnEscalatorStatusChanged(EscalatorStatus status, int floor)
    {
        if (targetEscalatorStatus == EscalatorStatus.None) return;

        if (TargetFloor == floor)
        {
            targetEscalatorStatus = EscalatorStatus.None;
            TargetFloor = 0;
            m_ConditionHint?.Hide();
            //SwitchArrows(false);
            ShowRoad();
            return;
        }

        switch (status)
        {
            case EscalatorStatus.Enter:
                m_RoadContianer.HideRoads();
                m_ConditionHint?.Show(targetEscalatorStatus);
                SwitchArrows(true);
                break;
            case EscalatorStatus.Exit:
                _SetLastGoal(2);
                m_ConditionHint?.Hide();
                break;
        }
    }

    public void ShowRoad()
    {
        //TODO
        m_RoadContianer.HideRoads();
        m_RoadContianer.Roads[1].SetActive(true);
    }

    public bool TrySetGoal(int index)
    {
        //TODO NavMesh
        //Temporary
        m_RoadContianer.HideRoads();
        m_RoadContianer.Roads[0].SetActive(true);
        targetEscalatorStatus = EscalatorStatus.Up;
        TargetFloor = 3;
        GlobalEventSystem.Instance.OnStartNavigatting.Invoke();
        return true;
    }

    public void AssignEscalatorEntrance(EscalatorEntrance entrance)
    {
        currentEscalatorEntrance = entrance;
    }

    private void _SetLastGoal(int index)
    {
        TrySetGoal(index);
    }

    private void SwitchArrows(bool isOn)
    {
        foreach (var i in m_Arrows)
        {
            i.SetActive(isOn);
        }
    }
}
