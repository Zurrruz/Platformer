using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private PlayerInputController _playerInputController;

    private Animator _animator;

    private bool _isMoving;
    private int _zeroSpeed = 0;

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
        _isMoving = _playerInputController.Moving != _zeroSpeed;

        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, _isMoving);
    }
}
