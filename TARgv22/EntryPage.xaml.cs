using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Label label;
        public EntryPage()
        {
            Editor editor = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor=Color.AntiqueWhite,
                TextColor= Color.MediumPurple
            };
            editor.TextChanged += Editor_TextChanged;
            label = new Label
            {
                Text = "Pealkiri",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.AntiqueWhite,
                BackgroundColor = Color.MediumPurple
            };

            Button b = new Button
            {
                Text = "To Start Page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            b.Clicked += B_Clicked;

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {label, editor, b},
                BackgroundColor= Color.Lavender,
            };
            Content = st;
        }
        int i = 0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Получаем текст из Editor
            string text = e.NewTextValue ?? string.Empty;

            // Подсчитываем количество букв 'A' в тексте
            i = text.Count(c => c == 'A');

            // Обновляем счетчик в label
            label.Text = "A: " + i.ToString();
        }


        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}