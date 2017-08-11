#pragma strict

var soundhover : AudioClip;
var beep : AudioClip;
var confirma = false;

var botaoSim : GameObject;
var botaoNao : GameObject;
var janelaDeInicioDeProcedimento : GameObject;
var menuDePausa : GameObject;
var controladorDePersonagem : GameObject;

var PainelDeProcedimentos : GameObject;


function OnMouseEnter(){
    GetComponent.<AudioSource>().PlayOneShot(soundhover);
}

/*function OnMouseUp(){
	
	GetComponent.<AudioSource>().PlayOneShot(beep);
	janelaDeInicioDeProcedimento.SetActive(true);
	menuDePausa.SetActive(false);
	controladorDePersonagem.SetActive(false);

}
*/

function aplicaFade(estagioCarregado){
		var referencia = int.Parse(estagioCarregado);
		var fadeTime = gameObject.Find("scripts").GetComponent.<Fade>().BeginFade(1);
		yield new WaitForSeconds(fadeTime);
		Application.LoadLevel(referencia);
}

function iniciaProcedimento(){
	janelaDeInicioDeProcedimento.SetActive(false);
	PainelDeProcedimentos.SetActive(true);
	controladorDePersonagem.SetActive(false);

}

function naoIniciaProcedimento(){
	janelaDeInicioDeProcedimento.SetActive(false);
	menuDePausa.SetActive(true);
	controladorDePersonagem.SetActive(true);
	PainelDeProcedimentos.SetActive(false);
}

function fechaPainelDeProcedimentos(){
	PainelDeProcedimentos.SetActive(false);
	controladorDePersonagem.SetActive(true);
}

function iniciaTirarSangue(){
	aplicaFade("2");
}

function iniciaAplicarRemedio(){
	aplicaFade("3");
}
