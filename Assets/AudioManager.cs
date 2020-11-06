using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        GlobalEventSystem.Instance.OnEscalatorStatusChanged += _OnEscalatorStatusChanged;
        GlobalEventSystem.Instance.OnEndNavigatting += _OnEndNavigatting;
    }

    private void _OnEndNavigatting(GlobalEventSystem.EntranceStatus status)
    {
        if (status == GlobalEventSystem.EntranceStatus.Arrived)
            PlayAudio(1);
    }

    private void _OnEscalatorStatusChanged(GlobalEventSystem.EscalatorStatus status, int floorNo)
    {
        if (!GlobalEventSystem.Instance.IsNavigatting
           || status != GlobalEventSystem.EscalatorStatus.Enter
           || NavigateManager.Instance.TargetFloor == 0
           || floorNo == NavigateManager.Instance.TargetFloor) return;
        PlayAudio(0);
    }

    [SerializeField]
    private AudioClip[] m_AudioList;
    public void PlayAudio(int index)
    {
        audioSource.clip = m_AudioList[index];
        audioSource.Play();
    }
}
