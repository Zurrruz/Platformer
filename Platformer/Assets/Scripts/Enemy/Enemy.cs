using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PatrolEnemy _patrolEnemy;
    [SerializeField] private Pursuit _pursuit;
    [SerializeField] private DetectorPlayer _detectorPlayer;

    private void Start()
    {
        _patrolEnemy.StartPatrolling();
        _pursuit.StopPursuit();
    }

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

    private void ChasePlayer(Transform target)
    {
        _patrolEnemy.StopPatrolling();
        _pursuit.AssignsTargetPursuit(target);
    }

    private void ReturnsPatrol()
    {
        _pursuit.StopPursuit();
        _patrolEnemy.StartPatrolling();
    }
}