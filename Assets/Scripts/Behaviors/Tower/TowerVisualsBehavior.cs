using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerVisualsBehavior : MonoBehaviour
{
    [HideInInspector] public TowerBehavior towerBehavior;
    public Transform head;

    [Header("Animation")]
    public Animator animator;
    public AnimationClip idleAnimation;
    public AnimationClip shootAnimation;

    AnimatorOverrideController animatorOverrideController;
    
    void Start()
    {
        if(animator == null) animator = GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        animatorOverrideController["A_Tower_Default_Idle"] = idleAnimation;
        animatorOverrideController["A_Tower_Default_Shoot"] = shootAnimation;
    }

    void Update()
    {
        if(towerBehavior != null && towerBehavior.target != null)
        {
            // Rotate the tower visual towards its target
            head.transform.LookAt(towerBehavior.target.transform.position);

            if(Time.time > towerBehavior.reloadTimer)
            {
                // Fire to the target
                animator.SetTrigger("Shoot");
            }
        }
    }
}
