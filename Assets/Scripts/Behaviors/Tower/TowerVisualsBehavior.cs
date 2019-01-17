using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerVisualsBehavior : MonoBehaviour
{
    [HideInInspector] public TowerBehavior tower;
    public Transform head;

    [Header("Animation")]
    [HideInInspector] public Animator animator;
    public AnimationClip idleAnimation;
    public AnimationClip shootAnimation;

    AnimatorOverrideController animatorOverrideController;
    
    void Start()
    {
        if(animator == null) animator = GetComponent<Animator>();
        if(animator.runtimeAnimatorController != GameManager.instance.library.towerAnimator) 
            animator.runtimeAnimatorController = GameManager.instance.library.towerAnimator;

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        animatorOverrideController["A_Tower_Default_Idle"] = idleAnimation;
        animatorOverrideController["A_Tower_Default_Shoot"] = shootAnimation;
    }

    void Update()
    {
        if(tower != null && tower.weapon.target != null)
        {
            // Rotate the tower visual towards its target
            head.transform.LookAt(tower.weapon.target.transform.position);

            if(Time.time > tower.weapon.reloadTimer)
            {
                // Fire to the target
                animator.SetTrigger("Shoot");
            }
        }
    }
}
