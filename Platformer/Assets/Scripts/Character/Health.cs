using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    private float _minValue = 0;

    public event Action EndedHealth;

    public int CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = _maxValue;
    }    

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            CurrentValue -= damage;

        CurrentValue = Convert.ToInt32(Mathf.Clamp(CurrentValue, _minValue, _maxValue));

        InformZeroHealth();
    }

    public void Restore(int value)
    {
        if (value > 0)
            CurrentValue += value;

        CurrentValue = Convert.ToInt32(Mathf.Clamp(CurrentValue, _minValue, _maxValue));
    }

    private void InformZeroHealth()
    {
        if (CurrentValue <= 0)
            EndedHealth?.Invoke();
    }
}
