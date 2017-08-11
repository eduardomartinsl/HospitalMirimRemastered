using UnityEngine;
using System.Collections;

public class colisorUrso : MonoBehaviour {
	
	public GameObject janelaDeInicioDeProcedimento;

	void OnTriggerEnter() {
		janelaDeInicioDeProcedimento.SetActive(true);
	}

	void OnTriggerExit(){
		janelaDeInicioDeProcedimento.SetActive(false);		
	}
}
