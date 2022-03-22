/**************************************************************************
 *                                                                        *
 *  File:        ChoiceExercise.cs                                        *
 *  Copyright:   (c) 2019-2020, Andreea Bianca Caprian                    *
 *  E-mail:      andreea-bianca.caprian@student.tuiasi.ro                 *
 *  Description: "Engleza fara profesor" application                      *
 *               ChoiceExercise (Software Engineering)                    *
 *                                                                        *
 *  This code represents the implementation of the type of exercise with  *
 *  answer options.The code is customized to this  application, so it     *
 *  is not recommended to use it in other applications.                   *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseNamespace
{
    /// <summary>
    /// A class containing a Romanian term, corresponding English term and a list of options to choose the right answer from
    /// </summary>
    public class ChoiceExercise : IExercise
    {
        static public readonly string Label = "Cum se traduce acest cuvant in engleza?";
        public readonly string RomanianVersion;
        public readonly string EnglishVersion;
        public readonly string[] Options;
        private static Random _random = new Random();

        /// <summary>
        /// ChoiceExercise constructor
        /// </summary>
        /// <param name="romanian">Romanian term</param>
        /// <param name="english">English term</param>
        /// <param name="others">Other word options to choose from</param>
        public ChoiceExercise(string romanian,string english, string[] others)
        {
            RomanianVersion = romanian;
            EnglishVersion = english;

            //in options cuvantul corect se afla pe ultima pozitie
            Options = new string[4];
            others.CopyTo(Options, 0);
            int index = _random.Next(0, 4);
            string temp = Options[3];
            Options[3] = Options[index];
            Options[index] = temp;
        }

        /// <summary>
        /// Verify if the provided answer matches English term provided in exercise class constructor
        /// </summary>
        /// <param name="answer">User's answer</param>
        /// <returns>True, if answer matches English term, false otherwise</returns>
        public bool IsCorrect(string answer)
        {
            if (answer == EnglishVersion)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Calls view's method specialised in displaying ChoiceExercises
        /// </summary>
        /// <param name="view">Concrete view used by the application</param>
        public void Display(IView view)
        {
            view.ShowExercise(this);
        }
    }
}
