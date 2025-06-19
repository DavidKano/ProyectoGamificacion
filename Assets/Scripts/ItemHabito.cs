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

    private GestorHabitos gestor;



    public void Configurar(string texto, GestorHabitos g = null, bool estadoCompletado = false)
    {
        textoHabito.text = texto;
        toggleCompletado.isOn = estadoCompletado;
        completado = estadoCompletado;

        gestor = g;
    }

    public Habito ObtenerDatos()
    {
        return new Habito
        {
            texto = textoHabito.text,
            completado = toggleCompletado.isOn
        };
    }

    public void Eliminar()
    {
        if (gestor != null)
        {
            gestor.listaHabitos.RemoveAll(h => h.texto == textoHabito.text);
            gestor.GuardarHabitos();
        }

        Destroy(gameObject); // elimina el objeto visual
    
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

        if (gestor != null)
        {
            // Buscar este hábito en la lista y actualizar el texto
            int index = transform.GetSiblingIndex();
            if (index >= 0 && index < gestor.listaHabitos.Count)
            {
                gestor.listaHabitos[index].texto = Edicion.text;
            }

            gestor.GuardarHabitos();
        }
    }


    public void CambiarEstadoToggle()
    {
        completado = toggleCompletado.isOn;

        if (gestor != null)
        {
            // Actualizar el estado del hábito en la lista
            int index = transform.GetSiblingIndex();
            if (index >= 0 && index < gestor.listaHabitos.Count)
            {
                gestor.listaHabitos[index].completado = completado;
            }

            gestor.GuardarHabitos();
        }
        if (completado)
        {
            GestorJugador jugador = FindObjectOfType<GestorJugador>();
            if (jugador != null)
                jugador.GanarXP(10); // Suma 10 XP por ejemplo
        }

    }

}
