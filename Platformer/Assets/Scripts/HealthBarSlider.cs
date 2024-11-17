using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : HealthBar
{
    [SerializeField] private Slider _slider;

    private float _step = 0.2f;

    public override void Show()
    {
        StartCoroutine(Ñhange());
    }

    private IEnumerator Ñhange()
    {
        while (_slider.value != health.CurrentValue / health.MaxValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health.CurrentValue / health.MaxValue, _step * Time.deltaTime);
            yield return null;
        }
    }
}
