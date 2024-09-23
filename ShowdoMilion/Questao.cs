namespace ShowdoMilion;

public  class Questao
{
    public string Pergunta;
    public string Resposta1;
    public string Resposta2;
    public string Resposta3;
    public string Resposta4;
    public string Resposta5;
    public int RespostaCorreta = 0;
    public int Nivel;
    private Label labelPergunta;
    private Button botao1;
    private Button botao2;
    private Button botao3;
    private Button botao4;
    private Button botao5;

    public Questao()
    {

    }
    
    public Questao(Label lb, Button but1, Button but2,Button but3,Button but4,Button but5)
    {
        labelPergunta = lb;
        botao1 = but1;
        botao2 = but2;
        botao3 = but3;
        botao4 = but4;
        botao5 = but5;
    }

    public void ConfigurarTelaDesenho(Label lb, Button but1, Button but2,Button but3,Button but4,Button but5)
    {
        labelPergunta = lb;
        botao1 = but1;
        botao2 = but2;
        botao3 = but3;
        botao4 = but4;
        botao5 = but5;
    }
    public void Desenhar()
    {
        labelPergunta.Text = Pergunta;
        botao1.Text = Resposta1;
        botao2.Text = Resposta2;
        botao3.Text = Resposta3;
        botao4.Text = Resposta4;
        botao5.Text = Resposta5;
    }

    public bool VerificarResposta(int respostaCerta)
    {
        if (RespostaCorreta == respostaCerta)
        {
            var btn = QualButton(respostaCerta);
            btn.BackgroundColor = Colors.Green;
            return true;
        }
        else 
        {
            var btnCorreto = QualButton(RespostaCorreta);
            var btnIncorreto = QualButton(respostaCerta);
                btnCorreto.BackgroundColor = Colors.Yellow;
                btnIncorreto.BackgroundColor = Colors.Red;
                return false;
        } 
    }

    private Button QualButton(int qualbot)
    {
        if (qualbot == 1)
            return botao1;
        else if (qualbot == 2)
            return botao2;
        else if (qualbot == 3)
            return botao3;
        else if (qualbot == 4)
            return botao4;
        else
            return botao5; 
    }
}