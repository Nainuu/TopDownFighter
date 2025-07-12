// using UnityEngine;

// public class BossRun : StateMachineBehaviour
// {
//     Transform player;
//     Rigidbody2D rb;
//     public float speed = 2f; // Speed of the boss
//     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         rb = animator.GetComponent<Rigidbody2D>();
//         if (player == null)
//         {
//             Debug.LogWarning("Player not found in BossRun state");
//             return;
//         }
//     }

//     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//        Vector2 targetPosition = player.position;
//         Vector2 direction = (targetPosition - rb.position).normalized;
        
//         // Move the boss towards the player
//         rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        
//         // Optionally, you can add logic to check if the boss is close enough to attack
//         // if (Vector2.Distance(rb.position, targetPosition) < attackRange)
//         // {
//         //     animator.SetTrigger("Attack");
//         // }
//     }

//     // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
       
//     }


// }
