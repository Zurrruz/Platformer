using System.Collections.Generic;
using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _pointsPatrol;
    [SerializeField] private float _minDistansSpot;

    private Vector3 _turn = new Vector3(0, 180, 0);

    private int _numberPoint;

    private void Update()
    {
        Move();
        CompletesPath();
        Rotate();
    }

    private void Move()
    {
        var _pointNumberArray = _pointsPatrol[_numberPoint];
        transform.position = Vector3.MoveTowards(transform.position, _pointNumberArray.position, _speed * Time.deltaTime);
    }

    private void SpecifyPointMovement()
    {
        _numberPoint++;

        if (_numberPoint == _pointsPatrol.Count)
            _numberPoint = 0;
    }

    private void CompletesPath()
    {
        Vector3 offset = _pointsPatrol[_numberPoint].position - transform.position;
        float sqrLen = offset.sqrMagnitude;

        if (sqrLen < _minDistansSpot * _minDistansSpot)
            SpecifyPointMovement();
    }

    private void Rotate()
    {
        if (_pointsPatrol[_numberPoint].position.x > transform.position.x)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(_turn);
    }
}