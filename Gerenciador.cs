

namespace ShowdoMilion;

public class Gerenciador
{
    List<Questao>listaTodasQuestoes = new List<Questao>();
    List<Questao>listaTodasQuestoesRespondidas = new List<Questao>();
    public Questao QuestaoCorrente;
    public int Pontuacao {get; private set;}
    int NivelAtual = 1;
    Label labelPontuacao;
    Label labelNivel;
    
    void Inicializar()
    {
        Pontuacao = 0;
        NivelAtual = 1;
        listaTodasQuestoesRespondidas.Clear();
        ProximaQuestao();
    }



    public Gerenciador(Label labelPerg, Button bntResp01, Button bntResp02, Button bntResp03, Button bntResp04, Button bntResp05, Label labelPontuacao, Label labelNivel)
    {
        CriaPergunta(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        this.labelPontuacao = labelPontuacao;
        this.labelNivel = labelNivel;  
    }

    public async void VerificarCorreta(int RR)
    {
        if (QuestaoCorrente.VerificarResposta(RR))
        {
            await Task.Delay(1000);
            AdicionaPontuacao(NivelAtual);
            if (NivelAtual == 10)
            {
              await App.Current.MainPage.DisplayAlert("Parabéns!", "Você Ganhou um Milhâo", "OK");
              Inicializar();
            }
            NivelAtual ++;
            ProximaQuestao();
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("FIM!", "VOCÊ ERROU", "OK!");
            Inicializar();
        }
        labelPontuacao.Text = "R$ " + Pontuacao.ToString();
        labelNivel.Text = "Nivel:" + NivelAtual.ToString(); 
    }

    public void ProximaQuestao()
    {   
        var listaQuestao = listaTodasQuestoes.Where(d=>d.Nivel == NivelAtual).ToList();
        var numRand = Random.Shared.Next(0,listaQuestao.Count -1);
        var novaQuestao = listaQuestao[numRand];
        while (listaTodasQuestoesRespondidas.Contains(novaQuestao))
        {
            numRand = Random.Shared.Next(0, listaQuestao.Count -1);
            novaQuestao = listaQuestao[numRand];
        }
        listaTodasQuestoesRespondidas.Add(novaQuestao);
        QuestaoCorrente = novaQuestao;
        QuestaoCorrente.Desenhar();
    }

    void AdicionaPontuacao(int n)
    {
        if ( n==1)
            Pontuacao = 1000;
        else if ( n==2)
            Pontuacao = 2000;
        else if ( n == 3)
            Pontuacao = 5000;
        else if ( n==4)
            Pontuacao = 10000;
        else if ( n==5)
            Pontuacao = 20000;
        else if ( n==6)
            Pontuacao = 50000;
        else if ( n==7)
            Pontuacao = 100000;
        else if ( n==8)
            Pontuacao = 200000;
        else if ( n==9)
            Pontuacao = 500000;
        else 
            Pontuacao = 1000000;
    }


        void CriaPergunta(Label labelPerg, Button bntResp01, Button bntResp02, Button bntResp03, Button bntResp04, Button bntResp05)
    {
        var Quest1 = new Questao();
        Quest1.Nivel = 1;
        Quest1.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest1.Pergunta = "Que dia Tiradentes morreu?";
        Quest1.Resposta1 = "17 abril";
        Quest1.Resposta2 = "21 abril";
        Quest1.Resposta3 = "15 abril";
        Quest1.Resposta4 = "12 abril";
        Quest1.Resposta5 = "12 abril";
        Quest1.RespostaCorreta = 2; // A resposta correta é "21 abril"
        listaTodasQuestoes.Add(Quest1);

        var Quest2 = new Questao();
        Quest2.Nivel = 1;
        Quest2.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest2.Pergunta = "Qual é a capital do Brasil?";
        Quest2.Resposta1 = "Rio de Janeiro";
        Quest2.Resposta2 = "São Paulo";
        Quest2.Resposta3 = "Brasília";
        Quest2.Resposta4 = "Salvador";
        Quest2.Resposta5 = "Recife";
        Quest2.RespostaCorreta = 3; // A resposta correta é "Brasília"
        listaTodasQuestoes.Add(Quest2);

        // Questão 3
        var Quest3 = new Questao();
        Quest3.Nivel = 1;
        Quest3.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest3.Pergunta = "Qual é o maior país da América do Sul?";
        Quest3.Resposta1 = "Argentina";
        Quest3.Resposta2 = "Brasil";
        Quest3.Resposta3 = "Colômbia";
        Quest3.Resposta4 = "Chile";
        Quest3.Resposta5 = "Peru";
        Quest3.RespostaCorreta = 2; // A resposta correta é "Brasil"
        listaTodasQuestoes.Add(Quest3);

        // Questão 4
        var Quest4 = new Questao();
        Quest4.Nivel = 1;
        Quest4.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest4.Pergunta = "Qual é o planeta mais próximo do Sol?";
        Quest4.Resposta1 = "Terra";
        Quest4.Resposta2 = "Marte";
        Quest4.Resposta3 = "Júpiter";
        Quest4.Resposta4 = "Vênus";
        Quest4.Resposta5 = "Mercúrio";
        Quest4.RespostaCorreta = 5; // A resposta correta é "Mercúrio"
        listaTodasQuestoes.Add(Quest4);

        // Questão 5
        var Quest5 = new Questao();
        Quest5.Nivel = 1;
        Quest5.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest5.Pergunta = "Qual é a fórmula química da água?";
        Quest5.Resposta1 = "CO2";
        Quest5.Resposta2 = "O2";
        Quest5.Resposta3 = "H2O";
        Quest5.Resposta4 = "H2";
        Quest5.Resposta5 = "O3";
        Quest5.RespostaCorreta = 3; // A resposta correta é "H2O"
        listaTodasQuestoes.Add(Quest5);

        // Questão 6
        var Quest6 = new Questao();
        Quest6.Nivel = 1;
        Quest6.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest6.Pergunta = "Qual é o menor continente em área?";
        Quest6.Resposta1 = "Ásia";
        Quest6.Resposta2 = "América do Norte";
        Quest6.Resposta3 = "Europa";
        Quest6.Resposta4 = "Oceania";
        Quest6.Resposta5 = "África";
        Quest6.RespostaCorreta = 4; // A resposta correta é "Oceania"
        listaTodasQuestoes.Add(Quest6);

        // Questão 7
        var Quest7 = new Questao();
        Quest7.Nivel = 1;
        Quest7.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest7.Pergunta = "Qual é a moeda oficial dos Estados Unidos?";
        Quest7.Resposta1 = "Euro";
        Quest7.Resposta2 = "Dólar";
        Quest7.Resposta3 = "Libra";
        Quest7.Resposta4 = "Peso";
        Quest7.Resposta5 = "Iene";
        Quest7.RespostaCorreta = 2; // A resposta correta é "Dólar"
        listaTodasQuestoes.Add(Quest7);

        // Questão 8
        var Quest8 = new Questao();
        Quest8.Nivel = 1;
        Quest8.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest8.Pergunta = "Qual é o maior oceano do mundo?";
        Quest8.Resposta1 = "Atlântico";
        Quest8.Resposta2 = "Índico";
        Quest8.Resposta3 = "Ártico";
        Quest8.Resposta4 = "Pacífico";
        Quest8.Resposta5 = "Antártico";
        Quest8.RespostaCorreta = 4; // A resposta correta é "Pacífico"
        listaTodasQuestoes.Add(Quest8);

        // Questão 9
        var Quest9 = new Questao();
        Quest9.Nivel = 1;
        Quest9.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest9.Pergunta = "Quem escreveu 'Dom Casmurro'?";
        Quest9.Resposta1 = "Jorge Amado";
        Quest9.Resposta2 = "José de Alencar";
        Quest9.Resposta3 = "Machado de Assis";
        Quest9.Resposta4 = "Graciliano Ramos";
        Quest9.Resposta5 = "Carlos Drummond de Andrade";
        Quest9.RespostaCorreta = 3; // A resposta correta é "Machado de Assis"
        listaTodasQuestoes.Add(Quest9);

        // Questão 10
        var Quest10 = new Questao();
        Quest10.Nivel = 1;
        Quest10.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest10.Pergunta = "Qual é o elemento químico representado pelo símbolo 'O'?";
        Quest10.Resposta1 = "Oxigênio";
        Quest10.Resposta2 = "Ouro";
        Quest10.Resposta3 = "Osso";
        Quest10.Resposta4 = "Ósmio";
        Quest10.Resposta5 = "Oganesson";
        Quest10.RespostaCorreta = 1; // A resposta correta é "Oxigênio"
        listaTodasQuestoes.Add(Quest10);

        // Questão 11
        var Quest11 = new Questao();
        Quest11.Nivel = 2;
        Quest11.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest11.Pergunta = "Quem pintou o teto da Capela Sistina?";
        Quest11.Resposta1 = "Leonardo da Vinci";
        Quest11.Resposta2 = "Rafael";
        Quest11.Resposta3 = "Michelangelo";
        Quest11.Resposta4 = "Donatello";
        Quest11.Resposta5 = "Botticelli";
        Quest11.RespostaCorreta = 3; // A resposta correta é "Michelangelo"
        listaTodasQuestoes.Add(Quest11);

        // Questão 12
        var Quest12 = new Questao();
        Quest12.Nivel = 2;
        Quest12.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest12.Pergunta = "Qual é a montanha mais alta do mundo?";
        Quest12.Resposta1 = "Monte Everest";
        Quest12.Resposta2 = "K2";
        Quest12.Resposta3 = "Kangchenjunga";
        Quest12.Resposta4 = "Lhotse";
        Quest12.Resposta5 = "Makalu";
        Quest12.RespostaCorreta = 1; // A resposta correta é "Monte Everest"
        listaTodasQuestoes.Add(Quest12);

        // Questão 13
        var Quest13 = new Questao();
        Quest13.Nivel = 2;
        Quest13.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest13.Pergunta = "Em que ano ocorreu a Revolução Francesa?";
        Quest13.Resposta1 = "1789";
        Quest13.Resposta2 = "1799";
        Quest13.Resposta3 = "1804";
        Quest13.Resposta4 = "1776";
        Quest13.Resposta5 = "1815";
        Quest13.RespostaCorreta = 1; // A resposta correta é "1789"
        listaTodasQuestoes.Add(Quest13);

        // Questão 14
        var Quest14 = new Questao();
        Quest14.Nivel = 2;
        Quest14.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest14.Pergunta = "Qual foi o primeiro homem a pisar na Lua?";
        Quest14.Resposta1 = "Buzz Aldrin";
        Quest14.Resposta2 = "Yuri Gagarin";
        Quest14.Resposta3 = "Neil Armstrong";
        Quest14.Resposta4 = "John Glenn";
        Quest14.Resposta5 = "Michael Collins";
        Quest14.RespostaCorreta = 3; // A resposta correta é "Neil Armstrong"
        listaTodasQuestoes.Add(Quest14);

        // Questão 15
        var Quest15 = new Questao();
        Quest15.Nivel = 2;
        Quest15.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest15.Pergunta = "Qual é o número atômico do carbono?";
        Quest15.Resposta1 = "12";
        Quest15.Resposta2 = "6";
        Quest15.Resposta3 = "8";
        Quest15.Resposta4 = "16";
        Quest15.Resposta5 = "14";
        Quest15.RespostaCorreta = 2; // A resposta correta é "6"
        listaTodasQuestoes.Add(Quest15);

        // Questão 16
        var Quest16 = new Questao();
        Quest16.Nivel = 2;
        Quest16.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest16.Pergunta = "Quem escreveu a peça 'Romeu e Julieta'?";
        Quest16.Resposta1 = "William Shakespeare";
        Quest16.Resposta2 = "Charles Dickens";
        Quest16.Resposta3 = "Jane Austen";
        Quest16.Resposta4 = "Victor Hugo";
        Quest16.Resposta5 = "Fiódor Dostoiévski";
        Quest16.RespostaCorreta = 1; // A resposta correta é "William Shakespeare"
        listaTodasQuestoes.Add(Quest16);

        // Questão 17
        var Quest17 = new Questao();
        Quest17.Nivel = 2;
        Quest17.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest17.Pergunta = "Qual é a principal fonte de energia da Terra?";
        Quest17.Resposta1 = "Água";
        Quest17.Resposta2 = "Vento";
        Quest17.Resposta3 = "Combustíveis fósseis";
        Quest17.Resposta4 = "Sol";
        Quest17.Resposta5 = "Energia geotérmica";
        Quest17.RespostaCorreta = 4; // A resposta correta é "Sol"
        listaTodasQuestoes.Add(Quest17);

        // Questão 18
        var Quest18 = new Questao();
        Quest18.Nivel = 2;
        Quest18.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest18.Pergunta = "Qual é o maior órgão do corpo humano?";
        Quest18.Resposta1 = "Fígado";
        Quest18.Resposta2 = "Pulmão";
        Quest18.Resposta3 = "Coração";
        Quest18.Resposta4 = "Cérebro";
        Quest18.Resposta5 = "Pele";
        Quest18.RespostaCorreta = 5; // A resposta correta é "Pele"
        listaTodasQuestoes.Add(Quest18);

        // Questão 19
        var Quest19 = new Questao();
        Quest19.Nivel = 2;
        Quest19.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest19.Pergunta = "Em que país se encontra o Deserto do Saara?";
        Quest19.Resposta1 = "Brasil";
        Quest19.Resposta2 = "Austrália";
        Quest19.Resposta3 = "Egito";
        Quest19.Resposta4 = "Estados Unidos";
        Quest19.Resposta5 = "Canadá";
        Quest19.RespostaCorreta = 3; // A resposta correta é "Egito"
        listaTodasQuestoes.Add(Quest19);

        // Questão 20
        var Quest20 = new Questao();
        Quest20.Nivel = 2;
        Quest20.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest20.Pergunta = "Qual é o nome do processo em que uma célula se divide em duas células-filhas?";
        Quest20.Resposta1 = "Meiose";
        Quest20.Resposta2 = "Fagocitose";
        Quest20.Resposta3 = "Osmose";
        Quest20.Resposta4 = "Mitoses";
        Quest20.Resposta5 = "Anabolismo";
        Quest20.RespostaCorreta = 4; // A resposta correta é "Mitose"
        listaTodasQuestoes.Add(Quest20);

       // Questão 21
        var Quest21 = new Questao();
        Quest21.Nivel = 3;
        Quest21.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest21.Pergunta = "Qual é o maior oceano do mundo?";
        Quest21.Resposta1 = "Atlântico";
        Quest21.Resposta2 = "Índico";
        Quest21.Resposta3 = "Ártico";
        Quest21.Resposta4 = "Pacífico";
        Quest21.Resposta5 = "Antártico";
        Quest21.RespostaCorreta = 4; 
        listaTodasQuestoes.Add(Quest21);

        // Questão 22
        var Quest22 = new Questao();
        Quest22.Nivel = 3;
        Quest22.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest22.Pergunta = "Em que ano o homem pisou na Lua pela primeira vez?";
        Quest22.Resposta1 = "1965";
        Quest22.Resposta2 = "1969";
        Quest22.Resposta3 = "1972";
        Quest22.Resposta4 = "1959";
        Quest22.Resposta5 = "1975";
        Quest22.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest22);

        // Questão 23
        var Quest23 = new Questao();
        Quest23.Nivel = 3;
        Quest23.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest23.Pergunta = "Qual é a capital da Austrália?";
        Quest23.Resposta1 = "Sydney";
        Quest23.Resposta2 = "Melbourne";
        Quest23.Resposta3 = "Canberra";
        Quest23.Resposta4 = "Brisbane";
        Quest23.Resposta5 = "Perth";
        Quest23.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest23);

