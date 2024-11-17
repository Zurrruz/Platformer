using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PatrolEnemy _patrolEnemy;
    [SerializeField] private Pursuit _pursuit;
    [SerializeField] private DetectorPlayer _detectorPlayer;
    [SerializeField] private Health _health;

    private void Start()
    {
        _patrolEnemy.StartPatrolling();
        _pursuit.StopPursue();
    }

    private void OnEnable()
    {
        _detectorPlayer.StartedPursuit += ChasePlayer;
        _detectorPlayer.FinishedPursuit += ReturnPatrol;
        _health.Ended += Die;
    }

    private void OnDisable()
    {
        _detectorPlayer.StartedPursuit -= ChasePlayer;
        _detectorPlayer.FinishedPursuit -= ReturnPatrol;
        _health.Ended -= Die;
    }

    private void ChasePlayer(Health target)
    {
        _patrolEnemy.StopPatrolling();
        _pursuit.AssignsTargetPursuit(target.transform);
    }

    private void ReturnPatrol()
    {
        _pursuit.StopPursue();
        _patrolEnemy.StartPatrolling();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}