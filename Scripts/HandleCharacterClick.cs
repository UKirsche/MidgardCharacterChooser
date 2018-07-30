using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HandleCharacterClick : MonoBehaviour
{
	private FillCharacterSheet sheetManager;
	public GameObject characterControler;

	// Use this for initialization
	void Start ()
	{
		sheetManager = characterControler.GetComponent<FillCharacterSheet> ();
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
	/// Handles the on item click. Lädt den Charakter in die UI
	/// </summary>
	/// <param name="itemDisplay">Item display.</param>
	public void HandleOnItemClick (CharacterInventoryItemDisplay characterDisplay)
	{
		sheetManager.mCharacter = characterDisplay.item.mCharacter;
		sheetManager.SetCharacterValues ();

	}
}
