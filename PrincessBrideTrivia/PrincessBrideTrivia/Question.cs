using System;

namespace PrincessBrideTrivia
{
    public class Question
    {
        public string Text;
        public string[] Answers;
        public string CorrectAnswerIndex;

        public Question()
        {
        }
        
        public Question(string questionText, string[] answers, string correctAnswerIndex)
        {
            Text = questionText;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;

         }

    }

  
}