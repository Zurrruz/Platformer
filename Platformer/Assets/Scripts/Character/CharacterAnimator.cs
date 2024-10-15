using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private bool _isMoving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlaysWalkingAnimation();
    }
    
    private void PlaysWalkingAnimation()
    {
        if (Input.GetAxis("Horizontal") == 0)
            _isMoving = false;
        else
            _isMoving = true;

        _animator.SetBool("IsMoving", _isMoving);
    }
}
