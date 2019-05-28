using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearnC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private void ChangeButtonsStyle()
        {
            if ((bool)App.Current.Properties["Глава 2"])
                chapter2.Style = ActiveButtonStyle;
            if ((bool)App.Current.Properties["Глава 3"])
                chapter3.Style = ActiveButtonStyle;
            if ((bool)App.Current.Properties["Глава 4"])
                chapter4.Style = ActiveButtonStyle;
            if ((bool)App.Current.Properties["Глава 5"])
                chapter5.Style = ActiveButtonStyle;
            if ((bool)App.Current.Properties["Глава 6"])
                chapter6.Style = ActiveButtonStyle;
        }

        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            ChangeButtonsStyle();
        }

        private async void Chapter1_Clicked(object sender, EventArgs e)
        {
            int n = 0;
            List<string> themes = new List<string>
            {
                "Структура программы на Си",
                "Переменные",
                "Типы данных",
                "Консольный вывод. Функция printf",
                "Константы",
                "Арифметические операции",
                "Логические операции и операции отношения",
                "Поразрядные операции",
                "Операции присваивания",
                "Преобразование типов",
                "Условные конструкции",
                "Циклы",
                "Введение в массивы и строки",
                "Ввод в консоли. Функция scanf",
                "Пройти тест по главе 1"
            };
            n = 1;
            Model.Test test = new Model.Test
            {
                Id = 1,
                Answers = new bool[][]
                {
                    new bool[] {false, true, false},
                    new bool[] {false, true, false},
                    new bool[] {false, true, false, false},
                    new bool[] {false, false, true},
                    new bool[] {true, false, true}
                },
                Quastions = new Dictionary<string, string[]>
                     {
                         {"язык Си является ... языком программирования",
                            new string[]
                            {
                                "объектно - ориентированным",
                                "процедурным",
                                "скриптовым"
                            }
                         },
                         {"Тип double может занимать ... бит(а) в памяти",
                            new string[]
                            {
                                "32",
                                "64",
                                "16"
                            }
                         },
                         {"Каким будет результат выполнения данного кода:\n" +
                         "for(size_t i = 0; i < 10; i++)\n" +
                         "    if(i == 10) i = 100;",
                            new string[]
                            {
                                "10",
                                "9",
                                "будет вызвано исключение",
                                "11"
                            }
                         },
                         {"Каким будет результат данного кода: int a = 3 > 5 ? 3 : 5;",
                            new string[]
                            {
                                "3",
                                "код не скомпилируется",
                                "5"
                            }
                         },
                         {"Укажите, где корректно объявлен массив:",
                            new string[]
                            {
                                "int numbers[5] = { 10, 12};",
                                "int numbers[2][3] = { {1, 2}, {4, 5}, {7, 8} };",
                                "char welcome[] = \"Hello\";"
                            }
                         }
                     }
            };
            n = 2;
            try
            {
                //Chapter chapter = new Chapter(themes, test);
                //TabbedPage chapter = new TabbedPage();
                n = 4;
                //foreach (var theme in themes)
                   // await DisplayAlert(theme, n.ToString(), "OK");
                //chapter.Children.Add(new ThemePage(theme, ""));
                n = 5;
                //.Children.Add(new TestPage(test));
                n = 6;
                await Navigation.PushAsync(new Chapter(themes, test), false);
                n = 7;
            }
            catch(NullReferenceException ex)
            {
                await DisplayAlert(ex.Message, n.ToString(), "OK");
            }
        }

        private async void ShowAlert(Button button)
        {
            if (!(bool)App.Current.Properties[button.Text])
                await DisplayAlert("Вы ещё не открыли эту главу!", "", "OK");
        }

        private void Chapter2_Clicked(object sender, EventArgs e)
        {
            ShowAlert((Button)sender);
        }

        private void Chapter3_Clicked(object sender, EventArgs e)
        {
            ShowAlert((Button)sender);
        }

        private void Chapter4_Clicked(object sender, EventArgs e)
        {
            ShowAlert((Button)sender);
        }

        private void Chapter5_Clicked(object sender, EventArgs e)
        {
            ShowAlert((Button)sender);
        }

        private void Chapter6_Clicked(object sender, EventArgs e)
        {
            ShowAlert((Button)sender);
        }
    }
}
