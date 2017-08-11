#pragma strict

var BotaoDePause : 		GameObject;
var InterfaceDragDrop : GameObject;
var Dialogos : 			GameObject;
var PauseScreen: GameObject;
// script de fade para mudança de nível
var aplicadorDeFade : Fade;
var placar : GameObject;

function update(){

}
function Start () {

}

function Pausado(){
	PauseScreen.SetActive(true);
	InterfaceDragDrop.SetActive(false);
	Dialogos.SetActive(false);
	BotaoDePause.SetActive(false);
	Time.timeScale = 0;
	if(placar.active){
		placar.SetActive(false);
	}

}

function Despausado(){
	InterfaceDragDrop.SetActive(true);
	PauseScreen.SetActive(false);
	Dialogos.SetActive(true);
	BotaoDePause.SetActive(true);
	Time.timeScale = 1;
	if(!placar.active){
		placar.SetActive(true);
	}
}

function MenuPrincipal(){
	Time.timeScale = 1;
	AplicaFade("0");
}

function voltarQuarto(){
	Time.timeScale =1;
	AplicaFade("1");
}

function Sair(){
	Application.Quit();
}

function AplicaFade(estagioCarregado){
	var referencia = int.Parse(estagioCarregado);
	var fadeTime = aplicadorDeFade.GetComponent.<Fade>().BeginFade(1);
	yield new WaitForSeconds(fadeTime);
	Application.LoadLevel(referencia);
//	SceneManager.LoadScene(referencia);
}