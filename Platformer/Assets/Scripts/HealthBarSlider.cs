using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : HealthBar
{
    [SerializeField] private Slider _slider;

    private float _step = 0.3f;

    private void Update()
    {
        Show();
    }

    public override void Show()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _healthCharacter.CurrentValue / _healthCharacter.MaxValue, _step * Time.deltaTime);
    }
}
