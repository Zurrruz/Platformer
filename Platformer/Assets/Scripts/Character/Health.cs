using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _minValue = 0;

    public event Action Ended;
    public event Action Changed;

    public float MaxValue { get; private set; } = 10f;
    public float CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = MaxValue;
    }    

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            CurrentValue -= damage;

        CurrentValue = Convert.ToInt32(Mathf.Clamp(CurrentValue, _minValue, MaxValue));

        InformZeroHealth();

        Changed?.Invoke();
    }

    public void Restore(int value)
    {
        if (value > 0)
            CurrentValue += value;

        CurrentValue = Convert.ToInt32(Mathf.Clamp(CurrentValue, _minValue, MaxValue));

        Changed?.Invoke();
    }

    private void InformZeroHealth()
    {
        if (CurrentValue <= 0)
            Ended?.Invoke();
    }
}
