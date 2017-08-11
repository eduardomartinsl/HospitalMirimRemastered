#pragma strict


//Função referente aos botões do script de escolhas

/*function OnGUI(){
	if(confirmaMedico){
		if (GUI.Button (Rect ((Screen.width - 100)/2,Screen.height - 60,100,50), "Confirmar")) {
			if (confirmaMedico){
	    		Debug.Log("Selecionado o medico: " + selecionadoMedico);
	    		cam.GetComponent.<Animator>().SetTrigger("selecionou2");
	   			confirmaMedico = false;
   			}
    		if(confirmaMedico)return;
		}
	}
		if ((confirmaPaciente) && (selecionadoPaciente == 1)){
		GUI.Box (Rect ((Screen.width)/2-100, (Screen.height)/2-100, 200, 180), "EM DESENVOLVIMENTO");
		if (GUI.Button (Rect (Screen.width/2-60,Screen.height/2-60,120,50)," Retornar ")) {
				confirmaPaciente = false;
				//menuDosPacientes.SetActive(false);
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
		if (confirmaPaciente){
			//menuDosPacientes.SetActive(true);
			return;	
		} 
	}
}*/