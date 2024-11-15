using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroDeEvento : ContentPage
{
	public CadastroDeEvento()
	{
		InitializeComponent();

        data_inicio.MinimumDate = DateTime.Now;
        data_inicio.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        data_termino.MinimumDate = data_inicio.Date.AddDays(1);
        data_termino.MaximumDate = data_inicio.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento h = new Evento
            {
                NomeDoEvento = nome_evento.Text,
                NumeroDeParticipante = Convert.ToInt32(numero_participantes.Value),
                DataInicio = data_inicio.Date,
                DataTermino = data_termino.Date,
                LocalDoEvento = local_evento.Text,
                CustoPorPaciente = Convert.ToInt32(custo_paciente.Text)
            };

            await Navigation.PushAsync(new DetalhesDoEvento()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void data_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        data_termino.MinimumDate = data_selecionada_checkin.AddDays(1);
        data_termino.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }

    private void nome_evento_Focused(object sender, FocusEventArgs e)
    {

    }
}