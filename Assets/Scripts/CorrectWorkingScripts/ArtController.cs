using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtController : MonoBehaviour
{
	public MeshRenderer Wall;

	public Material[] Materials;
	private string _materialNamePlayerPref = "MaterialNum";

	private void Awake()
	{
		try
		{
			if (PlayerPrefs.GetInt(_materialNamePlayerPref) == Materials.Length - 1)
			{
				Wall.material = Materials[PlayerPrefs.GetInt(_materialNamePlayerPref)];
				PlayerPrefs.SetInt(_materialNamePlayerPref, 0);
			}
			else
			{
				Wall.material = Materials[PlayerPrefs.GetInt(_materialNamePlayerPref)];
				PlayerPrefs.SetInt(_materialNamePlayerPref, PlayerPrefs.GetInt(_materialNamePlayerPref) + 1);
			}
		}
		catch
		{
			PlayerPrefs.SetInt(_materialNamePlayerPref, 0);
			Wall.material = Materials[PlayerPrefs.GetInt(_materialNamePlayerPref)];
		}
	}
}
