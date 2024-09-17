namespace ShowdoMilion;

public partial class JogodoMilion : ContentPage
{


	public JogodoMilion()
	{
		InitializeComponent();
	}

	private void IrJogo(object sender, EventArgs e)
	{
		if (Application.Current != null)
      Application.Current.MainPage = new JogodoMilion();
	}
}
