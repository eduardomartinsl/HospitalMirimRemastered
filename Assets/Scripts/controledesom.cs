using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controledesom : MonoBehaviour {

	public AudioSource somGeral;
	public Sprite ImagemSemSom;
	public Sprite ImagemComSom;
	public int comecou = 0;

	// Use this for initialization
	void Start () {
		Scene scene = SceneManager.GetActiveScene();

		somGeral = GameObject.Find("Som Ambiente").GetComponent<AudioSource>();
//		Começar o jogo no mudo
//		if (comecou == 0) {
//			if (scene.buildIndex == 0) {
//				somGeral.mute = true;
//			}
//		}

		if(!somGeral.mute){
			this.gameObject.GetComponent<Image>().sprite = ImagemComSom;
		}else{
			this.gameObject.GetComponent<Image>().sprite = ImagemSemSom;
		}
	}
	public void botaoDeMudo(){
		if(somGeral.mute){
			this.gameObject.GetComponent<Image>().sprite = ImagemComSom;
			somGeral.mute = false;
		}else{
			this.gameObject.GetComponent<Image>().sprite = ImagemSemSom;
			somGeral.mute = true;
		}
	}
}