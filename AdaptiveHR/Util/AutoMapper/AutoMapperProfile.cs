using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Util.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            PDSDTOMap();
            EmployeeDTOMap();
            DocsDTOMap();
            JobDTOMap();
            EducationDTOMap();
            SeminarDTOMap();
            WorkScheduleDTOMap();
            TrainingsDTOMap();
            Training_detailDTOMap();
            TrainingResponseDTOMap();
            AttendanceDTOMap();
            PayslipDTOMap();
            PayrollUploadDTOMap();
            PayrollItemTypeDTOMap();
            SMSProfileDTOMap();
            SMSLogDTOMap();
            EmailProfileDTOMap();
            EmailLogDTOMap();
            SMSTemplateDTOMap();
            EmailTemplateDTOMap();
            ApplicationScheduleDTOMap();
            OBDTOMap();
            OTDTOMap();
            LeaveDTOMap();
            LeaveTypeDTOMap();
            Leave_DetailDTOMap();
            ApproverGroupDTOMap();
            ApproverGroup_DetailDTOMap();
            LeaveCreditsDTOMap();
            LeaveParameterDTOMap();
            LeaveParameter_detailDTOMap();
            AccrualTypeDTOMap();
            EmployeeUpdatesDTOMap();
            StatusDTOMap();
            HumanResourceDTOMap();
            HumanResourceStatusDTOMap();

        }

        private void PDSDTOMap()
        {
            CreateMap<Pds, PDSDTO>().IgnoreAllNonExisting();
        }
        private void EmployeeDTOMap()
        {
            CreateMap<Employee, EmployeeDTO>().IgnoreAllNonExisting();
        }
        private void DocsDTOMap()
        {
            CreateMap<Docs, DocsDTO>().IgnoreAllNonExisting();
        }
        private void JobDTOMap()
        {
            CreateMap<Job, JobDTO>().IgnoreAllNonExisting();
        }
        private void EducationDTOMap()
        {
            CreateMap<Education, EducationDTO>().IgnoreAllNonExisting();
        }
        private void SeminarDTOMap()
        {
            CreateMap<Seminar, SeminarDTO>().IgnoreAllNonExisting();
        }
        private void WorkScheduleDTOMap()
        {
            CreateMap<WorkSchedule, WorkScheduleDTO>().IgnoreAllNonExisting();
        }
        private void TrainingsDTOMap()
        {
            CreateMap<Trainings, TrainingsDTO>().IgnoreAllNonExisting();
        }
        private void Training_detailDTOMap()
        {
            CreateMap<TrainingDetail, Training_detailDTO>().IgnoreAllNonExisting();
        }
        private void TrainingResponseDTOMap()
        {
            CreateMap<TrainingResponse, TrainingResponseDTO>().IgnoreAllNonExisting();
        }
        private void AttendanceDTOMap()
        {
            CreateMap<Attendance, AttendanceDTO>().IgnoreAllNonExisting();
        }
        private void PayslipDTOMap()
        {
            CreateMap<Payslip, PayslipDTO>().IgnoreAllNonExisting();
        }
        private void PayrollUploadDTOMap()
        {
            CreateMap<PayrollUpload, PayrollUploadDTO>().IgnoreAllNonExisting();
        }
        private void PayrollItemTypeDTOMap()
        {
            CreateMap<PayrollItemType, PayrollItemTypeDTO>().IgnoreAllNonExisting();
        }
        private void SMSProfileDTOMap()
        {
            CreateMap<Smsprofile, SMSProfileDTO>().IgnoreAllNonExisting();
        }
        private void SMSLogDTOMap()
        {
            CreateMap<Smslog, SMSLogDTO>().IgnoreAllNonExisting();
        }
        private void EmailProfileDTOMap()
        {
            CreateMap<EmailProfile, EmailProfileDTO>().IgnoreAllNonExisting();
        }
        private void EmailLogDTOMap()
        {
            CreateMap<EmailLog, EmailLogDTO>().IgnoreAllNonExisting();
        }
        private void SMSTemplateDTOMap()
        {
            CreateMap<Smstemplate, SMSTemplateDTO>().IgnoreAllNonExisting();
        }
        private void EmailTemplateDTOMap()
        {
            CreateMap<EmailTemplate, EmailTemplateDTO>().IgnoreAllNonExisting();
        }
        private void ApplicationScheduleDTOMap()
        {
            CreateMap<ApplicationSchedule, ApplicationScheduleDTO>().IgnoreAllNonExisting();
        }
        private void OBDTOMap()
        {
            CreateMap<Ob, OBDTO>().IgnoreAllNonExisting();
        }
        private void OTDTOMap()
        {
            CreateMap<Ot, OTDTO>().IgnoreAllNonExisting();
        }
        private void LeaveDTOMap()
        {
            CreateMap<Leave, LeaveDTO>().IgnoreAllNonExisting();
        }
        private void LeaveTypeDTOMap()
        {
            CreateMap<LeaveType, LeaveTypeDTO>().IgnoreAllNonExisting();
        }
        private void Leave_DetailDTOMap()
        {
            CreateMap<LeaveDetail, Leave_DetailDTO>().IgnoreAllNonExisting();
        }
        private void ApproverGroupDTOMap()
        {
            CreateMap<ApproverGroup, ApproverGroupDTO>().IgnoreAllNonExisting();
        }
        private void ApproverGroup_DetailDTOMap()
        {
            CreateMap<ApproverGroupDetail, ApproverGroup_DetailDTO>().IgnoreAllNonExisting();
        }
        private void LeaveCreditsDTOMap()
        {
            CreateMap<LeaveCredits, LeaveCreditsDTO>().IgnoreAllNonExisting();
        }
        private void LeaveParameterDTOMap()
        {
            CreateMap<LeaveParameter, LeaveParameterDTO>().IgnoreAllNonExisting();
        }
        private void LeaveParameter_detailDTOMap()
        {
            CreateMap<LeaveParameterDetail, LeaveParameter_detailDTO>().IgnoreAllNonExisting();
        }
        private void AccrualTypeDTOMap()
        {
            CreateMap<AccrualType, AccrualTypeDTO>().IgnoreAllNonExisting();
        }
        private void EmployeeUpdatesDTOMap()
        {
            CreateMap<EmployeeUpdates, EmployeeUpdatesDTO>().IgnoreAllNonExisting();
        }
        private void StatusDTOMap()
        {
            CreateMap<Status, StatusDTO>().IgnoreAllNonExisting();
        }
        private void HumanResourceDTOMap()
        {
            CreateMap<HumanResource, HumanResourceDTO>().IgnoreAllNonExisting();
        }
        private void HumanResourceStatusDTOMap()
        {
            CreateMap<HumanResourceStatus, HumanResourceStatusDTO>().IgnoreAllNonExisting();
        }



    }
}
