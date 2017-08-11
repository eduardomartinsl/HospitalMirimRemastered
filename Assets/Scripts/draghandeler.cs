using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class draghandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject ItemBeingDragged;
	Vector3 startPosition;
	public GameObject mainCamera;
	public int index;

	void Start(){
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		ItemBeingDragged = gameObject;
		startPosition = transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	#endregion
	
	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		ItemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		transform.position = startPosition;
	#endregion

	}

	public void OnMouseEnter(){
		Debug.Log("funcionando");
	}
}