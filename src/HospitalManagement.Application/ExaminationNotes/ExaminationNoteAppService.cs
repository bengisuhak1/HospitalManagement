using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HospitalManagement.ExaminationNotes;

public class ExaminationNoteAppService :
    CrudAppService<
        ExaminationNote,
        ExaminationNoteDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateExaminationNoteDto>,
    IExaminationNoteAppService
{
    public ExaminationNoteAppService(IRepository<ExaminationNote, Guid> repository)
        : base(repository)
    {
        ObjectMapperContext = typeof(HospitalManagementApplicationModule);
    }
}
