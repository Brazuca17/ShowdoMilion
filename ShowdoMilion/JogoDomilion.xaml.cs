namespace ShowdoMilion;

public partial class JogodoMilion : ContentPage
{
  Gerenciador gerenciador;

	public JogodoMilion()
	{
		InitializeComponent();
    gerenciador = new Gerenciador(labelPergunta, botao01, botao02, botao03, botao04, botao05);
	}

  private void OnBtnResposta01Clicked(object sender, EventArgs e)
  {
    gerenciador!.VerificarCorreta(1);
  }

  private void OnBtnResposta02Clicked(object sender, EventArgs e)
  {
    gerenciador!.VerificarCorreta(2);
  }

  private void OnBtnResposta03Clicked(object sender, EventArgs e)
  {
    gerenciador!.VerificarCorreta(3);
  }

  private void OnBtnResposta04Clicked(object sender, EventArgs e)
  {
    gerenciador!.VerificarCorreta(4);
  }

  private void OnBtnResposta05Clicked(object sender, EventArgs e)
  {
    gerenciador!.VerificarCorreta(5);
  }
}