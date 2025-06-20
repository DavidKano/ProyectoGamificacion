using System;
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
        toggleCompletado.onValueChanged.RemoveAllListeners();
        //toggleCompletado.isOn = estadoCompletado;
        //toggleCompletado.onValueChanged.AddListener((_) => CambiarEstadoToggle());


        completado = estadoCompletado;

        gestor = g;

        toggleCompletado.SetIsOnWithoutNotify(estadoCompletado);

        toggleCompletado.onValueChanged.AddListener(delegate { CambiarEstadoToggle(); });
            
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
        // Si se intenta desmarcar manualmente, no lo permitimos
        if (!toggleCompletado.isOn)
        {
            toggleCompletado.isOn = true;
            return;
        }

        completado = true; // Como no se puede desmarcar, esto siempre es true

        // Bloqueamos el toggle para que no se pueda cambiar
        toggleCompletado.interactable = false;

        if (gestor != null)
        {
            // Guardamos el estado en la lista de hábitos
            int index = transform.GetSiblingIndex();
            if (index >= 0 && index < gestor.listaHabitos.Count)
            {
                gestor.listaHabitos[index].completado = true;
                gestor.listaHabitos[index].tiempoCompletado = DateTimeOffset.Now.ToUnixTimeSeconds(); // ← Aquí se guarda el tiempo
            }

            gestor.GuardarHabitos();
        }

        // Ganar XP
        GestorJugador jugador = FindObjectOfType<GestorJugador>();
        if (jugador != null)
            jugador.GanarXP(10);
    }


}
