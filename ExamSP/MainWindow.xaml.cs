using PersonsCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamSP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickTaskOne(object sender, RoutedEventArgs e)
        {
            buttonTask1.Visibility = Visibility.Collapsed;
            textBlockNumber.Visibility = Visibility.Visible;
            textBoxNumber.Visibility = Visibility.Visible;
            buttonGenerated.Visibility = Visibility.Visible;
            listArray.Visibility = Visibility.Visible;

            buttonTask2.Visibility = Visibility.Visible;
            textBlockName.Visibility = Visibility.Collapsed;
            textBlockSurname.Visibility = Visibility.Collapsed;
            textBlockAge.Visibility = Visibility.Collapsed;
            textBlockBirthCountry.Visibility = Visibility.Collapsed;
            textBlockPhoneNumber.Visibility = Visibility.Collapsed;
            textBoxName.Visibility = Visibility.Collapsed;
            textBoxSurname.Visibility = Visibility.Collapsed;
            textBoxAge.Visibility = Visibility.Collapsed;
            textBoxBirthCountry.Visibility = Visibility.Collapsed;
            textBoxPhoneNumber.Visibility = Visibility.Collapsed;
            buttonSave.Visibility = Visibility.Collapsed;

        }

        private void ButtonClickTaskTwo(object sender, RoutedEventArgs e)
        {
            buttonTask2.Visibility = Visibility.Collapsed;
            textBlockName.Visibility = Visibility.Visible;
            textBlockSurname.Visibility = Visibility.Visible;
            textBlockAge.Visibility = Visibility.Visible;
            textBlockBirthCountry.Visibility = Visibility.Visible;
            textBlockPhoneNumber.Visibility = Visibility.Visible;
            textBoxName.Visibility = Visibility.Visible;
            textBoxSurname.Visibility = Visibility.Visible;
            textBoxAge.Visibility = Visibility.Visible;
            textBoxBirthCountry.Visibility = Visibility.Visible;
            textBoxPhoneNumber.Visibility = Visibility.Visible;
            buttonSave.Visibility = Visibility.Visible;

            buttonTask1.Visibility = Visibility.Visible;
            textBlockNumber.Visibility = Visibility.Collapsed;
            textBoxNumber.Visibility = Visibility.Collapsed;
            buttonGenerated.Visibility = Visibility.Collapsed;
            listArray.Visibility = Visibility.Collapsed;

        }

        private async void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            using (var context = new ContextPersons())
            {
                CharacterPerson persons = new CharacterPerson
                {
                    FirstName = textBoxName.Text,
                    SecondName = textBoxSurname.Text,
                    Age = int.Parse(textBoxAge.Text),
                    Country = textBoxBirthCountry.Text,
                    PhoneNumber = textBoxPhoneNumber.Text
                };
                context.CharacterPeople.Add(persons);
                await context.SaveChangesAsync();
            }
        }

        private object lockObject = new object();

        int[] mas = new int[1];

        int numbers = 1;

        private void ButtonClickGenerated(object sender, RoutedEventArgs e)
        {
            ShowArray();
        }

        public void ShowArray()
        {
            numbers = int.Parse(textBoxNumber.Text);
            var threads = new Thread[numbers];
                mas = new int[numbers];
                for (int i = 0; i < threads.Length; i++)
                {
                    var thread = new Thread(CalculateGeneral);
                    threads[i] = thread;
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }
                foreach (var i in mas)
                {
                    listArray.Items.Insert(i, i);
                }
        }

        private void CalculateGeneral(object count)
        {
            lock (lockObject)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = i;
                }
            }
        }
    }
}
