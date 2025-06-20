using UnityEngine;
using UnityEngine.UI;

public class PantallaPrincipal : MonoBehaviour
{

    public Sprite avatarMasculino;
    public Sprite avatarFemenino;
    public Image imagenAvatar;

    void Start()
    {
        string avatarSeleccionado = PlayerPrefs.GetString("avatarSeleccionado", "masculino");

        if (avatarSeleccionado == "masculino")

            imagenAvatar.sprite = avatarMasculino;

        else if (avatarSeleccionado == "femenino")

            imagenAvatar.sprite = avatarFemenino;             

       
    }
  
}
