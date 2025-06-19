using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestorJugador : MonoBehaviour
{
    public TextMeshProUGUI txtXP;
    public TextMeshProUGUI txtNivel;
    public Slider barraXP;

    private int xpActual = 0;
    private int nivel = 1;
    private int xpMaximo = 100;

    private void Start()
    {
        CargarDatosJugador();
        ActualizarUI();
    }

    public void GanarXP(int cantidad)
    {
        xpActual += cantidad;

        while (xpActual >= xpMaximo)
        {
            xpActual -= xpMaximo;
            nivel++;
        }

        GuardarDatosJugador();
        ActualizarUI();
    }

    void ActualizarUI()
    {
        txtXP.text = $"XP {xpActual} / {xpMaximo}";
        txtNivel.text = nivel.ToString();
        barraXP.maxValue = xpMaximo;
        barraXP.value = xpActual;
    }

    void GuardarDatosJugador()
    {
        PlayerPrefs.SetInt("xp", xpActual);
        PlayerPrefs.SetInt("nivel", nivel);
    }

    void CargarDatosJugador()
    {
        xpActual = PlayerPrefs.GetInt("xp", 0);
        nivel = PlayerPrefs.GetInt("nivel", 1);
    }
    

}
