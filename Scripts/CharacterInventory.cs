using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInventory : FillInventoryBase {

	public CharacterInventoryDisplay inventoryDisplayPrefab;
	const string UNNAMED = "<unbenannt>";

	public void Start () {
		panelName= "CharacterPanel";
	}

	// Use this for initialization
	void OnEnable () {
		FillPanel();
	}

	/// <summary>
	/// Transformiert Character und füllt das Panel
	/// </summary>
	public void FillPanel()
	{
		MidgardCharacterSaveLoad.Load ();
		List<MidgardCharakter> midgardCharaktere = MidgardCharacterSaveLoad.midgardSavings.savedCharacters;
		List<CharacterInventoryItem> _listItems;
		_listItems = CreateListeItems (midgardCharaktere);

		//Prepare listItems und fülle
		ConfigurePrefab (_listItems);
	}

	/// <summary>
	/// Takes list and creates and fills display
	/// </summary>
	/// <param name="listItems">List items.</param>
	protected void ConfigurePrefab(List<CharacterInventoryItem> listItems){

		CharacterInventoryDisplay _inventoryDisplayPrefab=null;
		_inventoryDisplayPrefab = Instantiate (inventoryDisplayPrefab) as CharacterInventoryDisplay;
		_inventoryDisplayPrefab.name = panelName;
		_inventoryDisplayPrefab.transform.SetParent (displayParent, false);
		_inventoryDisplayPrefab.FillItemDisplay (listItems);
	}

	/// <summary>
	/// Creates the liste items.
	/// </summary>
	/// <returns>The liste items.</returns>
	/// <param name="midgardCharaktere">Midgard charaktere.</param>
	private List<CharacterInventoryItem> CreateListeItems (List<MidgardCharakter> midgardCharaktere)
	{
		List<CharacterInventoryItem> listItems = new List<CharacterInventoryItem>();
		foreach (var charakter in midgardCharaktere) {
			CharacterInventoryItem newItem = CreateInventoryItem (charakter);
			listItems.Add (newItem);
		}

		return listItems;
	}


	/// <summary>
	/// Creates the inventory item from the string for a name (charactername)
	/// </summary>
	/// <returns>The inventory item.</returns>
	/// <param name="name">Name.</param>
	private CharacterInventoryItem CreateInventoryItem(MidgardCharakter charakter){
		string name = charakter.CharacterName;
		if (name == null || name.Length == 0) {
			name = UNNAMED;
		}

		CharacterInventoryItem newItem = new CharacterInventoryItem ();
		newItem.name = name;
		newItem.mCharacter = charakter;
		return newItem;
	}
}
