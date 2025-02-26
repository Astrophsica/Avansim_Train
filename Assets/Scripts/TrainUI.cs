using UnityEngine;
using UnityEngine.UI;

public class TrainUI : MonoBehaviour
{
    public GameObject Train;
    private Slider AccelerationSlider;
    private Slider BrakeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AccelerationSlider = transform.Find("Acceleration").GetComponent<Slider>();
        BrakeSlider = transform.Find("Brake").GetComponent<Slider>();
        AccelerationSlider.onValueChanged.AddListener(OnSliderChanged);
        BrakeSlider.onValueChanged.AddListener(OnSliderChanged);
    }


    void OnSliderChanged(float newValue)
    {
        var brakeValue = -BrakeSlider.value;
        var accelerationValue = AccelerationSlider.value;

        var newAcceleration = brakeValue + accelerationValue;
        Train.GetComponent<TrainController>().Acceleration = newAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
