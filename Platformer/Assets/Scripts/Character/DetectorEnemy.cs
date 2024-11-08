using UnityEngine;

public class DetectorEnemy : MonoBehaviour
{
    public Health HealthEnemy { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy))
            HealthEnemy = enemy;
    }

    public void Renew()
    {
        HealthEnemy = null;
    }
}
