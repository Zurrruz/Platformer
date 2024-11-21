public class SliderHealthBar : HealthBar
{  
    public override void Show()
    {
        Slider.value = Health.CurrentValue / Health.MaxValue;
    }
}
