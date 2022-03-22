/**************************************************************************
 *                                                                        *
 *  File:       IView.cs                                                  *
 *  Copyright:   (c) 2019-2020, Maria Mesina                              *
 *  E-mail:      maria.mesina@student.tuiasi.ro                           *
 *  Description: "Engleza fara profesor" application                      *
 *                IView (Software Engineering)                            *
 *                                                                        *
 *  This code describes IView interface, which                         x   *
 *  facilitates the visualization of different types of exercises.        *
 *  The code is customized to this  application, so it is not             * 
 *  recommended to use it in other applications.                          *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IView inteface is used to allow different implementations of user interface, making it available to higher layers to create custom views
/// The user interface has to implement the IView class in order for different types of exercises to be displayed
/// </summary>
namespace CourseNamespace
{
    public interface IView
    {
        /// <summary>
        /// Method specialised in displaying TranslationExercises 
        /// </summary>
        /// <param name="ex">TranslationExercise to be displayed</param>
        void ShowExercise(TranslationExercise ex);

        /// <summary>
        /// Method specialised in displaying ChoiceExercises 
        /// </summary>
        /// <param name="ex">ChoiceExercise to be displayed</param>
        void ShowExercise(ChoiceExercise ex);
    }
}
