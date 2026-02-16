using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTexturing : MonoBehaviour
{
	// Determines the amount of shells to be produced
	// Determina quantas camadas serão produzidas
	public int Iterations = 10;

	void Start()
	{
		// Defines a "mesh" variable containing the mesh to be rendered and a "mat" variable for the material
		// Define uma variavel "mesh" contendo a malha que sera renderizada e uma variavel "mat" para o material
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Material mat = GetComponent<MeshRenderer>().material;
		
		//For loop to instantiate (create) all shell GameObjects
		//Estrutura de repetição For para instanciar (criar) todos os GameObjects de camadas
		for (float i=0; i<1; i+=1f/Iterations)
		{
			// Creates a new GameObject
			// Cria um novo GameObject
			GameObject shell = new GameObject("Shell" + i.ToString());

			// Adds the mesh-related components
			// Adiciona os componentes relacionados a malha
			shell.AddComponent<MeshFilter>();
   			shell.AddComponent<MeshRenderer>();

			// Sets up the mesh and materials
			// Configura a malha e os materiais
   			shell.GetComponent<MeshFilter>().mesh = mesh;
     		shell.GetComponent<MeshRenderer>().material = mat;
     		shell.transform.SetParent(transform, false);	

			// Sets the height in the material to the instance's ID
			// Define a altura no material como o ID da instancia
     		shell.GetComponent<MeshRenderer>().material.SetFloat("_Height", i);
		}

		// Destroys the original mesh, as the shells replace it
		// Destroi a malha original, dado as camadas substituirem ele
		Destroy(GetComponent<MeshFilter>());
		Destroy(GetComponent<MeshRenderer>());
	}
}


