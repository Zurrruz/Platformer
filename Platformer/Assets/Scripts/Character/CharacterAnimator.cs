using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private InputReader _inputParameters;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private SwordAttack _swordAttack;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _swordAttack.Attaked += PlayAttackAnimation;
    }

    private void OnDisable()
    {
        _swordAttack.Attaked -= PlayAttackAnimation;
    }

    private void Update()
    {
        PlayWalkingAnimation();
    }

    private void PlayWalkingAnimation()
    {
        _animator.SetBool(AnimatorData.Params.IsMoving, _characterMover.IsMoving);
    }

    private void PlayAttackAnimation()
    {
        _animator.Play(AnimatorData.Params.Attack);
    }
}
