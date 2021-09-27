using UnityEngine;
using UnityEngine.AI;

public class AttackState : INPCState
{
    public INPCState DoState(NPCSearch_ClassBased npc)
    {
      //what needs to happen for state work

        if (npc.navAgent == null)
            npc.navAgent = npc.GetComponent<NavMeshAgent>();

        //do the action that should happen when we are in attack state
        MoveToCritter(npc);

        //is the transition condition met
        if (!npc.critterTarget.activeSelf)
            return npc.wanderState;
        else
            return npc.attackState;
    }

    private void MoveToCritter(NPCSearch_ClassBased npc)
    {
        if (npc.navAgent.destination != npc.critterTarget.transform.position)
            npc.navAgent.SetDestination(npc.critterTarget.transform.position);
    }
}
