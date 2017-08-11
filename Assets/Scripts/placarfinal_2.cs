using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class placarfinal_2 : MonoBehaviour {

	public GameObject janelaDePlacar;				//janela que contém todos os elementos 

	public GameObject botaoTentarDeNovo;			//botão de tentar de novo
	public GameObject botaoVoltarParaOQuarto;		//botão de retornar para o quarto

	public Text pontuacao;							//variável que retornará o texto da caixa de placar

	public dropper_Estagio2 ReferenciaDaPontuacao;

	public FadeSharp AplicadorDeFade;

	public AudioClip Comemoracao;
	
	public void BotaoDeReferencia(int valor){
		StartCoroutine (AplicaFade (valor));
		//se o valor for 1, retorna para o quarto
		//se o valor for 2, reinicia o procedimento
	}
	public void EscrevePontuacao(){
		GetComponent<AudioSource> ().PlayOneShot (Comemoracao);
		if(ReferenciaDaPontuacao.PontuacaoTotal >= 250){
			pontuacao.text = ("Parabéns! Você fez "+ReferenciaDaPontuacao.PontuacaoTotal+" pontos! Agora é sua vez de receber o medicamento. \nVamos fazer igual ao nosso paciente?");
		}else if(ReferenciaDaPontuacao.PontuacaoTotal < 250 && ReferenciaDaPontuacao.PontuacaoTotal > 130){
			pontuacao.text = ("Muito bem! Você fez "+ReferenciaDaPontuacao.PontuacaoTotal+" pontos. Vamos tentar mais uma vez?");
		}else if(ReferenciaDaPontuacao.PontuacaoTotal < 130){
			pontuacao.text = ("Não foi dessa vez. Você fez "+ReferenciaDaPontuacao.PontuacaoTotal+" pontos. Que tal tentar de novo?");
		}
	}

	public IEnumerator AplicaFade(int estagioCarregado){
		float fadeTime = AplicadorDeFade.BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(estagioCarregado);
//		Application.LoadLevel(estagioCarregado);
	}
}
