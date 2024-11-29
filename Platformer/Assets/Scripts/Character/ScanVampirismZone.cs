using System.Collections.Generic;
using UnityEngine;

public class ScanVampirismZone : MonoBehaviour
{
    private List<Health> _health;

    private void Awake()
    {
        _health = new();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy))
            _health.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy))
            _health.Remove(enemy);
    }

    public bool CanSeeNearesEnemy(out Health enemyHealth)
    {
        Health nearestEnemy = null;

        if (_health.Count > 0)
        {
            nearestEnemy = _health[0];

            for (int i = 1; i < _health.Count; i++)
            {
                Vector3 offset = nearestEnemy.transform.position - transform.position;
                float squareLengthFirstEnemy = offset.sqrMagnitude;

                offset = _health[i].transform.position - transform.position;
                float squareLengthSecondEnemy = offset.sqrMagnitude;                

                if (squareLengthSecondEnemy < squareLengthFirstEnemy)
                    nearestEnemy = _health[i];
            }
        }

        enemyHealth = nearestEnemy;

        if(enemyHealth != null)
            return true;
        else 
            return false;        
    }
}
