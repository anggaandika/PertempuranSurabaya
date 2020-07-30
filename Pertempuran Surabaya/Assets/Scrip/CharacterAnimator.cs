using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float speedPrecent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPrecent", speedPrecent, locomationAnimationSmoothTime, Time.deltaTime);

        animator.SetBool("inCombat",  combat.InCombat);
    }
}
