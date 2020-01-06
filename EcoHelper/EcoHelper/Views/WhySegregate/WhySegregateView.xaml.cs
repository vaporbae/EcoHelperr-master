using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.WhySegregate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WhySegregateView : ContentPage
    {
        List<Tip> Tips;
        int position = 0;
        public WhySegregateView()
        {
            Tips = new List<Tip>();
            GenerateTips();
            InitializeComponent();
            UpdateTip();
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
            else if (position == Tips.Count())
            {
                Img.Source = Tips[Tips.Count() - 1].Image;
                LabelText.Text = Tips[Tips.Count() - 1].Description;
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
            Tips.Add(new Tip { Image = "icons8beach96.png", Description = "Zmniejszamy ilości śmieci, które zanieczyszczają wody, plaże, ziemie, całe środowisko." });
            Tips.Add(new Tip { Image = "icons8acacia96.png", Description = "Zmniejszamy zużycie surowców naturalnych, ponieważ coraz więcej produktów wraca do klientów po recyklingu." });
            Tips.Add(new Tip { Image = "icons8moneybox96.png", Description = "Obniżamy koszty związane z wysypiskami śmieci." });
            Tips.Add(new Tip { Image = "icons8defendfamily96.png", Description = "Polepszamy jakość życia osób, które żyły wcześniej w zanieczyszczonych środowiskach." });
            Tips.Add(new Tip { Image = "icons83dhouse96.png", Description = "Pozyskujemy surowce wtórne, które z powrotem trafiają do klientów." });
            Tips.Add(new Tip { Image = "icons8knowledgetransfer96.png", Description = "Zwiększamy świadomość ekologiczną ludzi." });
            Tips.Add(new Tip { Image = "icons8squirrel96.png", Description = "Mniejsza ilość śmieci oznacza również lepsze warunki do życia dla roślin i zwierząt." });
        }

        class Tip
        {
            public string Image { get; set; }
            public string Description { get; set; }
        }
    }
}