using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classes para controlar a movimentacão do jogador, representado por uma barra horizontal
/// </summary>
public class PlayerBarController : MonoBehaviour {

	public float speed = 20.0f;				// velocidade da barra
	
	// Update is called once per frame
	void Update () {
		// Verifica se as setas para direita ou esquerda foram pressionadas e aplica a velocidade na direcão especificada,
		// ponderada pelo deltaTime para garantir a mesma velocidade de execucão em diferentes configuracões
		if (Input.GetKey (KeyCode.RightArrow))
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		else if (Input.GetKey(KeyCode.LeftArrow))
			transform.Translate (Vector3.left * speed * Time.deltaTime);
	}
}
