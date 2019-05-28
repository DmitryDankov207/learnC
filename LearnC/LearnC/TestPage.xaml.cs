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
            
            int n = 0;
            try
            {
                StackLayout stackLayout = new StackLayout();
                ScrollView scrollView = new ScrollView();
                scrollView.Content = stackLayout;

                SetAnswers(test);
                n = 1;
                foreach (var quastion in test.Quastions.Keys)
                {
                    n = 2;
                    Grid grid = new Grid
                    {
                        ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                            new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) }
                        }
                    };
                    n = 3;
                    grid.RowDefinitions = new RowDefinitionCollection();
                    n = 4;
                    grid.RowDefinitions.Add(new RowDefinition
                    { Height = new GridLength(1, GridUnitType.Star) });
                    Label quastionLabel = new Label
                    {
                        FontSize = 16,
                        Text = quastion
                    };
                    grid.Children.Add(quastionLabel, 0, 0);
                    Grid.SetColumnSpan(quastionLabel, 2);
                    n = 5;
                    AnswerSwitchers = new Dictionary<string, Switch[]>();
                    n = 6;
                    AnswerSwitchers.Add(quastion,
                        new Switch[test.Quastions[quastion].Length]);
                    n = 7;
                    for (int i = 0; i < test.Quastions[quastion].Length; i++)
                    {
                        n = 8;
                        grid.RowDefinitions.Add(new RowDefinition
                        { Height = new GridLength(1, GridUnitType.Star) });
                        n = 9;
                        AnswerSwitchers[quastion][i] = new Switch
                        {
                            IsToggled = false,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center
                        };

                        /*Binding binding = new Binding
                        {
                            Source = Answers[quastion].Item2[i],
                            Mode = BindingMode.TwoWay
                        };
                        AnswerSwitchers[quastion][i].SetBinding(
                            AnswerSwitchers[quastion][i].IsToggled, binding);*/

                        AnswerSwitchers[quastion][i].IsToggled =
                            Answers[quastion].Item2[i];

                        grid.Children.Add(AnswerSwitchers[quastion][i], 0, i + 1);
                        n = 10;

                        grid.Children.Add(new Label
                        { Text = test.Quastions[quastion][i] }, 1, i + 1);
                        n = 11;
                    }
                    grid.Margin = 5;
                    stackLayout.Children.Add(grid);
                    n = 12;
                }

                Button button = new Button
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                button.Clicked += OnButtonClicked;

                stackLayout.Children.Add(button);

                Content = stackLayout;
                n = 13;
                InitializeComponent();
            }
            catch (Exception e)
            {
                Content = new StackLayout
                {
                    Children =
                            {
                                new Label{Text = n.ToString() + e.Message}
                            }
                };
                InitializeComponent();
                return;
            }
            
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            int score = 0;
            bool flag;
            int n = 0;
            try
            {
                foreach (var question in Answers.Keys)
                {
                    n = 1;
                    bool[] correctAnswers = Answers[question].Item1;
                    //Switch[] switchers = AnswerSwitchers[question];
                    n = 2;
                    bool[] userAnswers =
                        new bool[AnswerSwitchers[question].Length];
                    n = 3;
                    for (int i = 0; i < userAnswers.Length; i++)
                        userAnswers[i] = AnswerSwitchers[question][i].IsToggled;
                    n = 4;
                    flag = true;
                    for (int i = 0; i < userAnswers.Length; i++)
                        if (userAnswers[i] != correctAnswers[i])
                            flag = false;
                    n = 5;
                    if (flag) score++;
                }
            }
            catch(Exception)
            {
                await DisplayAlert($"{n}", $" ", "OK");
            }
            await DisplayAlert("Your score is:", $"{score}", "OK");
        }
    }
}