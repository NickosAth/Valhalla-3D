using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public Transform[] Goals;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    private static readonly int walk = Animator.StringToHash("Walking");
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        var randGoal = Random.Range(0, Goals.Length);
        agent.destination = Goals[randGoal].transform.position;

        animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger(walk);
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GoToNextPoint();
        }
    }

    private void GoToNextPoint()
    {
        var randGoal = Random.Range(0, Goals.Length);
        agent.destination = Goals[randGoal].transform.position;
    }
}
