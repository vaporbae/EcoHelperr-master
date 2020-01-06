using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.DoNotBurnWaste
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoNotBurnWasteView : ContentPage
    {
        List<Tip> Tips;
        int position = 0;
        public DoNotBurnWasteView()
        {
            Tips = new List<Tip>();
            GenerateTips();
            InitializeComponent();
            LeftArrowButton.IsEnabled = false;
            
        }

        private void UpdateTip()
        {
            if (position == 0)
            {
                Img.Source = Tips[0].Image;
                LabelText.Text = Tips[0].Description;
                LeftArrowButton.IsEnabled = false;
            }
            else if(position == Tips.Count())
            {
                Img.Source = Tips[Tips.Count()-1].Image;
                LabelText.Text = Tips[Tips.Count()-1].Description;
                RightArrowButton.IsEnabled = false;
            }
            else
            {
                Img.Source = Tips[position].Image;
                LabelText.Text = Tips[position].Description;
                LeftArrowButton.IsEnabled = true;
                RightArrowButton.IsEnabled = true;
            }
        }

        private void onGoLeftClicked(object sender, EventArgs e)
        {
            position--;
            UpdateTip();
        }

        private void onGoRightClicked(object sender, EventArgs e)
        {
            position++;
            UpdateTip();
        }

        public void GenerateTips()
        {
            Tips.Add(new Tip { Image = "icons8poison96.png", Description = "W czasie spalania śmieci powstają substancje, które mają silne działanie rakotwórcze iśmiercionośne." });
            Tips.Add(new Tip { Image = "icons8sprout96.png", Description = "Chorobotwórcze substancje przedostają się do otoczenia - są w powietrzu, osiadają na roślinach i przedmiotach i pozostają tam długi czas." });
            Tips.Add(new Tip { Image = "icons8waiter96.png", Description = "Następnie wraz z pożywieniem, na którym się osadziły i z wdychanym powietrzem dostają się do organizmu." });
            Tips.Add(new Tip { Image = "icons8lungs96.png", Description = "Dioksyny i furany powstające w czasie spalania nieodwracalnie niszczą zdrowie powodując nowotwory wątroby i płuc, mają działanie alergiczne oraz uszkadzają płód i strukturę kodu genetycznego człowieka.​" });
            Tips.Add(new Tip { Image = "icons8bacteria96.png", Description = "Związki te to jedne z najsilniejszych trucizn jakie zna ludzkość. Ich działanie toksyczne polega na podstępnym i powolnym, ale niezwykle skutecznym uszkadzaniu komórek w organizmach żywych." });
            Tips.Add(new Tip { Image = "icons8dead96.png", Description = "Niecałe 2 miligramy dioksyn wystarczą by zabić ważącego 80 kg człowieka." });
        }

        class Tip
        {
            public string Image { get; set; }
            public string Description { get; set; }
        }
    }
}