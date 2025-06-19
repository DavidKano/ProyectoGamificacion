using TMPro;
using UnityEngine;

public class NombreUsuario : MonoBehaviour
{

    public TextMeshProUGUI Nombre;

    void Start()
    {

        string nombre = PlayerPrefs.GetString("usuario", "Usuario");
        Nombre.text = nombre;
        
    }

}
