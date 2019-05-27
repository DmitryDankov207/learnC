using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearnC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Chapter1_Clicked(object sender, EventArgs e)
        {
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

            Model.Test test = new Model.Test
            {
                Id = 1,
                Answers = new bool[][]
                {
                    new bool[] {false, true, false},
                    new bool[] {false, true, false},
                    new bool[] {false, false, true}
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
                         {"Тип double занимает ... бит(а) в памяти",
                            new string[]
                            {
                                "32",
                                "64",
                                "16"
                            }
                         },
                         {"Каким будет результат данного кода: int a = 3 > 5 ? 3 : 5;",
                            new string[]
                            {
                                "3",
                                "код не скомпилируется",
                                "5"
                            }
                         }
                     }
            };

            await Navigation.PushAsync(new Chapter(themes, test), false);
        }

        private void Chapter2_Clicked(object sender, EventArgs e)
        {

        }

        private void Chapter3_Clicked(object sender, EventArgs e)
        {

        }

        private void Chapter4_Clicked(object sender, EventArgs e)
        {

        }

        private void Chapter5_Clicked(object sender, EventArgs e)
        {

        }

        private void Chapter6_Clicked(object sender, EventArgs e)
        {

        }
    }
}
