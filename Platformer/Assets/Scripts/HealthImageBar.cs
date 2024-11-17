using UnityEngine;
using UnityEngine.UI;

public class HealthImageBar : HealthBar
{
    [SerializeField] private Image _healthBar;    

    public override void Show()
    {
        _healthBar.fillAmount = health.CurrentValue / health.MaxValue;
    }
}
