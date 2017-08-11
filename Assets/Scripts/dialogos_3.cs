using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dialogos_3 : MonoBehaviour {

	/*REGIÃO DE DECLARAÇÃO DE FATORES DO PLACAR FINAL*/

	public GameObject dropurso;
	public placarFinal ReferenciaDoPlacar;
	public GameObject botaoDePlacar;
	public GameObject placar;
	public GameObject painelDragDrop;
	public GameObject painelDeDialogos;
	public GameObject PauseMenu;

    private bool InicializaCaricatura = false;
	/***********************************************************************/
	/*REGIÃO DE DECLARAÇÃO DOS OBJETOS DA PUNÇÃO (USADO PARA DESATIVAR O COLISOR NA JANELA 5)*/

	public GameObject seringaAplicadaNoUrso;
	public GameObject garroteAplicadoNoUrso;

	/***********************************************************************/
	//public GameObject botaoDeOk; //implementação do botão a ser apertado na janela de erro e dialogos iniciais;

	public GameObject canvasDragDrop;

	public GameObject BotaoRetorno;

	public GameObject dialogosDoInicio; //armazenar os dialogos para serem desativados futuramente

	//vetor que contém os diálogos do início;
	public GameObject[] dialogosIniciais = new GameObject[5];
	private int contadorDeJanelasIniciais = 0;

	//janela responsável por conter todos os diálogos (Os diálogos são objetos filhos dentro desta janela);
	//exclui os diálogos de erro
	public GameObject todosDialogosDeProcedimento;

	//vetor que contém os dialogos de procedimento;
	public GameObject[] dialogosDeProcedimento = new GameObject[8];
	private int contadorDeProcedimento;
	
	//janela responsável por conter todos os diálogos de erro (Dialogos de erro são objetos filhos dentro desta janela);
	public GameObject janelasDeErro;

	//vetor que contém os diálogos de erro;
	public GameObject[] dialogosDeErro = new GameObject[4];
	private int contadorDeErro = 0;

	//Referência par ao desativamento do Drag Handeler dos objetos arrastáveis
	public GameObject[] ObjetosArrastaveis = new GameObject[5];

	//referencia de conversa utilizada para ser resgatada futuramente
	//Quando ocorre uma substituição de dialogo de procedimento por diálogo de erro é salva uma referência para ser resgatada
	//quando a janela de erro for fechada;
	private GameObject referencia; 

	//referencia ao script que contém todas as caricaturas;
	public caricaturas ReferenciaDaCaricatura;

	//caricatura do personagem utilizada (Importada do script acima);
	public Image Carica;

	public Animator animacao;

	//AUDIOS
	public AudioClip Acertou;
	public AudioClip Errou;

    void Awake(){
        //inicia dizendo qual caricatura deve ser utilizada;
        Carica.sprite = ReferenciaDaCaricatura.CaricaturaSelecionada[0];
    }

	void Start () {

		dropurso.SetActive(false);

		BotaoRetorno.SetActive(false);
		//implementar o pause em todo o contexto do jogo;
        
		//começa com os primeiros dialogos de janela inicial;
		PrimeirosDialogos(contadorDeJanelasIniciais);
		
		//como não utilizaremos o drag and drop no inicio do procedimento não tem nescessidade de manter ele ativo;
		canvasDragDrop.SetActive(false);
	}

	void Update(){
        //Ordem de carregamento não está sendo executada no Start ou Awake (Explicação deste trecho em Update);
        if (!InicializaCaricatura) { 
            Carica.sprite = ReferenciaDaCaricatura.CaricaturaSelecionada[0];
            InicializaCaricatura = true;
        }

        //se estiver no procedimento 4 (procedimento de aplicação da seringa), o drag drop vai desaparecer para substituir por uma mensagem curta; (Não doeu nada!)
        //quando o contador estiver no 4, habilitará a janela 5 (Contador de procedimento começa no 0 e vai até 8; Contador de janela vai de 1 até 9);

        if (contadorDeProcedimento == dialogosDeProcedimento.Length-1) {
			botaoDePlacar.SetActive (true);
		}
		if(contadorDeJanelasIniciais == 0){
			BotaoRetorno.SetActive(false);
		}
		else if(contadorDeJanelasIniciais != 0){
			BotaoRetorno.SetActive(true);
		}
	}


	/*ÁREA RESPONSÁVEL POR FAZER FUNCIONAR OS DIÁLOGOS INICIAIS*/

	public void PrimeirosDialogos(int contadorLocal){
		dialogosIniciais[contadorLocal].SetActive(true);
	}

	public void BotaoDePular(){

		if(contadorDeJanelasIniciais == 4){
			dialogosDoInicio.SetActive(false);
			canvasDragDrop.SetActive(true);
			dropurso.SetActive(true);
			abreConversa(contadorDeProcedimento);


		}else{
			dialogosIniciais[contadorDeJanelasIniciais].SetActive(false);
			contadorDeJanelasIniciais++;
			PrimeirosDialogos(contadorDeJanelasIniciais);
		}
	}

	public void BotaoDeRetornar(){

		dialogosIniciais[contadorDeJanelasIniciais].SetActive(false);
		contadorDeJanelasIniciais--;
		PrimeirosDialogos(contadorDeJanelasIniciais);

	}

	/*ÁREA RESPONSÁVEL POR FAZER FUNCIONAR OS DIÁLOGOS DE PROCEDIMENTO*/

	public void abreConversa(int contadorLocal){
		dialogosDeProcedimento[contadorLocal].SetActive(true);
	}

	public void ReferenciaParaPularDeDialogo(){
		if(contadorDeProcedimento == 8){
			Debug.Log ("nada não");
		}else{
			GetComponent<AudioSource> ().PlayOneShot (Acertou);
			dialogosDeProcedimento[contadorDeProcedimento].SetActive(false);
			contadorDeProcedimento++;
			abreConversa(contadorDeProcedimento);
			//AQUI
		}
	}

	public void JanelaDeConversa(GameObject dialogo){
		dialogo.SetActive(true);
		referencia = dialogo;
	}

	public IEnumerator JanelaDeErro(GameObject[] dialogoDeErro){
		Carica.sprite = ReferenciaDaCaricatura.CaricaturaSelecionada[1]; // caricatura 1 corresponde a caricatura de erro
		GetComponent<AudioSource> ().PlayOneShot (Errou);
		yield return new WaitForSeconds(1/2);
		todosDialogosDeProcedimento.SetActive(false);
		canvasDragDrop.SetActive(false);
		janelasDeErro.SetActive(true);
		dialogoDeErro[contadorDeErro].SetActive(true);
		referencia = dialogoDeErro[contadorDeErro];
		contadorDeErro++;
		if (contadorDeErro == 4){
			contadorDeErro = 0;
		}
	}

	public void fechaJanelaDeErro(){
		Carica.sprite = ReferenciaDaCaricatura.CaricaturaSelecionada[0]; // caricatura 0 corresponde a caricatura padrão
		referencia.SetActive(false);
		janelasDeErro.SetActive(false);
		todosDialogosDeProcedimento.SetActive(true);
		canvasDragDrop.SetActive(true);
	}

	/*Sessão responsável pelo placar*/

	public void abrePlacarFinal(){
		StartCoroutine(mostraMenu());
	}

	public IEnumerator mostraMenu(){
		yield return new WaitForSeconds(1);
		placar.SetActive(true);
		painelDragDrop.SetActive(false);
		painelDeDialogos.SetActive(false);
		PauseMenu.SetActive(false);
		ReferenciaDoPlacar.EscrevePontuacao();
	}

	/*FIM DA SESSÃO*/
}

/*
	NOVA SEQUENCIA 
	0 - Aplica garrote;
	1 - aplica Algodao No Alcool;
	2 - aplica Algodao com alcool No Urso;
	3 - aplica Seringa;
	4 - dialogo Pos Seringa;
	5 - remove garrote;
	6 - remove seringa;
	7 - aplica bandeide;

	*/