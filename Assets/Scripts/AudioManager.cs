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

    private void _OnEndNavigatting(EntranceStatus status)
    {
        if (status == EntranceStatus.Arrived)
            PlayAudio(2);
    }

    private void _OnEscalatorStatusChanged(EscalatorStatus status, int floorNo)
    {
        if (!GlobalEventSystem.Instance.IsNavigatting
           || status != EscalatorStatus.Enter
           || NavigateManager.Instance.TargetFloor == 0) return;
        if (floorNo == NavigateManager.Instance.TargetFloor) PlayAudio(1);
        else PlayAudio(0);
    }

    [SerializeField]
    private AudioClip[] m_AudioList;
    public void PlayAudio(int index)
    {
        audioSource.clip = m_AudioList[index];
        audioSource.Play();
    }
}
