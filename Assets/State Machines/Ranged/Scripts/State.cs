using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class State : ScriptableObject
{
    [SerializeField]
    private Ai EntryAction;
    [SerializeField]
    private Ai[] StateActions;
    [SerializeField]
    private Ai ExitAction;
    [SerializeField]
    private Transition[] Transitions;

    public Ai[] GetActions()
    {
        return StateActions;
    }
    public Ai GetEntryAction()
    {
        return EntryAction;
    }
    public Ai GetExitAction()
    {
        return ExitAction;
    }
    public Transition[] GetTransition()
    {
        return Transitions;
    }

}
