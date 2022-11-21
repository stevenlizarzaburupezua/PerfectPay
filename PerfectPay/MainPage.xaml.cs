namespace PerfectPay;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int nroPersons = 1;

	public MainPage()
	{
		InitializeComponent();
	}

	private void txtBill_Completed(object sender, EventArgs e)
	{
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
	}

	private void CalculateTotal()
	{
		//Total Tip
		var totalTip = (bill * tip) / 100;
			
		var tipByperson = (totalTip / nroPersons);
		lblTipByPerson.Text = $"{tipByperson:C}";

		//SubTotal
		var subtotal = (bill / nroPersons);
		lblSubtotal.Text = $"{subtotal:C}";	

		//Total
		var totalByPerson = (bill + totalTip) / nroPersons;
		lblTotal.Text = $"{totalByPerson:C}";
	}

	private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tip: {tip}%";
		CalculateTotal();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		if (sender is Button)
		{
			var btn = (Button)sender;
			var percentage = int.Parse(btn.Text.Replace("%",""));
			sldTip.Value = percentage;
		}
	}

	private void btnMinus_Clicked(object sender, EventArgs e)
	{
		if (nroPersons > 1)
		{
			nroPersons--;
		}
		lblNoPerons.Text = nroPersons.ToString();
		CalculateTotal();
	}

	private void btnPlus_Clicked(object sender, EventArgs e)
	{
		nroPersons++;
		lblNoPerons.Text = nroPersons.ToString();
		CalculateTotal();
	}
}

