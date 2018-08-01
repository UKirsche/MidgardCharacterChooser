using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HandleCharacterClick : MonoBehaviour
{
	const string GONAMESCROLLFILLER = "SwitchSerializeCharacter";
	private FillCharacterSheet sheetManager;
	private HandleScrollBoxes scrollBoxFiller;
	public GameObject characterController;

	// Use this for initialization
	void Start ()
	{
		sheetManager = characterController.GetComponent<FillCharacterSheet> ();
		GameObject switchSerializer = GameObject.Find (GONAMESCROLLFILLER);
		scrollBoxFiller = switchSerializer.gameObject.GetComponent<HandleScrollBoxes> ();
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
		SetToolboxCharacter ();
		sheetManager.FillCharacter ();
	}


	/// <summary>
	/// Füllt die Fertigkeitenscrollboxen auf: Normale-, Waffen-, Zauberfertigkeiten.
	/// Für die entsprechenden Methoden wird noch eine Toolbox-Variable gesetzt (Singleton)
	/// </summary>
	private void FillFertigkeitenScrollBoxes ()
	{
		scrollBoxFiller.FillFertigkeiten ();
	}

	/// <summary>
	/// Speichert den Character in der Singleton-Toolbox
	/// </summary>
	private void SetToolboxCharacter ()
	{
		Toolbox globalVars = Toolbox.Instance;
		globalVars.mCharacter = sheetManager.mCharacter;
	}
}
