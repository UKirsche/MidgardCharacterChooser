using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterChosen : MonoBehaviour {


	public void SaveChosenCaracter(){
		Toolbox globalVars = Toolbox.Instance;
		MidgardCharakter mCharacterChosen = globalVars.mCharacter;

		if (mCharacterChosen != null) {
			MidgardCharacterSaveLoad.SaveChosen (mCharacterChosen);
		}
	}

}
