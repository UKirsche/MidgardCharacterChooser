using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;



/// <summary>
/// Inventory item. Verfügt über Namen und Wert
/// </summary>
public class CharacterInventoryItem: IName {
	public string name { get; set;}
	public MidgardCharakter mCharacter{ get; set;}

	private bool _activated;
	public bool activated { 
		get{ return _activated;}
		set{ _activated = value;}
	}

	//Standard
	public CharacterInventoryItem(){
	}

	public CharacterInventoryItem(string _name, MidgardCharakter _mCharacter):this(){
		name = _name;
		mCharacter = _mCharacter;
	}
		
}
