using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsPatrol;
    [SerializeField] private MoverEnemy _moverEnemy;
    [SerializeField] private float _minDistansSpot;

    private Transform _target;

    private int _numberPoint = 0;
    private bool _canPatrol;

    private void Awake()
    {
        FixTarget();
    }

    private void Update()
    {
        Defend();
    }

    private void CompletesPath()
    {
        Vector3 offset = _target.position - transform.position;
        float squareLength = offset.sqrMagnitude;

        if (squareLength < _minDistansSpot * _minDistansSpot)
        {
            _numberPoint = ++_numberPoint % _pointsPatrol.Count;
            FixTarget();
        }
    }

    private void FixTarget()
    {
        _target = _pointsPatrol[_numberPoint];
    }

    private void Defend()
    {
        if (_canPatrol)
        {
            CompletesPath();
            _moverEnemy.Move(_target);
        }
    }

    public void StartPatrolling()
    {
        _canPatrol = true;
    }

    public void StopPatrolling()
    {
        _canPatrol = false;
    }
}
