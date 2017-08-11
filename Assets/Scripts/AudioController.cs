using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

	public static AudioController Instancia;


	public AudioClip MusicaMenuPrincipal;
	public AudioClip MusicaDePuncao;

	public Sprite ImagemSemSom;
	public Sprite ImagemComSom;

	public GameObject BotaoDeAudio;
//	public int level;

	public static AudioController GetInstance(){
		return Instancia;
	}

	void Start () {
		//GetComponent<AudioSource> ().mute = true;

		Scene scene = SceneManager.GetActiveScene();

		if (Instancia != null && Instancia != this) {
			Destroy (this.gameObject);
			return;
		} else {
			Instancia = this;
			CarregaMusicaDeLvl (scene.buildIndex);
		}

		if (!GetComponent<AudioSource> ().mute) {
			BotaoDeAudio.GetComponent<Image> ().sprite = ImagemComSom;
		} else {
			BotaoDeAudio.GetComponent<Image> ().sprite = ImagemSemSom;
		}

		DontDestroyOnLoad (this.gameObject);

	}

	public void Update(){
		BotaoDeAudio = GameObject.Find ("Botao mudo");
	}

	void CarregaMusicaDeLvl(int level){
		if (level == 0) {
			//GetComponent<AudioSource> ().mute = true;
			GetComponent<AudioSource> ().clip = MusicaMenuPrincipal;
			GetComponent<AudioSource> ().Play ();
		}

		if (level == 1) {
			if (GetComponent<AudioSource> ().clip == MusicaDePuncao) {
				GetComponent<AudioSource> ().Stop ();
				GetComponent<AudioSource> ().clip = MusicaMenuPrincipal;
				GetComponent<AudioSource> ().Play ();
			}
		}

		if (level == 2 || level == 3) {
			GetComponent<AudioSource> ().Stop ();
			GetComponent<AudioSource> ().clip = MusicaDePuncao;
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void botaoDeMudo(){
		
		if (GetComponent<AudioSource> ().mute) {
			BotaoDeAudio.GetComponent<Image> ().sprite = ImagemComSom;
			GetComponent<AudioSource> ().mute = false;
		} else {
			BotaoDeAudio.GetComponent<Image> ().sprite = ImagemSemSom;
			GetComponent<AudioSource> ().mute = true;

		}
	}
}