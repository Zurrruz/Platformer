using UnityEngine;

public class Pursuit : MonoBehaviour
{
    [SerializeField] private MoverEnemy _moverEnemy;
    [SerializeField] private AttackEnemy _attackEnemy;

    private Transform _target;

    private bool _canPursue = false;

    private void Update()
    {
        Pursue();
    }

    private void Pursue()
    {
        if (_canPursue && _attackEnemy.IsAttack == false)
            _moverEnemy.Move(_target);
    }

    public void AssignsTargetPursuit(Transform target)
    {
        _target = target;
        _canPursue = true;
    }

    public void StopPursuit()
    {
        _canPursue = false;
    }
}
