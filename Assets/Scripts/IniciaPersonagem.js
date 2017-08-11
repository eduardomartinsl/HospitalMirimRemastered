#pragma strict

var medico0 : GameObject;
var medico1 : GameObject;
var medico2 : GameObject;
var medico3 : GameObject;
var medico4 : GameObject;
var medico5 : GameObject;

var paciente0 : GameObject;
var paciente1 : GameObject;
var paciente2 : GameObject;

var medicoSelecionado : int = 0;
var pacienteSelecionado : int = 0;

function Awake () {

	medicoSelecionado = PlayerPrefs.GetInt("selecionadoMedico");
	pacienteSelecionado = PlayerPrefs.GetInt("selecionadoPaciente");
	
	medico0 = GameObject.Find("medico0");
	medico1 = GameObject.Find("medico1");
	medico2 = GameObject.Find("medico2");
	medico3 = GameObject.Find("medico3");
	medico4 = GameObject.Find("medico4");
	medico5 = GameObject.Find("medico5");

	paciente0 = GameObject.Find("Urso");
	paciente1 = GameObject.Find("Boneca");
	paciente2 = GameObject.Find("Robo");

	if(medicoSelecionado == 0){
		medico0.SetActive(true);
		medico1.SetActive(false);
		medico2.SetActive(false);
		medico3.SetActive(false);
		medico4.SetActive(false);
		medico5.SetActive(false);
	}else if(medicoSelecionado == 1){
		medico0.SetActive(false);
		medico1.SetActive(true);
		medico2.SetActive(false);
		medico3.SetActive(false);
		medico4.SetActive(false);
		medico5.SetActive(false);
	}else if(medicoSelecionado == 2){
		medico0.SetActive(false);
		medico1.SetActive(false);
		medico2.SetActive(true);
		medico3.SetActive(false);
		medico4.SetActive(false);
		medico5.SetActive(false);
	}else if(medicoSelecionado == 3){
		medico0.SetActive(false);
		medico1.SetActive(false);
		medico2.SetActive(false);
		medico3.SetActive(true);
		medico4.SetActive(false);
		medico5.SetActive(false);
	}else if(medicoSelecionado == 4){
		medico0.SetActive(false);
		medico1.SetActive(false);
		medico2.SetActive(false);
		medico3.SetActive(false);
		medico4.SetActive(true);
		medico5.SetActive(false);
	}else if(medicoSelecionado == 5){
		medico0.SetActive(false);
		medico1.SetActive(false);
		medico2.SetActive(false);
		medico3.SetActive(false);
		medico4.SetActive(false);
		medico5.SetActive(true);
	}

	if(pacienteSelecionado == 0){
		paciente0.SetActive(true);
		paciente1.SetActive(false);
		paciente2.SetActive(false);
	}else if(pacienteSelecionado == 1){
		paciente0.SetActive(false);
		paciente1.SetActive(true);
		paciente2.SetActive(false);
	}else if(pacienteSelecionado == 2){
		paciente0.SetActive(false);
		paciente1.SetActive(false);
		paciente2.SetActive(true);
	}
}