using BowlingGame.Core.Classes;
using BowlingGame.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BowlingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = ConfigureServices();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            Game game = serviceProvider.GetService<Game>();

            string data = "2,3,5,4,7,3,10,8,2,5,2";
            //string data = "10,10,10,10,10,10,10,10,10,10,10,10"; 
            var rollList = data.Split(',').Select(x => int.Parse(x)).ToList();

            game.Start();
            rollList.ForEach(r =>
            {
                game.Roll(r);
            });

            int score = game.TotalScore();
            Console.WriteLine("Total Score: {0}: ", score);

            var scoreCard = game.ScoreByFrame();
            for (int i=0; i < scoreCard.Frames.Count; i++)
            {
                Console.WriteLine("Frame: {0},  FrameScore: {1}, Is Strike: {2}, Is Spare: {3}, Roll1: {4}, Roll2: {5}, Roll3: {6}",
                    i+1, scoreCard.Frames[i].Score, scoreCard.Frames[i].IsStrike,
                    scoreCard.Frames[i].IsSpare, scoreCard.Frames[i].Roll1, 
                    scoreCard.Frames[i].Roll2, scoreCard.Frames[i].Roll3); 
            };
            Console.ReadLine(); 
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // Register all services for DI
            services.AddTransient<IScoreCardService, ScoreCardService>();
            services.AddTransient<IScoreCalcService,  ScoreCalcService>();
            services.AddTransient<IValidatorService, ValidatorService>(); 
            services.AddTransient<Game>();

            return services;
        }
    }
}
