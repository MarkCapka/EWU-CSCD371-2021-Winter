using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            
            string filePath = GetFilePath();
            
            Question[] questions = LoadQuestions(filePath);

            //added to shuffle the order of the questions.
            Random randomizeOrder = new Random();
            //avoid duplicate additions by adding each index to an array
            int[] usedIndices = new int[questions.Length]; 

            int numberCorrect = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                int curIndex;
                         
                while(true)
                {
                    curIndex = randomizeOrder.Next(1, (questions.Length));
                   //  if(!CheckArray(usedIndices, (curIndex))) break;
                }

                usedIndices[i] = curIndex;


                bool result = AskQuestion(questions[i]);

                if (result)
                {
                    numberCorrect++;
                }
              
            }
            int numberOfQuestions = questions.Length; //reduce ambiguity
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, numberOfQuestions) + " correct");
           
            //currently it is NOT randomizing successfully, although it does scucessfully pass all of the tests. for 1 & 2 
            //Console.WriteLine("End of program");
        }
        //fixed to pass in the fields as doubles AS well as cast since I did this very wrong teh first time :p
        public static string GetPercentCorrect(double numberCorrect, double numberOfQuestions)
        {
            //FIXED: Cast to double to ensure correct percentages. may double up, but had other error here before...
            return (numberCorrect / numberOfQuestions * 100) + "%";

        }

        //wrote this to ensure that randomization occurs. (although not actually being employed?
        public static bool CheckArray(int[] indices, int randomIndex)
        {
            for (int i = 0; i < indices.Length; i++)
            {
                if (indices[i] == randomIndex)
                    return true;

            }
            return false;
        }

        

        public static bool AskQuestion(Question question)
        {

            //fixed:  corrected so that question will reassign if loaded as invalid.
            if (question == null)
            {
                string filePath = GetFilePath();
                Question[] questions = LoadQuestions(filePath);
             
            }

            DisplayQuestion(question);


            string userGuess = GetGuessFromUser();


            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            Console.WriteLine("Please enter an index for your guess to the trivia question: ");
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            //FIXED: correction: added slot to catch 
            if (question is null)
            {
                Question[] questions = LoadQuestions(GetFilePath());

                return;
            }
                  
          
            Console.WriteLine("Question: " + question.Text);

            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);

            }



        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {

            string[] lines = File.ReadAllLines(filePath);


            Question[] questions = new Question[lines.Length / 5];


            for (int i = 0; i < questions.Length; i++)
            {


                int lineIndex = i * 5;
                string questionText = lines[lineIndex];
                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;

               
                questions[i] = question; //added as I needed to reassignthe question to the correct question index.             }

            }

                return questions;
            }

        

    }
}
