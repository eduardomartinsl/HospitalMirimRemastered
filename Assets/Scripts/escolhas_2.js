#pragma strict
var selecionadoMedico : int;
var selecionadoPaciente : int;
var selecionou : AudioClip;
var destacou : AudioClip;
var cam : Camera;
var jalecos : SkinnedMeshRenderer[];	//Vetor responsavel por armazenar o jaleco dos personagens selecionados
var setaPacientes : MeshRenderer[];		//vetor responsavel por armazenar as setas na cabeça dos pacientes selecionados

var confirmaMedico = false;
var confirmaPaciente = false;

function Start () {
	QualitySettings.vSyncCount = 0;
	this.jalecos = [	
			GameObject.Find("jaleco0").GetComponent.<SkinnedMeshRenderer>(),  	//jaleco do medico 0
			GameObject.Find("jaleco1").GetComponent.<SkinnedMeshRenderer>(),   	//jaleco do medico 1
			GameObject.Find("jaleco2").GetComponent.<SkinnedMeshRenderer>(),	//jaleco do medico 2
			GameObject.Find("jaleco3").GetComponent.<SkinnedMeshRenderer>(), 	//jaleco do medico 3
			GameObject.Find("jaleco4").GetComponent.<SkinnedMeshRenderer>(), 	//jaleco do medico 4
			GameObject.Find("jaleco5").GetComponent.<SkinnedMeshRenderer>()  	//jaleco do medico 5

			//seis médicos (Dois de cada etnia, sendo uma menina e um menino)
	];
	
	this.setaPacientes = [
		GameObject.Find("seta0").GetComponent.<MeshRenderer>(),
		GameObject.Find("seta1").GetComponent.<MeshRenderer>()
	];
	
	selecionadoMedico = -1;
	selecionadoPaciente = -1;
}

function Update () {
			
	if (Input.GetMouseButtonUp(0)){
		var ray: Ray = cam.ScreenPointToRay (Input.mousePosition);
		var hit : RaycastHit;
		if (Physics.Raycast (ray, hit, 100)){
		
			if(hit.collider.name.Length >= 7 && hit.collider.name.Substring(0,6) == "medico"){
				PersonagemSelecionado(hit.collider.name.Substring(6));
				GetComponent.<AudioSource>().PlayOneShot(selecionou);
			}	
			
			if(hit.collider.name.Length >= 9 && hit.collider.name.Substring(0,8) == "paciente"){
				PacienteSelecionado(hit.collider.name.Substring(8));
				GetComponent.<AudioSource>().PlayOneShot(selecionou);
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
		}else{
			jalecos[i].enabled = false;
		}
	}
}

function PacienteSelecionado(numero){

	selecionadoPaciente = int.Parse(numero);
	Debug.Log("Paciente Selecionado: " + selecionadoPaciente);
	PlayerPrefs.SetInt("selecionadoPaciente", (selecionadoPaciente)); // variavel de set do paciente
	for(var i = 0; i<setaPacientes.length; i++){
		if(i == selecionadoPaciente){
			setaPacientes[i].enabled = true;
			confirmaPaciente = true;
		}else{
			setaPacientes[i].enabled = false;
		}
	}
}

function aplicaFade(){
		var fadeTime = gameObject.Find("menu").GetComponent.<Fade>().BeginFade(1);
		yield new WaitForSeconds(fadeTime);
		Application.LoadLevel(1);
}

function OnGUI(){
	if(confirmaMedico){
		if (GUI.Button (Rect ((Screen.width - 100)/2,Screen.height - 60,100,50), "Confirmar")) {
			if (confirmaMedico){
	    		cam.GetComponent.<Animator>().SetTrigger("selecionou2");
	   			confirmaMedico = false;
   			}
    		if(confirmaMedico)return;
		}
	}
	

	//substituir uma janela de seleção apropriada
	if ((confirmaPaciente) && (selecionadoPaciente == 1)){
		GUI.Box (Rect ((Screen.width)/2-100, (Screen.height)/2-100, 200, 180), "EM DESENVOLVIMENTO");
		if (GUI.Button (Rect (Screen.width/2-60,Screen.height/2-60,120,50)," Retornar ")) {
				confirmaPaciente = false;
		}
	}else if (confirmaPaciente){
			if(GUI.Button (Rect((Screen.width - 100)/2, Screen.height - 60, 100, 50), "Confirmar")){
				Debug.Log("Selecionado o paciente: "+selecionadoPaciente);
				confirmaPaciente = false;
				aplicaFade();
			}
		if(GUI.Button (Rect((Screen.width - 330)/2, Screen.height - 60, 100, 50), "Retornar")){
			for(var i = 0; i<setaPacientes.length; i++){
				setaPacientes[i].enabled = false;
			}
			cam.GetComponent.<Animator>().SetTrigger("retornou2");
			confirmaPaciente = false;
		}
		if (confirmaPaciente) return;
	}
}