#pragma strict
 
 var soundhover : AudioClip;
 var beep : AudioClip;
 var QuitButton : boolean = false;
 public var camera1 : Camera;
 var LetreiroDeSelecaoDePersonagem : GameObject;
 var quadro : GameObject;

function Start(){
	LetreiroDeSelecaoDePersonagem.SetActive(false);
}

 function Update(){
 	if(Input.GetKey ("escape")){
 		Application.Quit();
 	}
 }
 
 function OnMouseEnter(){
     GetComponent.<AudioSource>().PlayOneShot(soundhover);
 }
 
 function OnMouseUp(){
     GetComponent.<AudioSource>().PlayOneShot(beep);
     yield new WaitForSeconds(0.35);
     if(QuitButton){
         Application.Quit();
     }
     if (!QuitButton){
     	camera1.GetComponent.<Animator>().SetBool("iniciou", true);
     	LetreiroDeSelecaoDePersonagem.SetActive(true);
          quadro.SetActive(false);
     }
 }
 
 
 @script RequireComponent(AudioSource)