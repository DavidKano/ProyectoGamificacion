using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemHabito : MonoBehaviour
{
    public TMP_Text textoHabito;
    public Toggle toggleCompletado;
    public GameObject panelEdicion;
    public TMP_InputField Edicion;

    private bool completado = false;


    public void Configurar(string texto)
    {
        textoHabito.text = texto;
        toggleCompletado.isOn = false;
        completado = false;
    }

    public void Eliminar()
    {
        Destroy(gameObject);
    }

    public void ActivarEdicion()
    {
        panelEdicion.SetActive(true);
        Edicion.text = textoHabito.text;
                
    }

    public void ConfirmarEdicion()
    {
        textoHabito.text = Edicion.text;
        panelEdicion.SetActive(false);
    }

    public void CambiarEstadoToggle()
    {
        completado = toggleCompletado.isOn;
        // sumar XP si  más adelante
    }
    
    

}
