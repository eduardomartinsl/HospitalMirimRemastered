using UnityEngine;
using System.Collections;
using CnControls;

public class movimentacao2 : MonoBehaviour {

	Transform player;
	public float velocidade = 2f;
	public float rotacao = 120f;
	public Animator animacao;


	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Transform>();
		animacao = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float gira = CnInputManager.GetAxis ("Horizontal");
		float frente_tras = CnInputManager.GetAxis ("Vertical");
		//aplicando o input nas variaveis 
		
		//aplicaçao da movimentaçao do personagem
		movimentando(frente_tras, gira);
		
		//aplicando a animacao de movimentacao
		animando(frente_tras, gira);

	}
	void movimentando(float frente_tras,float  gira){
		
		player.Translate(Vector3.forward * Time.deltaTime * velocidade * frente_tras);
		player.Rotate(0, rotacao * Time.deltaTime * gira, 0);
	}
	
	void animando (float frente_tras,float gira){
		bool andando = frente_tras != 0f || gira != 0f;
		
		animacao.SetBool ("caminhando", andando);
	}
}
