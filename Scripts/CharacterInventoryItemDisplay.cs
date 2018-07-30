using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CharacterInventoryItemDisplay : MonoBehaviour {

	public Text nameItem; 
	public CharacterInventoryItem item;


	public delegate void CharacterInventoryItemDisplayDelegate(CharacterInventoryItemDisplay item);
	public static event CharacterInventoryItemDisplayDelegate  onClick;

	// Use this for initialization
	void Start () {

	}

	public void SetDisplayValuesName(CharacterInventoryItem _item)
	{
		nameItem.text = _item.name;
		item = _item;
	}

	public void Click()
	{
		if (onClick != null && item!=null) {
			onClick.Invoke (this);
		} 	
		Debug.Log("I Character " + nameItem.text + " was clicked");
	}
}
