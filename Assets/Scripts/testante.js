#pragma strict

     var objeto : Transform;
     var grabDistance : float = 10.0f;
     var grabLayerMask : int;
     var grabOffset : Vector3; //delta between transform transform position and hit point
     var useToggleDrag : boolean; // Didn't know which style you prefer. 
     
     function Update () {
         if (useToggleDrag){
             UpdateToggleDrag();
         } else {
             UpdateHoldDrag();
         }
     }
     
     // Toggles drag with mouse click
     function UpdateToggleDrag () {
         if (Input.GetMouseButtonDown(0)){ 
             Grab();
         } else {
             if (objeto) {
                 Drag();
             }
         }
     }
     // Drags when user holds down button
     function UpdateHoldDrag () {
         if (Input.GetMouseButton(0)) {
             if (objeto){
                 Drag();
             } else { 
                 Grab();
             }
         } else {
             if(objeto){
                 //restore the original layermask
                 objeto.gameObject.layer = grabLayerMask;
             }
             objeto = null;
         }
     }
     
     function Grab() {
         if (objeto){ 
            objeto = null;
         } else {
             var hit : RaycastHit;
             var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, hit)){          
                 objeto = hit.transform;
                 if(objeto.parent){
                     objeto = objeto.parent.transform;
                 }
                 //set the object to ignore raycasts
                 grabLayerMask = objeto.gameObject.layer;
                 objeto.gameObject.layer = 2;
                 //now immediately do another raycast to calculate the offset
                 if (Physics.Raycast(ray, hit)){
                     grabOffset = objeto.position - hit.point;
                 } else {
                     //important - clear the gab if there is nothing
                     //behind the object to drag against
                     objeto = null;
                 }
             }
         }
     }
     function Drag() {    
         var hit : RaycastHit;
         var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, hit)){      
             objeto.position = hit.point + grabOffset;
             //grabOffset.x = 0;
         }
     
     }