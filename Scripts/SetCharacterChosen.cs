using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterChosen : MonoBehaviour {

	public Text textChosenCharacterName;
	MidgardCharakter mCharacterChosen;

	void Start(){
		Toolbox globalVars = Toolbox.Instance;
		mCharacterChosen = globalVars.mCharacter;
		SetChosenCharaterNameSheet ();
		HandleScrollBoxes boxFiller = GetComponent<HandleScrollBoxes> ();
		boxFiller.FillFertigkeiten ();
	}


	public void SaveChosenCaracter(){
		Toolbox globalVars = Toolbox.Instance;
		mCharacterChosen = globalVars.mCharacter;

		if (mCharacterChosen != null) {
			MidgardCharacterSaveLoad.SaveChosen (mCharacterChosen);
			SetChosenCharaterNameSheet ();

		}
	}

	public void SetChosenCharaterNameSheet(){
		textChosenCharacterName.text = mCharacterChosen.CharacterName;
	}

}
