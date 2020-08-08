using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    #region Singleton

    public static HealthBar instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HealthBar >();
            }
            return _instance;
        }
    }
    static HealthBar _instance;

    void Awake()
    {
        _instance = this;
    }

    #endregion


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