        // Questão 24
        var Quest24 = new Questao();
        Quest24.Nivel = 3;
        Quest24.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest24.Pergunta = "Quantos estados possui o Brasil?";
        Quest24.Resposta1 = "26";
        Quest24.Resposta2 = "27";
        Quest24.Resposta3 = "25";
        Quest24.Resposta4 = "28";
        Quest24.Resposta5 = "29";
        Quest24.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest24);

        // Questão 25
        var Quest25 = new Questao();
        Quest25.Nivel = 3;
        Quest25.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest25.Pergunta = "Quem foi o primeiro presidente dos Estados Unidos?";
        Quest25.Resposta1 = "George Washington";
        Quest25.Resposta2 = "Thomas Jefferson";
        Quest25.Resposta3 = "Abraham Lincoln";
        Quest25.Resposta4 = "John Adams";
        Quest25.Resposta5 = "James Madison";
        Quest25.RespostaCorreta = 1; 
        listaTodasQuestoes.Add(Quest25);

        // Questão 26
        var Quest26 = new Questao();
        Quest26.Nivel = 3;
        Quest26.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest26.Pergunta = "Qual é a moeda oficial do Japão?";
        Quest26.Resposta1 = "Iene";
        Quest26.Resposta2 = "Dólar";
        Quest26.Resposta3 = "Yuan";
        Quest26.Resposta4 = "Won";
        Quest26.Resposta5 = "Peso";
        Quest26.RespostaCorreta = 1; 
        listaTodasQuestoes.Add(Quest26);

        // Questão 27
        var Quest27 = new Questao();
        Quest27.Nivel = 3;
        Quest27.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest27.Pergunta = "Qual é a unidade fundamental da matéria?";
        Quest27.Resposta1 = "Molécula";
        Quest27.Resposta2 = "Átomo";
        Quest27.Resposta3 = "Partícula";
        Quest27.Resposta4 = "Elemento";
        Quest27.Resposta5 = "Próton";
        Quest27.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest27);

        // Questão 28
        var Quest28 = new Questao();
        Quest28.Nivel = 3;
        Quest28.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest28.Pergunta = "Qual é a camada da Terra onde vivemos?";
        Quest28.Resposta1 = "Manto";
        Quest28.Resposta2 = "Núcleo";
        Quest28.Resposta3 = "Crosta";
        Quest28.Resposta4 = "Estratosfera";
        Quest28.Resposta5 = "Litosfera";
        Quest28.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest28);

        // Questão 29
        var Quest29 = new Questao();
        Quest29.Nivel = 3;
        Quest29.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest29.Pergunta = "Qual é o maior país do mundo em extensão territorial?";
        Quest29.Resposta1 = "Canadá";
        Quest29.Resposta2 = "China";
        Quest29.Resposta3 = "Estados Unidos";
        Quest29.Resposta4 = "Rússia";
        Quest29.Resposta5 = "Brasil";
        Quest29.RespostaCorreta = 4; 
        listaTodasQuestoes.Add(Quest29);

        // Questão 30
        var Quest30 = new Questao();
        Quest30.Nivel = 3;
        Quest30.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest30.Pergunta = "Qual é o gás mais abundante na atmosfera terrestre?";
        Quest30.Resposta1 = "Oxigênio";
        Quest30.Resposta2 = "Dióxido de carbono";
        Quest30.Resposta3 = "Argônio";
        Quest30.Resposta4 = "Hidrogênio";
        Quest30.Resposta5 = "Nitrogênio";
        Quest30.RespostaCorreta = 5; 
        listaTodasQuestoes.Add(Quest30);

        // Questão 31
        var Quest31 = new Questao();
        Quest31.Nivel = 4;
        Quest31.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest31.Pergunta = "Qual é a fórmula química da água?";
        Quest31.Resposta1 = "CO2";
        Quest31.Resposta2 = "H2O";
        Quest31.Resposta3 = "O2";
        Quest31.Resposta4 = "N2";
        Quest31.Resposta5 = "H2";
        Quest31.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest31);

        // Questão 32
        var Quest32 = new Questao();
        Quest32.Nivel = 4;
        Quest32.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest32.Pergunta = "Quem foi o autor de 'Dom Casmurro'?";
        Quest32.Resposta1 = "Machado de Assis";
        Quest32.Resposta2 = "Jorge Amado";
        Quest32.Resposta3 = "Carlos Drummond de Andrade";
        Quest32.Resposta4 = "Clarice Lispector";
        Quest32.Resposta5 = "José de Alencar";
        Quest32.RespostaCorreta = 1; 
        listaTodasQuestoes.Add(Quest32);

        // Questão 33
        var Quest33 = new Questao();
        Quest33.Nivel = 4;
        Quest33.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest33.Pergunta = "Qual é a moeda oficial do Reino Unido?";
        Quest33.Resposta1 = "Euro";
        Quest33.Resposta2 = "Dólar";
        Quest33.Resposta3 = "Libra Esterlina";
        Quest33.Resposta4 = "Franco";
        Quest33.Resposta5 = "Peso";
        Quest33.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest33);

        // Questão 34
        var Quest34 = new Questao();
        Quest34.Nivel = 4;
        Quest34.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest34.Pergunta = "Qual é o nome do maior deserto quente do mundo?";
        Quest34.Resposta1 = "Deserto do Saara";
        Quest34.Resposta2 = "Deserto de Gobi";
        Quest34.Resposta3 = "Deserto de Atacama";
        Quest34.Resposta4 = "Deserto da Arábia";
        Quest34.Resposta5 = "Deserto de Kalahari";
        Quest34.RespostaCorreta = 1; 
        listaTodasQuestoes.Add(Quest34);

        // Questão 35
        var Quest35 = new Questao();
        Quest35.Nivel = 4;
        Quest35.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest35.Pergunta = "Qual é a raiz quadrada de 144?";
        Quest35.Resposta1 = "10";
        Quest35.Resposta2 = "11";
        Quest35.Resposta3 = "12";
        Quest35.Resposta4 = "13";
        Quest35.Resposta5 = "14";
        Quest35.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest35);

        // Questão 36
        var Quest36 = new Questao();
        Quest36.Nivel = 4;
        Quest36.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest36.Pergunta = "Qual é o maior planeta do sistema solar?";
        Quest36.Resposta1 = "Terra";
        Quest36.Resposta2 = "Marte";
        Quest36.Resposta3 = "Saturno";
        Quest36.Resposta4 = "Júpiter";
        Quest36.Resposta5 = "Netuno";
        Quest36.RespostaCorreta = 4; 
        listaTodasQuestoes.Add(Quest36);

        // Questão 37
        var Quest37 = new Questao();
        Quest37.Nivel = 4;
        Quest37.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest37.Pergunta = "Qual é a menor unidade de medida de informação no computador?";
        Quest37.Resposta1 = "Byte";
        Quest37.Resposta2 = "Bit";
        Quest37.Resposta3 = "Kilobyte";
        Quest37.Resposta4 = "Megabyte";
        Quest37.Resposta5 = "Gigabyte";
        Quest37.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest37);

        // Questão 38
        var Quest38 = new Questao();
        Quest38.Nivel = 4;
        Quest38.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest38.Pergunta = "Em que continente está localizado o Egito?";
        Quest38.Resposta1 = "Ásia";
        Quest38.Resposta2 = "Europa";
        Quest38.Resposta3 = "África";
        Quest38.Resposta4 = "América do Norte";
        Quest38.Resposta5 = "Oceania";
        Quest38.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest38);

        // Questão 39
        var Quest39 = new Questao();
        Quest39.Nivel = 4;
        Quest39.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest39.Pergunta = "Qual é o maior animal terrestre do mundo?";
        Quest39.Resposta1 = "Girafa";
        Quest39.Resposta2 = "Rinoceronte";
        Quest39.Resposta3 = "Elefante Africano";
        Quest39.Resposta4 = "Hipopótamo";
        Quest39.Resposta5 = "Tigre";
        Quest39.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest39);

        // Questão 40
        var Quest40 = new Questao();
        Quest40.Nivel = 4;
        Quest40.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest40.Pergunta = "Qual é o maior país em população no mundo?";
        Quest40.Resposta1 = "Índia";
        Quest40.Resposta2 = "Estados Unidos";
        Quest40.Resposta3 = "China";
        Quest40.Resposta4 = "Brasil";
        Quest40.Resposta5 = "Rússia";
        Quest40.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest40);

        // Questão 41
        var Quest41 = new Questao();
        Quest41.Nivel = 5;
        Quest41.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest41.Pergunta = "Qual é a capital da Islândia?";
        Quest41.Resposta1 = "Oslo";
        Quest41.Resposta2 = "Helsinque";
        Quest41.Resposta3 = "Reykjavik";
        Quest41.Resposta4 = "Estocolmo";
        Quest41.Resposta5 = "Copenhague";
        Quest41.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest41);

        // Questão 42
        var Quest42 = new Questao();
        Quest42.Nivel = 5;
        Quest42.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest42.Pergunta = "Qual é a unidade padrão de frequência?";
        Quest42.Resposta1 = "Ampere";
        Quest42.Resposta2 = "Watt";
        Quest42.Resposta3 = "Newton";
        Quest42.Resposta4 = "Hertz";
        Quest42.Resposta5 = "Joule";
        Quest42.RespostaCorreta = 4; 
        listaTodasQuestoes.Add(Quest42);

        // Questão 43
        var Quest43 = new Questao();
        Quest43.Nivel = 5;
        Quest43.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest43.Pergunta = "Qual é o símbolo químico do ouro?";
        Quest43.Resposta1 = "Ag";
        Quest43.Resposta2 = "Au";
        Quest43.Resposta3 = "Fe";
        Quest43.Resposta4 = "Hg";
        Quest43.Resposta5 = "Pb";
        Quest43.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest43);

        // Questão 44
        var Quest44 = new Questao();
        Quest44.Nivel = 5;
        Quest44.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest44.Pergunta = "Quem foi o autor de 'A Divina Comédia'?";
        Quest44.Resposta1 = "Dante Alighieri";
        Quest44.Resposta2 = "William Shakespeare";
        Quest44.Resposta3 = "Homero";
        Quest44.Resposta4 = "Virgílio";
        Quest44.Resposta5 = "Cervantes";
        Quest44.RespostaCorreta = 1; 
        listaTodasQuestoes.Add(Quest44);

        // Questão 45
        var Quest45 = new Questao();
        Quest45.Nivel = 5;
        Quest45.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest45.Pergunta = "Qual é o número atômico do oxigênio?";
        Quest45.Resposta1 = "6";
        Quest45.Resposta2 = "7";
        Quest45.Resposta3 = "8";
        Quest45.Resposta4 = "9";
        Quest45.Resposta5 = "10";
        Quest45.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest45);

        // Questão 46
        var Quest46 = new Questao();
        Quest46.Nivel = 5;
        Quest46.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest46.Pergunta = "Qual é o nome do acelerador de partículas mais famoso do mundo?";
        Quest46.Resposta1 = "FERMI";
        Quest46.Resposta2 = "LHC (Large Hadron Collider)";
        Quest46.Resposta3 = "RHIC";
        Quest46.Resposta4 = "SLAC";
        Quest46.Resposta5 = "Tevatron";
        Quest46.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest46);

        // Questão 47
        var Quest47 = new Questao();
        Quest47.Nivel = 5;
        Quest47.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest47.Pergunta = "Qual é a fórmula da velocidade média?";
        Quest47.Resposta1 = "V = m/s";
        Quest47.Resposta2 = "V = d/t";
        Quest47.Resposta3 = "V = t/d";
        Quest47.Resposta4 = "V = a*t";
        Quest47.Resposta5 = "V = F/m";
        Quest47.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest47);

        // Questão 48
        var Quest48 = new Questao();
        Quest48.Nivel = 5;
        Quest48.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest48.Pergunta = "Quem pintou o teto da Capela Sistina?";
        Quest48.Resposta1 = "Leonardo da Vinci";
        Quest48.Resposta2 = "Michelangelo";
        Quest48.Resposta3 = "Raphael";
        Quest48.Resposta4 = "Donatello";
        Quest48.Resposta5 = "Botticelli";
        Quest48.RespostaCorreta = 2; 
        listaTodasQuestoes.Add(Quest48);

        // Questão 49
        var Quest49 = new Questao();
        Quest49.Nivel = 5;
        Quest49.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest49.Pergunta = "Qual é a distância média da Terra ao Sol?";
        Quest49.Resposta1 = "93 milhões de milhas";
        Quest49.Resposta2 = "100 milhões de milhas";
        Quest49.Resposta3 = "150 milhões de quilômetros";
        Quest49.Resposta4 = "120 milhões de quilômetros";
        Quest49.Resposta5 = "200 milhões de quilômetros";
        Quest49.RespostaCorreta = 3; 
        listaTodasQuestoes.Add(Quest49);

        // Questão 50
        var Quest50 = new Questao();
        Quest50.Nivel = 5;
        Quest50.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest50.Pergunta = "Qual é o maior rio do mundo em volume de água?";
        Quest50.Resposta1 = "Nilo";
        Quest50.Resposta2 = "Mississipi";
        Quest50.Resposta3 = "Yangtzé";
        Quest50.Resposta4 = "Amazonas";
        Quest50.Resposta5 = "Congo";
        Quest50.RespostaCorreta = 4; 
        listaTodasQuestoes.Add(Quest50);


        // Questão 51
        var Quest51 = new Questao();
        Quest51.Nivel = 6;
        Quest51.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest51.Pergunta = "Qual é o nome do processo pelo qual as plantas produzem seu próprio alimento?";
        Quest51.Resposta1 = "Respiração";
        Quest51.Resposta2 = "Fotossíntese";
        Quest51.Resposta3 = "Fermentação";
        Quest51.Resposta4 = "Oxidação";
        Quest51.Resposta5 = "Transpiração";
        Quest51.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest51);

        // Questão 52
        var Quest52 = new Questao();
        Quest52.Nivel = 6;
        Quest52.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest52.Pergunta = "Quem é conhecido como o pai da física moderna?";
        Quest52.Resposta1 = "Isaac Newton";
        Quest52.Resposta2 = "Albert Einstein";
        Quest52.Resposta3 = "Galileu Galilei";
        Quest52.Resposta4 = "Nikola Tesla";
        Quest52.Resposta5 = "Marie Curie";
        Quest52.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest52);

        // Questão 53
        var Quest53 = new Questao();
        Quest53.Nivel = 6;
        Quest53.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest53.Pergunta = "Qual é o nome do maior osso do corpo humano?";
        Quest53.Resposta1 = "Úmero";
        Quest53.Resposta2 = "Fêmur";
        Quest53.Resposta3 = "Tíbia";
        Quest53.Resposta4 = "Rádio";
        Quest53.Resposta5 = "Fíbula";
        Quest53.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest53);

        // Questão 54
        var Quest54 = new Questao();
        Quest54.Nivel = 6;
        Quest54.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest54.Pergunta = "Qual é a unidade de medida de intensidade luminosa no SI?";
        Quest54.Resposta1 = "Candela";
        Quest54.Resposta2 = "Lumen";
        Quest54.Resposta3 = "Lux";
        Quest54.Resposta4 = "Watt";
        Quest54.Resposta5 = "Ampere";
        Quest54.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest54);

        // Questão 55
        var Quest55 = new Questao();
        Quest55.Nivel = 6;
        Quest55.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest55.Pergunta = "Qual é a velocidade da luz no vácuo?";
        Quest55.Resposta1 = "299.792 km/s";
        Quest55.Resposta2 = "300.000 km/s";
        Quest55.Resposta3 = "299.792.458 m/s";
        Quest55.Resposta4 = "300.000.000 m/s";
        Quest55.Resposta5 = "299.792.458 km/s";
        Quest55.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest55);

        // Questão 56
        var Quest56 = new Questao();
        Quest56.Nivel = 6;
        Quest56.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest56.Pergunta = "Quem escreveu 'O Capital'?";
        Quest56.Resposta1 = "Adam Smith";
        Quest56.Resposta2 = "Karl Marx";
        Quest56.Resposta3 = "Friedrich Engels";
        Quest56.Resposta4 = "Max Weber";
        Quest56.Resposta5 = "David Ricardo";
        Quest56.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest56);

        // Questão 57
        var Quest57 = new Questao();
        Quest57.Nivel = 6;
        Quest57.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest57.Pergunta = "Qual é o menor país do mundo em área?";
        Quest57.Resposta1 = "Mônaco";
        Quest57.Resposta2 = "Vaticano";
        Quest57.Resposta3 = "Malta";
        Quest57.Resposta4 = "San Marino";
        Quest57.Resposta5 = "Liechtenstein";
        Quest57.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest57);

        // Questão 58
        var Quest58 = new Questao();
        Quest58.Nivel = 6;
        Quest58.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest58.Pergunta = "Quem pintou 'Guernica'?";
        Quest58.Resposta1 = "Pablo Picasso";
        Quest58.Resposta2 = "Salvador Dalí";
        Quest58.Resposta3 = "Joan Miró";
        Quest58.Resposta4 = "Diego Rivera";
        Quest58.Resposta5 = "Frida Kahlo";
        Quest58.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest58);

        // Questão 59
        var Quest59 = new Questao();
        Quest59.Nivel = 6;
        Quest59.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest59.Pergunta = "Qual é o elemento mais abundante na crosta terrestre?";
        Quest59.Resposta1 = "Oxigênio";
        Quest59.Resposta2 = "Silício";
        Quest59.Resposta3 = "Alumínio";
        Quest59.Resposta4 = "Ferro";
        Quest59.Resposta5 = "Carbono";
        Quest59.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest59);

        // Questão 60
        var Quest60 = new Questao();
        Quest60.Nivel = 6;
        Quest60.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest60.Pergunta = "Qual foi o primeiro elemento químico a ser descoberto?";
        Quest60.Resposta1 = "Hidrogênio";
        Quest60.Resposta2 = "Oxigênio";
        Quest60.Resposta3 = "Fósforo";
        Quest60.Resposta4 = "Carbono";
        Quest60.Resposta5 = "Enxofre";
        Quest60.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest60);

        // Questão 61
        var Quest61 = new Questao();
        Quest61.Nivel = 7;
        Quest61.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest61.Pergunta = "Qual é o maior planeta do sistema solar?";
        Quest61.Resposta1 = "Saturno";
        Quest61.Resposta2 = "Júpiter"; // Resposta correta
        Quest61.Resposta3 = "Urano";
        Quest61.Resposta4 = "Netuno";
        Quest61.Resposta5 = "Marte";
        Quest61.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest61);

        // Questão 62
        var Quest62 = new Questao();
        Quest62.Nivel = 7;
        Quest62.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest62.Pergunta = "Qual é a fórmula química da água?";
        Quest62.Resposta1 = "H2O"; // Resposta correta
        Quest62.Resposta2 = "CO2";
        Quest62.Resposta3 = "O2";
        Quest62.Resposta4 = "H2O2";
        Quest62.Resposta5 = "CH4";
        Quest62.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest62);

        // Questão 63
        var Quest63 = new Questao();
        Quest63.Nivel = 7;
        Quest63.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest63.Pergunta = "Quem desenvolveu a teoria da relatividade?";
        Quest63.Resposta1 = "Isaac Newton";
        Quest63.Resposta2 = "Albert Einstein"; // Resposta correta
        Quest63.Resposta3 = "Galileo Galilei";
        Quest63.Resposta4 = "Niels Bohr";
        Quest63.Resposta5 = "Stephen Hawking";
        Quest63.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest63);

        // Questão 64
        var Quest64 = new Questao();
        Quest64.Nivel = 7;
        Quest64.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest64.Pergunta = "Qual é a capital da Austrália?";
        Quest64.Resposta1 = "Sydney";
        Quest64.Resposta2 = "Canberra"; // Resposta correta
        Quest64.Resposta3 = "Melbourne";
        Quest64.Resposta4 = "Brisbane";
        Quest64.Resposta5 = "Perth";
        Quest64.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest64);

        // Questão 65
        var Quest65 = new Questao();
        Quest65.Nivel = 7;
        Quest65.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest65.Pergunta = "Quem é conhecido como o 'Pai da História'?";
        Quest65.Resposta1 = "Heródoto"; // Resposta correta
        Quest65.Resposta2 = "Tucídides";
        Quest65.Resposta3 = "Platão";
        Quest65.Resposta4 = "Aristóteles";
        Quest65.Resposta5 = "Sócrates";
        Quest65.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest65);

        // Questão 66
        var Quest66 = new Questao();
        Quest66.Nivel = 7;
        Quest66.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest66.Pergunta = "Qual é a teoria que explica a origem das espécies?";
        Quest66.Resposta1 = "Teoria do Big Bang";
        Quest66.Resposta2 = "Teoria da Evolução"; // Resposta correta
        Quest66.Resposta3 = "Teoria da Relatividade";
        Quest66.Resposta4 = "Teoria da Tectônica de Placas";
        Quest66.Resposta5 = "Teoria Quântica";
        Quest66.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest66);

        // Questão 67
        var Quest67 = new Questao();
        Quest67.Nivel = 7;
        Quest67.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest67.Pergunta = "Quem pintou a Mona Lisa?";
        Quest67.Resposta1 = "Michelangelo";
        Quest67.Resposta2 = "Leonardo da Vinci"; // Resposta correta
        Quest67.Resposta3 = "Raphael";
        Quest67.Resposta4 = "Vincent van Gogh";
        Quest67.Resposta5 = "Claude Monet";
        Quest67.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest67);

        // Questão 68
        var Quest68 = new Questao();
        Quest68.Nivel = 7;
        Quest68.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest68.Pergunta = "Qual é a capital do Japão?";
        Quest68.Resposta1 = "Tóquio"; // Resposta correta
        Quest68.Resposta2 = "Seul";
        Quest68.Resposta3 = "Pequim";
        Quest68.Resposta4 = "Bangkok";
        Quest68.Resposta5 = "Hanoi";
        Quest68.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest68);

        // Continue até a questão 100...
        // Questão 69
        var Quest69 = new Questao();
        Quest69.Nivel = 8;
        Quest69.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest69.Pergunta = "Qual é a capital da França?";
        Quest69.Resposta1 = "Berlim";
        Quest69.Resposta2 = "Madrid";
        Quest69.Resposta3 = "Paris"; // Resposta correta
        Quest69.Resposta4 = "Roma";
        Quest69.Resposta5 = "Lisboa";
        Quest69.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest69);

        // Questão 70
        var Quest70 = new Questao();
        Quest70.Nivel = 8;
        Quest70.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest70.Pergunta = "Qual é a obra mais famosa de William Shakespeare?";
        Quest70.Resposta1 = "Hamlet"; // Resposta correta
        Quest70.Resposta2 = "Romeu e Julieta";
        Quest70.Resposta3 = "Macbeth";
        Quest70.Resposta4 = "Othello";
        Quest70.Resposta5 = "Sonhos de uma Noite de Verão";
        Quest70.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest70);

        // Questão 71
        var Quest71 = new Questao();
        Quest71.Nivel = 8;
        Quest71.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest71.Pergunta = "Qual é a teoria que explica o comportamento dos gases?";
        Quest71.Resposta1 = "Teoria dos Gases Ideais"; // Resposta correta
        Quest71.Resposta2 = "Teoria da Relatividade";
        Quest71.Resposta3 = "Teoria Quântica";
        Quest71.Resposta4 = "Teoria da Evolução";
        Quest71.Resposta5 = "Teoria da Tectônica de Placas";
        Quest71.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest71);

        // Questão 72
        var Quest72 = new Questao();
        Quest72.Nivel = 8;
        Quest72.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest72.Pergunta = "Quem foi o primeiro homem a pisar na Lua?";
        Quest72.Resposta1 = "Buzz Aldrin";
        Quest72.Resposta2 = "Neil Armstrong"; // Resposta correta
        Quest72.Resposta3 = "Yuri Gagarin";
        Quest72.Resposta4 = "Michael Collins";
        Quest72.Resposta5 = "John Glenn";
        Quest72.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest72);

        // Questão 73
        var Quest73 = new Questao();
        Quest73.Nivel = 8;
        Quest73.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest73.Pergunta = "Qual é o maior oceano do mundo?";
        Quest73.Resposta1 = "Atlântico";
        Quest73.Resposta2 = "Índico";
        Quest73.Resposta3 = "Ártico";
        Quest73.Resposta4 = "Pacífico"; // Resposta correta
        Quest73.Resposta5 = "Antártico";
        Quest73.RespostaCorreta = 4;
        listaTodasQuestoes.Add(Quest73);

        // Questão 74
        var Quest74 = new Questao();
        Quest74.Nivel = 8;
        Quest74.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest74.Pergunta = "Qual elemento químico tem o símbolo 'Fe'?";
        Quest74.Resposta1 = "Ferro"; // Resposta correta
        Quest74.Resposta2 = "Fósforo";
        Quest74.Resposta3 = "Flúor";
        Quest74.Resposta4 = "Cálcio";
        Quest74.Resposta5 = "Mercúrio";
        Quest74.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest74);

        // Questão 75
        var Quest75 = new Questao();
        Quest75.Nivel = 8;
        Quest75.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest75.Pergunta = "Qual é a primeira letra do alfabeto grego?";
        Quest75.Resposta1 = "Beta";
        Quest75.Resposta2 = "Gama";
        Quest75.Resposta3 = "Alfa"; // Resposta correta
        Quest75.Resposta4 = "Delta";
        Quest75.Resposta5 = "Épsilon";
        Quest75.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest75);

        // Questão 76
        var Quest76 = new Questao();
        Quest76.Nivel = 9;
        Quest76.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest76.Pergunta = "Quem formulou as leis do movimento?";
        Quest76.Resposta1 = "Isaac Newton"; // Resposta correta
        Quest76.Resposta2 = "Galileo Galilei";
        Quest76.Resposta3 = "Albert Einstein";
        Quest76.Resposta4 = "Niels Bohr";
        Quest76.Resposta5 = "Max Planck";
        Quest76.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest76);

        // Questão 77
        var Quest77 = new Questao();
        Quest77.Nivel = 9;
        Quest77.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest77.Pergunta = "Qual é a principal linguagem de programação para desenvolvimento web?";
        Quest77.Resposta1 = "Python";
        Quest77.Resposta2 = "Java";
        Quest77.Resposta3 = "JavaScript"; // Resposta correta
        Quest77.Resposta4 = "C#";
        Quest77.Resposta5 = "Ruby";
        Quest77.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest77);

        // Questão 78
        var Quest78 = new Questao();
        Quest78.Nivel = 9;
        Quest78.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest78.Pergunta = "Qual é a capital da Rússia?";
        Quest78.Resposta1 = "Moscovo"; // Resposta correta
        Quest78.Resposta2 = "São Petersburgo";
        Quest78.Resposta3 = "Kiev";
        Quest78.Resposta4 = "Minsk";
        Quest78.Resposta5 = "Tbilisi";
        Quest78.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest78);

        // Questão 79
        var Quest79 = new Questao();
        Quest79.Nivel = 9;
        Quest79.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest79.Pergunta = "Qual é a unidade de medida da frequência?";
        Quest79.Resposta1 = "Hertz"; // Resposta correta
        Quest79.Resposta2 = "Decibel";
        Quest79.Resposta3 = "Joule";
        Quest79.Resposta4 = "Pascal";
        Quest79.Resposta5 = "Newton";
        Quest79.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest79);

        // Questão 80
        var Quest80 = new Questao();
        Quest80.Nivel = 9;
        Quest80.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest80.Pergunta = "Qual é a capital do Canadá?";
        Quest80.Resposta1 = "Toronto";
        Quest80.Resposta2 = "Vancouver";
        Quest80.Resposta3 = "Ottawa"; // Resposta correta
        Quest80.Resposta4 = "Montreal";
        Quest80.Resposta5 = "Calgary";
        Quest80.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest80);

        // Questão 81
        var Quest81 = new Questao();
        Quest81.Nivel = 9;
        Quest81.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest81.Pergunta = "Quem é o autor de 'Dom Casmurro'?";
        Quest81.Resposta1 = "Machado de Assis"; // Resposta correta
        Quest81.Resposta2 = "Jorge Amado";
        Quest81.Resposta3 = "Graciliano Ramos";
        Quest81.Resposta4 = "Carlos Drummond de Andrade";
        Quest81.Resposta5 = "Clarice Lispector";
        Quest81.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest81);

        // Questão 82
        var Quest82 = new Questao();
        Quest82.Nivel = 9;
        Quest82.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest82.Pergunta = "Qual é o valor de π (pi) com duas casas decimais?";
        Quest82.Resposta1 = "3.12";
        Quest82.Resposta2 = "3.14"; // Resposta correta
        Quest82.Resposta3 = "3.16";
        Quest82.Resposta4 = "3.10";
        Quest82.Resposta5 = "3.15";
        Quest82.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest82);

        // Questão 83
        var Quest83 = new Questao();
        Quest83.Nivel = 9;
        Quest83.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest83.Pergunta = "Qual é o elemento químico com o símbolo 'Au'?";
        Quest83.Resposta1 = "Prata";
        Quest83.Resposta2 = "Ouro"; // Resposta correta
        Quest83.Resposta3 = "Cobre";
        Quest83.Resposta4 = "Ferro";
        Quest83.Resposta5 = "Mercúrio";
        Quest83.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest83);

        // Questão 84
        var Quest84 = new Questao();
        Quest84.Nivel = 10;
        Quest84.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest84.Pergunta = "Qual é a teoria que descreve a natureza da luz?";
        Quest84.Resposta1 = "Teoria da Relatividade";
        Quest84.Resposta2 = "Teoria da Mecânica Quântica"; // Resposta correta
        Quest84.Resposta3 = "Teoria da Evolução";
        Quest84.Resposta4 = "Teoria da Tectônica de Placas";
        Quest84.Resposta5 = "Teoria dos Gases Ideais";
        Quest84.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest84);

        // Questão 85
        var Quest85 = new Questao();
        Quest85.Nivel = 10;
        Quest85.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest85.Pergunta = "Qual é o maior animal terrestre?";
        Quest85.Resposta1 = "Elefante"; // Resposta correta
        Quest85.Resposta2 = "Girafa";
        Quest85.Resposta3 = "Rinoceronte";
        Quest85.Resposta4 = "Hipopótamo";
        Quest85.Resposta5 = "Urso";
        Quest85.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest85);

        // Questão 86
        var Quest86 = new Questao();
        Quest86.Nivel = 10;
        Quest86.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest86.Pergunta = "Quem foi o primeiro presidente dos Estados Unidos?";
        Quest86.Resposta1 = "George Washington"; // Resposta correta
        Quest86.Resposta2 = "Thomas Jefferson";
        Quest86.Resposta3 = "Abraham Lincoln";
        Quest86.Resposta4 = "John Adams";
        Quest86.Resposta5 = "Franklin D. Roosevelt";
        Quest86.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest86);

        // Questão 87
        var Quest87 = new Questao();
        Quest87.Nivel = 10;
        Quest87.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest87.Pergunta = "Qual é o gás mais abundante na atmosfera terrestre?";
        Quest87.Resposta1 = "Oxigênio";
        Quest87.Resposta2 = "Hidrogênio";
        Quest87.Resposta3 = "Nitrogênio"; // Resposta correta
        Quest87.Resposta4 = "Dióxido de Carbono";
        Quest87.Resposta5 = "Argônio";
        Quest87.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest87);

        // Questão 88
        var Quest88 = new Questao();
        Quest88.Nivel = 10;
        Quest88.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest88.Pergunta = "Qual é a língua mais falada no mundo?";
        Quest88.Resposta1 = "Inglês";
        Quest88.Resposta2 = "Mandarim"; // Resposta correta
        Quest88.Resposta3 = "Espanhol";
        Quest88.Resposta4 = "Francês";
        Quest88.Resposta5 = "Árabe";
        Quest88.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest88);

        // Questão 89
        var Quest89 = new Questao();
        Quest89.Nivel = 10;
        Quest89.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest89.Pergunta = "Qual é a forma mais comum de energia?";
        Quest89.Resposta1 = "Química";
        Quest89.Resposta2 = "Mecânica";
        Quest89.Resposta3 = "Térmica"; // Resposta correta
        Quest89.Resposta4 = "Elétrica";
        Quest89.Resposta5 = "Nuclear";
        Quest89.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest89);

        // Questão 90
        var Quest90 = new Questao();
        Quest90.Nivel = 10;
        Quest90.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest90.Pergunta = "Qual é o país com a maior população do mundo?";
        Quest90.Resposta1 = "Índia";
        Quest90.Resposta2 = "Estados Unidos";
        Quest90.Resposta3 = "China"; // Resposta correta
        Quest90.Resposta4 = "Indonésia";
        Quest90.Resposta5 = "Paquistão";
        Quest90.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest90);

        // Questão 91
        var Quest91 = new Questao();
        Quest91.Nivel = 10;
        Quest91.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest91.Pergunta = "Qual é a distância média da Terra ao Sol?";
        Quest91.Resposta1 = "149,6 milhões de km"; // Resposta correta
        Quest91.Resposta2 = "93 milhões de milhas";
        Quest91.Resposta3 = "150 milhões de km";
        Quest91.Resposta4 = "100 milhões de km";
        Quest91.Resposta5 = "200 milhões de km";
        Quest91.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest91);

        // Questão 92
        var Quest92 = new Questao();
        Quest92.Nivel = 10;
        Quest92.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest92.Pergunta = "Qual é o continente mais frio do mundo?";
        Quest92.Resposta1 = "África";
        Quest92.Resposta2 = "Antártida"; // Resposta correta
        Quest92.Resposta3 = "Ásia";
        Quest92.Resposta4 = "América do Sul";
        Quest92.Resposta5 = "Europa";
        Quest92.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest92);

        // Questão 93
        var Quest93 = new Questao();
        Quest93.Nivel = 10;
        Quest93.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest93.Pergunta = "Qual é o maior deserto do mundo?";
        Quest93.Resposta1 = "Deserto do Saara";
        Quest93.Resposta2 = "Deserto da Antártica"; // Resposta correta
        Quest93.Resposta3 = "Deserto de Gobi";
        Quest93.Resposta4 = "Deserto de Kalahari";
        Quest93.Resposta5 = "Deserto de Atacama";
        Quest93.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest93);

        // Questão 94
        var Quest94 = new Questao();
        Quest94.Nivel = 10;
        Quest94.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest94.Pergunta = "Quem escreveu 'Cem Anos de Solidão'?";
        Quest94.Resposta1 = "Gabriel García Márquez"; // Resposta correta
        Quest94.Resposta2 = "Julio Cortázar";
        Quest94.Resposta3 = "Mario Vargas Llosa";
        Quest94.Resposta4 = "Jorge Luis Borges";
        Quest94.Resposta5 = "Pablo Neruda";
        Quest94.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest94);

        // Questão 95
        var Quest95 = new Questao();
        Quest95.Nivel = 10;
        Quest95.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest95.Pergunta = "Qual é o gás que causa o efeito estufa?";
        Quest95.Resposta1 = "Oxigênio";
        Quest95.Resposta2 = "Dióxido de Carbono"; // Resposta correta
        Quest95.Resposta3 = "Nitrogênio";
        Quest95.Resposta4 = "Hélio";
        Quest95.Resposta5 = "Argônio";
        Quest95.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest95);

        // Questão 96
        var Quest96 = new Questao();
        Quest96.Nivel = 10;
        Quest96.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest96.Pergunta = "Qual é a capital da Itália?";
        Quest96.Resposta1 = "Roma"; // Resposta correta
        Quest96.Resposta2 = "Milão";
        Quest96.Resposta3 = "Veneza";
        Quest96.Resposta4 = "Florença";
        Quest96.Resposta5 = "Nápoles";
        Quest96.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest96);

        // Questão 97
        var Quest97 = new Questao();
        Quest97.Nivel = 10;
        Quest97.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest97.Pergunta = "Qual é o principal componente do ar?";
        Quest97.Resposta1 = "Oxigênio";
        Quest97.Resposta2 = "Nitrogênio"; // Resposta correta
        Quest97.Resposta3 = "Hidrogênio";
        Quest97.Resposta4 = "Dióxido de Carbono";
        Quest97.Resposta5 = "Argônio";
        Quest97.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest97);

        // Questão 98
        var Quest98 = new Questao();
        Quest98.Nivel = 10;
        Quest98.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest98.Pergunta = "Qual é a moeda do Japão?";
        Quest98.Resposta1 = "Yuan";
        Quest98.Resposta2 = "Dólar";
        Quest98.Resposta3 = "Iene"; // Resposta correta
        Quest98.Resposta4 = "Won";
        Quest98.Resposta5 = "Euro";
        Quest98.RespostaCorreta = 3;
        listaTodasQuestoes.Add(Quest98);

        // Questão 99
        var Quest99 = new Questao();
        Quest99.Nivel = 10;
        Quest99.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest99.Pergunta = "Qual é o nome do processo pelo qual as plantas produzem seu alimento?";
        Quest99.Resposta1 = "Respiração";
        Quest99.Resposta2 = "Fotossíntese"; // Resposta correta
        Quest99.Resposta3 = "Evaporação";
        Quest99.Resposta4 = "Transpiração";
        Quest99.Resposta5 = "Glicólise";
        Quest99.RespostaCorreta = 2;
        listaTodasQuestoes.Add(Quest99);

        // Questão 100
        var Quest100 = new Questao();
        Quest100.Nivel = 10;
        Quest100.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest100.Pergunta = "Quem foi o fundador do império Mongol?";
        Quest100.Resposta1 = "Genghis Khan"; // Resposta correta
        Quest100.Resposta2 = "Kublai Khan";
        Quest100.Resposta3 = "Tamerlão";
        Quest100.Resposta4 = "Hulagu Khan";
        Quest100.Resposta5 = "Batu Khan";
        Quest100.RespostaCorreta = 1;
        listaTodasQuestoes.Add(Quest100);


        ProximaQuestao();
    }
}