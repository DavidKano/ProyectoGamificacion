using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class InicioSesion : MonoBehaviour
{
    public TMP_InputField UsuarioLogin;
    public TMP_InputField ContrasenaLogin;
    public TextMeshProUGUI txtErrorLogin;

    public void Entrar()
    {
        string usuario = UsuarioLogin.text;
        string contrasena = ContrasenaLogin.text;

        // Recuperar datos registrados
        string usuarioGuardado = PlayerPrefs.GetString("usuario", "");
        string contrasenaGuardada = PlayerPrefs.GetString("contrasena", "");

        if (usuario == usuarioGuardado && contrasena == contrasenaGuardada)
        {
            // Acceso correcto a la pantalla principal
            SceneManager.LoadScene("Principal");
        }
        else
        {
            // Error  mostrar mensaje
            if (txtErrorLogin != null)
                txtErrorLogin.text = "Usuario o contraseña incorrectos.";
        }
    }

     public void IrInicio()
    {
       SceneManager.LoadScene("Inicio");


    }
    
}



