using FerpaAnalisisApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FerpaAnalisisApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //if(context.Question.Any() && context.DocumentType.Any())
                //{
                //    return;
                //}
                // Look for any movies.
                //AddocumentType(context);
                //AddQuestions(context);
                //context.SaveChanges();
            }

        }
        private static void AddocumentType(ApplicationDbContext context)
        {
            if (context.DocumentType.Any())
            {
                return;   // DB has been seeded
            }

            context.DocumentType.AddRange(
                new DocumentType
                {
                    Title = "FERPA"
                },
                new DocumentType
                {
                    Title = "PII"
                },
                new DocumentType
                {
                    Title = "HIPAA"
                }
            );
        }
        private static void AddQuestions(ApplicationDbContext context)
        {
            //FERPA = 10
            //PII = 11
            //HIPPA = 12
            if (context.Question.Any())
            {
                return;   // DB has been seeded
            }

            context.Question.AddRange(
                //FERPA
                new Question
                {
                    QuestionDescription = "FERPA stands for:",
                    DocumentTypeId = 10,
                    Answers = "Family Educational Rights and Privacy Act,Famous Entertainers Reserve all Peoples Amphetamines,False Enjoyment Rigorously Punishes Adherents,Family Enhancement Righteous Pastoral Association",
                    CorrectAnswerNumber = 1
                },
                new Question
                {
                    QuestionDescription = "The rights over student’s information transfer from the student’s guardians to the student himself when he turns 18 years old",
                    DocumentTypeId = 10,
                    Answers = "True,False",
                    CorrectAnswerNumber = 1
                },
                new Question
                {
                    QuestionDescription = "Question",
                    DocumentTypeId = 10,
                    Answers = "True,False",
                    CorrectAnswerNumber = 2
                },
                //PII
                new Question
                {
                    QuestionDescription = "PII stands for:",
                    DocumentTypeId = 11,
                    Answers = "Portable Information Identifier,Participant Informative Information,Personally Identifiable Information,Potential Impediment Inclement",
                    CorrectAnswerNumber = 3
                },
                new Question
                {
                    QuestionDescription = "Is your Date of Birth considered PII",
                    DocumentTypeId = 11,
                    Answers = "True,False",
                    CorrectAnswerNumber = 1
                },
                new Question
                {
                    QuestionDescription = "Are using VPNs considered a good practice to protect PII?",
                    DocumentTypeId = 11,
                    Answers = "True,False",
                    CorrectAnswerNumber = 1
                },
                //HIPAA
                new Question
                {
                    QuestionDescription = "HIPAA stands for:",
                    DocumentTypeId = 12,
                    Answers = "Health Internal Portable Accounting Act,Heavy Internal Permissible Accountable Activity,Health Insurance Portability and Accountability Act,Honest Insurance Portability Accountable Admission",
                    CorrectAnswerNumber = 3
                },
                new Question
                {
                    QuestionDescription = "Is Healthcare one of the entities that could be subject to the privacy rule involved in HIPAA?",
                    DocumentTypeId = 12,
                    Answers = "True,False",
                    CorrectAnswerNumber = 1
                },
                new Question
                {
                    QuestionDescription = "Does Law Enforcement have the right to get your personal health information without your consent?",
                    DocumentTypeId = 12,
                    Answers = "True,False",
                    CorrectAnswerNumber = 2
                }
            );
        }
    }
}
