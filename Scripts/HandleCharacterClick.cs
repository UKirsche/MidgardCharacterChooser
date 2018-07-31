using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HandleCharacterClick : MonoBehaviour
{
	private FillCharacterSheet sheetManager;
	private SheetFillFertigkeitenInventory sheetFertigkeiten;
	private SheetFillWaffenInventory sheetWaffen;
	private SheetFillZauberInventory sheetZauber;
	public GameObject characterController;
	public GameObject fertigkeitenScroller;
	public GameObject waffenScroller;
	public GameObject zauberScroller;

	const string TAGFORSCROLLITEM = "scrollitem";

	// Use this for initialization
	void Start ()
	{
		sheetManager = characterController.GetComponent<FillCharacterSheet> ();
		sheetFertigkeiten = fertigkeitenScroller.GetComponent<SheetFillFertigkeitenInventory> ();
		sheetWaffen = waffenScroller.GetComponent<SheetFillWaffenInventory> ();
		sheetZauber = zauberScroller.GetComponent<SheetFillZauberInventory> ();
	}

	void OnEnable(){
		CharacterInventoryItemDisplay.onClick +=	HandleOnItemClick;
	}

	void OnDisable(){
		CharacterInventoryItemDisplay.onClick -= HandleOnItemClick;
	}

	void OnDestroy ()
	{
		CharacterInventoryItemDisplay.onClick -= HandleOnItemClick;
	}

	/// <summary>
	/// Handles the on item click. Lädt den Charakter in die UI und in die Toolbox
	/// </summary>
	/// <param name="itemDisplay">Item display.</param>
	public void HandleOnItemClick (CharacterInventoryItemDisplay characterDisplay)
	{
		FillBasicCharacterValues (characterDisplay);
		FillFertigkeitenScrollBoxes ();

	}

	/// <summary>
	/// Füllt die linke Seite des Charakterblattes aus (Deskriptiv, Basiseigenschaften, Aggeleitete...)
	/// </summary>
	/// <param name="characterDisplay">Character display.</param>
	private void FillBasicCharacterValues (CharacterInventoryItemDisplay characterDisplay)
	{
		sheetManager.mCharacter = characterDisplay.item.mCharacter;
		sheetManager.FillCharacter ();
	}


	/// <summary>
	/// Füllt die Fertigkeitenscrollboxen auf: Normale-, Waffen-, Zauberfertigkeiten.
	/// Für die entsprechenden Methoden wird noch eine Toolbox-Variable gesetzt (Singleton)
	/// </summary>
	private void FillFertigkeitenScrollBoxes ()
	{
		Toolbox globalVars = Toolbox.Instance;
		globalVars.mCharacter = sheetManager.mCharacter;


		GameObject[] gameObjects=GameObject.FindGameObjectsWithTag (TAGFORSCROLLITEM);
		foreach (var gameObject in gameObjects) {
			Destroy (gameObject);
		}

		sheetFertigkeiten.FillPanel ();
		sheetWaffen.FillPanel ();
		sheetZauber.FillPanel ();
	}
}
