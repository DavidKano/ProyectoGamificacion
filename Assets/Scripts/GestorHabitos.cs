using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class GestorHabitos : MonoBehaviour
{
    public GameObject prefabtItemHabito;           // Prefab del ítem
    public Transform contenedorHabitos;          // Content del Scroll View
    public TMP_InputField inputNuevoHabito;      // Campo de entrada de texto

    public GameObject panelNuevoHabito;

    public List<Habito> listaHabitos = new List<Habito>();


    void Start()
    {
        CargarHabitos();
    }

    public void CrearHabito()
    {
        string texto = inputNuevoHabito.text;

        if (string.IsNullOrWhiteSpace(texto))
            return;

        GameObject nuevoHabito = Instantiate(prefabtItemHabito, contenedorHabitos);
        nuevoHabito.GetComponent<ItemHabito>().Configurar(texto, this);

        // Crear y añadir a la lista de datos
        Habito nuevoDato = new Habito();
        nuevoDato.texto = texto;
        nuevoDato.completado = false;
        nuevoDato.tiempoCompletado = 0;
        listaHabitos.Add(nuevoDato);


        inputNuevoHabito.text = ""; // Limpiar campo tras crear
        panelNuevoHabito.SetActive(false);// Oculta el panel tras crear

        GuardarHabitos();

    }

    public void MostrarFormularioNuevo()
    {
        panelNuevoHabito.SetActive(!panelNuevoHabito.activeSelf);
    }

    public void GuardarHabitos()
    {
        string json = JsonUtility.ToJson(new ContenedorDeHabitos(listaHabitos));
        PlayerPrefs.SetString("habitos", json);
        PlayerPrefs.Save();
    }

    public void CargarHabitos()
    {
        //Intentamos obtener la cadena JSON guardada en PlayerPrefs bajo la clave "habitos".
        string json = PlayerPrefs.GetString("habitos", "");

        //Si se ha encontrado contenido (es decir, no está vacío)
        if (!string.IsNullOrEmpty(json))
        {
            //Esto  permite recuperar la lista completa de hábitos guardados
            ContenedorDeHabitos datosCargados = JsonUtility.FromJson<ContenedorDeHabitos>(json);

            //Recorre cada hábito de la lista cargada
            foreach (Habito habito in datosCargados.habitos)
            {
                GameObject nuevoHabito = Instantiate(prefabtItemHabito, contenedorHabitos);
                ItemHabito item = nuevoHabito.GetComponent<ItemHabito>();
                nuevoHabito.GetComponent<ItemHabito>().Configurar(habito.texto, this, habito.completado);
                listaHabitos.Add(habito);

                long ahora = DateTimeOffset.Now.ToUnixTimeSeconds();

                if (habito.tiempoCompletado > 0)
                {
                    long diferencia = ahora - habito.tiempoCompletado;

                    if (diferencia < 43200) // 12 horas en segundos
                    {
                        item.toggleCompletado.isOn = true;
                        item.toggleCompletado.interactable = false;
                    }
                }
            }
        }
    }

    public void GuardarTiempoDeCompletado(string texto)
    {
        foreach (var habito in listaHabitos)
        {
            if (habito.texto == texto)
            {
                habito.tiempoCompletado = DateTimeOffset.Now.ToUnixTimeSeconds();
                break;
            }
        }
    }


}

[System.Serializable]
public class ContenedorDeHabitos
{
    public List<Habito> habitos;

    public ContenedorDeHabitos(List<Habito> lista)
    {
        habitos = lista;
    }
}