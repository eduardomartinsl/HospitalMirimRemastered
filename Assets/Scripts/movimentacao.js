#pragma strict
//import CNControls;

var player : Transform;
var velocidade : float = 5f;
var rotacao : float = 180f;

private var animacao : Animator;
//var posicao : Vector3;

function Start () {

	player = gameObject.GetComponent.<Transform>();
	animacao = gameObject.GetComponent.<Animator>();

}

function FixedUpdate () {

	//aplicando o input nas variaveis 
	var gira : float = Input.GetAxis("Horizontal");
	var frente_tras : float =  Input.GetAxis("Vertical");
	
	//aplicaçao da movimentaçao do personagem
	movimentando(frente_tras, gira);
	
	//aplicando a animacao de movimentacao
	animando(frente_tras, gira);
	
	//third person mover (Procurar);
}

function movimentando(frente_tras : float, gira : float){

	player.Translate(Vector3.forward * Time.deltaTime * velocidade * frente_tras);
	player.Rotate(0, rotacao * Time.deltaTime * gira, 0);
}

function animando (frente_tras : float, gira : float){
	var andando : boolean = frente_tras != 0f || gira != 0f;
	
	animacao.SetBool ("caminhando", andando);
}