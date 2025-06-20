using System.Collections;
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
    public GameObject panelCelebracion;
    public Image imagenPulgar;
    public GameObject panelSubeNivel;
    public Image imagenNivel;





    private void Start()
    {
        CargarDatosJugador();
        ActualizarUI();
    }

    public void GanarXP(int cantidad)
    {
        xpActual += cantidad;

        if (panelCelebracion != null)
            StartCoroutine(FlashCelebracion());


        while (xpActual >= xpMaximo)
        {
            xpActual -= xpMaximo;
            nivel++;

            if (panelSubeNivel != null && imagenNivel != null)
                StartCoroutine(MostrarSubidaDeNivel());
                
        }

        GuardarDatosJugador();
        ActualizarUI();
    }

    private IEnumerator FlashCelebracion()
    {
        panelCelebracion.SetActive(true);
        imagenPulgar.canvasRenderer.SetAlpha(0f);
        imagenPulgar.CrossFadeAlpha(1f, 0.2f, false); // aparece

        yield return new WaitForSeconds(0.6f);

        imagenPulgar.CrossFadeAlpha(0f, 0.2f, false); // desaparece
        yield return new WaitForSeconds(0.2f);

        panelCelebracion.SetActive(false);
    
    }
    private IEnumerator MostrarSubidaDeNivel()
    {
        panelSubeNivel.SetActive(true);

        imagenNivel.canvasRenderer.SetAlpha(0f);
        imagenNivel.CrossFadeAlpha(1f, 0.3f, false);

        yield return new WaitForSeconds(1.5f);

        imagenNivel.CrossFadeAlpha(0f, 0.5f, false);
        yield return new WaitForSeconds(0.5f);

        panelSubeNivel.SetActive(false);
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
