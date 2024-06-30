using sSandovalS5.Modelos;

namespace sSandovalS5.Vistas;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personrepo.AddNewPerson(txtNombre.Text);
        status.Text = App.personrepo.StatusMessage;
    }

    private void btnListarr_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
       List<Persona> people =App.personrepo.GetAllPeople();
        ListarPersonas.ItemsSource = people;
    }
}