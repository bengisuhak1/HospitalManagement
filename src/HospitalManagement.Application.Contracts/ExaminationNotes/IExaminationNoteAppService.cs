using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HospitalManagement.ExaminationNotes;

public interface IExaminationNoteAppService :
    ICrudAppService<
        ExaminationNoteDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateExaminationNoteDto>
{
}
