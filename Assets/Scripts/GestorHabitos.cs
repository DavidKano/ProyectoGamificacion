using UnityEngine;
using TMPro;

public class GestorHabitos : MonoBehaviour
{
    public GameObject prefabtItemHabito;           // Prefab del ítem
    public Transform contenedorHabitos;          // Content del Scroll View
    public TMP_InputField inputNuevoHabito;      // Campo de entrada de texto

    public GameObject panelNuevoHabito;

    public void CrearHabito()
    {
        string texto = inputNuevoHabito.text;

        if (string.IsNullOrWhiteSpace(texto))
            return;

        GameObject nuevoHabito = Instantiate(prefabtItemHabito, contenedorHabitos);
        nuevoHabito.GetComponent<ItemHabito>().Configurar(texto);

        inputNuevoHabito.text = ""; // Limpiar campo tras crear
        panelNuevoHabito.SetActive(false);// Oculta el panel tras crear
    }

    public void MostrarFormularioNuevo()
    {
        panelNuevoHabito.SetActive(!panelNuevoHabito.activeSelf);
    }

}
