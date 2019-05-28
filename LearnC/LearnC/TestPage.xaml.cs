using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        Dictionary<string, Switch[]> AnswerSwitchers { get; set; }

        Dictionary<string, (bool[], bool[])> Answers { get; set; }

        Dictionary<string, Grid> Grids { get; set; }

        private int ChapterId { get; set; }

        public TestPage(Model.Test test)
        {
            AnswerSwitchers = new Dictionary<string, Switch[]>();
            StackLayout gridLayout = new StackLayout
            { Padding = 10, BackgroundColor = Color.WhiteSmoke };
            ScrollView scrollView = new ScrollView();
            Grids = new Dictionary<string, Grid>();
            scrollView.Content = gridLayout;
            StackLayout stackLayout = new StackLayout
            { Children = {scrollView }, BackgroundColor = Color.DarkKhaki };
            SetAnswers(test);
            ChapterId = test.Id + 1;
            Title = $"Тест {ChapterId}";

            foreach (var quastion in test.Quastions.Keys)
            {
                Grid grid = new Grid
                {
                    ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                            new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) }
                        }
                };
                grid.RowDefinitions = new RowDefinitionCollection();
                grid.RowDefinitions.Add(new RowDefinition
                { Height = new GridLength(1, GridUnitType.Star) });
                Label quastionLabel = new Label
                {
                    FontSize = 16,
                    Text = quastion,
                    TextColor = Color.Black
                };
                grid.Children.Add(quastionLabel, 0, 0);
                Grid.SetColumnSpan(quastionLabel, 2);
                AnswerSwitchers.Add(quastion,
                    new Switch[test.Quastions[quastion].Length]);
                for (int i = 0; i < test.Quastions[quastion].Length; i++)
                    InitializeGridWithSwitchers(ref grid, test, 
                        quastion, i);
                grid.Margin = 5;
                Grids.Add(quastion, grid);
                gridLayout.Children.Add(grid);
            }

            CreateButton(out Button button);
            stackLayout.Children.Add(button);

            Content = stackLayout;
            InitializeComponent();
        }

        private void InitializeGridWithSwitchers(ref Grid grid, in Model.Test test,
            in string quastion, in int number)
        {
            grid.RowDefinitions.Add(new RowDefinition
            { Height = new GridLength(1, GridUnitType.Star) });
            AnswerSwitchers[quastion][number] = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            AnswerSwitchers[quastion][number].IsToggled =
                Answers[quastion].Item2[number];

            InitializeGridRow(ref grid, test, quastion, number);
        }

        private void InitializeGridRow(ref Grid grid, in Model.Test test,
            in string quastion, in int number)
        {
            grid.Children.Add(AnswerSwitchers[quastion][number], 0, number + 1);

            grid.Children.Add(new Label
            {
                Text = test.Quastions[quastion][number],
                VerticalOptions = LayoutOptions.CenterAndExpand
            }, 1, number + 1);
        }

        void SetAnswers(in Model.Test test)
        {
            Answers = new Dictionary<string, (bool[], bool[])>();

            for (int i = 0; i < test.Quastions.Keys.ToArray().Length; i++)
            {
                bool[] userAnswers = new bool[test.Answers[i].Length],
                    correctAnswers = test.Answers[i];
                for (int j = 0; j < correctAnswers.Length; j++)
                    userAnswers[j] = false;
                Answers.Add(test.Quastions.Keys.ToArray()[i],
                    (correctAnswers, userAnswers));
            }
        }

        private void CreateButton(out Button button)
        {
            button = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Text = "Завершить тест",
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                Margin = 2
            };

            button.Clicked += OnButtonClicked;
        }

        private async void SwitcherClicked(object sender, System.EventArgs e)
        {
            Switch switcher = (Switch)sender;

            //switcher.Parent
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            int score = 0;
            bool flag;

            foreach (var question in Answers.Keys)
            {
                bool[] correctAnswers = Answers[question].Item1;
                bool[] userAnswers =
                    new bool[AnswerSwitchers[question].Length];
                for (int i = 0; i < userAnswers.Length; i++)
                    userAnswers[i] = AnswerSwitchers[question][i].IsToggled;
                flag = true;
                for (int i = 0; i < userAnswers.Length; i++)
                    if (userAnswers[i] != correctAnswers[i])
                        flag = false;
                if (flag) score++;
            }

            string result;
            if (score == AnswerSwitchers.Keys.ToArray().Length)
            {
                result = "Поздравляем! Вы открыли новый раздел!";
                App.Current.Properties[$"Глава {ChapterId}"] = true;
            }
            else
                result = "Подучите и поробуйте еще!";
            App.Current.Properties[$"Глава {ChapterId}"] = true;

            await DisplayAlert($"Ваш результат: {score}", $"{result}", "OK");
        }
    }
}