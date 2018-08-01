using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScrollBoxes : MonoBehaviour {

	const string TAGFORSCROLLITEM = "scrollitem";

	private SheetFillFertigkeitenInventory sheetFertigkeiten;
	private SheetFillWaffenInventory sheetWaffen;
	private SheetFillZauberInventory sheetZauber;
	public GameObject fertigkeitenScroller;
	public GameObject waffenScroller;
	public GameObject zauberScroller;


	void Awake(){
		sheetFertigkeiten = fertigkeitenScroller.GetComponent<SheetFillFertigkeitenInventory> ();
		sheetWaffen = waffenScroller.GetComponent<SheetFillWaffenInventory> ();
		sheetZauber = zauberScroller.GetComponent<SheetFillZauberInventory> ();
	}


	// Use this for initialization
	void Start () {
		
	}

	/// <summary>
	/// Füllt die Fertigkeitenscrollboxen auf: Normale-, Waffen-, Zauberfertigkeiten.
	/// Für die entsprechenden Methoden wird noch eine Toolbox-Variable gesetzt (Singleton)
	/// </summary>
	public void FillFertigkeiten ()
	{
		ClearScrollBoxes ();
		sheetFertigkeiten.FillPanel ();
		sheetWaffen.FillPanel ();
		sheetZauber.FillPanel ();
	}

	/// <summary>
	/// Clears the scroll boxes.
	/// </summary>
	private void ClearScrollBoxes ()
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (TAGFORSCROLLITEM);
		foreach (var gameObject in gameObjects) {
			Destroy (gameObject);
		}
	}
	
}
