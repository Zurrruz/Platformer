using System;
using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    public event Action<Transform> StartedPursuit;
    public event Action FinishedPursuit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthCharacter character))
        {
            StartedPursuit?.Invoke(character.gameObject.transform);
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthCharacter>(out _))
            FinishedPursuit?.Invoke();
    }
}
