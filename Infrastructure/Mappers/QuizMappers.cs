using ApplicationCore.Models;
using Infrastructure.EF.Entities;

namespace Infrastructure.Mappers
{
    public static class QuizMappers
    {
        public static QuizItem FromEntityToQuizItem(QuizItemEntity entity)
        {
            return new QuizItem(
                entity.Id,
                entity.Question,
                entity.IncorrectAnswers.Select(e => e.Answer).ToList(),
                entity.CorrectAnswer);
        }

        public static Quiz FromEntityToQuiz(QuizEntity entity)
        {
            return new Quiz(
                entity.Id,
                entity.Items.Select(FromEntityToQuizItem).ToList(),
                entity.Title
                );

        }

        public static QuizItemUserAnswer FromEntityToQuizItemUserAnswer(QuizItemUserAnswerEntity entity)
        {
            return new QuizItemUserAnswer(
                              quizItem: FromEntityToQuizItem(entity.QuizItem),
                              userId: entity.UserId,
                              quizId: entity.QuizId,
                              answer: entity.UserAnswer
                                );
        }
    }
}
