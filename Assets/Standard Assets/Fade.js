#pragma strict

public var fadeOutTexture : Texture2D;
public var fadeSpeed : float = 0.8f;

private var drawDepth : int = -1000;
private var alpha : float = 1.0f;
private var fadeDir : int = -1;

function OnGUI(){
	alpha += fadeDir * fadeSpeed * Time.deltaTime;
	alpha = Mathf.Clamp01(alpha);
	
	GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
	GUI.depth = drawDepth;
	GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture );
}

public function BeginFade (direction){
	fadeDir = direction;
	return (fadeSpeed);
}

public function OnLevelWasLoaded (){
	//alpha = 1				//use this if the alpha is not set to 1 by default;
	BeginFade (-1);
}