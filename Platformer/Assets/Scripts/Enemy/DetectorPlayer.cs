using System;
using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    [SerializeField] private float _maxDistanceAttack;

    private Health _target;

    private bool _canInform = true;

    public event Action<Health> StartedPursuit;
    public event Action FinishedPursuit;

    public event Action<Health> Attacking;
    public event Action StoppedAttacking;

    private void Update()
    {
        DeterminesDistance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health healthCharacter))
        {
            StartedPursuit?.Invoke(healthCharacter);
            _target = healthCharacter;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out _))
        {
            FinishedPursuit?.Invoke();
            _target = null;
        }
    }

    private void DeterminesDistance()
    {
        if (_target != null)
        {
            Vector3 offset = _target.transform.position - transform.position;
            float squareLength = offset.sqrMagnitude;

            if (squareLength < _maxDistanceAttack * _maxDistanceAttack)
            {
                if (_canInform)
                {
                    Attacking?.Invoke(_target);
                    _canInform = false;
                }
            }
            else
            {
                StoppedAttacking?.Invoke();
                _canInform = true;
            }
        }
    }
}
