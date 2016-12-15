using UnityEngine;
using System.Collections;

public class RtsManager : MonoBehaviour {


	public static RtsManager Current = null;
	// Use this for initialization
	void Start () {
		Current = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
