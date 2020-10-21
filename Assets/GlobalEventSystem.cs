using System;

public class GlobalEventSystem
{
    private static GlobalEventSystem instance;
    public static GlobalEventSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GlobalEventSystem();
            }
            return instance;
        }
    }

    public void Init()
    {
        OnEnterEntrance += _InEntranceState;
        OnExitEntrance += _OutEntranceState;
        OnStartNavigatting += _OnStartNavigatting;
        OnEndNavigatting += _OnEndNavigatting;
        OnEscalatorStatusChanged += _OnEscalatorStatusChanged;
    }

    private void _OnEscalatorStatusChanged(EscalatorStatus status, int floor)
    {
        CurrentEscalatorStatus = status;
        CurrentFloor = floor;
    }

    private void _OnEndNavigatting(EntranceStatus obj)
    {
        IsNavigatting = false;
    }

    private void _OnStartNavigatting()
    {
        IsNavigatting = true;
    }

    public bool InEntranceCollider { get; private set; }
    public bool IsNavigatting { get; private set; }
    public EscalatorStatus CurrentEscalatorStatus { get; private set; } = EscalatorStatus.None;
    public int CurrentFloor { get; private set; } = 1;

    public Action OnInit = delegate { };
    public Action OnEnterEntrance = delegate { };
    public Action OnExitEntrance = delegate { };
    public Action<EscalatorStatus, int /*currentfloor*/> OnEscalatorStatusChanged = delegate { };
    public Action OnStartNavigatting = delegate { };
    public Action<EntranceStatus> OnEndNavigatting = delegate { };

    private void _InEntranceState()
    {
        InEntranceCollider = true;
    }

    private void _OutEntranceState()
    {
        InEntranceCollider = false;
    }
    public enum EntranceStatus
    {
        None,
        Arrivated,
        Faild,
        ForceStopped
    }
    public enum EscalatorStatus
    {
        None,
        Enter,
        Up,
        Down,
        Exit
    }
}
