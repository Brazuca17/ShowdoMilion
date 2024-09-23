using Windows.Graphics.Printing.Workflow;

namespace ShowdoMilion;

public class Gerenciador
{
    List<Questao>listaQuestoes = new List<Questao>();
    List<int>listaQuestoesRespondidas = new List<int>();
    Questao QuestaoCorrente;
    public int pontuação {get; private set;}
    int NivelAtual = 0;
    
    void Inicializar()
    {
        pontuação = 0;
        NivelAtual = 1;
        ProximaQuestao();
    }


    public Gerenciador(Label labelPerg, Button bntResp01, Button bntResp02, Button bntResp03, Button bntResp04, Button bntResp05)
    {
        CriaPergunta(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);  
    }

    void CriaPergunta(Label labelPerg, Button bntResp01, Button bntResp02, Button bntResp03, Button bntResp04, Button bntResp05)
    {
        var Quest1 = new Questao();
        Quest1.Nivel= 1;
        Quest1.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest1.Pergunta = "que dia tiradente morreu";
        Quest1.Resposta1 = "17 abril";
        Quest1.Resposta2 = "21 abril";
        Quest1.Resposta3 = "15 abril";
        Quest1.Resposta4 = "12 abril";
        Quest1.Resposta5 = "12 abril";
        Quest1.RespostaCorreta = 2;
        listaQuestoes.Add(Quest1);

        var Quest2 = new Questao();
        Quest2.Nivel= 1;
        Quest2.ConfigurarTelaDesenho(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);
        Quest2.Pergunta = "sadjioasjd";
        Quest2.Resposta1 = "asdsada";
        Quest2.Resposta2 = "...";
        Quest2.Resposta3 = "...";
        Quest2.Resposta4 = "...";
        Quest2.Resposta5 = "...";
        Quest2.RespostaCorreta = 3;
        listaQuestoes.Add(Quest2);


        


        ProximaQuestao();
    }

    public async void VerificarCorreta(int RR)
    {
        if (QuestaoCorrente.VerificarResposta(RR))
        {
            await Task.Delay(1000);
            AdicionaPontuacao(NivelAtual);
            NivelAtual ++;
            ProximaQuestao();
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("FIM!", "VOCÊ ERROU", "OK!");
            Inicializar();
        }
    }

    public void ProximaQuestao()
    {   
        var NumeroAle = Random.Shared.Next(0, listaQuestoes.Count);
        while (listaQuestoesRespondidas.Contains(NumeroAle))
            NumeroAle=Random.Shared.Next(0,listaQuestoes.Count);
        listaQuestoesRespondidas.Add(NumeroAle);
        QuestaoCorrente = listaQuestoes[NumeroAle];
        QuestaoCorrente.Desenhar();
    }

    void AdicionaPontuacao(int n)
    {
        if ( n==1)
            pontuação = 1000;
        else if ( n==2)
            pontuação = 2000;
        else if ( n == 3)
            pontuação = 5000;
        else if ( n==4)
            pontuação = 10000;
        else if ( n==5)
            pontuação = 20000;
        else if ( n==6)
            pontuação = 50000;
        else if ( n==7)
            pontuação = 100000;
        else if ( n==8)
            pontuação = 200000;
        else if ( n==9)
            pontuação = 500000;
        else 
            pontuação = 1000000;
    }

}