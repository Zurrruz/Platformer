using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _healthCharacter;
    [SerializeField] private Image _healthBar;

    private void OnEnable()
    {
        _healthCharacter.Changed += Show;
    }

    private void OnDisable()
    {
        _healthCharacter.Changed -= Show;
    }

    private void Show()
    {
        _healthBar.fillAmount = _healthCharacter.CurrentValue / _healthCharacter.MaxValue;
    }
}
