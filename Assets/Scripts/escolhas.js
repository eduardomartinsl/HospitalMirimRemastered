#pragma strict

var selecionadoMedico : int;
var selecionadoPaciente : int;
var selecionou : AudioClip;
var destacou : AudioClip;
var cam : Camera;
var menuDosMedicos : GameObject ;
var menuDosPacientes : GameObject;
var emDesenvolvimento : GameObject;
var jalecos : SkinnedMeshRenderer[];	//Vetor responsavel por armazenar o jaleco dos personagens selecionados
var setaPacientes : MeshRenderer[];		//vetor responsavel por armazenar as setas na cabeça dos pacientes selecionados

var confirmaMedico = false;
var confirmaPaciente = false;

var LetreiroDeSelecaoDePersonagem : GameObject;
var LetreiroDeSelecaoDePaciente : GameObject;

//var painelDeProcedimentos : GameObject;

var colisorDePacientes : BoxCollider[];

var ReferenciaParaSom : int;

function Start () {
	ReferenciaParaSom = 0;
//	painelDeProcedimentos.SetActive(false);
	QualitySettings.vSyncCount = 0;

	this.colisorDePacientes = [
			GameObject.Find("paciente0").GetComponent.<BoxCollider>(),
			GameObject.Find("paciente1").GetComponent.<BoxCollider>()
	];
	
	this.jalecos = [	
			GameObject.Find("jaleco0").GetComponent.<SkinnedMeshRenderer>(),  	//jaleco do medico 0
			GameObject.Find("jaleco1").GetComponent.<SkinnedMeshRenderer>(),  	//jaleco do medico 1
			GameObject.Find("jaleco2").GetComponent.<SkinnedMeshRenderer>(),	//jaleco do medico 2
			GameObject.Find("jaleco3").GetComponent.<SkinnedMeshRenderer>(),  	//jaleco do medico 3
			GameObject.Find("jaleco4").GetComponent.<SkinnedMeshRenderer>(),  	//jaleco do medico 4
			GameObject.Find("jaleco5").GetComponent.<SkinnedMeshRenderer>()  	//jaleco do medico 5
	];

	this.setaPacientes = [
		GameObject.Find("seta0").GetComponent.<MeshRenderer>(),
		GameObject.Find("seta1").GetComponent.<MeshRenderer>(),
		GameObject.Find("seta2").GetComponent.<MeshRenderer>()
	];
	
	selecionadoMedico = -1;
	selecionadoPaciente = -1;
}

function Update () {

//	if(selecionadoPaciente == 1){
//		for(var b = 0; b<setaPacientes.length; b++){
//			colisorDePacientes[b].enabled = false;
//		}
//		Debug.Log("Paciente em desenvolvimento");
//		emDesenvolvimento.SetActive(true);
//		selecionadoPaciente = -1;
//		menuDosPacientes.SetActive(false);
//
//		for(var i = 0; i<setaPacientes.length; i++){
//			setaPacientes[i].enabled = false;
//		}
//	}
			
	if (Input.GetMouseButtonUp(0)){
		var ray: Ray = cam.ScreenPointToRay (Input.mousePosition);
		var hit : RaycastHit;
		if (Physics.Raycast (ray, hit, 100)){
		
			if(hit.collider.name.Length >= 7 && hit.collider.name.Substring(0,6) == "medico"){
			Debug.Log(hit.collider.name.Substring(6));
				PersonagemSelecionado(hit.collider.name.Substring(6));
				GetComponent.<AudioSource>().PlayOneShot(selecionou);
				LetreiroDeSelecaoDePersonagem.SetActive(true);
			}	
			
			if(hit.collider.name.Length >= 9 && hit.collider.name.Substring(0,8) == "paciente"){
				PacienteSelecionado(hit.collider.name.Substring(8));
				GetComponent.<AudioSource>().PlayOneShot(selecionou);
				LetreiroDeSelecaoDePaciente.SetActive(true);
			}			
		}else{
			return;
		}
	}
}

function OnMouseEnter(){
	GetComponent.<AudioSource>().PlayOneShot(destacou);
}

function PersonagemSelecionado(numero){
	
	selecionadoMedico = int.Parse(numero);
	PlayerPrefs.SetInt("selecionadoMedico", (selecionadoMedico)); //variavel responsável por armazenar o médico setado
	for(var i = 0; i<jalecos.length; i++){
		if(i == selecionadoMedico){
			jalecos[i].enabled = true;
			confirmaMedico = true;
			menuDosMedicos.SetActive(true);
		}else{
			jalecos[i].enabled = false;
		}
	}
}

function PacienteSelecionado(numero){

	selecionadoPaciente = int.Parse(numero);
	PlayerPrefs.SetInt("selecionadoPaciente", (selecionadoPaciente)); // variavel de set do paciente
	for(var i = 0; i<setaPacientes.length; i++){
		if(i == selecionadoPaciente){
			setaPacientes[i].enabled = true;
//			if(selecionadoPaciente  == 0){
			menuDosPacientes.SetActive(true);
//			}
			confirmaPaciente = true;
		}else{
			setaPacientes[i].enabled = false;
		}
	}
}

function aplicaFade(estagioCarregado){
	var referencia = int.Parse(estagioCarregado);
	var fadeTime = gameObject.Find("scripts").GetComponent.<Fade>().BeginFade(1);
	yield new WaitForSeconds(fadeTime);
	Application.LoadLevel(referencia);
}

function Medicosss(){
	cam.GetComponent.<Animator>().SetTrigger("selecionou2");
	menuDosMedicos.SetActive(false);
	Debug.Log("Medico selecionado");
	LetreiroDeSelecaoDePersonagem.SetActive(false);
	LetreiroDeSelecaoDePaciente.SetActive(true);
}

function pacientesss(){
//	if(selecionadoPaciente == 1){
//		emDesenvolvimento.SetActive(true);
//		selecionadoPaciente = -1;
//		for(var i = 0; i<setaPacientes.length; i++){
//			setaPacientes[i].enabled = false;
//		}
//	}else{
/*		for(var j = 0; j<setaPacientes.length; j++){
			colisorDePacientes[j].enabled = false;
		}
		menuDosPacientes.SetActive(false);
		painelDeProcedimentos.SetActive(true);
*/
		aplicaFade("1");
		ReferenciaParaSom = 1;

//	}
}
/*
function iniciaTirarSangue(){
	aplicaFade("2");
}

function iniciaAplicarRemedio(){
	aplicaFade("3");
}
*/
function retornaMedicosss(){
	menuDosPacientes.SetActive(false);
	selecionadoMedico = -1;
	for(var i = 0; i<setaPacientes.length; i++){
		setaPacientes[i].enabled = false;
	}
	cam.GetComponent.<Animator>().SetTrigger("retornou2");
	LetreiroDeSelecaoDePaciente.SetActive(false);
	LetreiroDeSelecaoDePersonagem.SetActive(true);
}

function JanelaDeDesenvolvimento(){
	selecionadoPaciente = -1;
	Debug.Log("fechou desenvolvimento");
	emDesenvolvimento.SetActive(false);
	menuDosPacientes.SetActive(false);
	confirmaPaciente = false;
}

function fechaDesenvolvimento(){
	for(var i = 0; i<setaPacientes.length; i++){
		colisorDePacientes[i].enabled = true;
	}
	emDesenvolvimento.SetActive(false);
	Debug.Log("clicou no botao de fechar");
}
/*
function fechaPainelDeProcedimento(){
	for(var i = 0; i<setaPacientes.length; i++){
		colisorDePacientes[i].enabled = true;
	}
	painelDeProcedimentos.SetActive(false);
}
*/