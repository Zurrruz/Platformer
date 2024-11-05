using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        Debug.Log("получил урон");
        Debug.Log("осталось " + _health + " жизней");

        if (_health <= 0)
            Destroy(gameObject);
    }
}
