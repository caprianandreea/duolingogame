using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseNamespace;

namespace UnitTestExercises
{
    [TestClass]
    public class UnitTestExerciseFactory
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExistingExerciseAdjective()
        {
            IExercise ex = ExerciseFactory.CreateExercise(WordType.Adjective);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExistingExerciseNoun()
        {
            IExercise ex = ExerciseFactory.CreateExercise(WordType.Noun);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExistingExerciseVerb()
        {
            IExercise ex = ExerciseFactory.CreateExercise(WordType.Verb);
        }

        [TestMethod]
        public void ExistingExerciseAnimal()
        {
            IExercise ex = ExerciseFactory.CreateExercise(WordType.Animal);
        }

        [TestMethod]
        public void ExistingExercisePeople()
        {
            IExercise ex = ExerciseFactory.CreateExercise(WordType.People);
        }
    }
}
