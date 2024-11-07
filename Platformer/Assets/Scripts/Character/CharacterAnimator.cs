using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private InputParameters _inputParameters;
    [SerializeField] private Cooldown _cooldown;

    private Animator _animator;

    private int _zeroSpeed = 0;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayAttackAnimation();
        PlayWalkingAnimation();
    }

    private void PlayWalkingAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, _inputParameters.Moving != _zeroSpeed);
    }

    private void PlayAttackAnimation()
    {
        if (_inputParameters.IsAttacking && _cooldown.CanAttack)
            StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsAttack, _inputParameters.IsAttacking);

        yield return null;

        _animator.SetBool(PlayerAnimatorData.Params.IsAttack, _inputParameters.IsAttacking);
    }
}
