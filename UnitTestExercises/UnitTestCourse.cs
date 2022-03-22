using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseNamespace;

namespace UnitTestExercises
{
    [TestClass]
    public class UnitTestCourse
    {

        [TestMethod]
        public void NextPeople()
        {
            Course c = new Course(5, WordType.People);
            IExercise ex = c.Next();
        }
        [TestMethod]
        public void NextAdjective()
        {
            Course c = new Course(5, WordType.Adjective);
            IExercise ex = c.Next();
        }
        [TestMethod]
        public void NextVerb()
        {
            Course c = new Course(5, WordType.Verb);
            IExercise ex = c.Next();
        }
        [TestMethod]
        public void NextNoun()
        {
            Course c = new Course(5, WordType.Noun);
            IExercise ex = c.Next();
        }
        [TestMethod]
        public void NextAnimal()
        {
            Course c = new Course(5, WordType.Animal);
            IExercise ex = c.Next();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCount()
        {
            Course c = new Course(-1,WordType.Adjective);
        }

        [TestMethod]
        public void NULLNextExercise()
        {
            Course c = new Course(5, WordType.Animal);
            IExercise e=c.Next();
            for (int i = 1; i <= 5; i++)
                e = c.Next();
            Assert.AreEqual(null, e);
        }
    }
}
