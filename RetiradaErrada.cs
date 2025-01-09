namespace ShowdoMilion;

public class RetiradaErrada:IAjuda
{
    public override void RealizaAjuda(Questao questao)
    {
        switch(questao.RespostaCorreta)
        {
            case 1:
                btnResp02.IsVisible = false;
                btnResp03.IsVisible = false;
                btnResp04.IsVisible = false;
                break;
            
            case 2:
                btnResp01.IsVisible = false;
                btnResp03.IsVisible = false;
                btnResp05.IsVisible = false;
                 break;
            
            case 3:
                btnResp01.IsVisible = false;
                btnResp02.IsVisible = false;
                btnResp05.IsVisible = false;
                 break;

            case 4:
                btnResp01.IsVisible = false;
                btnResp02.IsVisible = false;
                btnResp05.IsVisible = false;
                 break;

            case 5:
                btnResp01.IsVisible = false;
                btnResp03.IsVisible = false;
                btnResp04.IsVisible = false;
                 break;
        }

    }
}