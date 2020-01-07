using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.Tips
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipsView : ContentPage
    {
        List<Tip> Tips;
        int DisplayedTips = 0;
        Tip displayedTip;
        public TipsView()
        {
            Tips = new List<Tip>();
            GenerateTips();
            DisplayedTips = 0;
            displayedTip = GetRandomTip();

            InitializeComponent();

            DisplayTip();
        }

        private void onNextTextClicked(object sender, EventArgs e)
        {
            displayedTip = GetRandomTip();
            DisplayTip();
        }

        private Tip GetRandomTip()
        {
            var tip = Tips.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (tip!= default)
            {
                Tips.Remove(tip);
                DisplayedTips++;
                return tip;
            }
            else
                return null;
        }

        private void DisplayTip()
        {
            if (displayedTip != null)
            {
                Img.Source = displayedTip.Image;
                LabelText.Text = displayedTip.Description;
                NextTipButton.IsVisible = true;
            }
            else if (displayedTip == null && DisplayedTips > 0)
            {
                Img.Source = "icons8questionmark100.png";
                LabelText.Text = "Nie posiadam więcej ciekawostek.";
                NextTipButton.BackgroundColor = Color.Gray;
            }
            else
            {
                Img.Source = "icons8questionmark100.png";
                LabelText.Text = "Nie posiadam żadnych ciekawostek.";
                NextTipButton.BackgroundColor = Color.Gray;
            }
        }

        public void GenerateTips()
        {
            Tips.Add(new Tip { Image = "icons8insecticide96.png", Description = "Opakowania po żywności czy kosmetykach opróżniamy, ale nie musimy ich myć – o ile gmina wyraźnie tego nie zaleca." });
            Tips.Add(new Tip { Image = "icons8cola.png", Description = "Jeśli opakowanie ma etykietę z folii termokurczliwej, o ile to możliwe, należy ją zdjąć." });
            Tips.Add(new Tip { Image = "icons8loveletter96.png", Description = "Z kopert z folią bąbelkową można (choć nie trzeba) odedrzeć papier i wyrzucić go do pojemnika na papier." });
            Tips.Add(new Tip { Image = "icons8emptyjamjar96.png", Description = "Aluminiowe wieczka przed wyrzuceniem oddzielamy od pojemników." });
            Tips.Add(new Tip { Image = "icons8tape96.png", Description = "Jeśli to możliwe, z kartonowych paczek usuwamy taśmę klejącą i wyrzucamy ją do odpadów zmieszanych." });
            Tips.Add(new Tip { Image = "icons8nofood96.png", Description = "Zabrudzone lub zatłuszczone części papieru (np. pudełek po pizzy) odrywamy i wyrzucamy do pojemnika na odpady zmieszane." });
            Tips.Add(new Tip { Image = "icons8copybook96.png", Description = "Z zeszytów czy gazet nie trzeba wyrywać zszywek." });
            Tips.Add(new Tip { Image = "icons8calendar96.png", Description = "Z książek czy kalendarzy oddzielamy duże elementy (np. okładki czy ramki)." });
            Tips.Add(new Tip { Image = "icons8glassjar96.png", Description = "Opróżnione słoiki wyrzucamy do pojemnika na odpady szklane, natomiast nakrętkę do właściwego ze względu na tworzywo pojemnika." });
            Tips.Add(new Tip { Image = "icons8emptyjamjar96.png", Description = "Słoików nie trzeba ich myć, o ile gmina wyraźnie tego nie zaleca." });
            Tips.Add(new Tip { Image = "icons8pape96.png", Description = "Odpady biodegradowalne można wrzucać do pojemnika BIO tylko w opakowaniach biodegradowalnych np. z papieru, ale niezadrukowanych." });
            Tips.Add(new Tip { Image = "icons8tea96.png", Description = "Zużytą torebkę z herbatą wyrzucamy do pojemnika na odpady zmieszane. Można też jednak z torebki oddzielić herbatę i wrzucić ją do pojemnika na odpady biodegradowalne, a papierową torebkę do pojemnika na odpady zmieszane. Rozwiązanie zależy od gminy." });
            Tips.Add(new Tip { Image = "icons8cheese96.png", Description = "W niektórych gminach jest możliwe – choć niewskazane – wyrzucanie nabiału, sera, jaj do pojemnika na odpady BIO." });
            Tips.Add(new Tip { Image = "icons8kawaiifrenchfries96.png", Description = "Opróżnij opakowanie z resztek żywności." });
            Tips.Add(new Tip { Image = "icons8fragile.png", Description = "Odpady bio i szkło wyrzucaj bez worków." });
            Tips.Add(new Tip { Image = "icons8bottlecap96.png", Description = "Odkręć metalowe i plastikowe nakrętki (nie musisz zdzierać etykiet)." });
            Tips.Add(new Tip { Image = "icons8bottleofwater96.png", Description = "Zgnieć plastikowe butelki, puszki i kartony (zajmą mniej miejsca)." });
            Tips.Add(new Tip { Image = "icons8brokenbottle96.png", Description = "Nie wrzucaj szkła do innych odpadów. Potłuczone butelki w odpadach zmieszanych utrudniają pracę w instalacjach odzyskujących surowce wtórne i nie pozwalają na uzyskanie wysokiej jakości kompostu." });
            Tips.Add(new Tip { Image = "icons8champagne96.png", Description = "Jeśli masz możliwość rozdzielaj szkło bezbarwne (pojemniki białe) i kolorowe (pojemniki białe)." });
            Tips.Add(new Tip { Image = "icons8compostheap96.png", Description = "Jeżeli masz taką możliwości, w ogródku postaw kompostownik. Ułatwi to znacznie sprawę utylizacji części śmieci organicznych." });
            Tips.Add(new Tip { Image = "icons8fridge96.png", Description = "Zużyty sprzęt elektryczny i elektroniczny, meble i inne odpady wielkogabarytowe, zużyte opony będą odbierane raz w miesiącu z nieruchomości, a także przez cały rok w Punkcie Selektywnego Zbierania Odpadów Komunalnych." });
            Tips.Add(new Tip { Image = "icons8lowbattery96.png", Description = "Zużyte baterie należy zdawać do wyznaczonych punków znajdujących się w budynkach użyteczności publicznej." });
            Tips.Add(new Tip { Image = "icons8lightbulb96.png", Description = "Akumulatory i żarówki należy oddawać do sklepów przy zakupie nowych lub  przez cały rok do Punktów Selektywnego Zbierania Odpadów Komunalnych." });
            Tips.Add(new Tip { Image = "icons8pill96.png", Description = "Przeterminowane leki należy zdawać do wyznaczonych aptek.." });
            Tips.Add(new Tip { Image = "icons8carbattery96.png", Description = "Miejscem zbierania zużytych baterii i akumulatorów małogabarytowych są ogólnodostępne pojemniki ustawione w miejscach publicznych." });
            Tips.Add(new Tip { Image = "icons8dose96.png", Description = "Miejscem zbierania przeterminowanych leków są apteki, w których ustawiono ogólnodostępne pojemniki na zbiórkę tych odpadów." });
            Tips.Add(new Tip { Image = "icons8cementbag96.png", Description = "Odpady budowlane i rozbiórkowe można oddać bezpłatnie do PSZOK w ilości do 0,1Mg rocznie." });
            Tips.Add(new Tip { Image = "icons8disposal96.png", Description = "Jeśli masz dużo miejsca, najwygodniejszym rozwiązaniem będzie kosz podzielony na różne frakcje. Możesz również postawić kilka odpowiednio oznaczonych pojemników." });
            Tips.Add(new Tip { Image = "icons8emptytrash96.png", Description = "Na mniejszych powierzchniach możesz ograniczyć ilość koszy do dwóch: do jednego wrzucaj odpady zmieszane, a do drugiego – wszystkie te, które nadają się do odzysku. Gdy pojemnik się wypełni, wyrzuć śmieci pamiętając o podziale na odpowiednie frakcje." });
            Tips.Add(new Tip { Image = "icons8addtag96.png", Description = "Sprawdzaj znak na opakowaniu, który informuje o tym, co należy z nim zrobić po wykorzystaniu zawartości." });
            Tips.Add(new Tip { Image = "icons8chargingbattery96.png", Description = "Zamiast zwykłych, jednorazowych baterii stosuj akumulatorki, które można wielokrotnie ładować." });
            Tips.Add(new Tip { Image = "icons8nobeverages96.png", Description = "Wybierz szklaną butelkę zwrotną zamiast butelki plastikowej. Szklana butelka może być wykorzystana powtórnie nawet 15 razy, podczas gdy butelka plastikowa jest jednorazowa." });
            Tips.Add(new Tip { Image = "icons8package96.png", Description = "Unikaj produktów zapakowanych w wiele warstw." });
            Tips.Add(new Tip { Image = "icons8fork96.png", Description = "Unikaj jednorazowych produktów np. plastikowych sztućców na grilla czy papierowych talerzyków." });
            Tips.Add(new Tip { Image = "icons8shoppingbag96.png", Description = "Jeśli wybieras się na zakupy, staraj się zabierać własną torbę do pakowania zakupów." });
            Tips.Add(new Tip { Image = "icons8muscle96.png", Description = "Wybieraj produkty trwałe." });
            Tips.Add(new Tip { Image = "icons8outgoingcall96.png", Description = "Jeśli nie jesteśmy pewni, gdzie wyrzucić dany odpad, możemy skontaktować się z Urzędem Gminy odpowiednim dla naszego miejsca zamieszkania. Tam uzyskamy informacje czy podlega on segregacji i w którym pojemniku powinien się znaleźć." });
        }

        class Tip
        {
            public string Image { get; set; }
            public string Description { get; set; }
        }
    }
}