using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _minValue = 0;

    public event Action Ended;
    public event Action Changed;

    public float MaxValue { get; private set; } = 20f;
    public float CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            CurrentValue -= damage;

            CurrentValue = Mathf.Clamp(CurrentValue, _minValue, MaxValue);

            if (CurrentValue <= 0)
                Ended?.Invoke();

            Changed?.Invoke();
        }
    }

    public void Restore(float value)
    {
        if (value > 0)
        {
            CurrentValue += value;

            CurrentValue = Mathf.Clamp(CurrentValue, _minValue, MaxValue);

            Changed?.Invoke();
        }
    }
}
