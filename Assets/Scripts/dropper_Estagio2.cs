using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
	Sequencia correta dos procedimentos: 
•	Aplicação do garrote no paciente
•	Aplicação do algodão no álcool para esterilização
•	Aplicação do algodão com álcool no paciente
•	Preenchimento da seringa com o medicamento
•	Aplicação da seringa com medicamento no paciente
•	Remoção do garrote
•	Remoção da seringa
•	Aplicação do curativo

	index
	0 garrote
	-------------
	1 algodao
	2 algodao com alcool
	-------------
	3 seringa
	4 seringa com remedio
	-------------
	5 remove garrote
	6 remove seringa
	-------------
	7 curativo

	nunca vão para o urso: 
	
	-alcool;
	-algodão sem alcool;
	-medicamento;
	-seringa sem medicamento;
*/

public class dropper_Estagio2 : MonoBehaviour, IDropHandler {

	public int PontuacaoTotal = 0;

	public int procedimentoAtual = 0;

	//Objetos utilizados no jogo
	//refinar

	//pontuação maxima por procedimento
	public int pontuacaoMaxima = 40;


	//contador de erros por procedimento executado. MÁXIMO DE ERROS PERMITIDOS POR PROCEDIMENTO: 3 (TRÊS);
	private int[] errosPorProcedimento = new int[15];

	//vetor responsavel por armazenar as pontuações de cada procedimento;
	private int[] pontuacaoPorProcedimento = new int[15];

	//definindo a cor azulada do algodao ao ser arrastado para o alcool;
	//também utilizado no segundo estágio

	public GameObject garroteAzul;
	public GameObject garroteVerde;
	public Image SpriteGarroteAzul;
	public Image SpriteGarroteVerde;
	public GameObject seringa;
	public GameObject bandeide;
	public GameObject algodao;
	private Color32 algodaoAzul = new Color32 (0, 236, 181, 255);

	public Image SeringaComum;
	public Sprite SeringaComRemedio;

	//referência pra acessar o script dialogos_3 (Script oficial de controle dos dialogos);
	public dialogos_1b ReferenciaDialogos;

	//revisar utilidade
	public Animator animacao;

	public GameObject PainelDePontuacao;

	// Use this for initialization
	void Start () {
		garroteAzul.SetActive(false);
		garroteVerde.SetActive(false);
		bandeide.SetActive(false);
		seringa.SetActive(false);
	}

	void Update(){
		try {
//			Debug.Log(PontuacaoTotal);
			PainelDePontuacao.GetComponentInChildren<Text> ().text = ("Pontuação " + GameObject.Find("dropurso").GetComponent<dropper_Estagio2>().PontuacaoTotal);
		} catch (System.Exception ex) {}
	}

	 void OnMouseEnter() {
		Debug.Log("Entrou com o mouse");
	}

	public void OnDrop(PointerEventData eventData){
		/*Existirão 3 drops neste estágio. 
			*Paciente
			*álcool
			*frasco de medicamento
		*/

			/******************REGIÃO DO URSO******************************/
		if(gameObject.name == "dropurso"){

			// RETORNO DE ERRO PARA PROCEDIMENTO DIFERENTE DE INDEX;
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index != procedimentoAtual) {
				ReduzPontuacao(eventData.pointerDrag, procedimentoAtual);
			}

			//O ALGODAO SECO NUNCA É UTILIZADO NO PERSONAGEM
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 1 && procedimentoAtual == 1) {
				ReduzPontuacao(eventData.pointerDrag, procedimentoAtual);
			}
				
