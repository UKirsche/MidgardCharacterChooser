using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CharacterInventoryDisplay : MonoBehaviour {

	public CharacterInventoryItemDisplay characterDisplayPrefab;

	public Transform displayPanel;
	public Text heading;

	/// <summary>
	/// Sets the heading for the inventory items
	/// </summary>
	/// <param name="titel">Titel.</param>
	public void SetHeading(string titel)
	{
		heading.text = titel;
	}


	/// <summary>
	/// Fills the item display: loads inventory items in panel
	/// </summary>
	/// <param name="items">Items.</param>
	public void FillItemDisplay(List<CharacterInventoryItem> items)
	{
		foreach (CharacterInventoryItem item in items) {
			if (item != null) {
				CharacterInventoryItemDisplay itemToDisplay = (CharacterInventoryItemDisplay)Instantiate (characterDisplayPrefab);
				itemToDisplay.transform.SetParent (displayPanel, false);
				itemToDisplay.SetDisplayValuesName (item);
			}
		}
	}
}
