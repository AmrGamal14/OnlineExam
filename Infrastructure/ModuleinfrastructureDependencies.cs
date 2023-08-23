using Infrastructure.Abstracts;
using Infrastructure.InfrastructureBases;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ModuleinfrastructureDependencies
    {
        public static IServiceCollection AddinfrastructureDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<IAuditService, AuditService>()
                 .AddTransient<ILevelRepository, LevelRepository>()
                 .AddTransient(typeof(IGenericeRepositoryAsync<>), typeof(GenericRepositoryAsync<>))
                .AddTransient<IRefreshTokenRepository, RefreshTokenRepository>()               
                .AddTransient<ISubjectRepository, SubjectRepository>()             
                .AddTransient<ISubjectLevelRepository, SubjectLevelRepository>()
                .AddTransient<IQuestionRepository, QuestionRepository>()
                .AddTransient<ISkillRepository, SkillRepository>()
                .AddTransient<IExamRepository, ExamRepository>()
                .AddTransient<IAnswerRepository, AnswerRepository>()
                .AddTransient<IExamQuestionRepository, ExamQuestionRepository>()
                .AddTransient<IStudentResultRepository, StudentResultRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IStudentExamRepository, StudentExamRepository>();
               

            return services;
        }
    }
}