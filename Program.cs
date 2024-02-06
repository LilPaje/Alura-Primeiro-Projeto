//Screen Sound
/*C# é uma linguagem fortemente tipada

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
string nomeCurso = "C#: Criando sua primeira aplicação";
string nome = "Izzy";
string sobrenome = "Oliveira";

Console.WriteLine(nomeCurso);
Console.WriteLine(nome + " " + sobrenome);
*/

string mensagemDeBoasVindas = "---Boas vindas ao Screen Sound---";
//List<string> listaDasBandas = new List<string>();

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();


void ExibirLogo() {
	//verbatil literal
	Console.WriteLine(@"
╭━━━╮╱╱╱╱╱╱╱╱╱╱╱╱╱╱╭━━━╮╱╱╱╱╱╱╱╱╱╱╭╮
┃╭━╮┃╱╱╱╱╱╱╱╱╱╱╱╱╱╱┃╭━╮┃╱╱╱╱╱╱╱╱╱╱┃┃
┃╰━━┳━━┳━┳━━┳━━┳━╮╱┃╰━━┳━━┳╮╭┳━╮╭━╯┃
╰━━╮┃╭━┫╭┫┃━┫┃━┫╭╮╮╰━━╮┃╭╮┃┃┃┃╭╮┫╭╮┃
┃╰━╯┃╰━┫┃┃┃━┫┃━┫┃┃┃┃╰━╯┃╰╯┃╰╯┃┃┃┃╰╯┃
╰━━━┻━━┻╯╰━━┻━━┻╯╰╯╰━━━┻━━┻━━┻╯╰┻━━╯
");
	Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu(){
	ExibirLogo();
	Console.WriteLine("\nDigite [1] para registrar uma banda");
	Console.WriteLine("Digite [2] para mostrar todas as bandas");
	Console.WriteLine("Digite [3] para avaliar uma banda");
	Console.WriteLine("Digite [4] para exibir a média de uma banda");
	Console.WriteLine("Digite [-1] para sair");
	
	Console.Write("\nDigite a sua opção: ");
	string opcaoUsuario = Console.ReadLine()!; //"!" retira a possibilidade de retornar valores núlos
	int opcaoEscolhidaNumerica = int.Parse(opcaoUsuario);
	switch (opcaoEscolhidaNumerica){
		case 1: RegistrarBanda();
			break;
		case 2: MostrarBandasRegistradas();
                        break;
		case 3: AvaliarUmaBanda();
                        break;
		case 4: MostrarMediaDeBanda();
                        break;
		case -1: Console.WriteLine("Você escolheu a opção " + opcaoUsuario);
                        break;

		default: Console.WriteLine("Opção inválida");
			break;
	}
}

void RegistrarBanda(){
	Console.Clear(); // Limpa o console
	ExibirTituloDaOpcao("Registro das Bandas");
	Console.Write("Digite o nome da banda que deseja registrar: ");
	string nomeDaBanda = Console.ReadLine()!; //Exclamação serve para não pegar valor nulo
	Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");	
	bandasRegistradas.Add(nomeDaBanda, new List<int>());
	Thread.Sleep(2000);
	Console.Clear();
	ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas(){
	Console.Clear();
	ExibirTituloDaOpcao("Exibindo todas as bandas Registradas");
	/*for(int i = 0; i < listaDasBandas.Count; i++){
		Console.WriteLine($"Banda: {listaDasBandas[i]}");
	}*/
	foreach (string banda in bandasRegistradas.Keys){
		Console.WriteLine($"Banda: {banda}");
	}

	Console.WriteLine("\nDigite uma tecla para voltar ao menu");
	Console.ReadKey();
	Console.Clear();
	
	ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo){
	int quantidadeDeLetras = titulo.Length;
	string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
	Console.WriteLine(asteriscos);
	Console.WriteLine(titulo);
	Console.WriteLine(asteriscos);	
}

void AvaliarUmaBanda(){
	//Digitar qual banda deseja avaliar

	//pesquisar banda se existe na base

	//atribuir nota
	Console.Clear();
	ExibirTituloDaOpcao("Avaliar Banda");
	Console.Write("Digite o nome da banda que deseja avaliar: ");
	string nomeDaBanda = Console.ReadLine()!;
	if (bandasRegistradas.ContainsKey(nomeDaBanda)){
		Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
		int nota = int.Parse(Console.ReadLine()!);
		bandasRegistradas[nomeDaBanda].Add(nota);
		Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
		Thread.Sleep(2000);		
	}else {Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");}
	Console.WriteLine("Digite uma tecla para voltar ao menu Principal");
	Console.ReadKey();
	Console.Clear();
	ExibirOpcoesDoMenu();
	
}

void MostrarMediaDeBanda(){
	Console.Clear();
	ExibirTituloDaOpcao("Exibir Nota Média da Banda");
	Console.Write("Digite o nome da banda que deseja verificar: ");
	string nomeDaBanda = Console.ReadLine()!;
	//float media = 0;
	if(bandasRegistradas.ContainsKey(nomeDaBanda)){
		Console.WriteLine($"Média da banda: {bandasRegistradas[nomeDaBanda].Average()}");
		/*if(bandasRegistradas[nomeDaBanda].Count > 0){	
			foreach(int nota in bandasRegistradas[nomeDaBanda]){
				media = nota + media;
			}			
			media = media / bandasRegistradas[nomeDaBanda].Count;
		} 
		Console.WriteLine($"Nota do {nomeDaBanda}: {media}");
	 */
	}
	else {

		Console.WriteLine("Banda Inválida, favor verificar novamente");
	}
	Console.WriteLine("Digite uma tecla para voltar ao menu Principal");
	Console.ReadKey();
	Console.Clear();
	ExibirOpcoesDoMenu();
}



ExibirOpcoesDoMenu();
