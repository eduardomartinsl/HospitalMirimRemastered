using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*public class dropper : MonoBehaviour, IDropHandler , IPointerEnterHandler, IPointerExitHandler {*/
public class dropper : MonoBehaviour, IDropHandler{

	public int PontuacaoTotal = 0;

	//contador de procedimentos
	public int procedimentoAtual = 0;

	//objetos utilizados no procedimento
	public GameObject garrote; 
	public GameObject seringa;
	public GameObject bandeide;
	public GameObject algodao;

	public GameObject SpriteGarrote;

	//pontuação máxima por procedimento
	public int pontuacaoMaxima= 40;

	//contador de erros por procedimento executado. MÁXIMO DE ERROS PERMITIDOS POR PROCEDIMENTO: 3 (TRÊS);
	//Cada procedimento tem uma casa no vetor (Total de 9 procedimentos);
	public int[] errosPorProcedimento = new int[9];

	//vetor responsavel por armazenar as pontuações de cada procedimento;
	public int[] pontuacaoPorProcedimento = new int[9];

	//definindo a cor azulada do algodao ao ser arrastado para o alcool;
	private Color32 algodaoAzul = new Color32 (0, 236, 181, 255); 

	//referência pra acessar o script dialogos_3 (Script oficial de controle dos dialogos);
	public dialogos_3 ReferenciaDialogos;

	public Animator animacao;

	public GameObject PainelDePontuacao;
    
    //Bool responsável por dizer se existe erro ou não

	public void Start(){
		PainelDePontuacao.SetActive (true);
		garrote.SetActive (false);
		seringa.SetActive (false);
		bandeide.SetActive (false);
	}

	public void Update(){
		try {
			PainelDePontuacao.GetComponentInChildren<Text> ().text = ("Pontuação " + PontuacaoTotal);
		} catch (System.Exception ex) {
			
		}
	}

	public void OnDrop(PointerEventData eventData){

		if (gameObject.name == "dropurso") {
			
			//EM MOMENTO ALGUM O ALGODAO SEM ALCOOL É COLOCADO NO URSO, POR ISSO EM QUALQUER MOMENTO ISSO É CONSIDERADO COMO ERRO.
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 1 && procedimentoAtual == 1) {
				ReduzPontuacao (eventData.pointerDrag, procedimentoAtual);
			}


			//se o elemento utilizado for diferente do procedimento atual, retornará erro;
			if (eventData.pointerDrag.GetComponent<draghandeler>().index != procedimentoAtual){
				ReduzPontuacao(eventData.pointerDrag, procedimentoAtual);
			}
				
			/*-----------------------------------------------------------------------------------------//
												APLICANDO O GARROTE*/

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 0 && procedimentoAtual == 0) {

				procedimentoAtual = 1;
				garrote.SetActive(true);

				SpriteGarrote.GetComponent<Image>().enabled = false;

				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
				RetornaPontuacaoPorEtapa ();

			}
			/*-----------------------------------------------------------------------------------------//
										APLICANDO O ALGODAO COM ALCOOL NO URSO*/

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 2 && procedimentoAtual == 2){

				procedimentoAtual = 3;
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
				animacao.SetTrigger("zoom_in");
				RetornaPontuacaoPorEtapa ();
			}

			/*-----------------------------------------------------------------------------------------//
												APLICANDO A SERINGA*/

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 3 && procedimentoAtual == 3){
			
				procedimentoAtual = 4;
				seringa.SetActive(true);

				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
				//aplicar a animação de zoom de camera 

				RetornaPontuacaoPorEtapa ();
			}

			/*-----------------------------------------------------------------------------------------//
												APLICANDO O BANDEIDE*/

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 6 && procedimentoAtual == 6){

				procedimentoAtual = 7;
				bandeide.SetActive(true);

				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
				RetornaPontuacaoPorEtapa ();
			}
		//Debug.Log (procedimentoAtual);
		}

		if (gameObject.name == "dropalcool") {

			//procedimento diferente do index do elemento arrastado;
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index != GameObject.Find ("dropurso").GetComponent<dropper> ().procedimentoAtual) {
				GameObject.Find ("dropurso").GetComponent<dropper> ().ReduzPontuacao (eventData.pointerDrag, procedimentoAtual);
			}
			/*-----------------------------------------------------------------------------------------//
												APLICANDO O ALCOOL NO ALGODAO*/

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 1 && GameObject.Find ("dropurso").GetComponent<dropper> ().procedimentoAtual == 1) {

				algodao.GetComponent<draghandeler> ().index = 2;
				algodao.GetComponent<Image> ().color = algodaoAzul;

				GameObject.Find ("dropurso").GetComponent<dropper> ().algodao.GetComponent<Image>().color = algodaoAzul;
				GameObject.Find ("dropurso").GetComponent<dropper> ().procedimentoAtual = 2;
				procedimentoAtual = 2;
				
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
				GameObject.Find ("dropurso").GetComponent<dropper> ().RetornaPontuacaoPorEtapa ();
			}
		}
	}

	public void ReduzPontuacao(GameObject elemento, int procedimentoAtual){
		
		Debug.Log(elemento.name + " Não é utilizado neste momento! Tente novamente o procedimento "+procedimentoAtual);

		if(errosPorProcedimento[procedimentoAtual] != 3){
			errosPorProcedimento[procedimentoAtual]++;
		}
         StartCoroutine(ReferenciaDialogos.JanelaDeErro(ReferenciaDialogos.dialogosDeErro));
	}

	public void RetornaPontuacaoPorEtapa(){
		pontuacaoPorProcedimento [procedimentoAtual-1] = pontuacaoMaxima -(errosPorProcedimento[procedimentoAtual-1]*10);
		PontuacaoTotal += pontuacaoPorProcedimento[procedimentoAtual-1];
//		Debug.Log ("Pontuacao total: " + PontuacaoTotal);
//		Debug.Log ("Pontuação pelo procedimento "+ procedimentoAtual + ": "+ pontuacaoPorProcedimento[procedimentoAtual-1]);
//		Debug.Log ("Erros pelo procedimento  "+ procedimentoAtual + ": "+ errosPorProcedimento[procedimentoAtual-1]);
	}
}

/*
 * 
 * O QUE FOI FEITO: 
 * 
 * 	1- Refeito o sistema de pontuação (Criação do procedimento RetornaPontuacaoPorEtapa();
 * 	2- Inserção de referencia deste procedimento em cada if do procedimento;
 *  3- criação de um panel com um object child do tipo Text
 *  4- atualização deste panel com o update contendo a pontuação total em tempo real
 * 
 * 		TUDO NESTE SCRIPT 
 * 		Inserir no procedimento de aplicação de medicamento
 * 
 * 
 * 
 */
