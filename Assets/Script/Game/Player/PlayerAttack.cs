
using System;
using System.Collections;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine;

public class PlayerAttack:MonoBehaviour
{
    [SerializeField]
    private float Radius = 0.5f;

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }

    private void Attack(Finger Finger)
    {
        playerAnimator.SetTrigger("Attack");
        foreach (var collider in Physics.OverlapSphere(transform.position,Radius))
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(1);
            }
        }
    }
    
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.onFingerUp += Attack;
    }
    
    private void OnDisable()
    {
        ETouch.onFingerUp -= Attack;
        EnhancedTouchSupport.Disable();
    }
}
    
  
