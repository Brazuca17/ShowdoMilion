namespace ShowdoMilion;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
	}

	private void IrJogo(object sender, EventArgs e)
	{
		if (Application.Current != null)
      Application.Current.MainPage = new JogodoMilion();
	}
}

