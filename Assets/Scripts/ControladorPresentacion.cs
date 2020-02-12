using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPresentacion : MonoBehaviour
{
    // Start is called before the first frame update
    public void iniciarNuevoJuego()
    {
        SceneManager.LoadScene("Escena01");
    }

    public void iniciarAcercaDe()
    {
        SceneManager.LoadScene("AcercaDe");
    }

    public void iniciarPresentacion()
    {
        SceneManager.LoadScene("Presentacion");
    }
}
