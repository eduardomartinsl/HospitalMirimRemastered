 #pragma strict
 
 public class MusicSingleton extends MonoBehaviour
 {
     public static var instance : MusicSingleton;
     
     public var musicMainMenu : AudioClip;
     public var musicLevel1 : AudioClip;
     public var ReferenciaEscolhas : escolhas;
    
    public static function GetInstance() : MusicSingleton{
         return instance;
     }

     function Awake() 
     {
         if ( instance != null && instance != this ) 
         {
             Destroy( this.gameObject );
             return;
         } 
         else 
        {
             instance = this;
             OnLevelWasLoaded(0);

         }
         
         DontDestroyOnLoad( this.gameObject );
     }
     
     function OnLevelWasLoaded( level : int ){

        if (level == 0){
    		GetComponent.<AudioSource>().clip = musicMainMenu;
        	GetComponent.<AudioSource>().Play();
        }

        if(level == 1){
        	if(GetComponent.<AudioSource>().clip == musicLevel1){
        		GetComponent.<AudioSource>().Stop();
             	GetComponent.<AudioSource>().clip = musicMainMenu;
             	GetComponent.<AudioSource>().Play();
        	}
        }

        if ( level == 2 || level == 3 || level == 4 || level == 5 || level == 6 || level == 7){
             GetComponent.<AudioSource>().Stop();
             GetComponent.<AudioSource>().clip = musicLevel1;
             GetComponent.<AudioSource>().Play();
         }
    }
 }