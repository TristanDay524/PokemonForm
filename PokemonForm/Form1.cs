using System;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using PokeAPI;

namespace PokemonForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += getSpeciesButton;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public async void GetSpecies()
        {
            try
            {
                string speciesName = textBox1.Text.ToLower().Trim();
                PokemonSpecies species = await DataFetcher.GetNamedApiObject<PokemonSpecies>(speciesName);

                textBox2.Text = species.Name;
                textBox3.Text = species.BaseHappiness.ToString();
                textBox4.Text = species.CaptureRate.ToString();
                textBox5.Text = species.Habitat?.Name ?? "N/A";
                textBox6.Text = species.GrowthRate?.Name ?? "N/A";
                textBox7.Text = species.FlavorTexts[0].FlavorText;
                    
                textBox8.Text = string.Join(", ", species.EggGroups.Select(g => g.Name));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        public void getSpeciesButton(object sender, EventArgs e)
        {
            GetSpecies();
        }
    }
}
