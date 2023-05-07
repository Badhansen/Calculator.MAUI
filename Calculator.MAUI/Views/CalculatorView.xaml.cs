using Calculator.MAUI.ViewModels;

namespace Calculator.MAUI.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
		InitializeComponent();
		this.BindingContext = new CalculatorViewModel();
	}
}
