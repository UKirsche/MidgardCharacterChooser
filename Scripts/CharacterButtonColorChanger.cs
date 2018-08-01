using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class CharacterButtonColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private const string CHARACTERITEMTAG = "characteritem";
	private Text theText;


	void Start(){
		theText = GetComponent<Text> ();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		theText.color = new Color(0.41f, 0.72f, 1.63f); //Or however you do your color
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = Color.white; //Or however you do your color
	}

	public void ButtonClick(){
		ResetButtonClickColors ();
		ChangeClickedColor ();
	}

	private void ResetButtonClickColors(){
		GameObject[] buttons = GameObject.FindGameObjectsWithTag (CHARACTERITEMTAG);

		foreach (var button in buttons) {
			Image buttonImage = button.GetComponent<Image> ();
			buttonImage.color = new Color (0.1f, 0.1f, 0.13f, 0.45f);
		}
	}

	void ChangeClickedColor ()
	{
		Image bgImage = transform.parent.gameObject.GetComponent<Image> ();
		bgImage.color = new Color (0.1f, 0.1f, 0.13f, 0.64f);
	}
}