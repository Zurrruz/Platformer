using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += Show;
    }

    private void OnDisable()
    {
        Health.Changed -= Show;
    }

    public abstract void Show();
}