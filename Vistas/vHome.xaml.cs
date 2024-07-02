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

        ActualizarListado();
    }

    private void btnListarr_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Persona> people = App.personrepo.GetAllPeople();
        ListarPersonas.ItemsSource = people;
    }

    Persona PersonAux = new Persona();
    private void ListarPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Persona;
        PersonAux = currentSelection;
        if (currentSelection != null)
        {
            DisplayAlert("Seleccionado", $"Has Seleccionado: {currentSelection.Nombre}", "OK");
        }

    }



    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var PersonaAux = button?.BindingContext as Persona;
        if (PersonaAux != null)
        {
            App.personrepo.DeletePerson(PersonaAux);
            DisplayAlert("Eliminando", $"Has Eliminado: {PersonaAux.Nombre}", "OK");
        }

        ActualizarListado();
    }
    private void ActualizarListado()
    {
        status.Text = "";
        List<Persona> people = App.personrepo.GetAllPeople();
        ListarPersonas.ItemsSource = people;
    }


    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var personaAux = button?.BindingContext as Persona;
        if (personaAux != null)
        {
            App.personrepo.UpdatePerson(personaAux);
            DisplayAlert("Actualizando", $"Has Actualizado: {personaAux.Nombre}", "OK");
        }
    }
}