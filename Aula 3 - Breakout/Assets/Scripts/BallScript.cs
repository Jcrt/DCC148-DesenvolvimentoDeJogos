using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pelo controle da bola
/// </summary>
public class BallScript : MonoBehaviour {

	private Vector2 direction;			// guarda a direcão em que a bola está se movendo

	public float speed = 5.0f;			// velocidade de movimentacão da bola
	public float maxAngle = 45.0f;		// ângulo máximo de deflexão na colisão da bola com a barra

	// Use this for initialization
	void Start () {
		
		// inicializa a direcão da bola com um vetor na vertical
		direction = Vector2.up;
	}

	// Update is called once per frame
	void Update () {

		// Converte as coordenadas da posicão da bola no mundo para as coordenadas em pixels na tela
		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);

		// Verifica a colisão com os limites da tela superior e laterais e reflete o vetor de direcão em torno da normal à borda de colisão
		if (screenPos.y > Screen.height)
			direction = Vector2.Reflect (direction, Vector2.down);
		if(screenPos.x > Screen.width)
			direction = Vector2.Reflect (direction, Vector2.left);
		else if(screenPos.x < 0)
			direction = Vector2.Reflect (direction, Vector2.right);

		// Translada a bola de acordo com a velocidade e direcão especificadas
		transform.Translate (direction * speed * Time.deltaTime);
	}

	// Método chamado quando é detectada a intersecão
	void OnCollisionEnter(Collision collision) {
		// Verifica se o objeto que colidiu com a bola é um bloco
		if (collision.gameObject.tag == "Block") {
			// Destrói o bloco e reflete a direcão da bola
			Destroy (collision.gameObject);
			direction = Vector2.Reflect (direction, Vector2.down);
		// Verifica se a bola colidiu com a barra do jogador
		} else if (collision.gameObject.tag == "Player") {
			// Obtém os pontos de contato entre a bola e a barra
			ContactPoint[] points = collision.contacts;

			// Determina a distância da posicão da barra em relacão ao ponto de contato
			Vector3 distFromCenter = collision.gameObject.transform.position - points [0].point;

			// A distância calculada é usada para definir um ângulo de deflexão
			float angle = distFromCenter.x / (collision.gameObject.transform.localScale.x * 0.5f);

			// A nova direcão é definida por uma rotacão do vetor vertical pelo ângulo calculado acima, respeitando o limite definido em maxAngle
			Vector2 newDirection = Quaternion.AngleAxis (angle * maxAngle, Vector3.forward) * Vector2.up;
			direction = newDirection;
		}
	}
}
