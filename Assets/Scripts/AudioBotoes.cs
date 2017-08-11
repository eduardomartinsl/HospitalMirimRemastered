using UnityEngine;
using System.Collections;

public class AudioBotoes : MonoBehaviour {

	public AudioClip AudioDeAcerto;
	public AudioClip AudioDeErro;

	public void Acertou(){
		GetComponent<AudioSource> ().clip = AudioDeAcerto;
		GetComponent<AudioSource> ().Play();
	}


	public void Errou(){
		GetComponent<AudioSource> ().clip = AudioDeErro;
		GetComponent<AudioSource> ().Play();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
