using AutoMapper;
using LeetifyGraphQL.DTOs;
using LeetifyGraphQL.Entities;
using LeetifyGraphQL.GraphQL.Types.Inputs;

namespace LeetifyGraphQL.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<QuestionCsvDto, Question>()
            .ForMember(
                dest => dest.Difficulty,
                opt => opt.MapFrom(src => Enum.Parse<Difficulty>(src.DifficultyString, true)))
            .ForMember(
                dest => dest.IsPremium,
                opt => opt.MapFrom(src => src.IsPremium == "1"));
        CreateMap<CreatePlanInput, Plan>()
            .ForMember(dest => dest.PlanQuestions, opt => opt.Ignore());
        CreateMap<PlanQuestionInput, PlanQuestion>()
            .ForMember(dest => dest.Question, opt => opt.Ignore());
    }
}