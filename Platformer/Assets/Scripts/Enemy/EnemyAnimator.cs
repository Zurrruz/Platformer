using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private AttackTriggerEnemy _attackTrigger;
    [SerializeField] private Animator _animator; 

    public bool _isAttack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _attackTrigger.Attacking += StartAttackAnimation;
        _attackTrigger.StoppedAttacking += StopAttackAnimation;
    }

    private void OnDisable()
    {
        _attackTrigger.Attacking -= StartAttackAnimation;
        _attackTrigger.StoppedAttacking -= StopAttackAnimation;
    }

    private void PlaysAttackAnimation()
    {        
        _animator.SetBool(PlayerAnimatorData.Params.IsAttack, _isAttack);
    }

    private void StartAttackAnimation(HealthCharacter character)
    {
        _isAttack = true;
        PlaysAttackAnimation();
    }

    private void StopAttackAnimation()
    {
        _isAttack = false;
        PlaysAttackAnimation();
    }
}
