using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInventory : FillInventory<BerufInventoryDisplay> {

	const string UNNAMED = "<unbenannt>";

	public override void Start () {
		panelName= "CharacterPanel";
	}

	// Use this for initialization
	void OnEnable () {
		FillPanel();
	}

	/// <summary>
	/// Fills the panel fachkenntnisse. 
	/// </summary>
	public override void FillPanel()
	{
		MidgardCharacterSaveLoad.Load ();
		List<MidgardCharakter> midgardCharaktere = MidgardCharacterSaveLoad.savedCharacters;
		List<InventoryItem> _listItems;
		_listItems = CreateListeItems (midgardCharaktere);

		//Prepare listItems 
		ConfigurePrefab (_listItems);
	}

	/// <summary>
	/// Creates the liste items.
	/// </summary>
	/// <returns>The liste items.</returns>
	/// <param name="midgardCharaktere">Midgard charaktere.</param>
	private List<InventoryItem> CreateListeItems (List<MidgardCharakter> midgardCharaktere)
	{
		List<InventoryItem> listItems = new List<InventoryItem>();
		foreach (var charakter in midgardCharaktere) {
			InventoryItem newItem = CreateInventoryItem (charakter.CharacterName);
			listItems.Add (newItem);
		}

		return listItems;
	}


	/// <summary>
	/// Creates the inventory item from the string for a name (charactername)
	/// </summary>
	/// <returns>The inventory item.</returns>
	/// <param name="name">Name.</param>
	private InventoryItem CreateInventoryItem(string name){

		if (name == null || name.Length == 0) {
			name = UNNAMED;
		}

		InventoryItem newItem = new InventoryItem ();
		newItem.name = name;
		return newItem;
		
	}
}
