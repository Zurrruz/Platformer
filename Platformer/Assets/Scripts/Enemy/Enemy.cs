using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PatrolEnemy _patrolEnemy;
    [SerializeField] private Pursuit _pursuit;
    [SerializeField] private DetectorPlayer _detectorPlayer;

    private void Start()
    {
        _patrolEnemy.StartPatrolling();
        _pursuit.StopPursue();
    }

    private void OnEnable()
    {
        _detectorPlayer.StartedPursuit += ChasePlayer;
        _detectorPlayer.FinishedPursuit += ReturnPatrol;
    }

    private void OnDisable()
    {
        _detectorPlayer.StartedPursuit -= ChasePlayer;
        _detectorPlayer.FinishedPursuit -= ReturnPatrol;
    }

    private void ChasePlayer(Transform target)
    {
        _patrolEnemy.StopPatrolling();
        _pursuit.AssignsTargetPursuit(target);
    }

    private void ReturnPatrol()
    {
        _pursuit.StopPursue();
        _patrolEnemy.StartPatrolling();
    }
}