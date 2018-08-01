using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class CharacterButtonColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private Text theText;


	void Start(){
		theText = GetComponent<Text> ();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		theText.color = Color.cyan; //Or however you do your color
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = Color.white; //Or however you do your color
	}


}