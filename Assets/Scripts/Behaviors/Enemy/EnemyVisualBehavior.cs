using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisualBehavior : MonoBehaviour
{
    [HideInInspector] public EnemyBehavior enemyBehavior;
    [Header("Animation")]
    public Animator animator;
    public AnimationClip idleAnimation;
    public AnimationClip moveAnimation;
    public AnimationClip dieAnimation;
    AnimatorOverrideController animatorOverrideController;

    bool moving;
    bool dead;

    void Start()
    {
        if(animator == null) animator = GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        if(idleAnimation != null)
            animatorOverrideController["A_Enemy_Default_Idle"] = idleAnimation;

        if(moveAnimation != null)
            animatorOverrideController["A_Enemy_Default_Move"] = moveAnimation;

        if(dieAnimation != null)
            animatorOverrideController["A_Enemy_Default_Die"] = dieAnimation;
    }

    void Update()
    {
        if(enemyBehavior != null)
        {
            if(enemyBehavior.health <= 0f)
            {
                if(!dead)
                {
                    animator.SetTrigger("Die");
                    dead = true;
                }
            }

            if(moving != enemyBehavior.movement.enabled)
            {
                moving = enemyBehavior.movement.enabled;
                if(moving) animator.SetBool("Moving", true);
                else animator.SetBool("Moving", false);
            }
        }
    }
}
