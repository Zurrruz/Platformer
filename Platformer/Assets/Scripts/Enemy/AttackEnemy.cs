using System;
using System.Collections;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private DetectorPlayer _detectorPlayer;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private WaitForSeconds _timeout;

    private Coroutine _enumerator;

    public event Action Attacking;

    public bool IsAttack { get; private set; } = false;

    private void Awake()
    {
        _timeout = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _detectorPlayer.Attacking += Assault;
        _detectorPlayer.StoppedAttacking += StopAttacking;
    }

    private void OnDisable()
    {
        _detectorPlayer.Attacking -= Assault;
        _detectorPlayer.StoppedAttacking -= StopAttacking;
    }

    private void Assault(Health character)
    {
        IsAttack = true;
        _enumerator = StartCoroutine(Delay(character));
    }

    private void StopAttacking()
    {
        IsAttack = false;

        if (_enumerator != null)
            StopCoroutine(_enumerator);
    }

    private IEnumerator Delay(Health character)
    {
        while (enabled)
        {
            yield return _timeout;
            
            character.TakeDamage(_damage);
            Attacking?.Invoke();
        }
    }
}
