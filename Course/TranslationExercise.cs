/**************************************************************************
 *                                                                        *
 *  File:        TranslationExercise.cs                                   *
 *  Copyright:   (c) 2019-2020, Andreea Bianca Caprian                    *
 *  E-mail:      andreea-bianca.caprian@student.tuiasi.ro                 *
 *  Description: "Engleza fara profesor" application                      *
 *               TranslationExercise (Software Engineering)               *
 *                                                                        *
 *  This code represents the implementation of the "fill-in" type of      *
 *  exercise.The code is customized to this  application, so it           *
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
    /// A class containing a Romanian term and corresponding English term
    /// </summary>
    public class TranslationExercise : IExercise
    {
        static public readonly string Label = "Tradu acest cuvant in engleza:";
        public readonly string RomanianVersion;
        public readonly string EnglishVersion;

        /// <summary>
        /// TranslationExercise constructor
        /// </summary>
        /// <param name="romanian">Romanian term</param>
        /// <param name="english">English term</param>
        public TranslationExercise(string romanian, string english)
        {
            RomanianVersion = romanian;
            EnglishVersion = english;
        }

        /// <summary>
        /// Verify if the provided answer matches English term provided in exercise class constructor
        /// </summary>
        /// <param name="answer">User's answer</param>
        /// <returns>True, if answer matches English term, false otherwise</returns>
        public bool IsCorrect(string answer)
        {
            if (answer.Trim().ToLower() == EnglishVersion)
                return true;
            else return false;
        }

        /// <summary>
        /// Calls view's method specialised in displaying TranslationExercises
        /// </summary>
        /// <param name="view">Concrete view used by the application</param>
        public void Display(IView view)
        {
            view.ShowExercise(this);
        }
    }
}
