/**************************************************************************
 *                                                                        *
 *  File:       IExercise.cs                                              *
 *  Copyright:   (c) 2019-2020, Maria Mesina                              *
 *  E-mail:      maria.mesina@student.tuiasi.ro                           *
 *  Description: "Engleza fara profesor" application                      *
 *                IExercise (Software Engineering)                        *
 *                                                                        *
 *  This code describes the IExercise interface,                          *
 *  which facilitates the creation of two types of exercises:             *
 *  ChoiceExercise and TranslationExercise.The code is customized to      *
 *  this application, so it is not recommended to use it in other         *
 *  applications.                                                         *         
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseNamespace
{
    /// <summary>
    /// Word Types
    /// </summary>
    public enum WordType
    {
        /// <summary>An object, place, action, quality, state of existence, or idea</summary>
        Noun,
        /// <summary>An action, an occurrence, or a state of being</summary>
        Verb,
        /// <summary>A word that modifies a verb or a noun</summary>
        Adjective,
        /// <summary>Human beings in general, family members or names of professions & occupations</summary>
        People,
        /// <summary>Animals, birds, reptiles, insects</summary>
        Animal
    };

    /// <summary>
    /// Word Exercise Types
    /// </summary>
    public enum ExerciseType
    {
        /// <summary>An exercise in which you have to traslate a term in Romanian to English</summary>
        TranslationExercise,
        /// <summary>An exercise in which you have to choose the right English term for an Romanian word</summary>
        ChoiceExercise
    };

    /// <summary>
    /// Common interface for all types of exercises
    /// </summary>
    public interface IExercise
    {
        /// <summary>
        /// Verify if the providen answer is the correct one
        /// </summary>
        /// <param name="answer">String representing provided answer</param>
        /// <returns>True if string matches correct answer, false otherwise</returns>
        bool IsCorrect(string answer);

        /// <summary>
        /// An intermediate step to avoid type-casting for displaying different types of exercises
        /// Must call IVIew method ShowExercise
        /// </summary>
        /// <param name="view">Concrete implementation of IView</param>
        void Display(IView view);
    }
}
