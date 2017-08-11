using UnityEngine;
using System.Collections;

public class dialogos : MonoBehaviour {

	//declaração dos objetos com as falas dos médicos
	// Use this for initialization

	public GameObject botaoOK;

	//as duas falas do início do procedimento
	public GameObject dialogoInicial;
	public GameObject dialogoAplicaGarrote;

	//telas de dialogos
	public GameObject dialogoAplicaAlcoolNoAlgodao;
	public GameObject dialogoAplicaAlgodaoComAlcool;
	public GameObject dialogoAplicaSeringa;
	public GameObject dialogoAplicaBandeide;
	public GameObject dialogoRemoveGarrote;

	//seção de janelas de erros
	public GameObject[] dialogosDeErros = new GameObject[4];

	//contador responsável por mostrar as imagens de erro diferentes;
	public int contador;

	//janela responsável por conter todas as janelas de diálogos
	public GameObject  janelaDeDialogo;

	//vetor de objetos arrastáveis para o procedimento de punção (para evitar que os objetos sejam arrastados no momento de diálogo da punção)
	//um slot para cada objeto (Garrote, ceringa, alcool, algodão e bandeide)
	public GameObject[] ObjetosArrastaveis = new GameObject[5];

	public GameObject referencia;
	public GameObject referenciaAntiga;

	private bool confereDialogoInicial = false;
	private bool errado = false;


	void Start () {
		//de inicio a janela deve mostrar as duas falas de procedimento padrão
		//preenchendo o vetor com os elementos do dragdrop
		ObjetosArrastaveis = GameObject.FindGameObjectsWithTag("ELEMENTOSDRAG");
		StartCoroutine(abreJanela(dialogoInicial, janelaDeDialogo));
		//botaoOK.SetActive(true);
	}

	public void Update(){
		if(confereDialogoInicial){
			StartCoroutine(abreJanela(dialogoAplicaGarrote, janelaDeDialogo));
			confereDialogoInicial = false;
		}
		if(errado){
			botaoOK.SetActive(true);
		}
	}

	public IEnumerator abreJanela(GameObject dialogo, GameObject janela){
		referenciaAntiga.SetActive(false);
		janela.SetActive(true);
		dialogo.SetActive(true);
		yield return new WaitForSeconds(1/2);
		//for (int i = 0; i <ObjetosArrastaveis.Length; i++){
		//	ObjetosArrastaveis[i].GetComponent<draghandeler>().enabled = false;
		//}
	}

	public IEnumerator abreJanelaDeErro(GameObject[] dialogoDeErro){
		errado = true;
		janelaDeDialogo.SetActive(true);
		dialogoDeErro[contador].SetActive(true);
		referencia = dialogoDeErro[contador];
		yield return new WaitForSeconds(1/2);
		for (int i = 0; i <ObjetosArrastaveis.Length; i++){
			ObjetosArrastaveis[i].GetComponent<draghandeler>().enabled = false;
		}
		contador++;
		if (contador == 4){
			contador = 0;
		}
	}

	public void FechaConversa(GameObject dialogo){
		referenciaAntiga = dialogo;
		referencia.SetActive(false);
		botaoOK.SetActive(false);
		if(referencia.name == "dialogo inicial"){
			confereDialogoInicial = true;
		}
		for (int i = 0; i <ObjetosArrastaveis.Length; i++){
			ObjetosArrastaveis[i].GetComponent<draghandeler>().enabled = true;
		}
	}
}
