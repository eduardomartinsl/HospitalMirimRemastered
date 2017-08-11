using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Rigidbody rb;
	private Image bgImg, joystickImg;
	private Vector3 inputVector;
	public float velocidade;
	public GameObject jogador;

	private void Start()
	{
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
		rb = jogador.GetComponent<Rigidbody> ();
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
	   	{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3(pos.x*2 -1,0,pos.y*2 - 1);
			inputVector = (inputVector.magnitude > 1.0f)?inputVector.normalized:inputVector;

			Debug.Log(inputVector);

			joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x/3), inputVector.z * (bgImg.rectTransform.sizeDelta.y/3));
		}
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public void Move()
	{
		if (inputVector.x > 0.5 ) 
		{
			jogador.transform.Rotate (0, Time.deltaTime * 100.0f, 0);
		} 
		else 
		{
			if (inputVector.x < 0) 
			{
				jogador.transform.Rotate (0, Time.deltaTime * -100.0f, 0);
			}
		}

		if (inputVector.z > 0) 
		{
			jogador.transform.position += transform.forward * Time.deltaTime * velocidade;
		}
		else
		{
			if(inputVector.z < 0)
			{
				rb.position += transform.forward * -1.0f * Time.deltaTime * velocidade;
			}	
		}
	}

	public void Rotate()
	{
		if (inputVector.x > 0) 
		{
			jogador.transform.Rotate (0, Time.deltaTime * 100.0f, 0);
		} 
		else 
		{
			if (inputVector.x < 0) 
			{
				jogador.transform.Rotate (0, Time.deltaTime * -100.0f, 0);
			}
		}
	}

	void FixedUpdate(){
		Move ();
		Rotate ();
	}

}
