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

        public TestPage(Model.Test test)
        {
            AnswerSwitchers = new Dictionary<string, Switch[]>();
            StackLayout stackLayout = new StackLayout();
            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;

            SetAnswers(test);
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
                    Text = quastion
                };
                grid.Children.Add(quastionLabel, 0, 0);
                Grid.SetColumnSpan(quastionLabel, 2);
                AnswerSwitchers.Add(quastion,
                    new Switch[test.Quastions[quastion].Length]);
                for (int i = 0; i < test.Quastions[quastion].Length; i++)
                {
                    grid.RowDefinitions.Add(new RowDefinition
                    { Height = new GridLength(1, GridUnitType.Star) });
                    AnswerSwitchers[quastion][i] = new Switch
                    {
                        IsToggled = false,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    AnswerSwitchers[quastion][i].IsToggled =
                        Answers[quastion].Item2[i];

                    grid.Children.Add(AnswerSwitchers[quastion][i], 0, i + 1);

                    grid.Children.Add(new Label
                    { Text = test.Quastions[quastion][i] }, 1, i + 1);
                }
                grid.Margin = 5;
                stackLayout.Children.Add(grid);
            }

            Button button = new Button
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            button.Clicked += OnButtonClicked;

            stackLayout.Children.Add(button);

            Content = stackLayout;
            InitializeComponent();
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
            await DisplayAlert("Your score is:", $"{score}", "OK");
        }
    }
}