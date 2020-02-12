using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorTubos : MonoBehaviour {

	// Velocidad de las columnas
	public Vector3 velocidad = new Vector3 (-2, 0, 0);
	// la distancia entra columnas máxima
	public Vector3 distanciaColumnas;
	// aleatoridad en distancia X
	//public float distanciaAletoriaX;

	// form mas coirrecta de hacerlo
	//public SpriteRenderer formaColumna;

	// puntuacion
	//public Text putuacion;
	//private int puntos = 0;

	// Controlador del juego --> Hago referencia al Script de GameObject Controlador de Juego
	public ControladorJuego controladorJuego;
	// Otra forma (mirar el start
	//public GameObject obj; --> enlazar en la interfaz
	//ControladorJuego controladorJuego;


	private bool aumentaPuntos = true;

	// Use this for initialization
	void Start () {
		//controladorJuego = obj.GetComponent<ControladorJuego>();
	}
	
	// Update is called once per frame
	void Update () {
		// mueve el tubo en cada update
		if (controladorJuego.getJuegoIniciado () == true) {
			moverTubo ();
		}
	}

	// movemos el tubo
	private void moverTubo() {
		// movemos el tubo a la derecha
		this.transform.position = this.transform.position + (velocidad * Time.deltaTime);

		// Distancia entre columnas para mover, -13 es el final de la camara
		//if(formaColumna.isVisible == true) {
		if (this.transform.position.x <= -17) {
			// le aumentamos la distancia
			Vector3 posicionTemporal = this.transform.position + distanciaColumnas;
			// La añado un alatetorio que mole un poco en X
			//posicionTemporal.x = Random.Range(-distanciaAletoriaX,distanciaAletoriaX);
			posicionTemporal.y = Random.Range(-3.10f,1.22f);
			// movemos a esa posicion
			this.transform.position = posicionTemporal;
			aumentaPuntos=true;
		}
		// Actualizo puntuación, cuando el pajaro pasa el tubo
		if (this.transform.position.x <= -12.20 & aumentaPuntos == true) {
			//puntos = int.Parse(putuacion.text.ToString());
			//puntos ++;
			//putuacion.text = puntos.ToString();
			controladorJuego.actualizarPuntuacion();
			aumentaPuntos = false;
		}
	}
}
