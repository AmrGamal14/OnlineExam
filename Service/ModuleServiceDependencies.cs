using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Hosting;
using Service.Implementations;
using Service.Abstracts;

namespace Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services
            .AddTransient<IAuthenticationService, AuthenticationService>()
            .AddTransient<IAuthorizationService, AuthorizationService>()
            .AddTransient<ISubjectService, SubjectService>()
            .AddTransient<ILevelService, LevelService>()
            .AddTransient<ISubjectLevelService, SubjectLevelService>()
            .AddTransient<ISkillService, SkillService>()
            .AddTransient<IQuestionService, QuestionService>()
            .AddTransient<IExamService, ExamService>()
            .AddTransient<IStudentExamSrevice, StudentExamSrevice>()
            .AddTransient<IExamQuestionService, ExamQuestionService>()
            .AddTransient<IUnitOfWorkService, UnitOfWorkService>()
            .AddTransient<IAnswerService, AnswerService>();
            return services;
        }

    }
} 