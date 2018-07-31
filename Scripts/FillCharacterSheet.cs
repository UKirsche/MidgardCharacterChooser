using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillCharacterSheet : MidgardCharacterSheetManager {

	public Text characterName, characterDescription;

	public override void Start ()
	{
		MidgardCharacterSaveLoad.Load ();
		this.mCharacter = MidgardCharacterSaveLoad.midgardSavings.chosenCharakter;
		Toolbox globalVars = Toolbox.Instance;
		globalVars.mCharacter = this.mCharacter;
		FillCharacter ();
	}

	public void FillCharacter(){
		SetBeschreibung ();
		SetCharacterValues ();
	}


	private void SetBeschreibung ()
	{
		characterName.text = mCharacter.CharacterName.ToString ();
		characterDescription.text = mCharacter.CharacterBeschreibung.ToString ();
	}

}
