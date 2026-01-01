using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum State { Idle, Running}
    [SerializeField]private float searchRadius;
    [SerializeField]private float moveSpeed;
    private State state;
    private Transform targetRunner;
    private Animator animator;

    private void Start()
    {
        state = State.Idle;
     
        animator = GetComponent<Animator>();

        animator.SetBool("IsRunning", false);
    }
    private void Update()
    {
        ManageState();
    }
    private void ManageState()
    {
        switch (state) {
            case State.Idle:
                SearchForTarget();
                break;
            case State.Running:
                RunTowardsPlayer();
            break;
        }

    }
    private void SearchForTarget()
    {
        Collider [] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget())
                    continue;
                runner.SetTarget();
                targetRunner = runner.transform;

                StartRunningTowardsPlayer();
            }
        }
    }
    private void StartRunningTowardsPlayer()
    {
        animator.SetBool("IsRunning", true);
        state = State.Running;
        
    }
    private void RunTowardsPlayer()
    {
        if (targetRunner == null)
            return;
        
        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, Time.deltaTime * moveSpeed);
        if (Vector3.Distance(transform.position, targetRunner.position) < 1f)
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);   
        }
    }
}
