using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseNamespace;

namespace UnitTestExercises
{
    [TestClass]
    public class UnitTestTranslationExercise
    {
        [TestMethod]
        public void ExistingExercise()
        {
            TranslationExercise te = new TranslationExercise("romanian", "english");
        }

        [TestMethod]
        public void IsCorrectStatus()
        {
            TranslationExercise te = new TranslationExercise("romanian", "english");
            Assert.AreEqual(true, te.IsCorrect(te.EnglishVersion));
        }

    }
}
