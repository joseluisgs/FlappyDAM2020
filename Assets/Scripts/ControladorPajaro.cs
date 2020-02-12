using UnityEngine;
using System.Collections;

public class ControladorPajaro : MonoBehaviour {

	// Velocidad inicial de pajaro
	Vector3 velocidad = Vector3.zero;
	// Gravedad, no usaremos la de Unity
	public Vector3  gravedad;
	// velocidad de aleteo
	public Vector3 velocidadVuelo;
	// si debemos volar, si hemos presionado
	bool volando = false;
	// velocidad máxima de rotacion
	public float velocidadMaxima;

	// vamos a parar las cosas
	public ControladorTubos tubo01;
	public ControladorTubos tubo02;

	// animador
	private Animator anim;

	// Controlador de juego
	public ControladorJuego controladorJuego;

	//private bool juegoTerminado = false;
	//private bool juegoIniciado = false;

	// Use this for initialization
	void Start () {
		// recogemos el Animator del pajaro y podemos usarlo comocódigo
		anim = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// para el movil evitar toques
		int numToques = 0;
		foreach (Touch toque in Input.touches) {
			if((toque.phase != TouchPhase.Ended) && (toque.phase != TouchPhase.Canceled)) {
				numToques++;
			}
		}
		// si presionamos el esoacio o hacemos clic
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || numToques > 0) {
			// Si el juego no ha terminado
			if(controladorJuego.getJuegoTerminado()==false) {
				volando = true;
			}
			controladorJuego.setJuegoIniciado(true);
			controladorJuego.reproducirSonidoVolar();
		}
	}

	// Actualización de la fisica de manera manual
	void FixedUpdate () {

		if (controladorJuego.getJuegoIniciado ()) {
			// A la velocidad le semamos la gravedad para que caiga el pajaro
			velocidad += gravedad * Time.deltaTime; // tiempo del juego (frames por segundo) y va acelrando

			// si presionaron algun boton de volar
			if (volando == true) {
				volando = false;
				// impulso hacia arriba
				velocidad.y = velocidadVuelo.y;
			}
			// Hacemos que el pajaro reciba la velocidad
			transform.position += velocidad * Time.deltaTime;
			float angulo = 0;
			if (velocidad.y >= 0) {
				// cambiamos el angulo para que el pajaro mire hacia arriba
				angulo = Mathf.Lerp (0, 25, velocidad.y / velocidadMaxima);
			} else {
				// cambiamos el angulo para que el pajaro mire hacia abajo
				angulo = Mathf.Lerp (0, -75, -velocidad.y / velocidadMaxima);
			}
			// Finalmente rotamos en el eje Z
			transform.rotation = Quaternion.Euler (0, 0, angulo);
		}
	}

	// cada vez que haya una colision con un objeto collider se actua
	// Collider son Box Collider 2D, Circle Collider, etc.

	void OnCollisionEnter2D (Collision2D colision) {
		//Si colisionamos con el tubo
		if (colision.gameObject.name == "TuboAbajo" | colision.gameObject.name == "TuboArriba" | colision.gameObject.name == "Suelo") {
			// Velocidad de los tubos es cero, se paran
			tubo01.velocidad = Vector3.zero; // new Vector3 (0,0,0);
			tubo02.velocidad = Vector3.zero;
			// Animacion, estado muerto
			anim.SetTrigger("JuegoTerminado");

		}
		// Al momento de caer queremos ignorar la colision con el tubo de abajo.
		if (colision.gameObject.name == "TuboAbajo") {
			colision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		// Si colisionamos con el piso que la gravedad no siga aumentando
		if (colision.gameObject.name == "Suelo") {
			gravedad = Vector3.zero;
		}
		// Controlador a juego muerto
		controladorJuego.setJuegoTerminado(true);
	}
}
