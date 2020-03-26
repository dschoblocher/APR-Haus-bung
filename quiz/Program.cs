using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Game spiel = new Game();


            Question f1 = new Question("Welches Virus beschäftigt uns zurzeit extrem?");
            f1.AddAnswer(new Answer("HIV"));
            f1.AddAnswer(new Answer("Coronavirus", true));
            spiel.AddQuestion(f1);

            Question f2 = new Question("Aus welchem Land ist das Coronavirus?");
            f2.AddAnswer(new Answer("Thailand"));
            f2.AddAnswer(new Answer("Brasilien"));
            f2.AddAnswer(new Answer("China", true));
            f2.AddAnswer(new Answer("Deutschland"));
            spiel.AddQuestion(f2);

            Question f3 = new Question("Wie viele Menschen sind zurzeit (26.03.2020) an Covid-19 in Österreich gestorben?");
            f3.AddAnswer(new Answer("2"));
            f3.AddAnswer(new Answer("60"));
            f3.AddAnswer(new Answer("106"));
            f3.AddAnswer(new Answer("42", true));
            spiel.AddQuestion(f3);


            while (spiel.Status == GameStatus.Active)
            {
                var frage = spiel.NextQuestion;
                var antworten = frage.Answers;

                int counter = 1;

                Console.WriteLine(frage.Text);

                foreach (var item in antworten)
                {
                    Console.WriteLine("{0}.) {1}", counter, item.Text);
                    counter++;

                }

                Console.Write("Eingabe: ");

                int eingabe = Convert.ToInt32(Console.ReadLine());


                antworten[eingabe].IsChecked = true;

                spiel.ValidateCurrentQuestion();

            }



            if (spiel.Status == GameStatus.HasFinished)
            {
                Console.WriteLine("Gratulation! Sie haben dieses Quiz erfolgreich durchgespielt!");
            }
            else
            {
                Console.WriteLine("Sie haben leider verloren!");
            }
        }
    }
}
