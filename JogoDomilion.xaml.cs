
namespace ShowdoMilion;

public partial class JogodoMilion : ContentPage
{
  Gerenciador gerenciador;
	public JogodoMilion()
	{
		InitializeComponent();
    gerenciador = new Gerenciador(labelPergunta, botao01, botao02, botao03, botao04, botao05, labelPontuacao, labelNivel);
	}

  private async void  OnBtnResposta01Clicked(object sender, EventArgs e)
  {
    botao01.BackgroundColor = Colors.Yellow;
    if (await App.Current.MainPage.DisplayAlert("Tem Certeza Disso?", "", "Sim", "Não"))
        gerenciador!.VerificarCorreta(1);
        botao01.BackgroundColor = Colors.DarkBlue;
  }

  private async void OnBtnResposta02Clicked(object sender, EventArgs e)
  {
    botao02.BackgroundColor = Colors.Yellow;
    if (await App.Current.MainPage.DisplayAlert("Tem Certeza Disso?", "", "Sim", "Não"))
    gerenciador!.VerificarCorreta(2);
    botao02.BackgroundColor = Colors.DarkBlue;
  }

  private async void OnBtnResposta03Clicked(object sender, EventArgs e)
  {
    botao03.BackgroundColor = Colors.Yellow;
    if (await App.Current.MainPage.DisplayAlert("Tem Certeza Disso?", "", "Sim", "Não"))
    gerenciador!.VerificarCorreta(3);
    botao03.BackgroundColor = Colors.DarkBlue;
  }

  private async void OnBtnResposta04Clicked(object sender, EventArgs e)
  {
    botao04.BackgroundColor = Colors.Yellow;
    if (await App.Current.MainPage.DisplayAlert("Tem Certeza Disso?", "", "Sim", "Não"))
    gerenciador!.VerificarCorreta(4);
    botao04.BackgroundColor = Colors.DarkBlue;
  }

  private async void OnBtnResposta05Clicked(object sender, EventArgs e)
  {
    botao05.BackgroundColor = Colors.Yellow;
    if (await App.Current.MainPage.DisplayAlert("Tem Certeza Disso?", "", "Sim", "Não"))
    gerenciador!.VerificarCorreta(5);
    botao05.BackgroundColor = Colors.DarkBlue;
  }

  private async void Retira3(object sender, EventArgs e)
  {
    var ajuda = new RetiradaErrada();
    ajuda.ConfiguraDesenho(botao01, botao02,botao03,botao04,botao05);
    ajuda.RealizaAjuda(gerenciador.QuestaoCorrente);
    gustavo.IsVisible = false;
  }

  private async void Pular(object sender, EventArgs e)
  {
    gerenciador.ProximaQuestao();
  }
}