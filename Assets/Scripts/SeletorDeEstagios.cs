using UnityEngine;
using System.Collections;

public class SeletorDeEstagios : MonoBehaviour {


	public FadeSharp AplicadorDeFade;
	public GameObject CharController;
	public GameObject SeletorDeProcedimento;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator AplicaFade(int estagioCarregado){
		float fadeTime = AplicadorDeFade.BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(estagioCarregado);
	}

	public void ColetaDeSangue(){
		if (PlayerPrefs.GetInt ("selecionadoPaciente") == 0) {
			StartCoroutine (AplicaFade (2));
		} else if (PlayerPrefs.GetInt ("selecionadoPaciente") == 1) {
			StartCoroutine (AplicaFade (4));
		} else if (PlayerPrefs.GetInt ("selecionadoPaciente") == 2) {
			StartCoroutine (AplicaFade (6));
		}

	}


	public void AplicaMedicamento(){
		if (PlayerPrefs.GetInt ("selecionadoPaciente") == 0) {
			StartCoroutine (AplicaFade (3));
		} else if (PlayerPrefs.GetInt ("selecionadoPaciente") == 1) {
			StartCoroutine (AplicaFade (5));
		}else if (PlayerPrefs.GetInt ("selecionadoPaciente") == 2) {
			StartCoroutine (AplicaFade (7));
		}
	}

	public void FechaJanelaDeProcedimentos(){
		CharController.SetActive (true);
		SeletorDeProcedimento.SetActive (false);
	}

}
