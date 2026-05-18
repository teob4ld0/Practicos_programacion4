using UnityEngine;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    [SerializeField] Button btnPosicionar;
    [SerializeField] Button btnCorrer;
    [SerializeField] Slider sliderVelocidad;
    [SerializeField] ControladorPosta posta;

    void Start()
    {
        btnPosicionar.onClick.AddListener(OnPositionClick);
        btnCorrer.onClick.AddListener(OnRunClick);
        sliderVelocidad.onValueChanged.AddListener(OnSliderChange);
        posta.new_speed(sliderVelocidad.value);
    }

    // Funciones afuera del Start y del Update
    void OnPositionClick()
    {
        posta.InPosition();
    }

    void OnRunClick()
    {
        posta.StartRace();
    }

    void OnSliderChange(float valor)
    {
        posta.new_speed(valor);
    }
}