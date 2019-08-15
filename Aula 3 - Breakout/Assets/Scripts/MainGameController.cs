using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe principal do jogo, associada à Main Camera
/// 
/// GameObjects definidos na Hierarquia do projeto
/// * Projeto 2D
/// * Main Camera (propriedades default)
/// 
/// * PlayerBar (3D Object/Cube)
/// - Tag: Player
/// - Transform
/// ---> Position: (0, -4, 0)
/// ---> Scale: (4, 0.5, 1)
/// - Box Collider (default)
/// - PlayerBarController (script)
/// ---> Speed: valor de teste 20
/// 
/// * Ball (3D Object/Sphere)
/// - Tag: Ball
/// - Transform
/// ---> Position: (0, -3.3, 0)
/// ---> Scale: (0.5, 0.5, 1)
/// - Sphere Collider
/// ---> Radius: 0.3
/// - Rigidbody
/// ---> Mass: 0.05
/// ---> Drag: 0
/// ---> Use Gravity: false
/// - BallScript (script)
/// ---> Speed: valor de teste 10
/// ---> Max Angle: valor de teste 45
/// </summary>
public class MainGameController : MonoBehaviour {

	public GameObject blockSample;			// prefab usado para criar os blocos

	public int lines;						// número de linhas de blocos
	public int blocksPerLine;				// número de blocos por linha

	// Use this for initialization
	void Start () {

		// Obtém o tamanho da tela e o tamanho do bloco
		Vector3 worldSize = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		Vector3 blockSize = blockSample.GetComponent<MeshRenderer> ().bounds.size;

		// Para cada linha, cria um conjunto de blocos e os posiciona de forma a caberem todos dentro da janela
		for (int i = 0; i < lines; i++) {
			for (int j = 0; j < blocksPerLine; j++) {
				GameObject block = Object.Instantiate (blockSample);
				float posx = (worldSize.x - ((float)j / blocksPerLine) * worldSize.x * 2.0f) - blockSize.x * 0.5f;
				float posy = (worldSize.y - ((float)i 		  / lines) * worldSize.y	   ) - blockSize.y * 0.5f;

				block.transform.Translate (posx, posy, 0);
			}
		}
	}
}
