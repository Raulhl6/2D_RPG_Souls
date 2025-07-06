using System;
using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private bool showGizmos = true;
    
    public event UnityAction<bool> OnGround = delegate { };
    
    public bool IsGrounded { get; private set; } = false;

    private void FixedUpdate()
    {
        bool groundedNow = CheckGround();

        if (groundedNow != IsGrounded)
        {
            IsGrounded = groundedNow;
            OnGround?.Invoke(groundedNow);
        }
    }

    private bool CheckGround()
    {
        return Physics2D.OverlapCircle(transform.position, checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected() {
        if (!showGizmos) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
