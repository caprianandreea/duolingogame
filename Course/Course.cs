/**************************************************************************
 *                                                                        *
 *  File:        Course.cs                                                *
 *  Copyright:   (c) 2019-2020, Maria Mesina                              *
 *  E-mail:      maria.mesina@student.tuiasi.ro                           *
 *  Description: "Engleza fara profesor" application                      *
 *               Course (Software Engineering)                            *
 *                                                                        *
 *  This code implements the creation of a set of distinct exercises      *
 *  for the type of word chosen by the user. The code is customized to    *
 *  this  application, so it is not recommended to use it in other        *
 *  applications.                                                         *
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
    /// A collection of exercises and methods for basic operations
    /// </summary>
    public class Course
    {
        private WordType _type;

        private List<IExercise> _exercises;
        private int _index;
        public int _correctAnswered;
        private double _stats;
        private int _finishedCoursesCount;

        /// <value>Gets the percentage of correct answers(grade)</value>
        public double LocalStats
        {
            get { return Math.Round((double)_correctAnswered / _exercises.Count * 100, 2); }
        }

        /// <value>Gets the overall percentage of correct answers(grade)for type of words specifiend in class constructor</value>
        public double GlobalStats
        {
            get { return _stats; }
        }

        /// <summary>
        /// Class constructor, creates an list of IExercises
        /// </summary>
        /// <exception cref = "System.ArgumentException" > Thrown when one parameter is max</exception>
        /// <param name="count">Number of IExercises to be created</param>
        /// <param name="type">WordType of words used in exercises</param>
        public Course(int count, WordType type)
        {
            if (count <= 0)
                throw new ArgumentException("Numarul de exercitii trebuie sa fie pozitiv!");
            _type = type;
            _exercises = new List<IExercise>();

            for (int i = 0; i < count; ++i)
            {
                _exercises.Add(ExerciseFactory.CreateExercise(type));
            }

            _index = -1;
            var temp = DBConnection.Instance().GetStatsByType(_type.ToString());
            _stats = temp.Item1;
            _finishedCoursesCount = temp.Item2;
        }

        /// <summary>
        /// Return next exercise from internal class list or null if there are no more exercises
        /// </summary>
        /// <returns>IExercise or null</returns>
        public IExercise Next()
        {
            _index++;
            if (_index < _exercises.Count)
                return _exercises[_index];
            else
                return null;
        }

        /// <summary>
        /// Verify if the provided answer is the correct one and updates LocalStats
        /// </summary>
        /// <param name="answer">String representing user's answer</param>
        public void Verify(string answer)
        {
            if (_index<_exercises.Count)
                if (_exercises[_index].IsCorrect(answer))
                    _correctAnswered++;
        }

        /// <summary>
        /// Computes new statistics and writes it to the database
        /// </summary>
        public void UpdateGlobalStats()
        {
            _finishedCoursesCount++;

            if (_finishedCoursesCount == 1)
                _stats = LocalStats;
            else
                _stats = Math.Round(_stats * ((double)(_finishedCoursesCount - 1) / _finishedCoursesCount) + LocalStats * ((double)1 / (_finishedCoursesCount)), 2);

            DBConnection.Instance().WriteStatsByType(_type.ToString(), _stats, _finishedCoursesCount);
        }
    }
}
