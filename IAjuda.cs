namespace ShowdoMilion;

public abstract class IAjuda
{
    protected Button btnResp01;
    protected Button btnResp02;
    protected Button btnResp03;
    protected Button btnResp04;
    protected Button btnResp05;
    protected Frame frameAjuda;

    public void ConfiguraDesenho(Button btnResp01, Button btnResp02, Button btnResp03, Button btnResp04, Button btnResp05)
    {
        this.btnResp01 = btnResp01;
        this.btnResp02 = btnResp02;
        this.btnResp03 = btnResp03;
        this.btnResp04 = btnResp04;
        this.btnResp05 = btnResp05;
    }
    
    public void ConfiguraDesenho(Frame frameAjuda)
    {
        this.frameAjuda = frameAjuda;
    }

    public abstract void RealizaAjuda(Questao questao);
}