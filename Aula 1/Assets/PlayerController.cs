using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe que controla o jogador.
/// 
/// Parametrizacão dos objetos de jogo:
/// DisplayText (objeto do Canvas)
/// - Componente "Rect Transform"
/// ==> PosX, PosY, PosZ: 0
/// ==> Width: 500
/// ==> Height: 100
/// 
/// UserInput (objeto do Canvas)
/// - Componente "Rect Transform"
/// ==> PosX, PosZ: 0
/// ==> PosY: -200
/// ==> Width: 900
/// ==> Height: 40
/// 
/// Placeholder (objeto do UserInput)
/// - Componente "Text (Script)"
/// ==> Text: "Digite o comando..."
/// 
/// Main Camera:
/// - Componente "Camera"
/// ==> Clear Flags: Solid Color
/// ==> Background: Preto
/// - Componente "Player Controller (Script)"
/// ==> Display: DisplayText (Text)
/// ==> User Input: UserInput (InputField)
/// </summary>
public class PlayerController : MonoBehaviour {

	int playerPosition = 0;			// armazena o id do local onde o jogador se encontra
	List<string> locations;			// lista com todos os locais importados do arquivo
	int[,] map;						// array bidimensional em que o índice da linha representa o local e cada coluna representa uma direcão (norte = 0, leste = 1, sul = 2 e oeste = 3)

	public Text display;			// objeto usado para exibir informacão de jogo na tela
	public InputField userInput;	// objeto usado para capturar os comandos do usuário

	// Use this for initialization
	void Start () {
		// Cria a lista de locais e carrega do arquivo, usando as funcões de manipulacão de arquivos do C#
		locations = new List<string> ();
		StreamReader file = File.OpenText ("Assets/Resources/cave.dat");
		loadLocations (file);

		// Cria a tabela de direcões e carrega a segunda secão do arquivo
		map = new int[locations.Count, 4];
		loadDirections (file);

		// Coloca o foco na caixa de texto
		userInput.Select ();
		userInput.ActivateInputField ();

		file.Close ();
	}

	void loadLocations(StreamReader file)
	{
		// Lê o arquivo linha por linha, enquanto não encontrar uma linha contendo "-1", que designa fim de secão.
		// Para cada linha lida, quebra a string em partes usando a funcão Split() e adiciona a segunda parte
		// (que representa a descricão do local) na lista. O índice do local é representado aqui pelo próprio
		// índice da lista somado de 1
		string line;
		while ((line = file.ReadLine ()) != null && line != "-1") {
			string[] parts = line.Split ('\t');
			locations.Add (parts [1]);
		}

		// Lê a linha em branco que separa a secão atual da próxima
		line = file.ReadLine ();
	}

	void loadDirections(StreamReader file)
	{
		// COLOQUE AQUI SEU CÓDIGO PARA CARREGAR A TABELA DE MOVIMENTOS
		// USE A FUNCÃO loadLocations COMO BASE, O CÓDIGO É SIMILAR
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			// COLOQUE AQUI SEU CÓDIGO PARA EXECUTAR AS ACÕES DE JOGO (ESTE É O SEU GAME LOOP)
			// NESSE CASO ESPECÍFICO, O IF GARANTE QUE SÓ EXECUTAREMOS ALGO QUANDO O USUÁRIO 
			// PRESSIONAR ENTER PARA ENVIAR O COMANDO QUE DESIGNA A ACÃO.
		}
	}
}
