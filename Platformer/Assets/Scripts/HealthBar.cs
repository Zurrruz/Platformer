using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health health;

    private void OnEnable()
    {
        health.Changed += Show;
    }

    private void OnDisable()
    {
        health.Changed -= Show;
    }

    public abstract void Show();
}
