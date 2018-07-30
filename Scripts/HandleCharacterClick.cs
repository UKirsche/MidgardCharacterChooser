using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HandleCharacterClick : MonoBehaviour
{


	// Use this for initialization
	void Start ()
	{

	}

	void OnEnable(){
		InventoryItemBerufDisplay.onClick +=	HandleOnItemClick;
	}

	void OnDisable(){
		InventoryItemBerufDisplay.onClick -= HandleOnItemClick;
	}

	void OnDestroy ()
	{
		InventoryItemBerufDisplay.onClick -= HandleOnItemClick;
	}

	/// <summary>
	/// Handles the on item click. Controls whole process of adding and removing items.
	/// </summary>
	/// <param name="itemDisplay">Item display.</param>
	public void HandleOnItemClick (InventoryItemDisplay itemDisplay)
	{
		
	}
}
