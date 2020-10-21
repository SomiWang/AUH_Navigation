﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class NavigateManager : MonoBehaviour
{
    [SerializeField]
    private RoadContianer m_RoadContianer;
    [SerializeField]
    private UIEscalator m_EscalatorUI;
    private EscalatorEntrance currentEscalatorEntrance;
    [SerializeField]
    private List<NavLocation> m_Locations = new List<NavLocation>();
    public static NavigateManager Instance;
    private GlobalEventSystem.EscalatorStatus targetEscalatorStatus;
    private int targetFloor;
    private void Awake()
    {
        Instance = this;
        GlobalEventSystem.Instance.OnEscalatorStatusChanged += _OnEscalatorStatusChanged;
    }

    private void _OnEscalatorStatusChanged(GlobalEventSystem.EscalatorStatus status, int floor)
    {
        if (targetEscalatorStatus == GlobalEventSystem.EscalatorStatus.None) return;

        if (targetFloor == floor)
        {
            targetEscalatorStatus = GlobalEventSystem.EscalatorStatus.None;
            targetFloor = 0;
            m_EscalatorUI?.Hide();
            ShowRoad();
            return;
        }

        switch (status)
        {
            case GlobalEventSystem.EscalatorStatus.Enter:
                m_RoadContianer.HideRoads();
                m_EscalatorUI?.Show(currentEscalatorEntrance.transform.position, targetEscalatorStatus);
                break;
            case GlobalEventSystem.EscalatorStatus.Exit:
                _SetLastGoal("Test");
                m_EscalatorUI?.Hide();
                break;
        }
    }

    public void ShowRoad()
    {
        //TODO
        m_RoadContianer.HideRoads();
        m_RoadContianer.Roads[1].SetActive(true);
    }

    public bool TrySetGoal(string name)
    {
        //TODO NavMesh
        //Temporary
        m_RoadContianer.HideRoads();
        m_RoadContianer.Roads[0].SetActive(true);
        targetEscalatorStatus = GlobalEventSystem.EscalatorStatus.Up;
        targetFloor = 3;
        GlobalEventSystem.Instance.OnStartNavigatting.Invoke();
        return true;
    }

    public void AssignEscalatorEntrance(EscalatorEntrance entrance)
    {
        currentEscalatorEntrance = entrance;
    }

    private void _SetLastGoal(string name)
    {
        TrySetGoal("Test");
    }


}