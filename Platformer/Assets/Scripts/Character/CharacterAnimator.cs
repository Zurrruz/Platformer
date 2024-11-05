using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private InputParameters _inputParameters;
    [SerializeField] private CooldownAttack _cooldownAttack;

    private Animator _animator;

    private bool _isMoving;
    private bool _isAttack;
    private int _zeroSpeed = 0;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlaysWalkingAnimation();
    }

    private void Update()
    {
        PlaysAttackAnimation();
    }

    private void PlaysWalkingAnimation()
    {
        _isMoving = _inputParameters.Moving != _zeroSpeed;

        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, _isMoving);
    }

    private void PlaysAttackAnimation()
    {
        _isAttack = _inputParameters.IsAttacking;

        if (_cooldownAttack.CanAttack)
            _animator.SetBool(PlayerAnimatorData.Params.IsAttack, _isAttack);
    }
}
