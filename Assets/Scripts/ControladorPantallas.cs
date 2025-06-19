using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPantallas : MonoBehaviour
{
    public void IrInicioSesion()
    {
        SceneManager.LoadScene("InicioSesion");

    }

    public void IrRegistro()
    {
       SceneManager.LoadScene("Registro");


    }

    
}
