using practica05.PageModels; // <-- agrega esto arriba

namespace practica05.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
        InitializeComponent();
        BindingContext = new ContactoViewModel();
    }
}