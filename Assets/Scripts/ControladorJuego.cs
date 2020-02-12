using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour {

	public int puntos;

	public Text putuacion;
	public Text mensajeBienvenida;
	public Canvas menuBotones;

	public AudioClip sonidoPunto;
	public AudioClip sonidoMuerto;
	public AudioClip sonidoVolar;

	private bool candadoSonidoMuerto = false;
	private bool juegoIniciado = false;
	private bool juegoTerminado = false;



	// Use this for initialization
	void Start () {
		puntos = 0;
		mostrarMensajeBienvenida ();
		esconderMenuBotones ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Actualizamos puntuacion
	public void actualizarPuntuacion() {
		puntos ++;
		putuacion.text = puntos.ToString();
		// repoducimos el sonido de puntuacion
		reproducirSonidoPunto ();
	}

	public bool getJuegoIniciado() {
		return juegoIniciado;
	}

	public void setJuegoIniciado(bool condicion) {
		juegoIniciado = condicion;
		if (juegoIniciado == true) {
			esconderMensajeBienvenida();
		}
	}

	public bool getJuegoTerminado() {
		return juegoTerminado;
	}
	
	public void setJuegoTerminado(bool condicion) {
		juegoTerminado= condicion;
		if (juegoTerminado== true) {
			reproducirSonidoMuerto();
			mostrarMenuBotones();
		}

	}

	public void iniciarNuevoJuego() {
		SceneManager.LoadScene("Escena01");
	}

	public void mostrarMenuBotones() {
		menuBotones.enabled = true;
	}

	public void esconderMenuBotones() {
		menuBotones.enabled = false;
	}

	public void mostrarMensajeBienvenida() {
		mensajeBienvenida.enabled = true;
	}

	public void esconderMensajeBienvenida() {
		mensajeBienvenida.enabled = false;
	}

	public void reproducirSonidoPunto() {
		// Reproduce un sonido
		AudioSource.PlayClipAtPoint (sonidoPunto, Vector3.zero);
	}

	public void reproducirSonidoMuerto() {
		// Reproduce un sonido
		if (candadoSonidoMuerto==false) {
			AudioSource.PlayClipAtPoint (sonidoMuerto, Vector3.zero);
			candadoSonidoMuerto = true;
		}
	}

	public void reproducirSonidoVolar() {
		// Reproduce un sonido
		AudioSource.PlayClipAtPoint (sonidoVolar, Vector3.zero);
	}

	public void iniciarPresentacion()
	{
		SceneManager.LoadScene("Presentacion");
	}
}
