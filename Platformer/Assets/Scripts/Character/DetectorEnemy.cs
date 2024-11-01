using UnityEngine;

public class DetectorEnemy : MonoBehaviour
{
    public Enemy Enemy {  get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            Enemy = enemy;
    }
}
