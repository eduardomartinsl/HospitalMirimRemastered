using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class caricaturas : MonoBehaviour {

	public Sprite[] medico0 = new Sprite[2];
	public Sprite[] medico1 = new Sprite[2];
	public Sprite[] medico2 = new Sprite[2];
	public Sprite[] medico3 = new Sprite[2];
	public Sprite[] medico4 = new Sprite[2];
	public Sprite[] medico5 = new Sprite[2];

	public Sprite[] CaricaturaSelecionada = new Sprite[2];

	public int RecuperaMedicoSelecionado;

	// Use this for initialization
	public void Start () {

		RecuperaMedicoSelecionado = PlayerPrefs.GetInt("selecionadoMedico");
		if (RecuperaMedicoSelecionado == 0){
			for(int i = 0; i < CaricaturaSelecionada.Length; i++){
				CaricaturaSelecionada[i] = medico0[i];
			}
		}else if (RecuperaMedicoSelecionado == 1){
			for(int i = 0; i < CaricaturaSelecionada.Length; i++){
				CaricaturaSelecionada[i] = medico1[i];
			}
		}else if (RecuperaMedicoSelecionado == 2){
			for(int i = 0; i < CaricaturaSelecionada.Length; i++){
				CaricaturaSelecionada[i] = medico2[i];
			}
		}else if (RecuperaMedicoSelecionado == 3){
			for(int i = 0; i < CaricaturaSelecionada.Length; i++){
				CaricaturaSelecionada[i] = medico3[i];
			}
		}else if (RecuperaMedicoSelecionado == 4){
			for(int i = 0; i < CaricaturaSelecionada.Length; i++){
				CaricaturaSelecionada[i] = medico4[i];
			}
		}else if (RecuperaMedicoSelecionado == 5){
			for(int i = 0; i < CaricaturaSelecionada.Length; i++){
				CaricaturaSelecionada[i] = medico5[i];
			}
		}
		//Debug.Log(CaricaturaSelecionada[0] + " Caricatura dentro do script de caricatura");
		Debug.Log(CaricaturaSelecionada[0] +" caricatura do script de caricatura");
	}
	// Update is called once per frame
	void Update () {
	
	}

	
}
