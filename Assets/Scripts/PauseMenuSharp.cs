using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuSharp : MonoBehaviour {


	public FadeSharp AplicadorDeFade;

	public GameObject BotaoDePause;
	public GameObject InterfaceDragDrop;
	public GameObject Dialogos;
	public GameObject pauseScreen;
	public GameObject placar;
	public GameObject TodoResto;
	public GameObject QuadConflito;

	public void Pausado(){
		Debug.Log ("Pausou o jogo");
		QuadConflito.SetActive (true);
		TodoResto.SetActive (false);
		pauseScreen.SetActive(true);
		Time.timeScale = 0;
	}

	public void Start(){
	
	}

	public void Despausado(){
		StartCoroutine (DesativaQuadDeCamera ());
		pauseScreen.SetActive (false);
		TodoResto.SetActive (true);
		Time.timeScale = 1;
	}

	public void MenuPrincipal(){
		Time.timeScale = 1;
		StartCoroutine(AplicaFade(0));
	}

	public void VoltarQuarto(){
		Time.timeScale =1;
		StartCoroutine(AplicaFade(1));
	}

	public void Sair(){
		Application.Quit();
	}

	public IEnumerator AplicaFade(int estagioCarregado){
		float fadeTime = AplicadorDeFade.BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(estagioCarregado);
	}

	public IEnumerator DesativaQuadDeCamera(){
		QuadConflito.SetActive (false);
		yield return new WaitForSeconds (1);
	}
}
