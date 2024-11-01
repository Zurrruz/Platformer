using System.Collections.Generic;
using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private DetectorPlayer _detectorPlayer;
    [SerializeField] private List<Transform> _pointsPatrol;
    [SerializeField] private AttackEnemy _attackEnemy;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistansSpot;

    private Transform _target;
    private Vector3 _turn = new Vector3(0, 180, 0);

    private int _numberPoint;

    private bool _canPatrol = true;

    private void OnEnable()
    {
        _detectorPlayer.StartedPursuit += ChasePlayer;
        _detectorPlayer.FinishedPursuit += ReturnsPatrol;
    }

    private void OnDisable()
    {
        _detectorPlayer.StartedPursuit -= ChasePlayer;
        _detectorPlayer.FinishedPursuit -= ReturnsPatrol;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void ChasePlayer(Transform target)
    {
        _canPatrol = false;
        _target = target;
    }

    private void ReturnsPatrol()
    {
        _canPatrol = true;
    }

    private void Move()
    {
        if (_canPatrol)
            _target = _pointsPatrol[_numberPoint];

        if (_attackEnemy.IsAttack == false)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        CompletesPath();
    }

    private void SpecifyPointMovement()
    {
        _numberPoint++;

        if (_numberPoint == _pointsPatrol.Count)
            _numberPoint = 0;
    }

    private void CompletesPath()
    {
        Vector3 offset = _target.position - transform.position;
        float sqrLen = offset.sqrMagnitude;

        if (sqrLen < _minDistansSpot * _minDistansSpot)
            SpecifyPointMovement();
    }

    private void Rotate()
    {
        if (_target.position.x > transform.position.x)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(_turn);
    }
}