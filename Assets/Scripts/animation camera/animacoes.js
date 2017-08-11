#pragma strict

public var anim : Animator;
var iniciou;
var selecionou;
var retornou;


function Start () {
	//todas as variáveis devem ser setadas na função start (Atualização Unity 5.1);
	
	anim = GetComponent.<Animator>();
	iniciou  = anim.GetBool("iniciou");
	selecionou = anim.GetBool("selecionou");
	retornou = anim.GetBool("retornou");

}

function Update () {
	if(iniciou){
		anim.Play("menu - personagens");
		//iniciou = false;
		anim.SetBool("iniciou",false);
	}
	if (selecionou){
		anim.Play("personagens - pacientes");
		//selecionou = false;
		anim.SetBool("selecionou", false);
	}
	if (retornou){
		//anim.Play("personagens - pacientes");
		//anim.animation["personagens - pacientes"].speed = -1;
		//animation["personagens - pacientes"].speed = -1;
		//retornou = false;
		anim.SetBool("retornou", false);
	
}

//function selecionado(){
//	if (selecionou){
//		anim.Play("personagens - pacientes");
//		selecionou = false;
//		anim.SetBool("selecionou", selecionou);
//		Debug.Log("status da variavel selecionou dentro do script menu-personagens: " + anim.GetBool("selecionou"));
//	}
}