namespace ShowdoMilion;

public  class Questao:IEquatable<Questao>
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
    
    public bool Equals(Questao q)
    {
        return this.Nivel == q.Nivel;
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
        botao1.IsVisible = true;
        botao2.Text = Resposta2;
        botao2.IsVisible = true;
        botao3.Text = Resposta3;
        botao3.IsVisible = true;
        botao4.Text = Resposta4;
        botao4.IsVisible = true;
        botao5.Text = Resposta5;
        botao5.IsVisible = true;

        botao1!.BackgroundColor = Colors.DarkBlue;
        botao1!.TextColor       = Colors.White;
        botao2!.BackgroundColor = Colors.DarkBlue;
        botao2!.TextColor       = Colors.White;
        botao3!.BackgroundColor = Colors.DarkBlue;
        botao3!.TextColor       = Colors.White;
        botao4!.BackgroundColor = Colors.DarkBlue;
        botao4!.TextColor       = Colors.White;
        botao5!.BackgroundColor = Colors.DarkBlue;
        botao5!.TextColor       = Colors.White; 
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