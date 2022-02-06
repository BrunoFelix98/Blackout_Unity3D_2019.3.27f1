using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Condition/Damage Condition")]
public class DamageCondition : Condition
{
    [SerializeField]
    private bool Negation;

    public override bool test(FiniteStateMachine fsm)
    {
        if (fsm.GetEnemy().health < fsm.GetEnemy().maxHealth)
        {
            return !Negation;
        }
        else
        {
            return Negation;
        }
    }
}
