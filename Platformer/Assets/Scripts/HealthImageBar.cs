using UnityEngine;
using UnityEngine.UI;

public class HealthImageBar : HealthBar
{
    [SerializeField] private Image _healthBar;

    private void OnEnable()
    {
        _healthCharacter.Changed += Show;
    }

    private void OnDisable()
    {
        _healthCharacter.Changed -= Show;
    }

    public override void Show()
    {
        _healthBar.fillAmount = _healthCharacter.CurrentValue / _healthCharacter.MaxValue;
    }
}
