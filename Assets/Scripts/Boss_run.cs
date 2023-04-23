using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    [SerializeField] float distance;
    [SerializeField] float _speed,attackRange;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb=animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        boss.LookAtPlayer();
        if (Vector2.Distance(player.position, rb.position) < distance)
        {
            animator.SetBool("__isRange", true);
            if (Vector2.Distance(player.position, rb.position) >= attackRange)
            {
                Vector2 target = new Vector2(player.position.x, rb.position.y);
                Vector2 newPosition = Vector2.MoveTowards(rb.position, target, _speed * Time.fixedDeltaTime);
                rb.MovePosition(newPosition);
                animator.SetBool("__isRange", false);
            }
        }
        //if (Vector2.Distance(player.position, rb.position) >= attackRange)
        //{
           

        //    Vector2 target = new Vector2(player.position.x, rb.position.y);
        //    Vector2 newPosition = Vector2.MoveTowards(rb.position, target, _speed * Time.fixedDeltaTime);
        //    rb.MovePosition(newPosition);
        //    animator.SetBool("__isRange", false);

        //}

        if (Vector2.Distance(player.position, rb.position) < attackRange)
        {
            
            animator.SetTrigger("__attack");
            animator.SetBool("__isRange", true);
            
        }

        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
        animator.SetBool("__isRange", false);

        animator.ResetTrigger("__attack");
    }
}
