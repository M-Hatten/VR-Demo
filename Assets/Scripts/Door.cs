using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorState
{
    CLOSED,
    OPENING,
    OPEN,
}

public class Door : MonoBehaviour
{
    private Dictionary<DoorState, Action> stateMethods;
    public DoorState CurState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        stateMethods = new()
        {
            [DoorState.CLOSED] = StateClosed,
            [DoorState.OPENING] = StateOpening,
            [DoorState.OPEN] = StateOpen,
        };
        CurState = DoorState.CLOSED;
    }

    public void ChangeState(DoorState NewState)
    {
        if (CurState != NewState)
        {
            CurState = NewState;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stateMethods.ContainsKey(CurState))
        {
            stateMethods[CurState]();
        }
    }

    private void StateClosed()
    {

    }

    private void StateOpening()
    {

    }

    private void StateOpen()
    {

    }
}
