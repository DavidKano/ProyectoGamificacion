using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RegistroUsuario : MonoBehaviour
{

    public TMP_InputField Usuario;
    public TMP_InputField Correo;
    public TMP_InputField Contrasena;
    public TMP_InputField ConfContrasena;
    public TextMeshProUGUI txtError;

    public Sprite avatarHombre;
    public Sprite avatarMujer;

    private string avatarSeleccionado = "masculino"; // valor por defecto

    public Image VistaPreviaAvatar;




    public void CrearCuenta()
    {
        string usuario = Usuario.text;
        string correo = Correo.text;
        string contrasena = Contrasena.text;
        string confirmarcon = ConfContrasena.text;

        if (usuario == "" || contrasena == "" || confirmarcon == "")
        {
            MostrarError("Inserta todos los campos");
            return;
        }

        if (contrasena != confirmarcon)
        {
            MostrarError("Las contraseñas no coinciden");
            return;
        }

        //guardado de datos con playerprefs
        PlayerPrefs.SetString("usuario", usuario);
        PlayerPrefs.SetString("correo", correo);
        PlayerPrefs.SetString("contrasena", contrasena);
        PlayerPrefs.SetString("avatarSeleccionado", avatarSeleccionado);
        PlayerPrefs.Save();

        //redireccion a pantalla Login
        SceneManager.LoadScene("InicioSesion");

    }

    public void IrInicio()
    {
        SceneManager.LoadScene("Inicio");


    }

    public void MostrarError(string mensaje)
    {
        if (txtError != null)
            txtError.text = mensaje;
    }

    public void SeleccionarAvatar(string tipo)
    {
        avatarSeleccionado = tipo;

        if (tipo == "masculino")
            VistaPreviaAvatar.sprite = avatarHombre;
        else if (tipo == "femenino")
            VistaPreviaAvatar.sprite = avatarMujer;
    }


}
