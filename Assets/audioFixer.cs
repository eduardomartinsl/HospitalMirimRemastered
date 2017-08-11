using UnityEngine;
using System.Collections;

public class audioFixer : MonoBehaviour {

	public controledesom ControleChecker;

	// Use this for initialization
	void Start () {
	
	}

	void setaDemais(){
	
	}

	// Update is called once per frame
	public void NaoDeixaMudoMais () {
		ControleChecker.comecou = 1;
	}
}
