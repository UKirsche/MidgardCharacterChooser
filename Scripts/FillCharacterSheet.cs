using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillCharacterSheet : MidgardCharacterSheetManager {

	public Text characterName, characterDescription;

	public void FillCharacter(){
		SetBeschreibung ();
		SetCharacterValues ();
	}


	private void SetBeschreibung ()
	{
		characterName.text = mCharacter.Archetyp.ToString ();
		characterDescription.text = mCharacter.Schicht.ToString ();
	}

}
