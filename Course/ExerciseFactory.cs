/**************************************************************************
 *                                                                        *
 *  File:        ExerciseFactory.cs                                       *
 *  Copyright:   (c) 2019-2020, Andreea Bianca Caprian                    *
 *  E-mail:      andreea-bianca.caprian@student.tuiasi.ro                 *
 *  Description: "Engleza fara profesor" application                      *
 *               ExerciseFactory (Software Engineering)                   *
 *                                                                        *
 *  This code represents the random generation of two different types     *
 *  of exercises. The code is customized to this application, so it is    *
 *  not recommended to use it in other applications.                      *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;

namespace CourseNamespace
{
    /// <summary>
    /// Creates objects from concrete classes, but returns an generic IExercise. Hides implementation details for creating an exercise. 
    /// </summary>
    public class ExerciseFactory
    {
        private static Random _random = new Random();
        private static List<Tuple<string, string>>[] _dictionary = new List<Tuple<string, string>>[Enum.GetNames(typeof(WordType)).Length];

        /// <summary>
        /// Instantiates an exercise of random type
        /// </summary>
        /// <param name="wordType">Category of words to be used for exercise's fields</param>
        /// <returns>An generic IExercise</returns>
        public static IExercise CreateExercise(WordType wordType)
        {
            //Check if words of needed type are loaded and if not, try to load. Throw an error if no words matching the category are found
            if (_dictionary[(int)wordType] == null)
                _dictionary[(int)wordType] = GetWordsByType(wordType);
            if (_dictionary[(int)wordType].Count == 0)
                throw new ArgumentException($"Nu s-a reusit incarcarea cuvintelor de tipul { wordType.ToString() }!Fisierul 'dictionary.db' este corupt!Asigurati integritatea fisierului si reporniti aplicatia!");

            ExerciseType exerciseType = (ExerciseType)_random.Next(Enum.GetNames(typeof(ExerciseType)).Length);
            
            Tuple<string, string> tuple = _dictionary[(int)wordType][_random.Next(0, _dictionary[(int)wordType].Count)];

            switch (exerciseType)
            {
                case ExerciseType.TranslationExercise:
                    return new TranslationExercise(tuple.Item1, tuple.Item2);

                case ExerciseType.ChoiceExercise:
                    //throw an error to prevent infinite loop
                    if (_dictionary[(int)wordType].Count < 4)
                        throw new ArgumentException($"Nu sunt destule cuvinte de tipul { wordType.ToString() }!Fisierul 'dictionary.db' este corupt!Asigurati integritatea fisierului si reporniti aplicatia!");

                    //create an option list with no duplicates
                    string[] englishWords = new string[4];
                    for (int i = 0; i < 3; i++)
                        englishWords[i]=_dictionary[(int)wordType][_random.Next(0, _dictionary[(int)wordType].Count)].Item2;
                    englishWords[3] = tuple.Item2;
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            if (i != j)
                                if (englishWords[i] == englishWords[j])
                                    englishWords[j]= _dictionary[(int)wordType][_random.Next(0, _dictionary[(int)wordType].Count)].Item2;

                    return new ChoiceExercise(tuple.Item1, tuple.Item2,englishWords);

                default:
                    throw new ArgumentException("Tip de cuvinte nerecunoscut!");
            }
        }

        /// <summary>
        ///  Get all the words belonging to specified category 
        /// </summary>
        /// <param name="wordType">A WordType enum member</param>
        /// <returns>A list of string pairs containing Romanian word and correspondent translation</returns>
        private static List<Tuple<string, string>> GetWordsByType(WordType wordType)
        {
            return DBConnection.Instance().GetWordsByType(wordType.ToString());
        }
    }

}
