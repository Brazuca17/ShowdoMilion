namespace ShowdoMilion;

public class Gerenciador
{
    List<Questao>listaQuestoes = new List<Questao>();
    List<int>listaQuestoesRespondidas = new List<int>();
    Questao QuestaoCorrente;


    public Gerenciador (Label labelPerg, Button bntResp01, Button bntResp02, Button bntResp03, Button bntResp04, Button bntResp05)
    {
        CriaPergunta(labelPerg, bntResp01, bntResp02, bntResp03, bntResp04, bntResp05);  
    }

    void CriaPergunta(Label labelPerg, Button bntResp01, Button bntResp02, Button bntRespo03, Button bntRespo04, Button bntResp5)
    {
        var Quest1 = new Questao();
        Quest1.ConfigurarTelaDesenho(labelPerg, btnResp01, btnResp02, btnResp03, btnResp04, btnResp05);
        Quest1.Pergunta = "quanto é ?";
        Quest1.Resposta1 = "...";
        Quest1.Resposta2 = "...";
        Quest1.Resposta3 = "...";
        Quest1.Resposta4 = "...";
        Quest1.Resposta5 = "...";
        Quest1.RespostaCorreta = "3";
        listaQuestoes.Add(Quest1);
    }

    public async void VerificarCorreta(int RR)
    {
        if (QuestaoCorrente.VerificarResposta(RR))
        {
            await Task.Delay(1000);
            ProximaQuestao();
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
}