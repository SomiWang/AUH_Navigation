using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IndexButton : Button
{
    public int Index;
    public IndexButtonClickedEvent OnClick { get; set; } = new IndexButtonClickedEvent();
    protected IndexButton() : base()
    {
        onClick.AddListener(_OnClick);
    }

    private void _OnClick()
    {
        OnClick.Invoke(Index);
    }

    public class IndexButtonClickedEvent : UnityEvent<int>
    {
        public IndexButtonClickedEvent() : base()
        {


        }
    }
}
