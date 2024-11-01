using System;
using UnityEngine;

public class AttackTriggerEnemy : MonoBehaviour
{
    public event Action<Character> Attacking;
    public event Action StoppedAttacking;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Character character))
        {
            Attacking?.Invoke(character);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Character character))
        {
            StoppedAttacking?.Invoke();
        }
    }
}
