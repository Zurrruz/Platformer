using System.Collections;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private AttackTriggerEnemy _attackTrigger;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private WaitForSeconds _timeout;

    private Coroutine _enumerator;

    public bool IsAttack { get; private set; } = false;

    private void Awake()
    {
        _timeout = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _attackTrigger.Attacking += Attacking;
        _attackTrigger.StoppedAttacking += StopAttacking;
    }

    private void OnDisable()
    {
        _attackTrigger.Attacking -= Attacking;
        _attackTrigger.StoppedAttacking -= StopAttacking;
    }

    private void Attacking(HealthCharacter character)
    {
        IsAttack = true;
        _enumerator = StartCoroutine(Delay(character));
    }

    private void StopAttacking()
    {
        IsAttack = false;
        StopCoroutine(_enumerator);
    }

    private IEnumerator Delay(HealthCharacter character)
    {
        while (enabled)
        {
            yield return _timeout;

            character.TakeDamage(_damage);
        }
    }
}
