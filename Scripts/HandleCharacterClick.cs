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
	public GameObject characterControler;
	public GameObject fertigkeitenScroller;
	public GameObject waffenScroller;
	public GameObject zauberScroller;

	// Use this for initialization
	void Start ()
	{
		sheetManager = characterControler.GetComponent<FillCharacterSheet> ();
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
		sheetManager.mCharacter = characterDisplay.item.mCharacter;
		Toolbox globalVars = Toolbox.Instance;
		globalVars.mCharacter = sheetManager.mCharacter;
		sheetManager.SetCharacterValues ();
		sheetFertigkeiten.FillPanel ();
		sheetWaffen.FillPanel ();
		sheetZauber.FillPanel ();

	}


}
