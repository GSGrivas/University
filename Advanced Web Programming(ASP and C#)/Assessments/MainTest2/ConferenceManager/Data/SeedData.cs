using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ConferenceManager.Models;

namespace ConferenceManager.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Topics.Any())
            {
                context.Topics.AddRange(
                    new Topic { TopicName = "Education" }, //1
                    new Topic { TopicName = "Data Science" }, //2
                    new Topic { TopicName = "Human-Computer Interaction" }, //3
                    new Topic { TopicName = "Internet of Things" }); //4
            }

            context.SaveChanges();

            if (!context.Papers.Any())
            {
                context.Papers.AddRange(
                    new Paper
                    {
                        PaperTitle = "The Views and Experiences of Selected South African Lecturers on COVID-19 Emergency Electronic Learning Use: Lessons Learned",
                        PaperAbstract = "The outbreak of COVID-19 pandemic necessitated a national lockdown that saw universities completely switch to online teaching and learning. Lecturers were ill prepared for a change of such magnitude. This study sought to investigate the views and experiences of lecturers’ use of electronic learning (eLearning) during the lockdown. A qualitative research methodology was used in which lecturers from selected public South African universities were engaged. Study findings show that participants faced challenges when using eLearning. However, positive outcomes from the use of eLearning were noted. Even though participants appear to be warming up to the idea of using eLearning, study findings show that careful planning and channeling of the necessary resources remains important.",
                        PaperAuthor = "mary",
                        PaperDateSubmitted = DateTime.Parse("2021-05-09"),
                        TopicId = 1 
                    },
                    new Paper
                    {
                        PaperTitle = "Determining Human Hand Performance with the Oculus Quest in Virtual Reality using Fitts's Law",
                        PaperAbstract = "The medium of Virtual Reality has become much more accessible to the general public in recent years. The Oculus Quest VR headset, released in 2019, is a recent device that is much more affordable to the average consumer while still providing a wide range of capabilities. This paper discusses a study focused on investigating novice human performance using the hand tracking capabilities of the Oculus Quest. ",
                        PaperAuthor = "john",
                        PaperDateSubmitted = DateTime.Parse("2021-05-11"),
                        TopicId = 3 
                    },
                    new Paper
                    {
                        PaperTitle = "An analysis on the adoption of Internet of Things (IoT) in the monitoring of diabetes",
                        PaperAbstract = "The Internet of Things (IoT) is an important emerging technology that enables (usually) pervasive ubiquitous devices to connect to the Internet. Medical and Healthcare Internet of Things (MHIoT) represents one of the application areas for IoT that has revolutionized the healthcare sector. In this study, a review of literature on the adoption of MHIoT for diabetes management is conducted to investigate the application of IoT in monitoring Diabetes, key challenges, what has been done, in which context, and the research gap.",
                        PaperAuthor = "thabo",
                        PaperDateSubmitted = DateTime.Parse("2021-05-10"),
                        TopicId = 4 
                    },
                    new Paper
                    {
                        PaperTitle = "Evaluating Deep Sequential Knowledge Tracing Models for Predicting Student Performance",
                        PaperAbstract = "One of the key priorities in all instructional environments is to ensure that students recognize their learning mechanisms and pathways. Knowledge Tracing (KT), the task of modelling student knowledge from their learning history, is an important problem in the field of Artificial Intelligence in Education (AIEd) and has a wide range of applications in developing interactive and adaptive learning technologies. ",
                        PaperAuthor = "mary",
                        PaperDateSubmitted = DateTime.Parse("2021-05-16"),
                        TopicId = 1 
                    }
                );

            }
            context.SaveChanges();

        }
    }
}