			//Aplicando o garrote!
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 0 && procedimentoAtual == 0) {
				if(eventData.pointerDrag.GetComponent<draghandeler> ().name == "Sprite garrote verde"){
					garroteVerde.SetActive(true);
					SpriteGarroteVerde.enabled=false;
				}else if (eventData.pointerDrag.GetComponent<draghandeler> ().name == "Sprite garrote azul"){
					garroteAzul.SetActive(true);
					SpriteGarroteAzul.enabled = false;
				}
				procedimentoAtual++;
				RetornaPontuacaoPorEtapa ();
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
			}


			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 2 && procedimentoAtual == 2) {
				Debug.Log("Algodão com alcool arrastado para o urso");
				procedimentoAtual++;
				RetornaPontuacaoPorEtapa ();
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
			}

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 4 && procedimentoAtual == 4){
				Debug.Log("Seringa com remedio arrastado para o urso");
				procedimentoAtual++;
				seringa.SetActive(true);
				seringa.GetComponent<BoxCollider>().enabled = false;
				RetornaPontuacaoPorEtapa ();
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
			}

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 7 && procedimentoAtual == 7) {
				Debug.Log("Curativo arrastado para o urso");
				procedimentoAtual++;
				ReferenciaDialogos.botaoDePlacar.SetActive(true);
				bandeide.SetActive(true);
				RetornaPontuacaoPorEtapa ();
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
			}
		}
			/******************REGIÃO DO ALCOOL******************************/
		if(gameObject.name == "dropalcool"){
			//seguir modelo utilizado no drop urso;
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index != GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().procedimentoAtual) {
				Debug.Log("Etapa de procedimento errado!");
				GameObject.Find("dropurso").GetComponent<dropper_Estagio2>().ReduzPontuacao(eventData.pointerDrag, procedimentoAtual);
			}

			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 1 && GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().procedimentoAtual == 1){
				Debug.Log("Algodão arrastado para o alcool");
				algodao.GetComponent<Image> ().color = algodaoAzul;
				GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().procedimentoAtual++;
				GameObject.Find("algodao").GetComponent<draghandeler>().index = 2;
				GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().RetornaPontuacaoPorEtapa ();
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();
			}
			
		}

		/******************REGIÃO DO REMEDIO******************************/
		if(gameObject.name == "dropremedio"){
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index != GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().procedimentoAtual) {
				Debug.Log("Etapa de procedimento errado!");
				GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().ReduzPontuacao(eventData.pointerDrag, procedimentoAtual);
			}					
			if (eventData.pointerDrag.GetComponent<draghandeler> ().index == 3 && GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().procedimentoAtual == 3){
				Debug.Log("Seringa arrastada para o remedio");
				GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().procedimentoAtual++;
				GameObject.Find("seringa").GetComponent<draghandeler>().index = 4;
				SeringaComum.GetComponent<Image>().sprite = SeringaComRemedio;
				animacao.SetTrigger("zoom_in");
				GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().RetornaPontuacaoPorEtapa ();
				ReferenciaDialogos.ReferenciaParaPularDeDialogo();

			}
		}

	}
	
	public void ReduzPontuacao(GameObject elemento, int procedimentoAtual){

		Debug.Log(elemento.name + " Não é utilizado neste momento! Tente novamente o procedimento "+procedimentoAtual);

		if(GameObject.Find("dropurso").GetComponent<dropper_Estagio2>().errosPorProcedimento[GameObject.Find("dropurso").GetComponent<dropper_Estagio2>().procedimentoAtual] != 3){
			GameObject.Find ("dropurso").GetComponent<dropper_Estagio2> ().errosPorProcedimento[GameObject.Find("dropurso").GetComponent<dropper_Estagio2>().procedimentoAtual]++;
		}
		Debug.Log (this.gameObject);
		StartCoroutine(ReferenciaDialogos.JanelaDeErro(ReferenciaDialogos.dialogosDeErro));
	}

	public void RetornaPontuacaoPorEtapa (){
		pontuacaoPorProcedimento [procedimentoAtual - 1] = pontuacaoMaxima - (errosPorProcedimento [procedimentoAtual - 1] * 10);
		PontuacaoTotal += pontuacaoPorProcedimento [procedimentoAtual - 1];
	}
}