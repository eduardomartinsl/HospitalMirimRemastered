using UnityEngine;
using System.Collections;

public class MenuPrincipal : MonoBehaviour {

	public bool QuitButton;
	// Use this for initialization
	public Camera camera1;
	public GameObject LetreiroDeSelecaoDePersonagem;
	public GameObject quadro;
	public GameObject PauseButton;
	public GameObject AudioButton;

	public void Start(){
		PauseButton.SetActive (false);
		//AudioButton.SetActive (false);
	}

	public void /*IEnumerator*/ Iniciar(){
		//yield return new WaitForSeconds(35/100);
		LetreiroDeSelecaoDePersonagem.SetActive(true);
		PauseButton.SetActive (true);
		AudioButton.SetActive (true);
		quadro.SetActive(false);
		camera1.GetComponent<Animator>().SetBool("iniciou", true);
	}

	public void QuitApp(){
		Application.Quit();
	}
}
