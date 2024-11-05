using UnityEngine;

public class DetectorEnemy : MonoBehaviour
{
    public HealthEnemy Enemy {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthEnemy enemy))
            Enemy = enemy;
    }
}
