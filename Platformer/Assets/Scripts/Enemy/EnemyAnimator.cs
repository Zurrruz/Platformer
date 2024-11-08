using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private AttackEnemy _attackEnemy;
    [SerializeField] private Animator _animator; 

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlaysIdleAnimation();
    }

    private void OnEnable()
    {
        _attackEnemy.Attacking += PlaysAttackAnimation;
    }

    private void OnDisable()
    {
        _attackEnemy.Attacking -= PlaysAttackAnimation;
    }

    private void PlaysIdleAnimation()
    {
        _animator.SetBool(AnimatorData.Params.IsIdle, _attackEnemy.IsAttack);
    }

    private void PlaysAttackAnimation()
    {                
        _animator.Play(AnimatorData.Params.AttackEnemy);
    }    
}
