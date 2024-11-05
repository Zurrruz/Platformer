using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsPatrol;
    [SerializeField] private MoverEnemy _moverEnemy;
    [SerializeField] private float _minDistansSpot;

    private Transform _target;

    private int _numberPoint;
    private bool _canPatrol;

    private void Update()
    {
        Patrolling();
    }

    private void CompletesPath()
    {
        _target = _pointsPatrol[_numberPoint];

        Vector3 offset = _target.position - transform.position;
        float squareLength = offset.sqrMagnitude;

        if (squareLength < _minDistansSpot * _minDistansSpot)
            _numberPoint = ++_numberPoint % _pointsPatrol.Count;
    }

    private void Patrolling()
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
