using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AttackEnemy _attackEnemy;    

    public bool _isAttack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlaysAttackAnimation();
    }

    private void PlaysAttackAnimation()
    {
        _isAttack = _attackEnemy.IsAttack;
        _animator.SetBool(PlayerAnimatorData.Params.IsAttack, _isAttack);
    }
}
