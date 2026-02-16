using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTexturing : MonoBehaviour
{
	public int Iterations;

	void Start()
	{
		for (float i=0; i<1; i+=1f/Iterations)
		{
			GameObject shell = new GameObject("Shell" + i.ToString());
			
			shell.AddComponent<MeshFilter>();
   			shell.AddComponent<MeshRenderer>();
            
   			shell.GetComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
     			shell.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
     			shell.transform.SetParent(transform, false);	
     			
     			shell.GetComponent<MeshRenderer>().material.SetFloat("_Height", i);
		}
		
		Destroy(GetComponent<MeshFilter>());
		Destroy(GetComponent<MeshRenderer>());
	}
}

