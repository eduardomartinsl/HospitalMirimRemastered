using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class desativaItens : MonoBehaviour {
	
	public GameObject dropurso;
	public GameObject Seringa;
	public GameObject garrote;
	public GameObject spriteGarrote;

	public Animator animacao;

	public void OnMouseDown(){

		if (dropurso.GetComponent<dropper> ().procedimentoAtual == 4) {
			spriteGarrote.GetComponent<Image>().enabled = true;
			garrote.GetComponent<SkinnedMeshRenderer> ().enabled = false;
			dropurso.GetComponent<dropper> ().procedimentoAtual = 5;
			dropurso.GetComponent<dropper> ().RetornaPontuacaoPorEtapa ();
			dropurso.GetComponent<dropper> ().ReferenciaDialogos.ReferenciaParaPularDeDialogo();
			animacao.SetTrigger("zoom_out");

		} else if (dropurso.GetComponent<dropper> ().procedimentoAtual == 5) {
			
			Seringa.SetActive (false);
			dropurso.GetComponent<dropper> ().procedimentoAtual = 6;
			dropurso.GetComponent<dropper> ().RetornaPontuacaoPorEtapa ();
			dropurso.GetComponent<dropper> ().ReferenciaDialogos.ReferenciaParaPularDeDialogo();
		
		}
	}
}