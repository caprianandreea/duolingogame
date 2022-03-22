using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseNamespace;

namespace UnitTestExercises
{
    [TestClass]
    public class UnitTestChoiceExercise
    {
        [TestMethod]
        public void ExistingExercise()
        {
            ChoiceExercise ce = new ChoiceExercise("romanian", "english", new string[] { "english", "answer1", "answer2", "answer3" });
        }

        [TestMethod]
        public void IsCorrectStatus()
        {
            ChoiceExercise ce = new ChoiceExercise("romanian", "english", new string[] { "english", "answer1", "answer2", "answer3" });
            Assert.AreEqual(true, ce.IsCorrect(ce.EnglishVersion));
        }

        [TestMethod]
        public void DuplicateAnswers()
        {
            ChoiceExercise ce = new ChoiceExercise("romanian", "english", new string[] { "english", "answer1", "english", "answer2" });
            bool duplicates = false;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (i != j)
                        if (ce.Options[i] == ce.Options[j])
                            duplicates = true;
            Assert.AreEqual(true, duplicates);
        }
    }
}
