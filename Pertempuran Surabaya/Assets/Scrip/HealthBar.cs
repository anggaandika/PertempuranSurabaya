using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;

    public Image HealthShape;

    public void SetMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        HealthShape.color = gradient.Evaluate(1f);
    }

    public void setHealth (int health)
    {
        slider.value = health;

        HealthShape.color = gradient.Evaluate(slider.normalizedValue);
    }
}
